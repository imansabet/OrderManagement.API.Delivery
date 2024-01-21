using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OrderManagement.API.Delivery.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataToDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("ab3c1a63-fefa-4934-824b-e4b5201cb84a"), "Customer2" },
                    { new Guid("f7948d66-ae41-4a2b-8a41-a5dea5750243"), "Customer1" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CustomerId", "Description" },
                values: new object[,]
                {
                    { new Guid("1c72b89b-41f6-495b-8ac2-ca46cd66edd2"), new Guid("f7948d66-ae41-4a2b-8a41-a5dea5750243"), "Order1" },
                    { new Guid("55525ef6-97c6-4f07-b814-5075ceb63610"), new Guid("f7948d66-ae41-4a2b-8a41-a5dea5750243"), "Order2" },
                    { new Guid("c6675f9b-dbec-4f51-9d2e-38e717870c4c"), new Guid("ab3c1a63-fefa-4934-824b-e4b5201cb84a"), "Order3" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("1c72b89b-41f6-495b-8ac2-ca46cd66edd2"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("55525ef6-97c6-4f07-b814-5075ceb63610"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("c6675f9b-dbec-4f51-9d2e-38e717870c4c"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("ab3c1a63-fefa-4934-824b-e4b5201cb84a"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("f7948d66-ae41-4a2b-8a41-a5dea5750243"));
        }
    }
}
