﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OrderManagement.API.Delivery.INfrastructure.Configuration;

#nullable disable

namespace OrderManagement.API.Delivery.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240121164223_SeedDataToDB")]
    partial class SeedDataToDB
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("OrderManagement.API.Delivery.INfrastructure.Entities.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = new Guid("f7948d66-ae41-4a2b-8a41-a5dea5750243"),
                            Name = "Customer1"
                        },
                        new
                        {
                            Id = new Guid("ab3c1a63-fefa-4934-824b-e4b5201cb84a"),
                            Name = "Customer2"
                        });
                });

            modelBuilder.Entity("OrderManagement.API.Delivery.INfrastructure.Entities.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            Id = new Guid("1c72b89b-41f6-495b-8ac2-ca46cd66edd2"),
                            CustomerId = new Guid("f7948d66-ae41-4a2b-8a41-a5dea5750243"),
                            Description = "Order1"
                        },
                        new
                        {
                            Id = new Guid("55525ef6-97c6-4f07-b814-5075ceb63610"),
                            CustomerId = new Guid("f7948d66-ae41-4a2b-8a41-a5dea5750243"),
                            Description = "Order2"
                        },
                        new
                        {
                            Id = new Guid("c6675f9b-dbec-4f51-9d2e-38e717870c4c"),
                            CustomerId = new Guid("ab3c1a63-fefa-4934-824b-e4b5201cb84a"),
                            Description = "Order3"
                        });
                });

            modelBuilder.Entity("OrderManagement.API.Delivery.INfrastructure.Entities.Order", b =>
                {
                    b.HasOne("OrderManagement.API.Delivery.INfrastructure.Entities.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("OrderManagement.API.Delivery.INfrastructure.Entities.Customer", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}