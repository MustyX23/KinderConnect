using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KinderConnect.Data.Migrations
{
    public partial class AddSummaryColumnToTeacherAndSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
            name: "Summary",
            table: "Teachers",
            type: "nvarchar(500)",
            maxLength: 500,
            nullable: false,
            defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "TeacherUserId",
                keyValue: new Guid("702DE3DD-C1E7-4F40-9131-623AADB7E765"), 
                column: "Summary",
                value: "Through engaging writing activities and interactive storytelling sessions, Lyubomir sparks imagination and ignites a love for literature and language in his students. He celebrates each child's unique voice and perspective, fostering confidence and a sense of accomplishment in their writing endeavors. Lyubomir's commitment to nurturing young writers creates a vibrant and enriching learning environment where every child's story is valued and cherished.");
                

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "TeacherUserId",
                keyValue: new Guid("C3010F38-EC8B-4C80-9599-E8FDADA9299F"),
                column: "Summary",
                value: "A dedicated drawing teacher, brings creativity and warmth to the kindergarten classroom as he introduces young children to the world of artistic expression through drawing. With a gentle and encouraging approach, Mustafa fosters the development of fine motor skills, creativity, and self-expression in his students. He designs engaging drawing activities tailored to the unique interests and abilities of each child, from exploring simple shapes to creating imaginative scenes.");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: new Guid("00b81662-9789-4943-9b9c-630b5207beec"));

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: new Guid("af6ac08d-8890-4ca7-97a4-0113aaac41f2"));

            migrationBuilder.DropColumn(
                name: "Summary",
                table: "Teachers");

        }
    }
}
