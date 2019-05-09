using System;

namespace NaughtyAttributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public class FoldOutGroupAttribute : GroupAttribute
    {
        public FoldOutGroupAttribute(string name = "")
            : base(name)
        {
        }
    }
}
