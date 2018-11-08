using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Winsoft.WorkSystem.Entity
{
    public class AdminScope
    {
        public int Id { set; get; }
        public string OneLevelScopeName { set; get; }
        public string TwoLevelScopeName { set; get; }
        public int OneLevelScopeId { set; get; }
        public int TwoLevelScopeId { set; get; }
        public int Identifier { set; get; }
    }
    public class AdminScopeConfiguration : IEntityTypeConfiguration<AdminScope>
    {
        public void Configure(EntityTypeBuilder<AdminScope> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.OneLevelScopeName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.TwoLevelScopeName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.OneLevelScopeId).IsRequired().HasMaxLength(11);
            builder.Property(x => x.TwoLevelScopeId).IsRequired().HasMaxLength(11);
            builder.Property(x => x.Identifier).IsRequired().HasMaxLength(11);
            builder.ToTable("AdminScope");
        }
    }
}
