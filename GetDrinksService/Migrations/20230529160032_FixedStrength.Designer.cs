﻿// <auto-generated />
using BreadService;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BreadService.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230529160032_FixedStrength")]
    partial class FixedStrength
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("DrinksService.Drink", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Category")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<double>("Rate")
                        .HasColumnType("double precision");

                    b.Property<double>("Strength")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.ToTable("tblDrinks");
                });

            modelBuilder.Entity("DrinksService.DrinkReview", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("DrinkId")
                        .HasColumnType("integer");

                    b.Property<int>("Rate")
                        .HasColumnType("integer");

                    b.Property<string>("Review")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("DrinkId");

                    b.ToTable("tblDrinkReviews");
                });

            modelBuilder.Entity("DrinksService.DrinkReview", b =>
                {
                    b.HasOne("DrinksService.Drink", "Drink")
                        .WithMany("drinkReviews")
                        .HasForeignKey("DrinkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Drink");
                });

            modelBuilder.Entity("DrinksService.Drink", b =>
                {
                    b.Navigation("drinkReviews");
                });
#pragma warning restore 612, 618
        }
    }
}
