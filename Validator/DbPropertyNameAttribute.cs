using System;

namespace ValidatorProject
{
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class DbPropertyNameAttribute : Attribute
    {
        public DbPropertyNameAttribute(string name)
        {
            this.Name = name;
        }

        public string Name { get; }
    }
}