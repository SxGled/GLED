using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace Winsoft.WorkSystem.Filter
{
    public class OverAllException : Attribute,IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            Exception e=context.Exception;
            Console.WriteLine(e.Message);
        }
    }
}
