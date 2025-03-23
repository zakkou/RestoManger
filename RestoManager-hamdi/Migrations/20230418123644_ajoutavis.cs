using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestoManager_hamdi.Migrations
{
    /// <inheritdoc />
    public partial class ajoutavis : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "admin");

            migrationBuilder.CreateTable(
                name: "TAvis",
                schema: "admin",
                columns: table => new
                {
                    CodeAvis = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomPersonne = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Note = table.Column<int>(type: "int", maxLength: 20, nullable: false),
                    Commentaire = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    NumResto = table.Column<int>(type: "int", nullable: false),
                    LeRestoCodeResto = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TAvis", x => x.CodeAvis);
                    table.ForeignKey(
                        name: "FK_TAvis_TRestaurant_LeRestoCodeResto",
                        column: x => x.LeRestoCodeResto,
                        principalSchema: "resto",
                        principalTable: "TRestaurant",
                        principalColumn: "CodeResto");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TAvis_LeRestoCodeResto",
                schema: "admin",
                table: "TAvis",
                column: "LeRestoCodeResto");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TAvis",
                schema: "admin");
        }
    }
}
