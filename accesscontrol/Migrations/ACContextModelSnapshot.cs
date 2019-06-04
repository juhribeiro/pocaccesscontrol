﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using accesscontrol.Data;

namespace accesscontrol.Migrations
{
    [DbContext(typeof(ACContext))]
    partial class ACContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("accesscontrol")
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("accesscontrol.Data.Application", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("CreateUser");

                    b.Property<string>("Description");

                    b.Property<DateTime>("LastChangeDate");

                    b.Property<string>("LastChangeUser");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.ToTable("Applications");
                });

            modelBuilder.Entity("accesscontrol.Data.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active");

                    b.Property<int>("ApplicationId");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("CreateUser");

                    b.Property<string>("Description");

                    b.Property<DateTime>("LastChangeDate");

                    b.Property<string>("LastChangeUser");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationId");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("accesscontrol.Data.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("CreateUser");

                    b.Property<string>("Description");

                    b.Property<DateTime>("LastChangeDate");

                    b.Property<string>("LastChangeUser");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("accesscontrol.Data.RoleGroup", b =>
                {
                    b.Property<int>("RoleId");

                    b.Property<int>("GroupId");

                    b.Property<bool>("Active");

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("CreateUser");

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("LastChangeDate");

                    b.Property<string>("LastChangeUser");

                    b.HasKey("RoleId", "GroupId");

                    b.HasAlternateKey("Id");

                    b.HasIndex("GroupId");

                    b.ToTable("RoleGroups");
                });

            modelBuilder.Entity("accesscontrol.Data.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active");

                    b.Property<string>("CellPhoneNumber")
                        .IsRequired();

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("CreateUser");

                    b.Property<string>("DocumentNumber");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<DateTime>("ExpirationDate");

                    b.Property<DateTime>("LastChangeDate");

                    b.Property<string>("LastChangeUser");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<int?>("NumberGenerate");

                    b.Property<int?>("NumberLoginErros");

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<string>("PhoneNumber");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("accesscontrol.Data.UserApplication", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("ApplicationId");

                    b.Property<bool>("Active");

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("CreateUser");

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("LastChangeDate");

                    b.Property<string>("LastChangeUser");

                    b.HasKey("UserId", "ApplicationId");

                    b.HasAlternateKey("Id");

                    b.HasIndex("ApplicationId");

                    b.ToTable("UserApplications");
                });

            modelBuilder.Entity("accesscontrol.Data.UserGroup", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("GroupId");

                    b.Property<bool>("Active");

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("CreateUser");

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("LastChangeDate");

                    b.Property<string>("LastChangeUser");

                    b.HasKey("UserId", "GroupId");

                    b.HasAlternateKey("Id");

                    b.HasIndex("GroupId");

                    b.ToTable("UserGroups");
                });

            modelBuilder.Entity("accesscontrol.Data.Group", b =>
                {
                    b.HasOne("accesscontrol.Data.Application", "Application")
                        .WithMany("Groups")
                        .HasForeignKey("ApplicationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("accesscontrol.Data.RoleGroup", b =>
                {
                    b.HasOne("accesscontrol.Data.Group", "Group")
                        .WithMany("RoleGroups")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("accesscontrol.Data.Role", "Role")
                        .WithMany("RoleGroups")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("accesscontrol.Data.UserApplication", b =>
                {
                    b.HasOne("accesscontrol.Data.Application", "Application")
                        .WithMany("UserApplications")
                        .HasForeignKey("ApplicationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("accesscontrol.Data.User", "User")
                        .WithMany("UserApplications")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("accesscontrol.Data.UserGroup", b =>
                {
                    b.HasOne("accesscontrol.Data.Group", "Group")
                        .WithMany("UserGroups")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("accesscontrol.Data.User", "User")
                        .WithMany("UserGroups")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
