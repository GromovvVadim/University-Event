using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace University_Event.Persistence.Migrations
{
    public partial class ThirdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "Email", "Password" },
                values: new object[] { "admin@gmail.com", "admin" });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Date", "LongTitle", "NumberOfPeople", "ShortTitle" },
                values: new object[] { 1, new DateTime(2020, 6, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Профспілка студентів орзанізовує шаховий турнір між студентами. Запрошуємо усіх бажаючих.", 24, "Шаховий турнір." });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "ID", "FirstName", "LastName", "MiddleName", "Password" },
                values: new object[,]
                {
                    { "123456c", "Вадим", "Громов", "Глібович", "123456c" },
                    { "123457c", "Данило", "Тимець", "Ігорович", "123457c" }
                });

            migrationBuilder.InsertData(
                table: "EventStudents",
                columns: new[] { "Id", "EventId", "StudentId" },
                values: new object[] { 1, 1, "123456c" });

            migrationBuilder.InsertData(
                table: "EventStudents",
                columns: new[] { "Id", "EventId", "StudentId" },
                values: new object[] { 2, 1, "123457c" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Admins",
                keyColumn: "Email",
                keyValue: "admin@gmail.com");

            migrationBuilder.DeleteData(
                table: "EventStudents",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "EventStudents",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "ID",
                keyValue: "123456c");

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "ID",
                keyValue: "123457c");
        }
    }
}
