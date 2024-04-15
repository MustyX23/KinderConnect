using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KinderConnect.Data.Migrations
{
    public partial class SeedMoreChildren : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Children",
                columns: new[] { "Id", "Age", "Allergies", "ClassroomId", "DateOfBirth", "FirstName", "Gender", "ImageUrl", "LastName", "MedicalInformation", "ParentGuardianContact", "ParentGuardianId" },
                values: new object[,]
                {
                    { new Guid("1e5e257e-b5c6-4c7c-957e-193477a788d2"), 4, null, new Guid("632bc679-3cc2-45b7-971b-6a92105321de"), new DateTime(2020, 5, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), "Luna", "female", "https://img.freepik.com/premium-photo/smiling-baby-girl-3-4-year-old-wearing-knitted-red-sweater-posing-nature-background-close-up-looking-camera-childhood-autumn-season_260913-2064.jpg", "Little", null, "+1987654321", new Guid("bbfe1b04-2741-4440-9334-595cb40a9f64") },
                    { new Guid("672be1fd-f93a-4823-872b-11cf18c0a609"), 10, null, new Guid("4faa63ab-f5f8-45ae-bdc4-2eb42ca9b266"), new DateTime(2013, 8, 12, 13, 0, 0, 0, DateTimeKind.Unspecified), "Oliver", "male", "https://www.telegram.com/gcdn/authoring/2019/10/21/NTEG/ghows-WT-955ebf6b-6734-21c5-e053-0100007f81d9-9950fec9.jpeg", "Techton", null, "+9988776655", new Guid("c3010f38-ec8b-4c80-9599-e8fdada9299f") },
                    { new Guid("7515c2aa-52a1-4b8a-8315-d516c0b81cfb"), 6, null, new Guid("c12f8035-d854-4cdc-bad7-489237b10fdf"), new DateTime(2018, 1, 20, 9, 30, 0, 0, DateTimeKind.Unspecified), "Ethan", "male", "https://cdn.cdnparenting.com/articles/2018/08/643990666-H.webp", "Mathews", null, "+1122334455", new Guid("73690111-8cdc-4e37-91c2-143c674f324f") },
                    { new Guid("a29137f4-920b-4c85-9414-a7b7a1aa8394"), 11, null, new Guid("4faa63ab-f5f8-45ae-bdc4-2eb42ca9b266"), new DateTime(2012, 11, 8, 15, 30, 0, 0, DateTimeKind.Unspecified), "Sophie", "female", "https://media.istockphoto.com/id/1035407268/photo/portrait-of-beautiful-girl-of-10-11-years-old-child-with-perfect-white-smile-isolated-on.jpg?s=612x612&w=0&k=20&c=wW_X1ZqF-i5acks0o_nSaL3yuDQgxIhmbCyXXUMMIBE=", "Techton", null, "+9988776655", new Guid("c3010f38-ec8b-4c80-9599-e8fdada9299f") },
                    { new Guid("b1b8dace-7b66-442f-a450-b1eafa42fc16"), 7, null, new Guid("c12f8035-d854-4cdc-bad7-489237b10fdf"), new DateTime(2017, 4, 25, 11, 45, 0, 0, DateTimeKind.Unspecified), "Ava", "female", "https://images.fineartamerica.com/images/artworkimages/mediumlarge/1/portrait-of-a-girl-seven-years-old-with-blond-hair-and-white-dress-elena-saulich.jpg", "Mathews", null, "+1122334455", new Guid("73690111-8cdc-4e37-91c2-143c674f324f") },                    
                    { new Guid("ce25da3b-5776-4f58-8037-2f16ff2bca22"), 5, null, new Guid("958b5667-9055-40a7-b7b2-81c19afe3329"), new DateTime(2019, 6, 15, 14, 45, 0, 0, DateTimeKind.Unspecified), "Mila", "female", "https://people.com/thmb/PUJBCZ6e6-0hakU8up3vt6TJkZE=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc():focal(749x0:751x2)/Imi-Schneider4-f5ffc7e6f4d948fb9e40d9c788acc71c.jpg", "Doodle", null, "+1234567890", new Guid("b785b0d0-3d8c-4c37-a304-e2c41dcab31a") },                    
                    { new Guid("f40bd113-766a-4fa9-a3cb-4b979195141d"), 4, null, new Guid("958b5667-9055-40a7-b7b2-81c19afe3329"), new DateTime(2020, 3, 10, 19, 0, 0, 0, DateTimeKind.Unspecified), "Leo", "male", "https://www.shutterstock.com/image-photo/happy-five-year-old-european-600nw-278349572.jpg", "Doodle", null, "+1234567890", new Guid("b785b0d0-3d8c-4c37-a304-e2c41dcab31a") }
                });

            migrationBuilder.DeleteData(
                table: "Children",
                keyColumn: "Id",
                keyValue: new Guid("8056EAA7-C723-4C54-B7D5-9BBD7AF93B08"));

            migrationBuilder.DeleteData(
                table: "Children",
                keyColumn: "Id",
                keyValue: new Guid("FE7DA49E-7478-4E8A-8CFC-C3E35EC5F3BC"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DeleteData(
                table: "Children",
                keyColumn: "Id",
                keyValue: new Guid("1e5e257e-b5c6-4c7c-957e-193477a788d2"));

            migrationBuilder.DeleteData(
                table: "Children",
                keyColumn: "Id",
                keyValue: new Guid("672be1fd-f93a-4823-872b-11cf18c0a609"));

            migrationBuilder.DeleteData(
                table: "Children",
                keyColumn: "Id",
                keyValue: new Guid("7515c2aa-52a1-4b8a-8315-d516c0b81cfb"));

            migrationBuilder.DeleteData(
                table: "Children",
                keyColumn: "Id",
                keyValue: new Guid("a29137f4-920b-4c85-9414-a7b7a1aa8394"));

            migrationBuilder.DeleteData(
                table: "Children",
                keyColumn: "Id",
                keyValue: new Guid("b1b8dace-7b66-442f-a450-b1eafa42fc16"));

            migrationBuilder.DeleteData(
                table: "Children",
                keyColumn: "Id",
                keyValue: new Guid("ce25da3b-5776-4f58-8037-2f16ff2bca22"));

            migrationBuilder.DeleteData(
                table: "Children",
                keyColumn: "Id",
                keyValue: new Guid("f40bd113-766a-4fa9-a3cb-4b979195141d"));

        }
    }
}
