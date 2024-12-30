using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SaifHassanW2.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    PID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.PID);
                });

            migrationBuilder.CreateTable(
                name: "TeamMembers",
                columns: table => new
                {
                    TeamID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Role = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamMembers", x => x.TeamID);
                });

            migrationBuilder.CreateTable(
                name: "tasks",
                columns: table => new
                {
                    TaskID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Priority = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Deadline = table.Column<DateTime>(type: "datetime2", nullable: false),
                    projectID = table.Column<int>(type: "int", nullable: false),
                    TeamMemberID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tasks", x => x.TaskID);
                    table.ForeignKey(
                        name: "FK_tasks_Projects_projectID",
                        column: x => x.projectID,
                        principalTable: "Projects",
                        principalColumn: "PID");
                    table.ForeignKey(
                        name: "FK_tasks_TeamMembers_TeamMemberID",
                        column: x => x.TeamMemberID,
                        principalTable: "TeamMembers",
                        principalColumn: "TeamID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_tasks_projectID",
                table: "tasks",
                column: "projectID");

            migrationBuilder.CreateIndex(
                name: "IX_tasks_TeamMemberID",
                table: "tasks",
                column: "TeamMemberID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tasks");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "TeamMembers");
        }
    }
}
