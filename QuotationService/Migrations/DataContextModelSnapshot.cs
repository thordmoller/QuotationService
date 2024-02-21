﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QuotationService.Data;

#nullable disable

namespace QuotationService.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.27")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("QuotationService.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<decimal>("Rate")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("Id");

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Stockholm",
                            Rate = 65m
                        },
                        new
                        {
                            Id = 2,
                            Name = "Uppsala",
                            Rate = 55m
                        });
                });

            modelBuilder.Entity("QuotationService.Service", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("Services");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CityId = 1,
                            Name = "Fönsterputs",
                            Price = 300m
                        },
                        new
                        {
                            Id = 2,
                            CityId = 1,
                            Name = "Balkongstädning",
                            Price = 150m
                        },
                        new
                        {
                            Id = 3,
                            CityId = 2,
                            Name = "Fönsterputs",
                            Price = 300m
                        },
                        new
                        {
                            Id = 4,
                            CityId = 2,
                            Name = "Balkongstädning",
                            Price = 150m
                        },
                        new
                        {
                            Id = 5,
                            CityId = 2,
                            Name = "Bortforsling av skräp",
                            Price = 400m
                        });
                });

            modelBuilder.Entity("QuotationService.Service", b =>
                {
                    b.HasOne("QuotationService.City", "City")
                        .WithMany("Services")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("QuotationService.City", b =>
                {
                    b.Navigation("Services");
                });
#pragma warning restore 612, 618
        }
    }
}
