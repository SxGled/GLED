using Microsoft.Extensions.Caching.Memory;
using System;
using System.Linq;
using System.Net;
using Winsoft.WorkSystem.Common.Json;
using Winsoft.WorkSystem.Context;
using Winsoft.WorkSystem.Entity;
using Winsoft.WorkSystem.Models.Admin;

namespace Winsoft.WorkSystem.Common.UserCommom
{
    public class UserCommom
    {
        public int ErrorCode = 40000;
        public string ErrorMsg = "";
        public Object Data = "";
        public bool Success = false;
        public int HttpCode = (int)HttpStatusCode.NotFound;
        public string CheckParamsSuccess = "no";

        /// <summary>
        /// 判断用户是否已登录  
        ///     是登录接口login  判断token
        ///         1.匹配 则说明用户token还未失效   则自动返回登录成功
        ///         2.不匹配   说明用户token已失效或未生成   则不处理
        ///    不是登录接口时   判断token
        ///          1.匹配  在接下去的过滤器判断权限
        ///          2.不匹配或无  说明token已失效或未生成   则返回  需要登录的信息
        /// </summary>
        /// <param name="path">接口名</param>
        /// <param name="token">用户带过来的token值</param>
        /// <param name="_cache">缓存</param>
        /// <returns></returns>

        public ReturnJson CheckLogin(string path, string token, IMemoryCache _cache) {
            //判断token是否存在
            if (path.Contains("checkLogOn"))
            {
                //如果访问的接口时checkLogOn   
                if (token != null)
                {
                    if (!string.IsNullOrEmpty(_cache.Get<string>(token)))
                    {
                        ErrorCode = 20001;
                        ErrorMsg = "已有token  登录成功！";
                        Success = true;
                    }
                    else
                    {
                        ErrorCode = 20002;
                        ErrorMsg = "toke过期或无效，请跳转到登录页面进行重新授权登录！";
                        Success = false;
                    }
                }
                else {
                    ErrorCode = 20002;
                    ErrorMsg = "toke过期或无效，请跳转到登录页面进行重新授权登录！";
                    Success = false;
                }
            }
            //登录页面
            else if (path.Contains("login")) {
                CheckParamsSuccess = "ok";
            } 
            else
            {
                if (token == null || string.IsNullOrEmpty(_cache.Get<string>(token)))
                {
                    ErrorCode = 20002;
                    ErrorMsg = "toke过期或无效，请跳转到登录页面进行重新授权登录！";
                    Success = false;
                }
                else {
                    CheckParamsSuccess = "ok";
                }
            }
            return new ReturnJson { ErrorCode = ErrorCode, ErrorMsg = ErrorMsg, Data = Data, Success = Success, CheckParamsSuccess = CheckParamsSuccess };
        }

        //获取所有用户对应的信息
        public static AdminInfoModel getUserInfo(IMemoryCache _cache,string token, basisContext _context) {
            string a = _cache.Get<string>(token);
            //获取当前用户
            Admin admin = ConvertJson.JsonStringToObj<Admin>(a);
            //获取当前用户权限
            var adminscope=_context.AdminScopes.Where(sa => sa.Identifier == admin.AdminScopeIdentifier).SingleOrDefault();

            AdminInfoModel user = new AdminInfoModel
            {
                Id = admin.Id,
                RealName =admin.RealName,
                UserName=admin.UserName,
                AdminScopeIdentifier =admin.AdminScopeIdentifier,
                OneLevelScopeName =adminscope.OneLevelScopeName,
                TwoLevelScopeName =adminscope.TwoLevelScopeName,
                OneLevelScopeId=adminscope.OneLevelScopeId,
                TwoLevelScopeId=adminscope.TwoLevelScopeId
            };
            return user;
        }
    }
}
