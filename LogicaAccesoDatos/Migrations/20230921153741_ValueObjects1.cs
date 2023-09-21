using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogicaAccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class ValueObjects1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "AtributosFisicos_RangoLongitudCm",
                table: "Especies",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "AtributosFisicos_RangoPesoKg",
                table: "Especies",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Imagen_Descripcion",
                table: "Especies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Imagen_Nombre",
                table: "Especies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nombre_NombreCientifico",
                table: "Especies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nombre_NombreVulgar",
                table: "Especies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Imagen_Descripcion",
                table: "Ecosistemas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Imagen_Nombre",
                table: "Ecosistemas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AtributosFisicos_RangoLongitudCm",
                table: "Especies");

            migrationBuilder.DropColumn(
                name: "AtributosFisicos_RangoPesoKg",
                table: "Especies");

            migrationBuilder.DropColumn(
                name: "Imagen_Descripcion",
                table: "Especies");

            migrationBuilder.DropColumn(
                name: "Imagen_Nombre",
                table: "Especies");

            migrationBuilder.DropColumn(
                name: "Nombre_NombreCientifico",
                table: "Especies");

            migrationBuilder.DropColumn(
                name: "Nombre_NombreVulgar",
                table: "Especies");

            migrationBuilder.DropColumn(
                name: "Imagen_Descripcion",
                table: "Ecosistemas");

            migrationBuilder.DropColumn(
                name: "Imagen_Nombre",
                table: "Ecosistemas");
        }
    }
}
