using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Memory;
using System;
using Winsoft.WorkSystem.Common.Json;
using Winsoft.WorkSystem.Common.UserCommom;

namespace Winsoft.WorkSystem.Filter
{
    //public class ScopeValidationAttribute : Attribute, IAuthorizationFilter
    public class CheckLoginValidationAttribute : TypeFilterAttribute
    {
        public CheckLoginValidationAttribute() : base(typeof(CheckLoginValidationAttributeImpl))
        {
        }
        /// <summary>
        /// 判断用户是否已登录
        /// </summary>
        public class CheckLoginValidationAttributeImpl : Attribute, IAuthorizationFilter
        {
            private readonly IMemoryCache _cache;
            public CheckLoginValidationAttributeImpl(IMemoryCache cache)
            {
                _cache = cache;
            }
            //判断用户token是否登录或者token是否失效
            public void OnAuthorization(AuthorizationFilterContext context)
            {
                string token = context.HttpContext.Request.Headers["token"];
                string path=context.HttpContext.Request.Path;

                UserCommom checklogin=new UserCommom();
                ReturnJson result=checklogin.CheckLogin(path,token,_cache);

                if (result.CheckParamsSuccess=="no") {
                    context.Result = new ObjectResult(result);
                }
            }
        }
    }
}
