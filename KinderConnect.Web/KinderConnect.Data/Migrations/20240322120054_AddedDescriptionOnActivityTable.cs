using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KinderConnect.Data.Migrations
{
    public partial class AddedDescriptionOnActivityTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Children",
                keyColumn: "Id",
                keyValue: new Guid("40f61d76-f979-4a67-ad4f-dcf06b6b0404"));

            migrationBuilder.DeleteData(
                table: "Children",
                keyColumn: "Id",
                keyValue: new Guid("774f424e-d567-4630-b926-4ab375ba1110"));

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: new Guid("62063cee-4a52-43f2-9139-a8507183dd99"));

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: new Guid("c87d9418-1359-44eb-8660-1aa926ff2a66"));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Activities",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Children",
                columns: new[] { "Id", "Age", "Allergies", "ClassroomId", "DateOfBirth", "FirstName", "Gender", "ImageUrl", "LastName", "MedicalInformation", "ParentGuardianContact", "ParentGuardianId" },
                values: new object[,]
                {
                    { new Guid("57b94939-fe49-4b27-b298-0185f907b500"), 3, null, new Guid("632bc679-3cc2-45b7-971b-6a92105321de"), new DateTime(2021, 3, 3, 18, 30, 0, 0, DateTimeKind.Unspecified), "Chicken", "male", "https://onebighappyphoto.com/wp-content/uploads/2-year-old-boy-and-family-photoshoot-2951-One-Big-Happy-Photo.jpg", "Little", null, "+1987654321", new Guid("bbfe1b04-2741-4440-9334-595cb40a9f64") },
                    { new Guid("975c57f5-2538-43a8-af6f-64a226886f29"), 4, null, new Guid("958b5667-9055-40a7-b7b2-81c19afe3329"), new DateTime(2020, 3, 10, 19, 0, 0, 0, DateTimeKind.Unspecified), "Emma", "female", "https://previews.123rf.com/images/mashiki/mashiki1802/mashiki180200333/96303002-close-up-indoor-portrait-of-cute-happy-2-years-old-baby-girl-in-pink-sweater.jpg", "Malinkova", null, "+1234567890", new Guid("b785b0d0-3d8c-4c37-a304-e2c41dcab31a") }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "Age", "FirstName", "Gender", "ImageUrl", "LastName", "QualificationId", "TeacherUserId" },
                values: new object[,]
                {
                    { new Guid("00f94629-ff1a-4df2-9cc2-e723f6741d47"), 56, "Lybomir", "male", "https://i.guim.co.uk/img/media/b897974dce4559ebe02af27e10c475068ead46a8/0_0_4000_2400/master/4000.jpg?width=1200&height=1200&quality=85&auto=format&fit=crop&s=a53a3c7714a215af7051daea5b14971c", "Popov", 1, new Guid("702de3dd-c1e7-4f40-9131-623aadb7e765") },
                    { new Guid("0404c2bd-10d9-4bd3-8766-0831efccc83b"), 50, "Mustafa", "male", "https://img.freepik.com/premium-photo/old-male-teacher-portrait-closeup-face-professor-teacher-blackboard-isolated_265223-53892.jpg", "Buhov", 1, new Guid("c3010f38-ec8b-4c80-9599-e8fdada9299f") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Children",
                keyColumn: "Id",
                keyValue: new Guid("57b94939-fe49-4b27-b298-0185f907b500"));

            migrationBuilder.DeleteData(
                table: "Children",
                keyColumn: "Id",
                keyValue: new Guid("975c57f5-2538-43a8-af6f-64a226886f29"));

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: new Guid("00f94629-ff1a-4df2-9cc2-e723f6741d47"));

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: new Guid("0404c2bd-10d9-4bd3-8766-0831efccc83b"));

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Activities");

            migrationBuilder.InsertData(
                table: "Children",
                columns: new[] { "Id", "Age", "Allergies", "ClassroomId", "DateOfBirth", "FirstName", "Gender", "ImageUrl", "LastName", "MedicalInformation", "ParentGuardianContact", "ParentGuardianId" },
                values: new object[,]
                {
                    { new Guid("40f61d76-f979-4a67-ad4f-dcf06b6b0404"), 3, null, new Guid("632bc679-3cc2-45b7-971b-6a92105321de"), new DateTime(2021, 3, 3, 18, 30, 0, 0, DateTimeKind.Unspecified), "Chicken", "male", "https://onebighappyphoto.com/wp-content/uploads/2-year-old-boy-and-family-photoshoot-2951-One-Big-Happy-Photo.jpg", "Little", null, "+1987654321", new Guid("bbfe1b04-2741-4440-9334-595cb40a9f64") },
                    { new Guid("774f424e-d567-4630-b926-4ab375ba1110"), 4, null, new Guid("958b5667-9055-40a7-b7b2-81c19afe3329"), new DateTime(2020, 3, 10, 19, 0, 0, 0, DateTimeKind.Unspecified), "Emma", "female", "https://previews.123rf.com/images/mashiki/mashiki1802/mashiki180200333/96303002-close-up-indoor-portrait-of-cute-happy-2-years-old-baby-girl-in-pink-sweater.jpg", "Malinkova", null, "+1234567890", new Guid("b785b0d0-3d8c-4c37-a304-e2c41dcab31a") }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "Age", "FirstName", "Gender", "ImageUrl", "LastName", "QualificationId", "TeacherUserId" },
                values: new object[,]
                {
                    { new Guid("62063cee-4a52-43f2-9139-a8507183dd99"), 50, "Mustafa", "male", "https://img.freepik.com/premium-photo/old-male-teacher-portrait-closeup-face-professor-teacher-blackboard-isolated_265223-53892.jpg", "Buhov", 1, new Guid("c3010f38-ec8b-4c80-9599-e8fdada9299f") },
                    { new Guid("c87d9418-1359-44eb-8660-1aa926ff2a66"), 56, "Lybomir", "male", "https://i.guim.co.uk/img/media/b897974dce4559ebe02af27e10c475068ead46a8/0_0_4000_2400/master/4000.jpg?width=1200&height=1200&quality=85&auto=format&fit=crop&s=a53a3c7714a215af7051daea5b14971c", "Popov", 1, new Guid("702de3dd-c1e7-4f40-9131-623aadb7e765") }
                });
        }
    }
}
