using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Sample.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Add_Client_Seeds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "ClientId", "CreatedBy", "CreatedDate", "CurrencyType", "IsStateRegistrationFree", "Language", "LastModifiedBy", "LastModifiedDate", "LogoURL", "Name", "Origin", "ParentClientId", "RegisteredNumber", "StateRegistration", "TimeZone", "TradeName", "Type" },
                values: new object[,]
                {
                    { 1, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "REAL", false, "BR", null, null, "LogoURL", "Grupo AAAA", "Origem", null, "000", "00000", "Brasilia", "Grupo AAAA", "Grupo" },
                    { 6, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "REAL", false, "BR", null, null, "LogoURL", "Grupo BBBB", "Origem", null, "000", "00000", "Brasilia", "Grupo BBBB", "Grupo" },
                    { 11, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "REAL", false, "BR", null, null, "LogoURL", "Grupo CCCC", "Origem", null, "000", "00000", "Brasilia", "Grupo CCCC", "Grupo" },
                    { 16, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "REAL", false, "BR", null, null, "LogoURL", "Grupo DDDD", "Origem", null, "000", "00000", "Brasilia", "Grupo DDDD", "Grupo" },
                    { 21, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "REAL", false, "BR", null, null, "LogoURL", "Grupo EEEE", "Origem", null, "000", "00000", "Brasilia", "Grupo EEEE", "Grupo" },
                    { 26, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "REAL", false, "BR", null, null, "LogoURL", "Rede AAA", "Origem", null, "000", "00000", "Brasilia", "Rede AAA", "Rede" },
                    { 30, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "REAL", false, "BR", null, null, "LogoURL", "Rede BBB", "Origem", null, "000", "00000", "Brasilia", "Rede BBB", "Rede" },
                    { 34, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "REAL", false, "BR", null, null, "LogoURL", "Parceiro  AA", "Origem", null, "000", "00000", "Brasilia", "Parceiro  AA", "Parceiro" },
                    { 37, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "REAL", false, "BR", null, null, "LogoURL", "Parceiro  BB", "Origem", null, "000", "00000", "Brasilia", "Parceiro  BB", "Parceiro" },
                    { 40, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "REAL", false, "BR", null, null, "LogoURL", "Hotel  A1", "Origem", null, "000", "00000", "Brasilia", "Hotel  A1", "Hotel" },
                    { 41, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "REAL", false, "BR", null, null, "LogoURL", "Hotel  B1", "Origem", null, "000", "00000", "Brasilia", "Hotel  B1", "Hotel" },
                    { 2, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "REAL", false, "BR", null, null, "LogoURL", "Rede AAAA", "Origem", 1, "000", "00000", "Brasilia", "Rede AAAA", "Rede" },
                    { 7, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "REAL", false, "BR", null, null, "LogoURL", "Rede BBBB", "Origem", 6, "000", "00000", "Brasilia", "Rede BBBB", "Rede" },
                    { 12, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "REAL", false, "BR", null, null, "LogoURL", "Rede CCCC", "Origem", 11, "000", "00000", "Brasilia", "Rede CCCC", "Rede" },
                    { 17, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "REAL", false, "BR", null, null, "LogoURL", "Rede DDDD", "Origem", 16, "000", "00000", "Brasilia", "Rede DDDD", "Rede" },
                    { 22, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "REAL", false, "BR", null, null, "LogoURL", "Rede EEEE", "Origem", 21, "000", "00000", "Brasilia", "Rede EEEE", "Rede" },
                    { 27, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "REAL", false, "BR", null, null, "LogoURL", "Parceiro  AAA", "Origem", 26, "000", "00000", "Brasilia", "Parceiro  AAA", "Parceiro" },
                    { 31, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "REAL", false, "BR", null, null, "LogoURL", "Parceiro  BBB", "Origem", 30, "000", "00000", "Brasilia", "Parceiro  BBB", "Parceiro" },
                    { 35, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "REAL", false, "BR", null, null, "LogoURL", "Hotel  AA1", "Origem", 34, "000", "00000", "Brasilia", "Hotel  AA1", "Hotel" },
                    { 36, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "REAL", false, "BR", null, null, "LogoURL", "Hotel  AA1", "Origem", 34, "000", "00000", "Brasilia", "Hotel  AA1", "Hotel" },
                    { 38, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "REAL", false, "BR", null, null, "LogoURL", "Hotel  BB1", "Origem", 37, "000", "00000", "Brasilia", "Hotel  BB1", "Hotel" },
                    { 39, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "REAL", false, "BR", null, null, "LogoURL", "Hotel  BB1", "Origem", 37, "000", "00000", "Brasilia", "Hotel  BB1", "Hotel" },
                    { 42, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "REAL", false, "BR", null, null, "LogoURL", "Rede AAAB", "Origem", 1, "000", "00000", "Brasilia", "Rede AAAB", "Rede" },
                    { 47, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "REAL", false, "BR", null, null, "LogoURL", "Parceiro  BBBC", "Origem", 6, "000", "00000", "Brasilia", "Parceiro  BBBC", "Parceiro" },
                    { 53, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "REAL", false, "BR", null, null, "LogoURL", "Hotel  DDDE1", "Origem", 16, "000", "00000", "Brasilia", "Hotel  DDDE1", "Hotel" },
                    { 54, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "REAL", false, "BR", null, null, "LogoURL", "Hotel  DDDE1", "Origem", 16, "000", "00000", "Brasilia", "Hotel  DDDE1", "Hotel" },
                    { 3, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "REAL", false, "BR", null, null, "LogoURL", "Parceiro  AAAA", "Origem", 2, "000", "00000", "Brasilia", "Parceiro  AAAA", "Parceiro" },
                    { 8, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "REAL", false, "BR", null, null, "LogoURL", "Parceiro  BBBB", "Origem", 7, "000", "00000", "Brasilia", "Parceiro  BBBB", "Parceiro" },
                    { 13, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "REAL", false, "BR", null, null, "LogoURL", "Parceiro  CCCC", "Origem", 12, "000", "00000", "Brasilia", "Parceiro  CCCC", "Parceiro" },
                    { 18, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "REAL", false, "BR", null, null, "LogoURL", "Parceiro  DDDD", "Origem", 17, "000", "00000", "Brasilia", "Parceiro  DDDD", "Parceiro" },
                    { 23, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "REAL", false, "BR", null, null, "LogoURL", "Parceiro  EEEE", "Origem", 22, "000", "00000", "Brasilia", "Parceiro  EEEE", "Parceiro" },
                    { 28, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "REAL", false, "BR", null, null, "LogoURL", "Hotel  AAA1", "Origem", 27, "000", "00000", "Brasilia", "Hotel  AAA1", "Hotel" },
                    { 29, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "REAL", false, "BR", null, null, "LogoURL", "Hotel  AAA1", "Origem", 27, "000", "00000", "Brasilia", "Hotel  AAA1", "Hotel" },
                    { 32, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "REAL", false, "BR", null, null, "LogoURL", "Hotel  BBB1", "Origem", 31, "000", "00000", "Brasilia", "Hotel  BBB1", "Hotel" },
                    { 33, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "REAL", false, "BR", null, null, "LogoURL", "Hotel  BBB1", "Origem", 31, "000", "00000", "Brasilia", "Hotel  BBB1", "Hotel" },
                    { 43, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "REAL", false, "BR", null, null, "LogoURL", "Parceiro  AAAB", "Origem", 42, "000", "00000", "Brasilia", "Parceiro  AAAB", "Parceiro" },
                    { 48, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "REAL", false, "BR", null, null, "LogoURL", "Hotel  BBBC1", "Origem", 47, "000", "00000", "Brasilia", "Hotel  BBBC1", "Hotel" },
                    { 49, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "REAL", false, "BR", null, null, "LogoURL", "Hotel  BBBC1", "Origem", 47, "000", "00000", "Brasilia", "Hotel  BBBC1", "Hotel" },
                    { 50, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "REAL", false, "BR", null, null, "LogoURL", "Parceiro  CCCD", "Origem", 12, "000", "00000", "Brasilia", "Parceiro  CCCD", "Parceiro" },
                    { 4, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "REAL", false, "BR", null, null, "LogoURL", "Hotel  AAAA1", "Origem", 3, "000", "00000", "Brasilia", "Hotel  AAAA1", "Hotel" },
                    { 5, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "REAL", false, "BR", null, null, "LogoURL", "Hotel  AAAA1", "Origem", 3, "000", "00000", "Brasilia", "Hotel  AAAA1", "Hotel" },
                    { 9, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "REAL", false, "BR", null, null, "LogoURL", "Hotel  BBBB1", "Origem", 8, "000", "00000", "Brasilia", "Hotel  BBBB1", "Hotel" },
                    { 10, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "REAL", false, "BR", null, null, "LogoURL", "Hotel  BBBB1", "Origem", 8, "000", "00000", "Brasilia", "Hotel  BBBB1", "Hotel" },
                    { 14, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "REAL", false, "BR", null, null, "LogoURL", "Hotel  CCCC1", "Origem", 13, "000", "00000", "Brasilia", "Hotel  CCCC1", "Hotel" },
                    { 15, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "REAL", false, "BR", null, null, "LogoURL", "Hotel  CCCC1", "Origem", 13, "000", "00000", "Brasilia", "Hotel  CCCC1", "Hotel" },
                    { 19, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "REAL", false, "BR", null, null, "LogoURL", "Hotel  DDDD1", "Origem", 18, "000", "00000", "Brasilia", "Hotel  DDDD1", "Hotel" },
                    { 20, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "REAL", false, "BR", null, null, "LogoURL", "Hotel  DDDD1", "Origem", 18, "000", "00000", "Brasilia", "Hotel  DDDD1", "Hotel" },
                    { 24, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "REAL", false, "BR", null, null, "LogoURL", "Hotel  EEEE1", "Origem", 23, "000", "00000", "Brasilia", "Hotel  EEEE1", "Hotel" },
                    { 25, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "REAL", false, "BR", null, null, "LogoURL", "Hotel  EEEE1", "Origem", 23, "000", "00000", "Brasilia", "Hotel  EEEE1", "Hotel" },
                    { 44, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "REAL", false, "BR", null, null, "LogoURL", "Hotel  AAAB", "Origem", 43, "000", "00000", "Brasilia", "Hotel  AAAB", "Hotel" },
                    { 45, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "REAL", false, "BR", null, null, "LogoURL", "Hotel  AAAB", "Origem", 43, "000", "00000", "Brasilia", "Hotel  AAAB", "Hotel" },
                    { 51, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "REAL", false, "BR", null, null, "LogoURL", "Hotel  CCCD1", "Origem", 50, "000", "00000", "Brasilia", "Hotel  CCCD1", "Hotel" },
                    { 52, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "REAL", false, "BR", null, null, "LogoURL", "Hotel  CCCD1", "Origem", 50, "000", "00000", "Brasilia", "Hotel  CCCD1", "Hotel" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: 21);
        }
    }
}
