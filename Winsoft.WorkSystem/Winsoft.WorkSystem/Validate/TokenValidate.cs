using Microsoft.Extensions.Caching.Memory;
using Winsoft.WorkSystem.Common.Json;
using Winsoft.WorkSystem.Entity;

namespace Winsoft.WorkSystem.Validate
{
    public class TokenValidate
    {
        public ReturnJson CheckToken(string token,IMemoryCache _cache) {
            if (token == null)
            {
                return new ReturnJson { ErrorCode = 20002, ErrorMsg = "token为空！", Data = "", Success = false , CheckParamsSuccess ="no"};
            }
            //查询token是否存在
            if (string.IsNullOrEmpty(_cache.Get<string>(token)))
            {
                return new ReturnJson { ErrorCode = 20002, ErrorMsg = "token过期或无效，请重新生成", Data = "", Success = false,CheckParamsSuccess = "no" };
            }
            //取出token对应的值
            //string a = _cache.Get<string>(token);
            //Admin admin = ConvertJson.JsonStringToObj<Admin>(a);

            return  new ReturnJson { ErrorCode = 20001, ErrorMsg = "验证成功", Data ="", Success = true, CheckParamsSuccess = "ok" };
        }
    }
}
