using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KinderConnect.Data.Migrations
{
    public partial class SeedClassroomTeachers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ClassroomsTeachers",
                columns: new[] { "ClassroomId", "TeacherId" },
                values: new object[,]
                {
                    { new Guid("4faa63ab-f5f8-45ae-bdc4-2eb42ca9b266"), new Guid("32521de9-eb61-49d9-b81f-b3dc5467fb4c") },
                    { new Guid("632bc679-3cc2-45b7-971b-6a92105321de"), new Guid("715C4EB6-ACA1-4864-B04A-396E8F16EE7C") },
                    { new Guid("958b5667-9055-40a7-b7b2-81c19afe3329"), new Guid("715C4EB6-ACA1-4864-B04A-396E8F16EE7C") },
                    { new Guid("c12f8035-d854-4cdc-bad7-489237b10fdf"), new Guid("32521de9-eb61-49d9-b81f-b3dc5467fb4c") },
                    { new Guid("8375650a-e0a4-4eb4-a5ab-849b955c79da"), new Guid("365d5460-43bb-4094-bd01-46f0c3197590") },
                    { new Guid("a92ed02a-bbf0-426b-b0f5-4bd8b89c33ea"), new Guid("365d5460-43bb-4094-bd01-46f0c3197590") },
                    { new Guid("4faa63ab-f5f8-45ae-bdc4-2eb42ca9b266"), new Guid("a5738953-616e-448c-8d2d-c1eb5921f6ba") },
                    { new Guid("c12f8035-d854-4cdc-bad7-489237b10fdf"), new Guid("a5738953-616e-448c-8d2d-c1eb5921f6ba") },
                    { new Guid("47196d67-0a98-4305-9e08-d8a2e1ae22c8"), new Guid("c8a7e14b-6543-47e9-bead-0e19f3a199c6") },
                    { new Guid("f9451730-fa24-466b-b852-4fa8d6eb1dfc"), new Guid("c8a7e14b-6543-47e9-bead-0e19f3a199c6") },
                    { new Guid("632bc679-3cc2-45b7-971b-6a92105321de"), new Guid("f51fd481-6ca4-45b8-9848-304132b479f8") },
                    { new Guid("958b5667-9055-40a7-b7b2-81c19afe3329"), new Guid("f51fd481-6ca4-45b8-9848-304132b479f8") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ClassroomsTeachers",
                keyColumns: new[] { "ClassroomId", "TeacherId" },
                keyValues: new object[] { new Guid("4faa63ab-f5f8-45ae-bdc4-2eb42ca9b266"), new Guid("32521de9-eb61-49d9-b81f-b3dc5467fb4c") });

            migrationBuilder.DeleteData(
                table: "ClassroomsTeachers",
                keyColumns: new[] { "ClassroomId", "TeacherId" },
                keyValues: new object[] { new Guid("632bc679-3cc2-45b7-971b-6a92105321de"), new Guid("715C4EB6-ACA1-4864-B04A-396E8F16EE7C") });

            migrationBuilder.DeleteData(
                table: "ClassroomsTeachers",
                keyColumns: new[] { "ClassroomId", "TeacherId" },
                keyValues: new object[] { new Guid("958b5667-9055-40a7-b7b2-81c19afe3329"), new Guid("715C4EB6-ACA1-4864-B04A-396E8F16EE7C") });

            migrationBuilder.DeleteData(
                table: "ClassroomsTeachers",
                keyColumns: new[] { "ClassroomId", "TeacherId" },
                keyValues: new object[] { new Guid("c12f8035-d854-4cdc-bad7-489237b10fdf"), new Guid("32521de9-eb61-49d9-b81f-b3dc5467fb4c") });

            migrationBuilder.DeleteData(
                table: "ClassroomsTeachers",
                keyColumns: new[] { "ClassroomId", "TeacherId" },
                keyValues: new object[] { new Guid("8375650a-e0a4-4eb4-a5ab-849b955c79da"), new Guid("365d5460-43bb-4094-bd01-46f0c3197590") });

            migrationBuilder.DeleteData(
                table: "ClassroomsTeachers",
                keyColumns: new[] { "ClassroomId", "TeacherId" },
                keyValues: new object[] { new Guid("a92ed02a-bbf0-426b-b0f5-4bd8b89c33ea"), new Guid("365d5460-43bb-4094-bd01-46f0c3197590") });

            migrationBuilder.DeleteData(
                table: "ClassroomsTeachers",
                keyColumns: new[] { "ClassroomId", "TeacherId" },
                keyValues: new object[] { new Guid("4faa63ab-f5f8-45ae-bdc4-2eb42ca9b266"), new Guid("a5738953-616e-448c-8d2d-c1eb5921f6ba") });

            migrationBuilder.DeleteData(
                table: "ClassroomsTeachers",
                keyColumns: new[] { "ClassroomId", "TeacherId" },
                keyValues: new object[] { new Guid("c12f8035-d854-4cdc-bad7-489237b10fdf"), new Guid("a5738953-616e-448c-8d2d-c1eb5921f6ba") });

            migrationBuilder.DeleteData(
                table: "ClassroomsTeachers",
                keyColumns: new[] { "ClassroomId", "TeacherId" },
                keyValues: new object[] { new Guid("47196d67-0a98-4305-9e08-d8a2e1ae22c8"), new Guid("c8a7e14b-6543-47e9-bead-0e19f3a199c6") });

            migrationBuilder.DeleteData(
                table: "ClassroomsTeachers",
                keyColumns: new[] { "ClassroomId", "TeacherId" },
                keyValues: new object[] { new Guid("f9451730-fa24-466b-b852-4fa8d6eb1dfc"), new Guid("c8a7e14b-6543-47e9-bead-0e19f3a199c6") });

            migrationBuilder.DeleteData(
                table: "ClassroomsTeachers",
                keyColumns: new[] { "ClassroomId", "TeacherId" },
                keyValues: new object[] { new Guid("632bc679-3cc2-45b7-971b-6a92105321de"), new Guid("f51fd481-6ca4-45b8-9848-304132b479f8") });

            migrationBuilder.DeleteData(
                table: "ClassroomsTeachers",
                keyColumns: new[] { "ClassroomId", "TeacherId" },
                keyValues: new object[] { new Guid("958b5667-9055-40a7-b7b2-81c19afe3329"), new Guid("f51fd481-6ca4-45b8-9848-304132b479f8") });
        }
    }
}
