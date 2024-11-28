using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace S_T.Apartaments.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addAptUserRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3f2504e0-4f89-11d3-9a0c-0305e82c3301",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c80f8883-db92-4e7e-a665-c15d63fb5733", "AQAAAAIAAYagAAAAEHN+vtSWrS5xxa9ytbt/uo58/oiJQsOV96TCpio6RE0+mABontgQZA/Sh88bC/9+fQ==", "31f165b4-d74f-4ceb-b2e5-0bf727df3e2a" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3f2504e0-4f89-11d3-9a0c-0305e82c3301",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d4d2b509-9e9b-483e-9f59-5a7ca3c569d8", "AQAAAAIAAYagAAAAECAgGz9HSJzqLO3BeB2P4HLUK0st7rLYXhBGC3xQ7dd4HeuNPTBE0i+oJ9WDuxYnHg==", "4d6ac88f-7666-4480-9473-4069cf9b9124" });
        }
    }
}
