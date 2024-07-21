using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolMenagmentSystem.Server.Migrations
{
    /// <inheritdoc />
    public partial class fix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NumberOfClasses",
                table: "Schools",
                newName: "NumberOfRooms");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NumberOfRooms",
                table: "Schools",
                newName: "NumberOfClasses");
        }
    }
}
