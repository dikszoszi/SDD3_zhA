namespace ValidatorProject
{
    using System.Linq;
    using System.Reflection;

    public static class Converter
    {
        public static void ConvertProperties(object source, object destination)
        {
            if (source is null || destination is null) return;
            var sourceProperties = from pinfo in source.GetType().GetProperties()
                                   where pinfo.GetCustomAttributes(typeof(DbPropertyNameAttribute), false).Length > 0
                                   select pinfo;
            foreach (PropertyInfo sourceProp in sourceProperties)
            {
                destination.GetType()
                    .GetProperty(sourceProp.GetCustomAttribute<DbPropertyNameAttribute>().Name)
                    .SetValue(destination, sourceProp.GetValue(source));
            }
        }
    }
}
