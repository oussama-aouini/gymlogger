using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace gymlogger.Migrations
{
    /// <inheritdoc />
    public partial class removedProps : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExerciseSession");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "37004a92-6a02-41b6-a3ef-9443b54a8121");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cc2d2c84-8c9e-4e9b-84f8-5e0b1244aca8");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "b90da1bd-b231-49ad-96f5-0352fffa7000", null, "User", "USER" },
                    { "f974f998-00a6-42ed-a997-8a017bd59843", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b90da1bd-b231-49ad-96f5-0352fffa7000");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f974f998-00a6-42ed-a997-8a017bd59843");

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
                    { "37004a92-6a02-41b6-a3ef-9443b54a8121", null, "Admin", "ADMIN" },
                    { "cc2d2c84-8c9e-4e9b-84f8-5e0b1244aca8", null, "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseSession_SessionsId",
                table: "ExerciseSession",
                column: "SessionsId");
        }
    }
}
