using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace gymlogger.Migrations
{
    /// <inheritdoc />
    public partial class renamedTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sets_WorkoutSessions_WorkoutSessionId",
                table: "Sets");

            migrationBuilder.DropTable(
                name: "ExerciseWorkoutSession");

            migrationBuilder.DropTable(
                name: "WorkoutSessions");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "77ea3432-811f-4907-b17a-98860715e7de");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ab4260bf-77eb-4a99-a334-dbbaa7f3ad60");

            migrationBuilder.RenameColumn(
                name: "WorkoutSessionId",
                table: "Sets",
                newName: "SessionId");

            migrationBuilder.RenameIndex(
                name: "IX_Sets_WorkoutSessionId",
                table: "Sets",
                newName: "IX_Sets_SessionId");

            migrationBuilder.CreateTable(
                name: "Sessions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sessions_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExerciseSession",
                columns: table => new
                {
                    ExercisesId = table.Column<int>(type: "int", nullable: false),
                    SessionsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseSession", x => new { x.ExercisesId, x.SessionsId });
                    table.ForeignKey(
                        name: "FK_ExerciseSession_Exercises_ExercisesId",
                        column: x => x.ExercisesId,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExerciseSession_Sessions_SessionsId",
                        column: x => x.SessionsId,
                        principalTable: "Sessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "38d4a454-ee65-485d-995e-ad18d35aefd3", null, "User", "USER" },
                    { "4eb63c4c-ad13-4109-939a-be2653e1b28d", null, "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseSession_SessionsId",
                table: "ExerciseSession",
                column: "SessionsId");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_AppUserId",
                table: "Sessions",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sets_Sessions_SessionId",
                table: "Sets",
                column: "SessionId",
                principalTable: "Sessions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sets_Sessions_SessionId",
                table: "Sets");

            migrationBuilder.DropTable(
                name: "ExerciseSession");

            migrationBuilder.DropTable(
                name: "Sessions");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "38d4a454-ee65-485d-995e-ad18d35aefd3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4eb63c4c-ad13-4109-939a-be2653e1b28d");

            migrationBuilder.RenameColumn(
                name: "SessionId",
                table: "Sets",
                newName: "WorkoutSessionId");

            migrationBuilder.RenameIndex(
                name: "IX_Sets_SessionId",
                table: "Sets",
                newName: "IX_Sets_WorkoutSessionId");

            migrationBuilder.CreateTable(
                name: "WorkoutSessions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutSessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkoutSessions_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExerciseWorkoutSession",
                columns: table => new
                {
                    ExercisesId = table.Column<int>(type: "int", nullable: false),
                    WorkoutSessionsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseWorkoutSession", x => new { x.ExercisesId, x.WorkoutSessionsId });
                    table.ForeignKey(
                        name: "FK_ExerciseWorkoutSession_Exercises_ExercisesId",
                        column: x => x.ExercisesId,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExerciseWorkoutSession_WorkoutSessions_WorkoutSessionsId",
                        column: x => x.WorkoutSessionsId,
                        principalTable: "WorkoutSessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "77ea3432-811f-4907-b17a-98860715e7de", null, "User", "USER" },
                    { "ab4260bf-77eb-4a99-a334-dbbaa7f3ad60", null, "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseWorkoutSession_WorkoutSessionsId",
                table: "ExerciseWorkoutSession",
                column: "WorkoutSessionsId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutSessions_AppUserId",
                table: "WorkoutSessions",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sets_WorkoutSessions_WorkoutSessionId",
                table: "Sets",
                column: "WorkoutSessionId",
                principalTable: "WorkoutSessions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
