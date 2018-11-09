using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System.Linq;
using System.Threading.Tasks;
using Winsoft.WorkSystem.Common.UserCommom;
using Winsoft.WorkSystem.Context;
using Winsoft.WorkSystem.Validate;

namespace Winsoft.WorkSystem.Controllers
{

    [Route("api/[controller]")]
    public class ProjectController:Controller
    {
        public basisContext _context;
        private static IMemoryCache _cache;
        public ProjectController(basisContext context, IMemoryCache cache)
        {
            _context = context;
            _cache = cache;
        }
        /// <summary>
        /// 获取用户对应下的所有项目
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpGet("GetProject")]
        public async Task<IActionResult> GetProject([FromHeader] string token) {
            //token验证   并且取回对应的值
            var result=(new TokenValidate()).CheckToken(token,_cache);
            if (result.CheckParamsSuccess=="no") {
                return Json(result);
            }
            var user=UserCommom.getUserInfo(_cache, token, _context);
            //判断是否是管理员
            if (user.AdminScopeIdentifier == 1)
            {
                //如果是管理员   则查询所有项目
                var project = _context.Projects.AsNoTracking().;
            }
            else {
                //查看该会员对应的项目
                var Project = _context.Projects.Where(p=>p.JoinUser.Contains(user.Id+"")).ToList();
            }
           //返回该返回的数据
            return Ok();
        }
    }
}
