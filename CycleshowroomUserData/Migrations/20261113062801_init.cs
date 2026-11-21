using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CycleshowroomUserData.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cycles",
                columns: table => new
                {
                    CId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CName = table.Column<string>(type: "TEXT", nullable: false),
                    CType = table.Column<int>(type: "INTEGER", nullable: false),
                    CPrice = table.Column<int>(type: "INTEGER", nullable: false),
                    CCount = table.Column<int>(type: "INTEGER", nullable: false),
                    CBrand = table.Column<string>(type: "TEXT", nullable: false),
                    CFileImage = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cycles", x => x.CId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    Role = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "showroomCycles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    CId = table.Column<int>(type: "INTEGER", nullable: false),
                    CName = table.Column<string>(type: "TEXT", nullable: false),
                    CType = table.Column<int>(type: "INTEGER", nullable: false),
                    CPrice = table.Column<int>(type: "INTEGER", nullable: false),
                    CCount = table.Column<int>(type: "INTEGER", nullable: false),
                    CBrand = table.Column<string>(type: "TEXT", nullable: false),
                    CFileImage = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_showroomCycles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_showroomCycles_cycles_Id",
                        column: x => x.Id,
                        principalTable: "cycles",
                        principalColumn: "CId",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "showroomCycles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "cycles");
        }
    }
}
