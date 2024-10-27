using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace gymlogger.Migrations
{
    /// <inheritdoc />
    public partial class UpdateExercise : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Muscles",
                table: "Exercises",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Muscles",
                table: "Exercises");
        }
    }
}
