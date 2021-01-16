using System;

namespace ValidatorProject
{
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class NotEmptyAttribute : Attribute
    {
    }
}