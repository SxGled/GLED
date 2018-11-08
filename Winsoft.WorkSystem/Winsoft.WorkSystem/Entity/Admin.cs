using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Winsoft.WorkSystem.Entity
{
    public class Admin
    {
        public int Id { set; get; }
        public string UserName{set;get;}
        public string RealName { set; get; }
        public string Password { set; get; }
        public int AdminScopeIdentifier { set; get; }
        public string CreateTime { set; get; }
        public string UpdateTime { set; get; }
    }
    public class AdminConfiguration : IEntityTypeConfiguration<Admin>
    {
        public void Configure(EntityTypeBuilder<Admin> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.UserName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.RealName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Password).IsRequired().HasMaxLength(30);
            builder.Property(x => x.AdminScopeIdentifier).HasMaxLength(11);
            builder.Property(x => x.CreateTime).HasMaxLength(30);
            builder.Property(x => x.UpdateTime).HasMaxLength(30);
            builder.ToTable("Admin");
        }
    }
}
