using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AzarDataNetTestAPI.Migrations
{
    /// <inheritdoc />
    public partial class KeyValueEntiityV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Key",
                table: "KeyValuesEntity",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_KeyValuesEntity_Key",
                table: "KeyValuesEntity",
                column: "Key",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_KeyValuesEntity_Key",
                table: "KeyValuesEntity");

            migrationBuilder.AlterColumn<string>(
                name: "Key",
                table: "KeyValuesEntity",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
