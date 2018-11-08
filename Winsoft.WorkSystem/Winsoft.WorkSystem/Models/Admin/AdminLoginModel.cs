using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Winsoft.WorkSystem.Model
{
    public class AdminLoginModel
    {
        [Required(ErrorMessage = "用户名不为空")]
        public string UserName { set; get; }
        [Required(ErrorMessage = "密码不为空")]
        public string Password { set; get; }
    }
}
