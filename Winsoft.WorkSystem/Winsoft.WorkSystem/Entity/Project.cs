using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Winsoft.WorkSystem.Entity
{
    public class Project
    {
        [Display(Name = "id")]
        public int Id { set; get; }
        [Display(Name = "项目名")]
        public string ProjectName { set; get; }
        [Display(Name = "项目描述")]
        public string ProjectDesc { set; get; }
        [Display(Name = "创建时间")]
        public string CreateTime { set; get; }
        [Display(Name = "预计完成时间")]
        public string EstimateTime { set; get; }
        [Display(Name = "完成时间")]
        public string FinishTime { set; get; }
    }
}
