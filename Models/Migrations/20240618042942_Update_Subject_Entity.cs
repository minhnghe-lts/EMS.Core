using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS.Core.Models.Migrations
{
    /// <inheritdoc />
    public partial class Update_Subject_Entity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CodeName",
                table: "Subjects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TotalExercise",
                table: "Subjects",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CodeName",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "TotalExercise",
                table: "Subjects");
        }
    }
}
