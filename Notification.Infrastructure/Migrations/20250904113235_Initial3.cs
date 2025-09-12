using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NotificationService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Templates",
                type: "timestamp(6) without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp(6) without time zone");

            migrationBuilder.AlterColumn<string>(
                name: "AuthtorUpdated",
                table: "Templates",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "Subject",
                table: "Templates",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Templates",
                columns: new[] { "Id", "AuthtorCreated", "AuthtorUpdated", "CreatedDate", "Description", "Enabled", "Name", "Subject", "Template", "Type", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("a65865e1-a1c0-42cf-b7fd-b7c9480f236a"), "Test", "", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Описание начльного шаблона", true, "Начальный шаблон", "Добро пожаловать!", "<html> \r\n                            <body>\r\n                            <h1>Добро пожаловать, {{UserName}} !</h1>\r\n                        <p>Ваш email: {{Email}}</p>\r\n                        <p>Дата регистрации: {{RegistrationDate}}</p>\r\n                        <p><a href='{{ActivationLink}}'>Активировать аккаунт</a></p>\r\n                    </body>\r\n                </html>", "Authorization", null },
                    { new Guid("b0669b35-8efc-4eb5-bf1c-702eae5e91ae"), "Test", "", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Описание начльного шаблона", true, "Начальный шаблон", "Добро пожаловать!", "<html> \r\n                            <body>\r\n                            <h1>Добро пожаловать, {{UserName}} !</h1>\r\n                        <p>Ваш email: {{Email}}</p>\r\n                        <p>Дата регистрации: {{RegistrationDate}}</p>\r\n                        <p><a href='{{ActivationLink}}'>Активировать аккаунт</a></p>\r\n                    </body>\r\n                </html>", "Authorization", null },
                    { new Guid("fd17ed09-6805-48dc-9f1f-ad89146979a9"), "Test", "", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Описание начльного шаблона", true, "Начальный шаблон", "Добро пожаловать!", "<html> \r\n                            <body>\r\n                            <h1>Добро пожаловать, {{UserName}} !</h1>\r\n                        <p>Ваш email: {{Email}}</p>\r\n                        <p>Дата регистрации: {{RegistrationDate}}</p>\r\n                        <p><a href='{{ActivationLink}}'>Активировать аккаунт</a></p>\r\n                    </body>\r\n                </html>", "Authorization", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Templates",
                keyColumn: "Id",
                keyValue: new Guid("a65865e1-a1c0-42cf-b7fd-b7c9480f236a"));

            migrationBuilder.DeleteData(
                table: "Templates",
                keyColumn: "Id",
                keyValue: new Guid("b0669b35-8efc-4eb5-bf1c-702eae5e91ae"));

            migrationBuilder.DeleteData(
                table: "Templates",
                keyColumn: "Id",
                keyValue: new Guid("fd17ed09-6805-48dc-9f1f-ad89146979a9"));

            migrationBuilder.DropColumn(
                name: "Subject",
                table: "Templates");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Templates",
                type: "timestamp(6) without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp(6) without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AuthtorUpdated",
                table: "Templates",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }
    }
}
