using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Palmfit.Data.Migrations
{
    /// <inheritdoc />
    public partial class updatedAppUserModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ActiveWeightGoal",
                table: "AppUser",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Age",
                table: "AppUser",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Height",
                table: "AppUser",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Weight",
                table: "AppUser",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "WeightGoal",
                table: "AppUser",
                type: "integer",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActiveWeightGoal",
                table: "AppUser");

            migrationBuilder.DropColumn(
                name: "Age",
                table: "AppUser");

            migrationBuilder.DropColumn(
                name: "Height",
                table: "AppUser");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "AppUser");

            migrationBuilder.DropColumn(
                name: "WeightGoal",
                table: "AppUser");
        }
    }
}
