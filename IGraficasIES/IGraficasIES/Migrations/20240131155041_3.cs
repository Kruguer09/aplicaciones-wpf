using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IGraficasIES.Migrations
{
    /// <inheritdoc />
    public partial class _3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ProfesorFuncionarioId",
                table: "OtrosDatosProfesores",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_OtrosDatosProfesores_ProfesorFuncionarioId",
                table: "OtrosDatosProfesores",
                column: "ProfesorFuncionarioId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OtrosDatosProfesores_Profesores_ProfesorFuncionarioId",
                table: "OtrosDatosProfesores",
                column: "ProfesorFuncionarioId",
                principalTable: "Profesores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OtrosDatosProfesores_Profesores_ProfesorFuncionarioId",
                table: "OtrosDatosProfesores");

            migrationBuilder.DropIndex(
                name: "IX_OtrosDatosProfesores_ProfesorFuncionarioId",
                table: "OtrosDatosProfesores");

            migrationBuilder.AlterColumn<string>(
                name: "ProfesorFuncionarioId",
                table: "OtrosDatosProfesores",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
