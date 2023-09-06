using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoynerCase.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "kategori",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    kategori_ismi = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__kategori__3213E83F26F1F3DB", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "urun",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    urun_ismi = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    aciklama = table.Column<string>(type: "text", nullable: true),
                    kategori_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__urun__3213E83FF311EAC3", x => x.id);
                    table.ForeignKey(
                        name: "FK__urun__kategori_i__38996AB5",
                        column: x => x.kategori_id,
                        principalTable: "kategori",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_urun_kategori_id",
                table: "urun",
                column: "kategori_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "urun");

            migrationBuilder.DropTable(
                name: "kategori");
        }
    }
}
