using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LogicaAccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class CargaDatos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Amenazas",
                columns: new[] { "Id", "Descripcion", "GradoPeligrosidad" },
                values: new object[,]
                {
                    { 1, "Caza furtiva", 8 },
                    { 2, "Deforestación", 7 }
                });

            migrationBuilder.InsertData(
                table: "EstadosConservacion",
                columns: new[] { "Id", "Nombre", "RangoSeguridadMaximo", "RangoSeguridadMinimo" },
                values: new object[,]
                {
                    { 1, "En peligro", 3, 1 },
                    { 2, "Vulnerable", 7, 4 }
                });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "Id", "CodigoAlpha3", "Nombre" },
                values: new object[,]
                {
                    { 1, "ARG", "Argentina" },
                    { 2, "BRA", "Brasil" }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Alias", "ContraseniaEncriptada", "ContraseniaSinEncriptar", "FechaIngreso", "TipoUsuario" },
                values: new object[,]
                {
                    { 1, "AdminUser", "SomeEncryptedPassword", "UserPasswordPlainText", new DateTime(2023, 10, 13, 11, 1, 43, 957, DateTimeKind.Local).AddTicks(2687), "Admin" },
                    { 2, "GeneralUser", "AnotherEncryptedPassword", "UserPasswordPlainText", new DateTime(2023, 10, 13, 11, 1, 43, 957, DateTimeKind.Local).AddTicks(2725), "Autorizado" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Amenazas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Amenazas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "EstadosConservacion",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "EstadosConservacion",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Paises",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
