using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KinderConnect.Data.Migrations
{
    public partial class SeedChildren : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: new Guid("30870b45-707e-4347-855e-db2757ad22b8"));

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: new Guid("601edbb4-958e-4b5b-b602-107670cafd6e"));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("702de3dd-c1e7-4f40-9131-623aadb7e765"),
                column: "ConcurrencyStamp",
                value: "3390a944-06ee-4e87-8b36-9730c3a013ec");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b785b0d0-3d8c-4c37-a304-e2c41dcab31a"),
                column: "ConcurrencyStamp",
                value: "2b2c1eb4-62d9-44c1-9bf5-8b4567a7b901");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("bbfe1b04-2741-4440-9334-595cb40a9f64"),
                column: "ConcurrencyStamp",
                value: "f683ea11-8b7b-426d-a581-14316afad189");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c3010f38-ec8b-4c80-9599-e8fdada9299f"),
                column: "ConcurrencyStamp",
                value: "f1d03d38-24c2-4e07-81af-3205c239f607");

            migrationBuilder.InsertData(
                table: "Children",
                columns: new[] { "Id", "Age", "Allergies", "ClassroomId", "DateOfBirth", "FirstName", "Gender", "ImageUrl", "LastName", "MedicalInformation", "ParentGuardianContact", "ParentGuardianId" },
                values: new object[,]
                {
                    { new Guid("8056eaa7-c723-4c54-b7d5-9bbd7af93b08"), 3, null, new Guid("632bc679-3cc2-45b7-971b-6a92105321de"), new DateTime(2021, 3, 3, 18, 30, 0, 0, DateTimeKind.Unspecified), "Chicken", "male", "https://onebighappyphoto.com/wp-content/uploads/2-year-old-boy-and-family-photoshoot-2951-One-Big-Happy-Photo.jpg", "Little", null, "+1987654321", new Guid("bbfe1b04-2741-4440-9334-595cb40a9f64") },
                    { new Guid("b6a90bd5-def8-45b1-99a6-9b2c01ee51ec"), 4, null, new Guid("958b5667-9055-40a7-b7b2-81c19afe3329"), new DateTime(2020, 3, 10, 19, 0, 0, 0, DateTimeKind.Unspecified), "Emma", "female", "https://previews.123rf.com/images/mashiki/mashiki1802/mashiki180200333/96303002-close-up-indoor-portrait-of-cute-happy-2-years-old-baby-girl-in-pink-sweater.jpg", "Malinkova", null, "+1234567890", new Guid("b785b0d0-3d8c-4c37-a304-e2c41dcab31a") }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "Age", "FirstName", "Gender", "ImageUrl", "LastName", "QualificationId", "TeacherUserId" },
                values: new object[,]
                {
                    { new Guid("715c4eb6-aca1-4864-b04a-396e8f16ee7c"), 56, "Lybomir", "male", "https://i.guim.co.uk/img/media/b897974dce4559ebe02af27e10c475068ead46a8/0_0_4000_2400/master/4000.jpg?width=1200&height=1200&quality=85&auto=format&fit=crop&s=a53a3c7714a215af7051daea5b14971c", "Popov", 1, new Guid("702de3dd-c1e7-4f40-9131-623aadb7e765") },
                    { new Guid("f51fd481-6ca4-45b8-9848-304132b479f8"), 50, "Mustafa", "male", "https://img.freepik.com/premium-photo/old-male-teacher-portrait-closeup-face-professor-teacher-blackboard-isolated_265223-53892.jpg", "Buhov", 1, new Guid("c3010f38-ec8b-4c80-9599-e8fdada9299f") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Children",
                keyColumn: "Id",
                keyValue: new Guid("8056eaa7-c723-4c54-b7d5-9bbd7af93b08"));

            migrationBuilder.DeleteData(
                table: "Children",
                keyColumn: "Id",
                keyValue: new Guid("b6a90bd5-def8-45b1-99a6-9b2c01ee51ec"));

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: new Guid("715c4eb6-aca1-4864-b04a-396e8f16ee7c"));

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: new Guid("f51fd481-6ca4-45b8-9848-304132b479f8"));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("702de3dd-c1e7-4f40-9131-623aadb7e765"),
                column: "ConcurrencyStamp",
                value: "706fb8ac-91c0-4575-850e-633088c49ee6");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b785b0d0-3d8c-4c37-a304-e2c41dcab31a"),
                column: "ConcurrencyStamp",
                value: "5ba44547-1846-472d-a871-b15d1779a76e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("bbfe1b04-2741-4440-9334-595cb40a9f64"),
                column: "ConcurrencyStamp",
                value: "b1b15f2f-1a28-45dd-9cf6-61e177522d68");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c3010f38-ec8b-4c80-9599-e8fdada9299f"),
                column: "ConcurrencyStamp",
                value: "93ef9558-3332-4bc1-b434-0914db0b64d5");

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "Age", "FirstName", "Gender", "ImageUrl", "LastName", "QualificationId", "TeacherUserId" },
                values: new object[,]
                {
                    { new Guid("30870b45-707e-4347-855e-db2757ad22b8"), 50, "Mustafa", "male", "https://img.freepik.com/premium-photo/old-male-teacher-portrait-closeup-face-professor-teacher-blackboard-isolated_265223-53892.jpg", "Buhov", 1, new Guid("c3010f38-ec8b-4c80-9599-e8fdada9299f") },
                    { new Guid("601edbb4-958e-4b5b-b602-107670cafd6e"), 56, "Lybomir", "male", "https://i.guim.co.uk/img/media/b897974dce4559ebe02af27e10c475068ead46a8/0_0_4000_2400/master/4000.jpg?width=1200&height=1200&quality=85&auto=format&fit=crop&s=a53a3c7714a215af7051daea5b14971c", "Popov", 1, new Guid("702de3dd-c1e7-4f40-9131-623aadb7e765") }
                });
        }
    }
}
