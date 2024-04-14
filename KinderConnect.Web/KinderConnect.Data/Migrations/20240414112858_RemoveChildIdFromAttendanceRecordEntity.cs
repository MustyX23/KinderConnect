using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KinderConnect.Data.Migrations
{
    public partial class RemoveChildIdFromAttendanceRecordEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AttendanceRecords_Children_ChildId",
                table: "AttendanceRecords");

            migrationBuilder.DropIndex(
                name: "IX_AttendanceRecords_ChildId",
                table: "AttendanceRecords");

            migrationBuilder.DropColumn(
                name: "ChildId",
                table: "AttendanceRecords");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ChildId",
                table: "AttendanceRecords",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_AttendanceRecords_ChildId",
                table: "AttendanceRecords",
                column: "ChildId");

            migrationBuilder.AddForeignKey(
                name: "FK_AttendanceRecords_Children_ChildId",
                table: "AttendanceRecords",
                column: "ChildId",
                principalTable: "Children",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
