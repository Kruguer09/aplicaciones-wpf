using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IGraficasIES.Migrations
{
    /// <inheritdoc />
    public partial class _1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OtrosDatosProfesores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoEstado = table.Column<long>(type: "bigint", nullable: false),
                    SEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IPeso = table.Column<int>(type: "int", nullable: false),
                    IEstatura = table.Column<int>(type: "int", nullable: false),
                    ProfesorFuncionarioId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtrosDatosProfesores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Profesores",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IAnyoIngresoCuerpo = table.Column<int>(type: "int", nullable: false),
                    BDestinoDefinitivo = table.Column<bool>(type: "bit", nullable: false),
                    TipoSeguro = table.Column<long>(type: "bigint", nullable: false),
                    SNombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SRutaFoto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SApellidos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IEdad = table.Column<int>(type: "int", nullable: false),
                    SMateria = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoProfesor = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profesores", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OtrosDatosProfesores");

            migrationBuilder.DropTable(
                name: "Profesores");
        }
    }
}
