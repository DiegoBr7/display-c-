using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fiap.Api.Alunos.Migrations
{
    /// <inheritdoc />
    public partial class AddAcidentes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Acidente",
                columns: table => new
                {
                    AcidenteId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Localizacao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Gravidade = table.Column<string>(type: "NVARCHAR2(450)", nullable: true),
                    DataHora = table.Column<DateTime>(type: "DATE", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acidente", x => x.AcidenteId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Acidente_Id",
                table: "Acidente",
                column: "AcidenteId",
                unique: true,
                filter: "\"AcidenteId\" IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Acidente");
        }
    }
}
