using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
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
        [Display(Name = "参与用户")]
        public string JoinUser { set; get; }
    }
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.ProjectName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.ProjectDesc).IsRequired().HasMaxLength(50);
            builder.Property(x => x.CreateTime).IsRequired().HasMaxLength(50);
            builder.Property(x => x.EstimateTime).IsRequired().HasMaxLength(50);
            builder.Property(x => x.FinishTime).IsRequired().HasMaxLength(50);
            builder.Property(x => x.JoinUser).IsRequired().HasMaxLength(255);
            builder.ToTable("Project");
        }
    }


}
