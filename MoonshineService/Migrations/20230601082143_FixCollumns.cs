using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CraftBreadService.Migrations
{
    /// <inheritdoc />
    public partial class FixCollumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NecessaryProducts",
                table: "tblCraftBread",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NecessaryProducts",
                table: "tblCraftBread");
        }
    }
}
