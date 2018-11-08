using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Winsoft.WorkSystem.Context;
using Winsoft.WorkSystem.Entity;
using System;
using System.Linq;
using System.Threading.Tasks;
using Winsoft.WorkSystem.Model;
using Winsoft.WorkSystem.Common.Token;
using Winsoft.WorkSystem.Common.Json;

namespace Winsoft.WorkSystem.Service
{
    public class LoginService:Controller
    {
        public LoginService(){}

        #region 更新缓存
        public string UpdateCache(Admin admin, IMemoryCache _cache ) {
            var key = this.TokenKey(admin.Id);
            string value= ConvertJson.ObjToJsonString(admin);
            //查询token是否存在
            if (string.IsNullOrEmpty(_cache.Get<string>(key)))
            {
                MemoryCacheEntryOptions options =new MemoryCacheEntryOptions();
                options.AbsoluteExpiration =DateTime.Now.AddMinutes(1);
                options.SlidingExpiration =TimeSpan.FromMinutes(1);
                _cache.Set<string>(key,value, options);
            }
            //string token = _cache.Get<string>("token");
            return key;
        }
        #endregion

        #region 获取token建
        private string TokenKey(int id) {
            Token _token = new Token();
            string key = _token.GetToken(id);
            return key;
        }
        #endregion

        //查询
        public async Task<Admin> CheckAdmin(AdminLoginModel AdminLogin, basisContext _context)
        {
            var entity = new Admin { UserName = AdminLogin.UserName, Password = AdminLogin.Password };
            var items = await _context.Admins.Where(a => a.UserName == entity.UserName && a.Password == entity.Password).SingleOrDefaultAsync();
          
            //await _context.AdminScopes.Where(a => a.Identifier == items.AdminScopeIdentifier).SingleOrDefaultAsync();
            return items;
        }
    }
}
