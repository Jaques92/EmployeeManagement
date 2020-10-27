using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeManagement.Migrations
{
    public partial class BaseMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(nullable: false),
                    RoleRate = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleID);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    TaskID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskName = table.Column<string>(nullable: false),
                    TaskDesc = table.Column<string>(nullable: false),
                    TaskDuration = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.TaskID);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeName = table.Column<string>(nullable: false),
                    EmployeeSurname = table.Column<string>(nullable: false),
                    EmployeeEmail = table.Column<string>(nullable: false),
                    EmployeePassword = table.Column<string>(nullable: false),
                    EmployeeStartDate = table.Column<DateTime>(nullable: false),
                    EmployeeEndDate = table.Column<DateTime>(nullable: false),
                    EmployeeImage = table.Column<byte[]>(nullable: true),
                    RoleID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeID);
                    table.ForeignKey(
                        name: "FK_Employees_Roles_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Roles",
                        principalColumn: "RoleID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActiveTasks",
                columns: table => new
                {
                    WIPID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskID = table.Column<int>(nullable: false),
                    EmployeeID = table.Column<int>(nullable: false),
                    EmployeeCurrentRate = table.Column<int>(nullable: false),
                    TaskStartDate = table.Column<DateTime>(nullable: false),
                    TaskEndDate = table.Column<DateTime>(nullable: false),
                    TimeCompleted = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActiveTasks", x => x.WIPID);
                    table.ForeignKey(
                        name: "FK_ActiveTasks_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActiveTasks_Tasks_TaskID",
                        column: x => x.TaskID,
                        principalTable: "Tasks",
                        principalColumn: "TaskID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleID", "RoleName", "RoleRate" },
                values: new object[,]
                {
                    { -1, "Manager", 100 },
                    { 1, "Casual Employee Level 1", 50 },
                    { 2, "Casual Employee Level 2", 75 }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "TaskID", "TaskDesc", "TaskDuration", "TaskName" },
                values: new object[,]
                {
                    { 1, "Create DB according to specification", 5, "Create DB" },
                    { 2, "Create API according to specification", 4, "Create API" },
                    { 3, "Create UI according to specification", 4, "Create UI" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeID", "EmployeeEmail", "EmployeeEndDate", "EmployeeImage", "EmployeeName", "EmployeePassword", "EmployeeStartDate", "EmployeeSurname", "RoleID" },
                values: new object[] { 3, "stacys@company.co.za", new DateTime(2020, 11, 3, 12, 44, 17, 48, DateTimeKind.Local).AddTicks(2101), null, "Stacy", "q1w2e3", new DateTime(2020, 10, 27, 12, 44, 17, 48, DateTimeKind.Local).AddTicks(2100), "Smith", -1 });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeID", "EmployeeEmail", "EmployeeEndDate", "EmployeeImage", "EmployeeName", "EmployeePassword", "EmployeeStartDate", "EmployeeSurname", "RoleID" },
                values: new object[] { 1, "jaquesg@company.co.za", new DateTime(2020, 11, 3, 12, 44, 17, 48, DateTimeKind.Local).AddTicks(803), null, "Jaques", "1234", new DateTime(2020, 10, 27, 12, 44, 17, 46, DateTimeKind.Local).AddTicks(9756), "Greyling", 1 });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeID", "EmployeeEmail", "EmployeeEndDate", "EmployeeImage", "EmployeeName", "EmployeePassword", "EmployeeStartDate", "EmployeeSurname", "RoleID" },
                values: new object[] { 2, "johanr@company.co.za", new DateTime(2020, 11, 3, 12, 44, 17, 48, DateTimeKind.Local).AddTicks(2068), null, "Johan", "qwer", new DateTime(2020, 10, 27, 12, 44, 17, 48, DateTimeKind.Local).AddTicks(2054), "Rogers", 2 });

            migrationBuilder.CreateIndex(
                name: "IX_ActiveTasks_EmployeeID",
                table: "ActiveTasks",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_ActiveTasks_TaskID",
                table: "ActiveTasks",
                column: "TaskID");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_RoleID",
                table: "Employees",
                column: "RoleID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActiveTasks");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
