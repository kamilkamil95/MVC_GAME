using Microsoft.EntityFrameworkCore.Migrations;

namespace FullstackMVC.Migrations
{
    public partial class AddMonsterModelToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "MonsterType",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ApplicationType",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "MonsterModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hp = table.Column<int>(type: "int", nullable: false),
                    DmgMin = table.Column<int>(type: "int", nullable: false),
                    DmgMax = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MonsterModelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonsterModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MonsterModel_MonsterType_MonsterModelId",
                        column: x => x.MonsterModelId,
                        principalTable: "MonsterType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MonsterModel_MonsterModelId",
                table: "MonsterModel",
                column: "MonsterModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MonsterModel");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "MonsterType",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ApplicationType",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
