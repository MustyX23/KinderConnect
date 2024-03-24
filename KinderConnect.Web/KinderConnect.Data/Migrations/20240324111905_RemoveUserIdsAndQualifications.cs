using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KinderConnect.Data.Migrations
{
    public partial class RemoveUserIdsAndQualifications : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Children_Classrooms_ClassroomId",
                table: "Children");

            migrationBuilder.DeleteData(
                table: "Qualifications",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Qualifications",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Qualifications",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "UserId",
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

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Teachers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "ClassroomId",
                table: "Children",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Children",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "Qualifications",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 1, "A bachelor's degree in early childhood education prepares teachers with comprehensive knowledge and skills in child development, curriculum design, assessment, and family engagement. This qualification enables educators to implement evidence-based practices and support children's holistic development.", "Bachelor's Degree in Early Childhood Education" });

            migrationBuilder.InsertData(
                table: "Qualifications",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 2, "This qualification equips teachers with essential knowledge and skills to effectively engage and educate young children in a kindergarten setting. It covers topics such as child development, curriculum planning, and fostering a nurturing learning environment.", "Early Childhood Education Certificate" });

            migrationBuilder.InsertData(
                table: "Qualifications",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 3, "The CDA credential is a nationally recognized certification for early childhood professionals. It emphasizes the importance of nurturing children's physical, social, emotional, and cognitive development. Teachers with a CDA credential demonstrate competence in providing high-quality care and education to young children.", "Child Development Associate (CDA) Credential" });

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
