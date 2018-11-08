﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using Winsoft.WorkSystem.Context;

namespace Winsoft.WorkSystem.Migrations
{
    [DbContext(typeof(basisContext))]
    [Migration("20181107074837_winsoft3")]
    partial class winsoft3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Winsoft.WorkSystem.Entity.Admin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AdminScopeIdentifier")
                        .HasMaxLength(11);

                    b.Property<string>("CreateTime")
                        .HasMaxLength(30);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("RealName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("UpdateTime")
                        .HasMaxLength(30);

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("AdminScopeIdentifier");

                    b.ToTable("Admin");
                });

            modelBuilder.Entity("Winsoft.WorkSystem.Entity.AdminScope", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Identifier")
                        .HasMaxLength(11);

                    b.Property<int>("OneLevelScopeId")
                        .HasMaxLength(11);

                    b.Property<string>("OneLevelScopeName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("TwoLevelScopeId")
                        .HasMaxLength(11);

                    b.Property<string>("TwoLevelScopeName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("AdminScope");
                });

            modelBuilder.Entity("Winsoft.WorkSystem.Entity.Admin", b =>
                {
                    b.HasOne("Winsoft.WorkSystem.Entity.AdminScope", "AdminScope")
                        .WithMany()
                        .HasForeignKey("AdminScopeIdentifier")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
