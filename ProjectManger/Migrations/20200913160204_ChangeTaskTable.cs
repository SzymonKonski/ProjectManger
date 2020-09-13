using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectManger.Migrations
{
    public partial class ChangeTaskTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "ProjectTasks");

            migrationBuilder.DropColumn(
                name: "Done",
                table: "ProjectTasks");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "ProjectTasks",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Deadline",
                table: "ProjectTasks",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "ProjectTasks",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Projects",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "Pricing",
                table: "Projects",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Projects",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "ProjectTasks");

            migrationBuilder.DropColumn(
                name: "Deadline",
                table: "ProjectTasks");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "ProjectTasks");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Pricing",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Projects");

            migrationBuilder.AddColumn<string>(
                name: "Date",
                table: "ProjectTasks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Done",
                table: "ProjectTasks",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
