using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Winsoft.WorkSystem.Common.Json;
using Winsoft.WorkSystem.Context;
using Winsoft.WorkSystem.Model;
using Winsoft.WorkSystem.Service;
using Winsoft.WorkSystem.Validate;

namespace Winsoft.WorkSystem.Controllers
{
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        public basisContext _context;
        private static IMemoryCache  _cache;
        public LoginController(basisContext context, IMemoryCache cache)
        {
            _context = context;
            _cache = cache;
        }

        #region 登录验证
        /// <summary>
        /// 登录验证
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpPost("checkLogOn")]
        public async Task<IActionResult> AutoCheckLogin([FromHeader] string token)
        {
            // 不处理
            return Json(new ReturnJson { ErrorCode = 20000, ErrorMsg = "去往登录界面", Data = "", Success = false });
        }
        #endregion


        #region 登录
        [HttpPost("login")]
        public async Task<IActionResult> CheckLogin([FromBody] AdminLoginModel AdminLogin)
        {
            //查看token是否存在  如果存在就从缓存里取值
            //ReturnJson returnjson = (new TokenValidate()).CheckToken(token, _cache);
            //if (returnjson.CheckParamsSuccess == "ok") {
            //    returnjson.ErrorMsg = "登录成功，已有token";
            //    returnjson.Data = token;
            //    return Json(returnjson);
            //}

            LoginService _loginservice = new LoginService();
            var items = await _loginservice.CheckAdmin(AdminLogin, _context);
            if (items == null)
            {
                //Response.StatusCode = (int)HttpStatusCode.Created;
                return Json(new ReturnJson { ErrorCode = 10002, ErrorMsg = "用户名或密码错误", Data = "", Success = false });
            }
            //获取token
            string key_token = _loginservice.UpdateCache(items, _cache);
            return Json(new ReturnJson { ErrorCode = 80000, ErrorMsg = "登录成功", Data = key_token, Success = true });
        }
        #endregion

        
        #region 获取用户信息
        [HttpGet]
        public async Task<IActionResult> GetUser([FromHeader] string token)
        {
            ReturnJson returnjson = (new TokenValidate()).CheckToken(token, _cache);
            return Json(returnjson);
        }
        #endregion
    }
}