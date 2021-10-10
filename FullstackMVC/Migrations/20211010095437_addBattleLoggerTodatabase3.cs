using Microsoft.EntityFrameworkCore.Migrations;

namespace FullstackMVC.Migrations
{
    public partial class addBattleLoggerTodatabase3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FightId",
                table: "BattleLogger",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FightId",
                table: "BattleLogger");
        }
    }
}
