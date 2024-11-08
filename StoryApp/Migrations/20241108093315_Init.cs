using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StoryApp.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stories",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublishedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    _isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    _createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    _lastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    _createdBy = table.Column<long>(type: "bigint", nullable: true),
                    _lastModifiedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    _isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    _createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    _lastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    _createdBy = table.Column<long>(type: "bigint", nullable: true),
                    _lastModifiedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Stories",
                columns: new[] { "Id", "Body", "_createdAt", "_createdBy", "_isDeleted", "_lastModifiedAt", "_lastModifiedBy", "PublishedDate", "Tile" },
                values: new object[,]
                {
                    { 2L, "Body Something 2", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, new DateTime(2024, 11, 9, 15, 33, 15, 216, DateTimeKind.Local).AddTicks(6809), "Title Something 2" },
                    { 3L, "Body Something 3", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, new DateTime(2024, 11, 10, 15, 33, 15, 216, DateTimeKind.Local).AddTicks(6816), "Title Something 3" },
                    { 4L, "Body Something 4", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, new DateTime(2024, 11, 11, 15, 33, 15, 216, DateTimeKind.Local).AddTicks(6818), "Title Something 4" },
                    { 5L, "Body Something 5", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, new DateTime(2024, 11, 13, 15, 33, 15, 216, DateTimeKind.Local).AddTicks(6819), "Title Something 5" },
                    { 10L, "Body Something 1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, new DateTime(2024, 11, 8, 15, 33, 15, 216, DateTimeKind.Local).AddTicks(6796), "Title Something 1" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "_createdAt", "_createdBy", "FirstName", "_isDeleted", "_lastModifiedAt", "_lastModifiedBy", "LastName", "Password", "Username", "isActive" },
                values: new object[] { 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "System", false, null, null, "", "System", "System", false });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stories");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
