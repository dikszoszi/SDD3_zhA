namespace Validator
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public static class Converter
    {
        public static void ConvertProperties(object source, object destination)
        {
            IEnumerable<PropertyInfo> sourceProperties = source.GetType().GetProperties()
                .Where(pinfo => pinfo.GetCustomAttributes(typeof(DbPropertyNameAttribute), false).Length > 0);
            foreach (PropertyInfo sourceProp in sourceProperties)
            {
                destination.GetType()
                    .GetProperty(sourceProp.GetCustomAttribute<DbPropertyNameAttribute>().Name)
                    .SetValue(destination, sourceProp.GetValue(source));
            }
        }
    }
}
