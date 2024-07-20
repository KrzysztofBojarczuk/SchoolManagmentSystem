using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolMenagmentSystem.Server.Migrations
{
    /// <inheritdoc />
    public partial class FixSchool : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SchoodId",
                table: "Schools",
                newName: "SchoolId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SchoolId",
                table: "Schools",
                newName: "SchoodId");
        }
    }
}
