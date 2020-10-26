﻿// <auto-generated />
using System;
using EmployeeManagement.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EmployeeManagement.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EmployeeManagement.DataAccess.ActiveTask", b =>
                {
                    b.Property<int>("EmployeeID")
                        .HasColumnType("int");

                    b.Property<DateTime>("TaskEndDate")
                        .HasColumnName("TaskEndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("TaskID")
                        .HasColumnType("int");

                    b.Property<DateTime>("TaskStartDate")
                        .HasColumnName("TaskStartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("TimeCompleted")
                        .HasColumnName("TimeCompleted")
                        .HasColumnType("int");

                    b.HasIndex("EmployeeID");

                    b.HasIndex("TaskID");

                    b.ToTable("ActiveTasks");
                });

            modelBuilder.Entity("EmployeeManagement.DataAccess.Employee", b =>
                {
                    b.Property<int>("EmployeeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("EmployeeID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EmployeeEmail")
                        .IsRequired()
                        .HasColumnName("EmployeeEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EmployeeEndDate")
                        .HasColumnName("EmployeeEndDate")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("EmployeeImage")
                        .HasColumnName("EmployeeImage")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("EmployeeName")
                        .IsRequired()
                        .HasColumnName("EmployeeName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmployeePassword")
                        .IsRequired()
                        .HasColumnName("EmployeePassword")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EmployeeStartDate")
                        .HasColumnName("EmployeeStartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmployeeSurname")
                        .IsRequired()
                        .HasColumnName("EmployeeSurnameName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleID")
                        .HasColumnType("int");

                    b.HasKey("EmployeeID");

                    b.HasIndex("RoleID");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("EmployeeManagement.DataAccess.Role", b =>
                {
                    b.Property<int>("RoleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("RoleID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnName("RoleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleRate")
                        .HasColumnName("RoleRate")
                        .HasColumnType("int");

                    b.HasKey("RoleID");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            RoleID = -1,
                            RoleName = "Manager",
                            RoleRate = 100
                        },
                        new
                        {
                            RoleID = 1,
                            RoleName = "Casual Employee Level 1",
                            RoleRate = 50
                        },
                        new
                        {
                            RoleID = 2,
                            RoleName = "Casual Employee Level 2",
                            RoleRate = 75
                        });
                });

            modelBuilder.Entity("EmployeeManagement.DataAccess.Task", b =>
                {
                    b.Property<int>("TaskID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("TaskID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TaskDesc")
                        .IsRequired()
                        .HasColumnName("TaskDesc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TaskDuration")
                        .IsRequired()
                        .HasColumnName("TaskDuration")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TaskName")
                        .IsRequired()
                        .HasColumnName("TaskName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TaskID");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("EmployeeManagement.DataAccess.ActiveTask", b =>
                {
                    b.HasOne("EmployeeManagement.DataAccess.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EmployeeManagement.DataAccess.Task", "Task")
                        .WithMany()
                        .HasForeignKey("TaskID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EmployeeManagement.DataAccess.Employee", b =>
                {
                    b.HasOne("EmployeeManagement.DataAccess.Role", null)
                        .WithMany("Employees")
                        .HasForeignKey("RoleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
