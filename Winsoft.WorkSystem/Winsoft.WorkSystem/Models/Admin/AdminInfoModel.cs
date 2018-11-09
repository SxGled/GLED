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
        /// <summary>
        ///  UserName  用户名
        ///  RealName  显示名
        ///  AdminScopeIdentifier  权限id
        ///  OneLevelScopeName  一级权限名
        ///  TwoLevelScopeName  二级权限名
        ///  OneLevelScopeId  一级权限id
        ///  TwoLevelScopeId  二级权限id
        /// </summary>
        public int Id { set; get; }
        public string UserName { set; get; }
        public string RealName { set; get; }
        public int AdminScopeIdentifier { set; get; }
        public string OneLevelScopeName { set; get; }
        public string TwoLevelScopeName { set; get; }
        public int OneLevelScopeId { set; get; }
        public int TwoLevelScopeId { set; get; }
    }
}
