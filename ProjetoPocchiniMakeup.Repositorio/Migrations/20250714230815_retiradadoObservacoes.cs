using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoPocchiniMakeup.Repositorio.Migrations
{
    public partial class retiradadoObservacoes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Observacoes",
                table: "Agendamento");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Observacoes",
                table: "Agendamento",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
