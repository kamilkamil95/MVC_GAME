using Microsoft.EntityFrameworkCore.Migrations;

namespace FullstackMVC.Migrations
{
    public partial class addMonsterNameToBattleviewModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MonsterName",
                table: "BattleViewModel",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MonsterName",
                table: "BattleViewModel");
        }
    }
}
