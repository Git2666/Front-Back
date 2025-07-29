using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Server.Book.Infrastructure.EF.Oracle.Migrations
{
    /// <inheritdoc />
    public partial class FirstModify : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "FILE_SIZE",
                table: "BOOKS",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "NUMBER(19)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "FILE_SIZE",
                table: "BOOKS",
                type: "NUMBER(19)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)");
        }
    }
}
