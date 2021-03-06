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
                    b.Property<int>("WIPID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("WIPID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EmployeeCurrentRate")
                        .HasColumnType("int");

                    b.Property<int>("EmployeeID")
                        .HasColumnType("int");

                    b.Property<int>("TaskID")
                        .HasColumnType("int");

                    b.Property<DateTime>("TaskStartDate")
                        .HasColumnName("TaskStartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("TimeCompleted")
                        .HasColumnName("TimeCompleted")
                        .HasColumnType("int");

                    b.HasKey("WIPID");

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
                        .HasColumnName("EmployeeSurname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleID")
                        .HasColumnType("int");

                    b.HasKey("EmployeeID");

                    b.HasIndex("RoleID");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            EmployeeID = 1,
                            EmployeeEmail = "jaquesg@company.co.za",
                            EmployeeEndDate = new DateTime(2020, 11, 5, 9, 20, 57, 435, DateTimeKind.Local).AddTicks(5775),
                            EmployeeName = "Jaques",
                            EmployeePassword = "1234",
                            EmployeeStartDate = new DateTime(2020, 10, 29, 9, 20, 57, 434, DateTimeKind.Local).AddTicks(5484),
                            EmployeeSurname = "Greyling",
                            RoleID = 1
                        },
                        new
                        {
                            EmployeeID = 2,
                            EmployeeEmail = "johanr@company.co.za",
                            EmployeeEndDate = new DateTime(2020, 11, 5, 9, 20, 57, 435, DateTimeKind.Local).AddTicks(7135),
                            EmployeeName = "Johan",
                            EmployeePassword = "qwer",
                            EmployeeStartDate = new DateTime(2020, 10, 29, 9, 20, 57, 435, DateTimeKind.Local).AddTicks(7121),
                            EmployeeSurname = "Rogers",
                            RoleID = 2
                        },
                        new
                        {
                            EmployeeID = 3,
                            EmployeeEmail = "stacys@company.co.za",
                            EmployeeEndDate = new DateTime(2020, 11, 5, 9, 20, 57, 435, DateTimeKind.Local).AddTicks(7162),
                            EmployeeName = "Stacy",
                            EmployeePassword = "q1w2e3",
                            EmployeeStartDate = new DateTime(2020, 10, 29, 9, 20, 57, 435, DateTimeKind.Local).AddTicks(7160),
                            EmployeeSurname = "Smith",
                            RoleID = -1
                        });
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

                    b.Property<int>("TaskDuration")
                        .HasColumnName("TaskDuration")
                        .HasColumnType("int");

                    b.Property<string>("TaskName")
                        .IsRequired()
                        .HasColumnName("TaskName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TaskID");

                    b.ToTable("Tasks");

                    b.HasData(
                        new
                        {
                            TaskID = 1,
                            TaskDesc = "Create DB according to specification",
                            TaskDuration = 5,
                            TaskName = "Create DB"
                        },
                        new
                        {
                            TaskID = 2,
                            TaskDesc = "Create API according to specification",
                            TaskDuration = 4,
                            TaskName = "Create API"
                        },
                        new
                        {
                            TaskID = 3,
                            TaskDesc = "Create UI according to specification",
                            TaskDuration = 4,
                            TaskName = "Create UI"
                        });
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
