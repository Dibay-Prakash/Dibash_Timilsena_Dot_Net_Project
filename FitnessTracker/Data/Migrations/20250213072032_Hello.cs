using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessTracker.Data.Migrations
{
    /// <inheritdoc />
    public partial class Hello : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bmi",
                table: "Fitness");

            migrationBuilder.RenameColumn(
                name: "age",
                table: "Fitness",
                newName: "Age");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Age",
                table: "Fitness",
                newName: "age");

            migrationBuilder.AddColumn<double>(
                name: "Bmi",
                table: "Fitness",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
