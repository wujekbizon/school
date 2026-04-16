using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgentHire.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddPageSubtitle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Subtitle",
                table: "Page",
                type: "nvarchar(MAX)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Subtitle",
                table: "Page");
        }
    }
}
