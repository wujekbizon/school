using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgentHire.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddSiteConfig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SiteConfig",
                columns: table => new
                {
                    IdSiteConfig = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiteConfig", x => x.IdSiteConfig);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SiteConfig");
        }
    }
}
