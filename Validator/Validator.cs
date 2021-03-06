namespace ValidatorProject
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public static class Validator
    {
        public static bool Validate(object obj, out string result)
        {
            if (obj is null) throw new ArgumentNullException(nameof(obj));
            List<bool> validityChecks = new ();
            //PropertyInfo[] properties = obj.GetType().GetProperties();

            result = string.Concat(obj.GetType().GetProperties().Select(pinfo =>
            {
                bool isValid;
                string temp = string.Empty;
                if (pinfo.GetCustomAttributes<NotNullAttribute>(false).Any())
                {
                    isValid = ValidationMethods.NotNull(pinfo.GetValue(obj));
                    temp += $"{pinfo.Name} = '{pinfo.GetValue(obj)}' => {typeof(NotNullAttribute)} -"
                        + (isValid ? "Passed" : "FAILED") + "\n";
                    validityChecks.Add(isValid);
                }
                if (pinfo.GetCustomAttributes<NotEmptyAttribute>(false).Any())
                {
                    isValid = ValidationMethods.NotEmpty(pinfo.GetValue(obj));
                    temp += $"{pinfo.Name} = '{pinfo.GetValue(obj)}' => {typeof(NotEmptyAttribute)} -"
                        + (isValid ? "Passed" : "FAILED") + "\n";
                    validityChecks.Add(isValid);
                }
                return temp;
            }));

            //var notNull = from pinfo in properties where pinfo.GetCustomAttributes(typeof(NotNullAttribute), false).Length > 0 select new { pinfo.Name, Value = pinfo.GetValue(obj), Validation = "Not Null", Validity = ValidationMethods.NotNull(pinfo.GetValue(obj)), };
            //var notEmpty = from pinfo in properties where pinfo.GetCustomAttributes(typeof(NotEmptyAttribute), false).Length > 0 select new { pinfo.Name, Value = pinfo.GetValue(obj), Validation = "Not Empty", Validity = ValidationMethods.NotEmpty(pinfo.GetValue(obj)), };
            /*
            foreach (var item in notNull.Concat(notEmpty))
            {
                validityChecks.Add(item.Validity);
                res += $"{item.Name} = '{item.Value}' => {item.Validation} - {item.Validity}\n";
            }
            */
            return !validityChecks.Contains(false);
        }
    }
}
