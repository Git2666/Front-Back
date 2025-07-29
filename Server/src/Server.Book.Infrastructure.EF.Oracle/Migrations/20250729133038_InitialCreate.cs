using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Server.Book.Infrastructure.EF.Oracle.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BOOKS",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    FILE_NAME = table.Column<string>(type: "NVARCHAR2(256)", maxLength: 256, nullable: false),
                    FILE_PATH = table.Column<string>(type: "NVARCHAR2(1024)", maxLength: 1024, nullable: false),
                    FILE_TYPE = table.Column<string>(type: "NVARCHAR2(10)", maxLength: 10, nullable: false),
                    FILE_SIZE = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    CREATED_AT = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    UPDATED_AT = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BOOKS", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BOOKS");
        }
    }
}
