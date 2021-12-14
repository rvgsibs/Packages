using System;

namespace CrossCutting.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple =false, Inherited =true)]
    public class HttpStatusCodeAttribute : Attribute
    {
        private int statusCode;

        public HttpStatusCodeAttribute(int statusCode)
        {
            this.statusCode = statusCode;
        }

        public int StatusCode { get => statusCode; }
    }
}
