using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace S_T.Apartaments.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateDbForRenterName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RenterName",
                table: "Apartments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3f2504e0-4f89-11d3-9a0c-0305e82c3301",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d4d2b509-9e9b-483e-9f59-5a7ca3c569d8", "AQAAAAIAAYagAAAAECAgGz9HSJzqLO3BeB2P4HLUK0st7rLYXhBGC3xQ7dd4HeuNPTBE0i+oJ9WDuxYnHg==", "4d6ac88f-7666-4480-9473-4069cf9b9124" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RenterName",
                table: "Apartments");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3f2504e0-4f89-11d3-9a0c-0305e82c3301",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e278ce51-2dff-4365-9c65-34c4dd9d2e83", "AQAAAAIAAYagAAAAEDUCTZyeyUtqCuJm37tvyGrIKkLr8EkQTINwrKrhqx1toNL5KIZQ3H2Ow9MkwljdLA==", "fe4fcadb-aed4-44dd-9064-7b9e73b1daa6" });
        }
    }
}
