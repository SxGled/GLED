using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Winsoft.WorkSystem.Context;
using Winsoft.WorkSystem.Entity;

namespace Winsoft.WorkSystem.Controllers
{
    /// <summary>
    /// 添加数据
    /// </summary>
    [Route("api/[controller]")]
    public class TestMain: Controller
    {
        public basisContext _context;
        private static IMemoryCache _cache;
        public TestMain(basisContext context, IMemoryCache cache)
        {
            _context = context;
            _cache = cache;
        }

        #region 添加权限数据
        [HttpGet("SetScope")]
        public async Task<IActionResult> SetScope()
        {
            var AdminScopes = new AdminScope[] {
                new AdminScope{OneLevelScopeName="总管理员",TwoLevelScopeName="总管理员",OneLevelScopeId=32,TwoLevelScopeId=32,Identifier=1},
                new AdminScope{OneLevelScopeName="管理员",TwoLevelScopeName="前台管理员",OneLevelScopeId=30,TwoLevelScopeId=29,Identifier=2},
                new AdminScope{OneLevelScopeName="管理员",TwoLevelScopeName="后台管理员",OneLevelScopeId=30,TwoLevelScopeId=28,Identifier=3},
                new AdminScope{OneLevelScopeName="管理员",TwoLevelScopeName="产品管理员",OneLevelScopeId=30,TwoLevelScopeId=27,Identifier=4},
                new AdminScope{OneLevelScopeName="管理员",TwoLevelScopeName="设计管理员",OneLevelScopeId=30,TwoLevelScopeId=26,Identifier=5},
                new AdminScope{OneLevelScopeName="管理员",TwoLevelScopeName="测试管理员",OneLevelScopeId=30,TwoLevelScopeId=25,Identifier=6},
                new AdminScope{OneLevelScopeName="操作员",TwoLevelScopeName="前台操作员",OneLevelScopeId=16,TwoLevelScopeId=15,Identifier=7},
                new AdminScope{OneLevelScopeName="操作员",TwoLevelScopeName="后台操作员",OneLevelScopeId=16,TwoLevelScopeId=14,Identifier=8},
                new AdminScope{OneLevelScopeName="操作员",TwoLevelScopeName="产品操作员",OneLevelScopeId=16,TwoLevelScopeId=13,Identifier=9},
                new AdminScope{OneLevelScopeName="操作员",TwoLevelScopeName="设计操作员",OneLevelScopeId=16,TwoLevelScopeId=12,Identifier=10},
                new AdminScope{OneLevelScopeName="操作员",TwoLevelScopeName="测试操作员",OneLevelScopeId=16,TwoLevelScopeId=11,Identifier=11},
            };
            foreach (AdminScope a   in AdminScopes)
            {
                _context.AdminScopes.Add(a);
            }
            _context.SaveChanges();
            return Ok();
        }
        #endregion

        #region 添加权限数据
        [HttpGet("SetAdmin")]
        public async Task<IActionResult> SetAdmin()
        {
            var Admins = new Admin[] {
                new Admin{AdminScopeIdentifier=1,Password="123456",UserName="admin",RealName="admin",CreateTime=DateTime.Now.ToString(),UpdateTime =DateTime.Now.ToString()},
                new Admin{AdminScopeIdentifier=8,Password="123456",UserName="wdq",RealName="吴大强",CreateTime=DateTime.Now.ToString(),UpdateTime =DateTime.Now.ToString()},
                new Admin{AdminScopeIdentifier=3,Password="123456",UserName="htadmin",RealName="后台管理员",CreateTime=DateTime.Now.ToString(),UpdateTime =DateTime.Now.ToString()},
            };
            foreach (Admin a in Admins)
            {
                _context.Admins.Add(a);
            }
            _context.SaveChanges();
            return Ok();
        }
        #endregion
    }
}
