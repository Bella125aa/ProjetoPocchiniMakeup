using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoPocchiniMakeup.Repositorio.Migrations
{
    public partial class AjusteRelacionamentoUsuarioAgendamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Agendamento",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Agendamento_UsuarioId",
                table: "Agendamento",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Agendamento_Usuario_UsuarioId",
                table: "Agendamento",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendamento_Usuario_UsuarioId",
                table: "Agendamento");

            migrationBuilder.DropIndex(
                name: "IX_Agendamento_UsuarioId",
                table: "Agendamento");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Agendamento");
        }
    }
}
