using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleTarefas.Migrations
{
    public partial class AdicionandoStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StatusTarefa",
                table: "Tarefas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StatusTarefa",
                table: "Tarefas");
        }
    }
}
