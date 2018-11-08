using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Winsoft.WorkSystem.Common.Json;

namespace Winsoft.WorkSystem.Filter
{

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true)]
    public class ModelValidationAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {
            //获取触发当前方法的Action方法的所有参数 
            var paramss = actionContext.ActionArguments;
            string Content = Newtonsoft.Json.JsonConvert.SerializeObject(paramss);
            Console.WriteLine(Content);

            var modelState = actionContext.ModelState;
            if (!modelState.IsValid)
            {
                List<string> sb = new List<string>();
                List<string> Keys = modelState.Keys.ToList();
                //获取每一个key对应的ModelStateDictionary
                foreach (var key in Keys)
                {
                    var errors = modelState[key].Errors.ToList();
                    //将错误描述添加到sb中
                    foreach (var error in errors)
                    {
                        sb.Add(error.ErrorMessage);
                    }
                }
                // 逻辑代码
                // filterContext.Result = new HttpUnauthorizedResult();//直接URL输入的页面地址跳转到登陆页  
                // filterContext.Result = new RedirectResult("http://www.baidu.com");//也可以跳到别的站点
                //filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new { Controller = "product", action = "Default" }));
                //actionContext.Result =new ObjectResult(new { code = 404, sub_msg = "未找到资源", msg = "" });
                actionContext.Result = new ObjectResult(new ReturnJson
                {
                    ErrorCode = 10002,
                    ErrorMsg = "参数错误！",
                    Data = sb,
                    Success = false,
                    HttpCode = (int)HttpStatusCode.NotFound,
                    CheckParamsSuccess = "no"
                });
            }
        }
    }
}
