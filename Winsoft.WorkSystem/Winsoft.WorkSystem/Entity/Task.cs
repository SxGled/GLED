using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Winsoft.WorkSystem.Entity
{
    public class Task
    {
        [Display(Name = "id")]
        public int Id { set; get; }
        [Display(Name = "任务名")]
        public string TaskName { set; get; }
        [Display(Name = "任务描述")]
        public string TaskDesc { set; get; }
        
        public string ProjectId { set; get; }
    }
}
