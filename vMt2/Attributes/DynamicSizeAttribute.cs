using System;
using System.Collections.Generic;
using System.Text;

namespace vMt2
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    class DynamicSizeAttribute : Attribute
    {
    }
}
