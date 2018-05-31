using System;
using System.Collections.Generic;
using System.Text;

namespace Easy.Test.Decorator
{
    [System.AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    sealed class ViewAttribute : Attribute
    {
        public string Prefix { get; set; }
    }
}
