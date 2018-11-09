using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Winsoft.WorkSystem.Model
{
    public class AdminLoginModel
    {
        /// <summary>
        /// 用户名 UserName
        /// 密码  Password
        /// </summary>
        [Required(ErrorMessage = "用户名不为空")]
        public string UserName { set; get; }
        [Required(ErrorMessage = "密码不为空")]
        public string Password { set; get; }
    }
}
