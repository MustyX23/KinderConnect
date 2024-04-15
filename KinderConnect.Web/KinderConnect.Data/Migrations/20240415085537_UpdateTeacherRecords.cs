using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KinderConnect.Data.Migrations
{
    public partial class UpdateTeacherRecords : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: new Guid("715C4EB6-ACA1-4864-B04A-396E8F16EE7C"),
                column: "ImageUrl",
                value: "https://www.fairviewer.org/wp-content/uploads/2017/12/1Q01257.jpg");

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: new Guid("715C4EB6-ACA1-4864-B04A-396E8F16EE7C"),
                column: "Summary",
                value: "Through engaging writing activities and interactive storytelling sessions, Lyubliana sparks imagination and ignites a love for literature and language in his students. She celebrates each child's unique voice and perspective, fostering confidence and a sense of accomplishment in their writing endeavors. Lyubliana's commitment to nurturing young writers creates a vibrant and enriching learning environment where every child's story is valued and cherished.");

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: new Guid("F51FD481-6CA4-45B8-9848-304132B479F8"),
                column: "ImageUrl",
                value: "https://www.richardsbrandt.com/wp-content/uploads/2021/07/RB-attorney-sq-Christine-Seminario.png");

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: new Guid("F51FD481-6CA4-45B8-9848-304132B479F8"),
                column: "Summary",
                value: "A dedicated drawing teacher, brings creativity and warmth to the kindergarten classroom as she introduces young children to the world of artistic expression through drawing. With a gentle and encouraging approach, Mustafa fosters the development of fine motor skills, creativity, and self-expression in his students. She designs engaging drawing activities tailored to the unique interests and abilities of each child, from exploring simple shapes to creating imaginative scenes.");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("702DE3DD-C1E7-4F40-9131-623AADB7E765"),
                columns: new[] { "FirstName", "LastName", "Gender" },
                values: new object[] { "Lyubliana", "Popova", "female" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("C3010F38-EC8B-4C80-9599-E8FDADA9299F"),
                columns: new[] { "FirstName", "LastName", "Gender" },
                values: new object[] { "Milena", "Benkova", "female" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
