using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KinderConnect.Data.Migrations
{
    public partial class SeedMoreClassrooms : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Classrooms",
                columns: new[] { "Id", "CreatedOn", "ImageUrl", "Information", "MaximumAge", "MinimumAge", "Name", "TotalSeats", "TutionFee" },
                values: new object[,]
                {
                    { new Guid("47196d67-0a98-4305-9e08-d8a2e1ae22c8"), new DateTime(2024, 4, 15, 8, 43, 25, 668, DateTimeKind.Local).AddTicks(2570), "https://scienceexplorers.com/wp-content/uploads/2023/09/Academic-Overview-Science-Explorers-01.jpg", "Hands-on science experiments.Discovering nature and the universe.Introduction to scientific concepts.Creative science projects.", 12, 8, "Science Explorers", 35, 190m },
                    { new Guid("4faa63ab-f5f8-45ae-bdc4-2eb42ca9b266"), new DateTime(2024, 4, 15, 8, 43, 25, 668, DateTimeKind.Local).AddTicks(2558), "https://www.nationalgeographic.org/wp-content/uploads/2021/10/Explorer-Classroom-Ryan-Carney_National-Geographic-scaled.jpeg", "Basic coding for kids.Robotics and engineering projects.Introduction to technology.Creative digital art.", 10, 7, "Tech Explorers", 30, 200m },
                    { new Guid("8375650a-e0a4-4eb4-a5ab-849b955c79da"), new DateTime(2024, 4, 15, 8, 43, 25, 668, DateTimeKind.Local).AddTicks(2564), "https://beauvoirmusic.com/wp-content/uploads/2022/08/BMMClass.ILA0070edit1-1024x768.jpg", "Introduction to musical instruments.Music theory basics.Group singing and performances.Fun rhythm and melody activities.", 8, 5, "Music Makers", 20, 170m },
                    { new Guid("a92ed02a-bbf0-426b-b0f5-4bd8b89c33ea"), new DateTime(2024, 4, 15, 8, 43, 25, 668, DateTimeKind.Local).AddTicks(2601), "https://i.ytimg.com/vi/fIZR5Ib1p_w/maxresdefault.jpg", "Introduction to various sports.Physical fitness activities.Team-building exercises.Healthy competition and fun.", 11, 7, "Sports Stars", 40, 210m },
                    { new Guid("c12f8035-d854-4cdc-bad7-489237b10fdf"), new DateTime(2024, 4, 15, 8, 43, 25, 668, DateTimeKind.Local).AddTicks(2509), "https://blogger.googleusercontent.com/img/b/R29vZ2xl/AVvXsEjy2CRd52Daq6LiABMz5N0pCnh9Ac9o4ccMvXoxUPmMPMyF9zhxcywuRhwWc2JA6NFcyrDc_j79bmvDk3V15JwmEuJ0v6LVC1bE_0V9W0WSOGs7nwDwyIJ707ej3Kz4QiAdw9ufVec4GAF18Cm5D-UJufeUzMIkqnaOVYWHrk44DbfkaDgKJIto6T02/s1748/teacher%20teaching%20math.png", "Hands-on math activities.Problem-solving challenges.Introduction to basic math concepts.Fun math games.", 9, 6, "Math Whizzes", 30, 180m },
                    { new Guid("f9451730-fa24-466b-b852-4fa8d6eb1dfc"), new DateTime(2024, 4, 15, 8, 43, 25, 668, DateTimeKind.Local).AddTicks(2595), "https://ksspreschool.com/wp-content/uploads/2021/12/KSS-Preschool-English-Skills-and-Language-Immersion.jpeg", "Introduction to new languages.Interactive language games.Cultural learning experiences.Basic vocabulary and phrases.", 9, 6, "Language Learners", 25, 160m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DeleteData(
                table: "Classrooms",
                keyColumn: "Id",
                keyValue: new Guid("47196d67-0a98-4305-9e08-d8a2e1ae22c8"));

            migrationBuilder.DeleteData(
                table: "Classrooms",
                keyColumn: "Id",
                keyValue: new Guid("4faa63ab-f5f8-45ae-bdc4-2eb42ca9b266"));

            migrationBuilder.DeleteData(
                table: "Classrooms",
                keyColumn: "Id",
                keyValue: new Guid("8375650a-e0a4-4eb4-a5ab-849b955c79da"));

            migrationBuilder.DeleteData(
                table: "Classrooms",
                keyColumn: "Id",
                keyValue: new Guid("a92ed02a-bbf0-426b-b0f5-4bd8b89c33ea"));

            migrationBuilder.DeleteData(
                table: "Classrooms",
                keyColumn: "Id",
                keyValue: new Guid("c12f8035-d854-4cdc-bad7-489237b10fdf"));

            migrationBuilder.DeleteData(
                table: "Classrooms",
                keyColumn: "Id",
                keyValue: new Guid("f9451730-fa24-466b-b852-4fa8d6eb1dfc"));
        }
    }
}
