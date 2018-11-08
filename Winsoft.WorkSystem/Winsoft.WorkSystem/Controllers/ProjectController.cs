using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Winsoft.WorkSystem.Common.Json;
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
        [HttpGet("GetProject")]
        public async Task<IActionResult> GetProject([FromHeader] string token) {
            //token验证   并且取回对应的值
            var result=(new TokenValidate()).CheckToken(token,_cache);
            if (result.CheckParamsSuccess=="no") {
                return Json(result);
            }
            var user=UserCommom.getUserInfo(_cache, token, _context);





            return Ok();
        }
    }
}
