using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolMenagmentSystem.Server.Migrations
{
    /// <inheritdoc />
    public partial class addenum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Schools",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Schools");
        }
    }
}
