using Microsoft.EntityFrameworkCore.Migrations;

namespace FullstackMVC.Migrations
{
    public partial class addBattleViewMOdelmonstertypeandmaptodatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Map",
                table: "BattleViewModel",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MonsterType",
                table: "BattleViewModel",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FightStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerHp = table.Column<int>(type: "int", nullable: false),
                    MonsterHp = table.Column<int>(type: "int", nullable: false),
                    BattleViewModelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FightStatus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FightStatus_BattleViewModel_BattleViewModelId",
                        column: x => x.BattleViewModelId,
                        principalTable: "BattleViewModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FightStatus_BattleViewModelId",
                table: "FightStatus",
                column: "BattleViewModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FightStatus");

            migrationBuilder.DropColumn(
                name: "Map",
                table: "BattleViewModel");

            migrationBuilder.DropColumn(
                name: "MonsterType",
                table: "BattleViewModel");
        }
    }
}
