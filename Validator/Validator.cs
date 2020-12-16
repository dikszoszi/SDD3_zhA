using System.Linq;

namespace Validator
{
    public class Validator
    {
        public static bool Validate(object obj, out string result)
        {
            System.Collections.Generic.List<bool> validityChecks = new System.Collections.Generic.List<bool>();
            string res = string.Empty;
            System.Reflection.PropertyInfo[] properties = obj.GetType().GetProperties();

            var notNull = properties.Where(p => p.GetCustomAttributes(typeof(NotNullAttribute), false).Length > 0)
                .Select(pinfo => new
                {
                    pinfo.Name,
                    Value = pinfo.GetValue(obj),
                    Validation = "Not Null",
                    Validity = ValidationMethods.NotNull(pinfo.GetValue(obj)),
                });
            var notEmpty = properties.Where(p => p.GetCustomAttributes(typeof(NotEmptyAttribute), false).Length > 0)
                .Select(pinfo => new
                {
                    pinfo.Name,
                    Value = pinfo.GetValue(obj),
                    Validation = "Not Empty",
                    Validity = ValidationMethods.NotEmpty(pinfo.GetValue(obj)),
                });
            foreach (var item in notNull.Concat(notEmpty))
            {
                validityChecks.Add(item.Validity);
                res += $"{item.Name} = '{item.Value}' => {item.Validation} - {item.Validity}\n";
            }
            result = res;
            return !validityChecks.Contains(false);
        }
    }
}
