using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmesApi.Migrations
{
    public partial class AddSessaorenomeado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_sessoes_Cinemas_CinemaId",
                table: "sessoes");

            migrationBuilder.DropForeignKey(
                name: "FK_sessoes_Filmes_FilmeId",
                table: "sessoes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_sessoes",
                table: "sessoes");

            migrationBuilder.RenameTable(
                name: "sessoes",
                newName: "Sessoes");

            migrationBuilder.RenameIndex(
                name: "IX_sessoes_FilmeId",
                table: "Sessoes",
                newName: "IX_Sessoes_FilmeId");

            migrationBuilder.RenameIndex(
                name: "IX_sessoes_CinemaId",
                table: "Sessoes",
                newName: "IX_Sessoes_CinemaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sessoes",
                table: "Sessoes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sessoes_Cinemas_CinemaId",
                table: "Sessoes",
                column: "CinemaId",
                principalTable: "Cinemas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sessoes_Filmes_FilmeId",
                table: "Sessoes",
                column: "FilmeId",
                principalTable: "Filmes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sessoes_Cinemas_CinemaId",
                table: "Sessoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Sessoes_Filmes_FilmeId",
                table: "Sessoes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sessoes",
                table: "Sessoes");

            migrationBuilder.RenameTable(
                name: "Sessoes",
                newName: "sessoes");

            migrationBuilder.RenameIndex(
                name: "IX_Sessoes_FilmeId",
                table: "sessoes",
                newName: "IX_sessoes_FilmeId");

            migrationBuilder.RenameIndex(
                name: "IX_Sessoes_CinemaId",
                table: "sessoes",
                newName: "IX_sessoes_CinemaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_sessoes",
                table: "sessoes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_sessoes_Cinemas_CinemaId",
                table: "sessoes",
                column: "CinemaId",
                principalTable: "Cinemas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_sessoes_Filmes_FilmeId",
                table: "sessoes",
                column: "FilmeId",
                principalTable: "Filmes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
