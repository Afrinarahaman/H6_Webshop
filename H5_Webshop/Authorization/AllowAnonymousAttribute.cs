using System;

namespace H5_Webshop.Authorization
{

    [AttributeUsage(AttributeTargets.Method)]
    public class AllowAnonymousAttribute : Attribute
    { }
}

