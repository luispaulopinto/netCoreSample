using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sample.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddRelationToContactAndDeptTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Contact_DepartmentId",
                table: "Contact",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contact_Department_DepartmentId",
                table: "Contact",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contact_Department_DepartmentId",
                table: "Contact");

            migrationBuilder.DropIndex(
                name: "IX_Contact_DepartmentId",
                table: "Contact");
        }
    }
}
