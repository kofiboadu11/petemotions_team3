using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetEmotionsApp.Migrations
{
    /// <inheritdoc />
    public partial class FileUploaderData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FileUpload",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FileContent = table.Column<byte[]>(type: "BLOB", nullable: false),
                    fileDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    emotion = table.Column<string>(type: "TEXT", nullable: false),
                    type = table.Column<string>(type: "TEXT", nullable: false),
                    name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileUpload", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FileUpload");
        }
    }
}
