using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace S_T.Apartaments.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateSeedUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3f2504e0-4f89-11d3-9a0c-0305e82c3301",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e278ce51-2dff-4365-9c65-34c4dd9d2e83", "ADMIN@ADMINSKY.COM", "ADMIN", "AQAAAAIAAYagAAAAEDUCTZyeyUtqCuJm37tvyGrIKkLr8EkQTINwrKrhqx1toNL5KIZQ3H2Ow9MkwljdLA==", "fe4fcadb-aed4-44dd-9064-7b9e73b1daa6" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3f2504e0-4f89-11d3-9a0c-0305e82c3301",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f872b5fa-ebce-4de1-a227-a5608f654a8f", null, null, "AQAAAAIAAYagAAAAEOKjrkrQhc9DNHprQRjI1675xS09o+dr+DAzQ1BLzOrQo9e2iWmVXykDLsVjWOTHMQ==", "47412a1b-d03d-4857-b2fd-14f8364c4057" });
        }
    }
}
