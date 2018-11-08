using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace Winsoft.WorkSystem.Filter
{
    public class UserScopeValidationAttribute : Attribute, IResourceFilter
    {
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            //获取所有参数
            Console.WriteLine("暂时没用");

            //获取headers里的token   
            string token=context.HttpContext.Request.Headers["token"];
            

            //查询用户否已经登录


            //获取body传过来的值
            //Stream stream = context.HttpContext.Request.Body;
            //byte[] buffer = new byte[context.HttpContext.Request.ContentLength.Value];
            //stream.Read(buffer, 0, buffer.Length);
            //string content = Encoding.UTF8.GetString(buffer);
            //Console.WriteLine(content);
        }
    }
}
