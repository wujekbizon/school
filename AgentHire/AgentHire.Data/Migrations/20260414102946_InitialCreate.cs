using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgentHire.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Inquiry",
                columns: table => new
                {
                    IdInquiry = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SenderName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Message = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    SubmittedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inquiry", x => x.IdInquiry);
                });

            migrationBuilder.CreateTable(
                name: "NewsItem",
                columns: table => new
                {
                    IdNewsItem = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LinkTitle = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Position = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsItem", x => x.IdNewsItem);
                });

            migrationBuilder.CreateTable(
                name: "Page",
                columns: table => new
                {
                    IdPage = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NavTitle = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Position = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Page", x => x.IdPage);
                });

            migrationBuilder.CreateTable(
                name: "ProjectCategory",
                columns: table => new
                {
                    IdProjectCategory = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(MAX)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectCategory", x => x.IdProjectCategory);
                });

            migrationBuilder.CreateTable(
                name: "Specialization",
                columns: table => new
                {
                    IdSpecialization = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(MAX)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialization", x => x.IdSpecialization);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    IdProject = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Budget = table.Column<decimal>(type: "money", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    PostedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdProjectCategory = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.IdProject);
                    table.ForeignKey(
                        name: "FK_Project_ProjectCategory_IdProjectCategory",
                        column: x => x.IdProjectCategory,
                        principalTable: "ProjectCategory",
                        principalColumn: "IdProjectCategory",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Agent",
                columns: table => new
                {
                    IdAgent = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Bio = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    HourlyRate = table.Column<decimal>(type: "money", nullable: false),
                    AvatarUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsHighlighted = table.Column<bool>(type: "bit", nullable: false),
                    IdSpecialization = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agent", x => x.IdAgent);
                    table.ForeignKey(
                        name: "FK_Agent_Specialization_IdSpecialization",
                        column: x => x.IdSpecialization,
                        principalTable: "Specialization",
                        principalColumn: "IdSpecialization",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PortfolioItem",
                columns: table => new
                {
                    IdPortfolioItem = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    ProjectUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdAgent = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortfolioItem", x => x.IdPortfolioItem);
                    table.ForeignKey(
                        name: "FK_PortfolioItem_Agent_IdAgent",
                        column: x => x.IdAgent,
                        principalTable: "Agent",
                        principalColumn: "IdAgent",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agent_IdSpecialization",
                table: "Agent",
                column: "IdSpecialization");

            migrationBuilder.CreateIndex(
                name: "IX_PortfolioItem_IdAgent",
                table: "PortfolioItem",
                column: "IdAgent");

            migrationBuilder.CreateIndex(
                name: "IX_Project_IdProjectCategory",
                table: "Project",
                column: "IdProjectCategory");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inquiry");

            migrationBuilder.DropTable(
                name: "NewsItem");

            migrationBuilder.DropTable(
                name: "Page");

            migrationBuilder.DropTable(
                name: "PortfolioItem");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "Agent");

            migrationBuilder.DropTable(
                name: "ProjectCategory");

            migrationBuilder.DropTable(
                name: "Specialization");
        }
    }
}
