using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Winsoft.WorkSystem.Models.Admin
{
    /// <summary>
    /// 获取用户所有信息
    /// </summary>
    public class AdminInfoModel
    {
        public string UserName { set; get; }
        public string RealName { set; get; }
        public int AdminScopeIdentifier { set; get; }
        public string OneLevelScopeName { set; get; }
        public string TwoLevelScopeName { set; get; }
        public int OneLevelScopeId { set; get; }
        public int TwoLevelScopeId { set; get; }
    }
}
