using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace gymlogger.Migrations
{
    /// <inheritdoc />
    public partial class userMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d6d02d52-f4b1-4d42-8890-c96d7aa45aae");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d77b1603-00da-4ed9-856e-45bacfcea450");

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "workoutsTemplates",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "WorkoutSessions",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "Sets",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "SetType",
                table: "Sets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "77ea3432-811f-4907-b17a-98860715e7de", null, "User", "USER" },
                    { "ab4260bf-77eb-4a99-a334-dbbaa7f3ad60", null, "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_workoutsTemplates_AppUserId",
                table: "workoutsTemplates",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutSessions_AppUserId",
                table: "WorkoutSessions",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Sets_AppUserId",
                table: "Sets",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sets_AspNetUsers_AppUserId",
                table: "Sets",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutSessions_AspNetUsers_AppUserId",
                table: "WorkoutSessions",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_workoutsTemplates_AspNetUsers_AppUserId",
                table: "workoutsTemplates",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sets_AspNetUsers_AppUserId",
                table: "Sets");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutSessions_AspNetUsers_AppUserId",
                table: "WorkoutSessions");

            migrationBuilder.DropForeignKey(
                name: "FK_workoutsTemplates_AspNetUsers_AppUserId",
                table: "workoutsTemplates");

            migrationBuilder.DropIndex(
                name: "IX_workoutsTemplates_AppUserId",
                table: "workoutsTemplates");

            migrationBuilder.DropIndex(
                name: "IX_WorkoutSessions_AppUserId",
                table: "WorkoutSessions");

            migrationBuilder.DropIndex(
                name: "IX_Sets_AppUserId",
                table: "Sets");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "77ea3432-811f-4907-b17a-98860715e7de");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ab4260bf-77eb-4a99-a334-dbbaa7f3ad60");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "workoutsTemplates");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "WorkoutSessions");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Sets");

            migrationBuilder.DropColumn(
                name: "SetType",
                table: "Sets");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "d6d02d52-f4b1-4d42-8890-c96d7aa45aae", null, "Admin", "ADMIN" },
                    { "d77b1603-00da-4ed9-856e-45bacfcea450", null, "User", "USER" }
                });
        }
    }
}
