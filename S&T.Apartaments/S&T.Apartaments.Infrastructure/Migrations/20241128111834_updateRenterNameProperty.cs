using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace S_T.Apartaments.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateRenterNameProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RenterName",
                table: "Apartments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3f2504e0-4f89-11d3-9a0c-0305e82c3301",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "77047424-4d4e-45c0-b37a-ed76fedf2929", "AQAAAAIAAYagAAAAED7Uwdz3pvZJXkOYCzQtD2IaWV0m2GglN7ITIqJGHDYKuuUB05px3tfK8C2J/IEnxA==", "8221121f-ea61-4389-8d10-a2335d2bea65" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RenterName",
                table: "Apartments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3f2504e0-4f89-11d3-9a0c-0305e82c3301",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c80f8883-db92-4e7e-a665-c15d63fb5733", "AQAAAAIAAYagAAAAEHN+vtSWrS5xxa9ytbt/uo58/oiJQsOV96TCpio6RE0+mABontgQZA/Sh88bC/9+fQ==", "31f165b4-d74f-4ceb-b2e5-0bf727df3e2a" });
        }
    }
}
