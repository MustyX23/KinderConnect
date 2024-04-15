using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KinderConnect.Data.Migrations
{
    public partial class SeedMoreTeachers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "ImageUrl", "QualificationId", "Summary", "TeacherUserId" },
                values: new object[,]
                {
                    { new Guid("32521de9-eb61-49d9-b81f-b3dc5467fb4c"), "https://img.freepik.com/premium-photo/close-up-face-young-female-teacher-near-chalkboard-digital-screen-classroom-headshot-positive-female-educator_116407-12458.jpg", 2, "Ava embraces a child-centered approach to education, focusing on nurturing the whole child's development. She incorporates play-based learning, hands-on activities, and interactive experiences to engage her students and make learning fun and meaningful.", new Guid("37ed60d0-efe7-4d5a-89c1-8169c7ae008f") },
                    { new Guid("365d5460-43bb-4094-bd01-46f0c3197590"), "https://www.shutterstock.com/image-photo/profile-picture-smiling-millennial-asian-600nw-1836020740.jpg", 2, "Savka's dedication, creativity, and compassionate nature make her an exceptional kindergarten teacher. Her unwavering commitment to nurturing the whole child, coupled with her innovative teaching methods and collaborative spirit, positions her as a valued and inspiring educator in the early childhood education community.", new Guid("31c9d7c4-5b0e-46b5-a6db-0ed766d6b563") },
                    { new Guid("a5738953-616e-448c-8d2d-c1eb5921f6ba"), "https://photos.demandstudios.com/getty/article/251/198/86806725.jpg", 1, "Aurora is a dedicated and passionate kindergarten teacher committed to fostering a nurturing and educational environment for young learners. With her warm personality and innovative teaching methods, she creates an engaging classroom atmosphere where students feel motivated to learn and explore.", new Guid("ffa6f8eb-02f7-4246-aa59-f7ce6d2be5ff") },
                    { new Guid("c8a7e14b-6543-47e9-bead-0e19f3a199c6"), "https://img.freepik.com/premium-photo/bright-picture-happy-smiling-woman_380164-16026.jpg?size=626&ext=jpg", 3, "Committed to continuous growth and learning, Amelia actively seeks opportunities to enhance her skills and knowledge in early childhood education. She engages in professional development workshops, conferences, and training sessions to stay updated with the latest trends and best practices in the field.", new Guid("47d28c7b-a4fc-4617-bbbd-60b05a0bfd45") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
