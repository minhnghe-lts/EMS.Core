using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS.Core.Models.Migrations
{
    /// <inheritdoc />
    public partial class Update_Course_And_Subject_Entity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CodeName",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CodeName",
                table: "Courses");
        }
    }
}
