using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RideBooking.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddDriverLocation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "CurrentLocation_Latitude",
                table: "Drivers",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "CurrentLocation_Longitude",
                table: "Drivers",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentLocation_Latitude",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "CurrentLocation_Longitude",
                table: "Drivers");
        }
    }
}
