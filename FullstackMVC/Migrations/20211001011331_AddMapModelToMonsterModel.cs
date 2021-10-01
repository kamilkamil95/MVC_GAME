using Microsoft.EntityFrameworkCore.Migrations;

namespace FullstackMVC.Migrations
{
    public partial class AddMapModelToMonsterModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MapModelId",
                table: "MonsterModel",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MonsterModel_MapModelId",
                table: "MonsterModel",
                column: "MapModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_MonsterModel_MapModel_MapModelId",
                table: "MonsterModel",
                column: "MapModelId",
                principalTable: "MapModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MonsterModel_MapModel_MapModelId",
                table: "MonsterModel");

            migrationBuilder.DropIndex(
                name: "IX_MonsterModel_MapModelId",
                table: "MonsterModel");

            migrationBuilder.DropColumn(
                name: "MapModelId",
                table: "MonsterModel");
        }
    }
}
