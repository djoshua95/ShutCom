using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShutCom.Model.Migrations
{
    /// <inheritdoc />
    public partial class Secondmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductAttachments",
                table: "ProductAttachments");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ProductAttachments",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductAttachments",
                table: "ProductAttachments",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ProductAttachments_ProductId",
                table: "ProductAttachments",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductAttachments",
                table: "ProductAttachments");

            migrationBuilder.DropIndex(
                name: "IX_ProductAttachments_ProductId",
                table: "ProductAttachments");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ProductAttachments");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductAttachments",
                table: "ProductAttachments",
                columns: new[] { "ProductId", "AttachmentId" });
        }
    }
}
