using System;

namespace Validator
{
    [AttributeUsage(AttributeTargets.Property)]
    internal class DbPropertyNameAttribute : Attribute
    {
        public DbPropertyNameAttribute(string name)
        {
            this.Name = name;
        }

        public string Name { get; }
    }
}