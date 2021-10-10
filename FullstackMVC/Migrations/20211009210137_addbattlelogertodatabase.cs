using Microsoft.EntityFrameworkCore.Migrations;

namespace FullstackMVC.Migrations
{
    public partial class addbattlelogertodatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BattleLogger_BattleViewModel_BattleViewModelId",
                table: "BattleLogger");

            migrationBuilder.DropIndex(
                name: "IX_BattleLogger_BattleViewModelId",
                table: "BattleLogger");

            migrationBuilder.DropColumn(
                name: "BattleViewModelId",
                table: "BattleLogger");

            migrationBuilder.AddColumn<int>(
                name: "BattleLoggerId",
                table: "BattleViewModel",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BattleViewModel_BattleLoggerId",
                table: "BattleViewModel",
                column: "BattleLoggerId");

            migrationBuilder.AddForeignKey(
                name: "FK_BattleViewModel_BattleLogger_BattleLoggerId",
                table: "BattleViewModel",
                column: "BattleLoggerId",
                principalTable: "BattleLogger",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BattleViewModel_BattleLogger_BattleLoggerId",
                table: "BattleViewModel");

            migrationBuilder.DropIndex(
                name: "IX_BattleViewModel_BattleLoggerId",
                table: "BattleViewModel");

            migrationBuilder.DropColumn(
                name: "BattleLoggerId",
                table: "BattleViewModel");

            migrationBuilder.AddColumn<int>(
                name: "BattleViewModelId",
                table: "BattleLogger",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BattleLogger_BattleViewModelId",
                table: "BattleLogger",
                column: "BattleViewModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_BattleLogger_BattleViewModel_BattleViewModelId",
                table: "BattleLogger",
                column: "BattleViewModelId",
                principalTable: "BattleViewModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
