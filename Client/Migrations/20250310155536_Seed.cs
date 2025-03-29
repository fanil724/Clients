using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Client.Migrations
{
    /// <inheritdoc />
    public partial class Seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
              table: "clients",
              columns: ["id", "name", "age", "email"],
              values: new object[,]
              {
                    { 1, "Иван-Брутал", 23, "test@mail.ru" },
                    { 2, "Мария-Светлая", 29, "maria@mail.ru" },
                    { 3, "Алексей-Грозный", 34, "alex@mail.ru" },
                    { 4, "Ольга-Тихая", 27, "olga@mail.ru" },
                    { 5, "Дмитрий-Шторм", 31, "dmitry@mail.ru" },
                    { 6, "Екатерина-Луна", 25, "ekaterina@mail.ru" },
                    { 7, "Сергей-Вулкан", 40, "sergey@mail.ru" },
                    { 8, "Анна-Заря", 22, "anna@mail.ru" },
                    { 9, "Павел-Гром", 33, "pavel@mail.ru" },
                    { 10, "Татьяна-Радуга", 28, "tatyana@mail.ru" },
                    { 11, "Николай-Буран", 36, "nikolay@mail.ru" }
              }
          );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
               table: "clients",
               keyColumn: "id",
               keyValues: [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11]
           );
        }
    }
}
