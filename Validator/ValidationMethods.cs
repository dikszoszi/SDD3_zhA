namespace Validator
{
    public class ValidationMethods
    {
        public static bool NotNull(object obj)
        {
            return obj is not null;
        }

        public static bool NotEmpty(object obj)
        {
            if (obj is string str)
            {
                return !string.IsNullOrEmpty(str);
            }
            return false;
        }
    }
}
