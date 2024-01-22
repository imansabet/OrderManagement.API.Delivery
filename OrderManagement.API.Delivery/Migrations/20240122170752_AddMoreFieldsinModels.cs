using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OrderManagement.API.Delivery.Migrations
{
    /// <inheritdoc />
    public partial class AddMoreFieldsinModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "TotalAmount",
                table: "Orders",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("ab3c1a63-fefa-4934-824b-e4b5201cb84a"),
                columns: new[] { "Address", "Email", "PhoneNumber" },
                values: new object[] { "Address2", "customer2@email.com", "9876543210" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("f7948d66-ae41-4a2b-8a41-a5dea5750243"),
                columns: new[] { "Address", "Email", "PhoneNumber" },
                values: new object[] { "Address1", "customer1@email.com", "1234567890" });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CreateDate", "CustomerId", "Description", "TotalAmount" },
                values: new object[,]
                {
                    { new Guid("85185bc1-e2c9-4467-b627-323e24237983"), new DateTime(2024, 1, 22, 20, 37, 52, 377, DateTimeKind.Local).AddTicks(7297), new Guid("f7948d66-ae41-4a2b-8a41-a5dea5750243"), "Order1", 100.00m },
                    { new Guid("cb6cbbd0-d063-410c-bc69-a921e1ca36de"), new DateTime(2024, 1, 22, 20, 37, 52, 377, DateTimeKind.Local).AddTicks(7314), new Guid("ab3c1a63-fefa-4934-824b-e4b5201cb84a"), "Order3", 75.25m },
                    { new Guid("f136b753-8ddc-4767-b55c-41db32f4020d"), new DateTime(2024, 1, 22, 20, 37, 52, 377, DateTimeKind.Local).AddTicks(7312), new Guid("f7948d66-ae41-4a2b-8a41-a5dea5750243"), "Order2", 150.50m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("85185bc1-e2c9-4467-b627-323e24237983"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("cb6cbbd0-d063-410c-bc69-a921e1ca36de"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("f136b753-8ddc-4767-b55c-41db32f4020d"));

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "TotalAmount",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Customers");

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
    }
}
