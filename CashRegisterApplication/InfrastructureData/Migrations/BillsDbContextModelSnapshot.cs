﻿// <auto-generated />
using InfrastructureData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace InfrastructureData.Migrations
{
    [DbContext(typeof(BillsDbContext))]
    partial class BillsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Domain.Bill", b =>
                {
                    b.Property<int>("Bill_number")
                        .HasColumnType("integer");

                    b.Property<int>("Credit_card")
                        .HasColumnType("integer");

                    b.Property<int>("Total_cost")
                        .HasColumnType("integer");

                    b.HasKey("Bill_number");

                    b.ToTable("Bills");
                });

            modelBuilder.Entity("Domain.Bill_Product", b =>
                {
                    b.Property<int>("Bill_number")
                        .HasColumnType("integer");

                    b.Property<int>("Product_id")
                        .HasColumnType("integer");

                    b.Property<int>("Product_quantity")
                        .HasColumnType("integer");

                    b.Property<int>("Products_cost")
                        .HasColumnType("integer");

                    b.HasKey("Bill_number", "Product_id");

                    b.HasIndex("Product_id");

                    b.ToTable("Bill_Products");
                });

            modelBuilder.Entity("Domain.Product", b =>
                {
                    b.Property<int>("Product_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Product_id"));

                    b.Property<int>("Cost")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Product_id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Domain.Bill_Product", b =>
                {
                    b.HasOne("Domain.Bill", "Bill")
                        .WithMany("Bill_Products")
                        .HasForeignKey("Bill_number")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Product", "Product")
                        .WithMany("Bill_Products")
                        .HasForeignKey("Product_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bill");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Domain.Bill", b =>
                {
                    b.Navigation("Bill_Products");
                });

            modelBuilder.Entity("Domain.Product", b =>
                {
                    b.Navigation("Bill_Products");
                });
#pragma warning restore 612, 618
        }
    }
}
