using System;

namespace MyWebServer
{
    [AttributeUsage(AttributeTargets.Method)]
    public class MethodAttribute : Attribute
    {
        public MethodAttribute(string Type, string Method)
        {
            this.Type = Type;
            this.Method = Method;
        }

        public string Type { get; set; }
        public string Method { get; set; }
    }
}
