using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KinderConnect.Data.Migrations
{
    public partial class AddClassroomToAttendanceRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ClassroomId",
                table: "AttendanceRecords",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_AttendanceRecords_ClassroomId",
                table: "AttendanceRecords",
                column: "ClassroomId");

            migrationBuilder.AddForeignKey(
                name: "FK_AttendanceRecords_Classrooms_ClassroomId",
                table: "AttendanceRecords",
                column: "ClassroomId",
                principalTable: "Classrooms",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AttendanceRecords_Classrooms_ClassroomId",
                table: "AttendanceRecords");

            migrationBuilder.DropIndex(
                name: "IX_AttendanceRecords_ClassroomId",
                table: "AttendanceRecords");

            migrationBuilder.DropColumn(
                name: "ClassroomId",
                table: "AttendanceRecords");
        }
    }
}
