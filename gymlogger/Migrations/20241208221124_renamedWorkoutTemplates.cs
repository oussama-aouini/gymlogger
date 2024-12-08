using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace gymlogger.Migrations
{
    /// <inheritdoc />
    public partial class renamedWorkoutTemplates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseRoutine_workoutsTemplates_RoutinesId",
                table: "ExerciseRoutine");

            migrationBuilder.DropForeignKey(
                name: "FK_workoutsTemplates_AspNetUsers_AppUserId",
                table: "workoutsTemplates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_workoutsTemplates",
                table: "workoutsTemplates");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0c89790e-67fb-417f-9b06-16764952b98b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ed1afd2f-55b0-4a6b-be3c-0b05bc024328");

            migrationBuilder.RenameTable(
                name: "workoutsTemplates",
                newName: "Routines");

            migrationBuilder.RenameIndex(
                name: "IX_workoutsTemplates_AppUserId",
                table: "Routines",
                newName: "IX_Routines_AppUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Routines",
                table: "Routines",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "37004a92-6a02-41b6-a3ef-9443b54a8121", null, "Admin", "ADMIN" },
                    { "cc2d2c84-8c9e-4e9b-84f8-5e0b1244aca8", null, "User", "USER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseRoutine_Routines_RoutinesId",
                table: "ExerciseRoutine",
                column: "RoutinesId",
                principalTable: "Routines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Routines_AspNetUsers_AppUserId",
                table: "Routines",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseRoutine_Routines_RoutinesId",
                table: "ExerciseRoutine");

            migrationBuilder.DropForeignKey(
                name: "FK_Routines_AspNetUsers_AppUserId",
                table: "Routines");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Routines",
                table: "Routines");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "37004a92-6a02-41b6-a3ef-9443b54a8121");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cc2d2c84-8c9e-4e9b-84f8-5e0b1244aca8");

            migrationBuilder.RenameTable(
                name: "Routines",
                newName: "workoutsTemplates");

            migrationBuilder.RenameIndex(
                name: "IX_Routines_AppUserId",
                table: "workoutsTemplates",
                newName: "IX_workoutsTemplates_AppUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_workoutsTemplates",
                table: "workoutsTemplates",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0c89790e-67fb-417f-9b06-16764952b98b", null, "User", "USER" },
                    { "ed1afd2f-55b0-4a6b-be3c-0b05bc024328", null, "Admin", "ADMIN" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseRoutine_workoutsTemplates_RoutinesId",
                table: "ExerciseRoutine",
                column: "RoutinesId",
                principalTable: "workoutsTemplates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_workoutsTemplates_AspNetUsers_AppUserId",
                table: "workoutsTemplates",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
