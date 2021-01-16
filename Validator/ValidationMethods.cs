namespace ValidatorProject
{
    public static class ValidationMethods
    {
        public static bool NotNull(object obj)
        {
            return obj is not null;
        }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Maintainability", "CA1508:Avoid dead conditional code", Justification = "false positive")]
        public static bool NotEmpty(object obj)
        {
            return !string.IsNullOrWhiteSpace(obj as string);
        }
    }
}
