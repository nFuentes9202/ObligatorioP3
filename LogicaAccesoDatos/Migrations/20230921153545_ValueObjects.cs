using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogicaAccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class ValueObjects : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Amenazas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GradoPeligrosidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Amenazas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EstadosConservacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RangoSeguridadMinimo = table.Column<int>(type: "int", nullable: false),
                    RangoSeguridadMaximo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadosConservacion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Paises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoAlpha3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paises", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ecosistemas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AreaMetrosCuadrados = table.Column<double>(type: "float", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Coordenadas_Latitud = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Coordenadas_Longitud = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EstadoConservacionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ecosistemas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ecosistemas_EstadosConservacion_EstadoConservacionId",
                        column: x => x.EstadoConservacionId,
                        principalTable: "EstadosConservacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Especies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstadoConservacionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Especies_EstadosConservacion_EstadoConservacionId",
                        column: x => x.EstadoConservacionId,
                        principalTable: "EstadosConservacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AmenazaEcosistema",
                columns: table => new
                {
                    AmenazasId = table.Column<int>(type: "int", nullable: false),
                    EcosistemasId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AmenazaEcosistema", x => new { x.AmenazasId, x.EcosistemasId });
                    table.ForeignKey(
                        name: "FK_AmenazaEcosistema_Amenazas_AmenazasId",
                        column: x => x.AmenazasId,
                        principalTable: "Amenazas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AmenazaEcosistema_Ecosistemas_EcosistemasId",
                        column: x => x.EcosistemasId,
                        principalTable: "Ecosistemas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EcosistemaPais",
                columns: table => new
                {
                    EcosistemasId = table.Column<int>(type: "int", nullable: false),
                    PaisesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EcosistemaPais", x => new { x.EcosistemasId, x.PaisesId });
                    table.ForeignKey(
                        name: "FK_EcosistemaPais_Ecosistemas_EcosistemasId",
                        column: x => x.EcosistemasId,
                        principalTable: "Ecosistemas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EcosistemaPais_Paises_PaisesId",
                        column: x => x.PaisesId,
                        principalTable: "Paises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AmenazaEspecie",
                columns: table => new
                {
                    AmenazasId = table.Column<int>(type: "int", nullable: false),
                    EspeciesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AmenazaEspecie", x => new { x.AmenazasId, x.EspeciesId });
                    table.ForeignKey(
                        name: "FK_AmenazaEspecie_Amenazas_AmenazasId",
                        column: x => x.AmenazasId,
                        principalTable: "Amenazas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AmenazaEspecie_Especies_EspeciesId",
                        column: x => x.EspeciesId,
                        principalTable: "Especies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EcosistemaEspecie",
                columns: table => new
                {
                    EcosistemasId = table.Column<int>(type: "int", nullable: false),
                    EspeciesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EcosistemaEspecie", x => new { x.EcosistemasId, x.EspeciesId });
                    table.ForeignKey(
                        name: "FK_EcosistemaEspecie_Ecosistemas_EcosistemasId",
                        column: x => x.EcosistemasId,
                        principalTable: "Ecosistemas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EcosistemaEspecie_Especies_EspeciesId",
                        column: x => x.EspeciesId,
                        principalTable: "Especies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AmenazaEcosistema_EcosistemasId",
                table: "AmenazaEcosistema",
                column: "EcosistemasId");

            migrationBuilder.CreateIndex(
                name: "IX_AmenazaEspecie_EspeciesId",
                table: "AmenazaEspecie",
                column: "EspeciesId");

            migrationBuilder.CreateIndex(
                name: "IX_EcosistemaEspecie_EspeciesId",
                table: "EcosistemaEspecie",
                column: "EspeciesId");

            migrationBuilder.CreateIndex(
                name: "IX_EcosistemaPais_PaisesId",
                table: "EcosistemaPais",
                column: "PaisesId");

            migrationBuilder.CreateIndex(
                name: "IX_Ecosistemas_EstadoConservacionId",
                table: "Ecosistemas",
                column: "EstadoConservacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Especies_EstadoConservacionId",
                table: "Especies",
                column: "EstadoConservacionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AmenazaEcosistema");

            migrationBuilder.DropTable(
                name: "AmenazaEspecie");

            migrationBuilder.DropTable(
                name: "EcosistemaEspecie");

            migrationBuilder.DropTable(
                name: "EcosistemaPais");

            migrationBuilder.DropTable(
                name: "Amenazas");

            migrationBuilder.DropTable(
                name: "Especies");

            migrationBuilder.DropTable(
                name: "Ecosistemas");

            migrationBuilder.DropTable(
                name: "Paises");

            migrationBuilder.DropTable(
                name: "EstadosConservacion");
        }
    }
}
