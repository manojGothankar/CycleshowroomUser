using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CycleshowroomUserData.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_showroomCycles_cycles_Id",
                table: "showroomCycles");

            migrationBuilder.CreateIndex(
                name: "IX_showroomCycles_CId",
                table: "showroomCycles",
                column: "CId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_showroomCycles_cycles_CId",
                table: "showroomCycles",
                column: "CId",
                principalTable: "cycles",
                principalColumn: "CId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_showroomCycles_cycles_CId",
                table: "showroomCycles");

            migrationBuilder.DropIndex(
                name: "IX_showroomCycles_CId",
                table: "showroomCycles");

            migrationBuilder.AddForeignKey(
                name: "FK_showroomCycles_cycles_Id",
                table: "showroomCycles",
                column: "Id",
                principalTable: "cycles",
                principalColumn: "CId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
