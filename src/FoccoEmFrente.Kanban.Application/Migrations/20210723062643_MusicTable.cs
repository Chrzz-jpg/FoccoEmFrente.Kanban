using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FoccoEmFrente.Kanban.Application.Migrations
{
    public partial class MusicTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Musics",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Tittle = table.Column<string>(nullable: true),
                    Style = table.Column<string>(nullable: true),
                    HumorPrincipal = table.Column<string>(nullable: true),
                    HumorSecundary = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Musics", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Musics");
        }
    }
}
