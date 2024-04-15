using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KinderConnect.Data.Migrations
{
    public partial class RemoveRepeatingTeacherRecords : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: new Guid("3A988BE1-CB4C-4C05-83D5-5D143ABCAA29"));

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: new Guid("3FA260E5-8AC6-44D3-8CFA-6F6CD0032720"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "ImageUrl", "QualificationId", "Summary", "TeacherUserId" },
                values: new object[,]
                {
                    { new Guid("3FA260E5-8AC6-44D3-8CFA-6F6CD0032720"), "https://img.freepik.com/premium-photo/old-male-teacher-portrait-closeup-face-professor-teacher-blackboard-isolated_265223-53892.jpg", 1, "A dedicated drawing teacher, brings creativity and warmth to the kindergarten classroom as he introduces young children to the world of artistic expression through drawing. With a gentle and encouraging approach, Mustafa fosters the development of fine motor skills, creativity, and self-expression in his students. He designs engaging drawing activities tailored to the unique interests and abilities of each child, from exploring simple shapes to creating imaginative scenes.", new Guid("c3010f38-ec8b-4c80-9599-e8fdada9299f") },
                    { new Guid("3A988BE1-CB4C-4C05-83D5-5D143ABCAA29"), "https://i.guim.co.uk/img/media/b897974dce4559ebe02af27e10c475068ead46a8/0_0_4000_2400/master/4000.jpg?width=1200&height=1200&quality=85&auto=format&fit=crop&s=a53a3c7714a215af7051daea5b14971c", 1, "Inspires young minds in the kindergarten classroom with his passion for storytelling and language. With a nurturing and supportive approach, Lyubomir guides children on a journey of exploration and discovery through the world of writing. He encourages creativity and self-expression, helping students develop foundational writing skills such as letter formation, phonics, and basic sentence structure.", new Guid("702de3dd-c1e7-4f40-9131-623aadb7e765") }
                });
        }
    }
}
