using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Net;
using Winsoft.WorkSystem.Common.Enum;
using Winsoft.WorkSystem.Common.Json;
using Winsoft.WorkSystem.Entity;

namespace Winsoft.WorkSystem.Filter
{
    public class AdminScopeValidationAttribute :  TypeFilterAttribute
    {
        public AdminScopeValidationAttribute() : base(typeof(AdminScopeValidationAttributeImpl))
        {
        }
        public class AdminScopeValidationAttributeImpl : Attribute, IResourceFilter
        {

            private readonly IMemoryCache _cache;
            public AdminScopeValidationAttributeImpl(IMemoryCache cache)
            {
                _cache = cache;
            }
            public void OnResourceExecuting(ResourceExecutingContext context)
            {
                ////获取headers里的token   
                //string token = context.HttpContext.Request.Headers["token"];
                //string path = context.HttpContext.Request.Path;
                ////获取token
                //string tokenarr = _cache.Get<string>(token);

                //Admin admin = ConvertJson.JsonStringToObj<Admin>(tokenarr);
                //if ((int)ScopeEnum.Admin>admin.Scope) {
                //    context.Result = new ObjectResult(new ReturnJson
                //    {
                //        ErrorCode = 30001,
                //        ErrorMsg = "您无访问权限！",
                //        Data = "",
                //        Success = false,
                //        HttpCode = (int)HttpStatusCode.Forbidden,
                //        CheckParamsSuccess = "no"
                //    });
                //}
            }
            public void OnResourceExecuted(ResourceExecutedContext context) {}
           
        }
    }
}
