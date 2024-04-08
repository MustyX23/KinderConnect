using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KinderConnect.Data.Migrations
{
    public partial class RemoveRequiredAttributeFromClassroomIdChildEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Children_Classrooms_ClassroomId",
                table: "Children");
 
            migrationBuilder.AlterColumn<Guid>(
                name: "ClassroomId",
                table: "Children",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Children_Classrooms_ClassroomId",
                table: "Children",
                column: "ClassroomId",
                principalTable: "Classrooms",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Children_Classrooms_ClassroomId",
                table: "Children");


            migrationBuilder.AlterColumn<Guid>(
                name: "ClassroomId",
                table: "Children",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);


            migrationBuilder.AddForeignKey(
                name: "FK_Children_Classrooms_ClassroomId",
                table: "Children",
                column: "ClassroomId",
                principalTable: "Classrooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
