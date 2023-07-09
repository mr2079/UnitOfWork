﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UnitOfWork.Architecture.Infrastructure.Persistence;

#nullable disable

namespace UnitOfWork.Architecture.Infrastructure.Migrations
{
    [DbContext(typeof(MainDbContext))]
    [Migration("20230709184923_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.19");

            modelBuilder.Entity("UnitOfWork.Architecture.Domain.Entities.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Apartment")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("POBox")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("PersonId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("Addresses", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Apartment = "3",
                            City = "Lisboa",
                            Country = "Portuguese",
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            POBox = "1900-349",
                            PersonId = 1,
                            Street = "Yango Avenida, Quadra 25",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            Apartment = "54",
                            City = "Faro",
                            Country = "Portuguese",
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            POBox = "1900-123",
                            PersonId = 2,
                            Street = "Braga Rua, Quadra 01",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            Apartment = "",
                            City = "Albufeira",
                            Country = "Portuguese",
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            POBox = "1900-73",
                            PersonId = 3,
                            Street = "Moraes Alameda, Casa 2",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("UnitOfWork.Architecture.Domain.Entities.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Persons", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Jordan",
                            LastName = "Davila",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Giovanni",
                            LastName = "Krueger",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Marjorie",
                            LastName = "Nolan",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("UnitOfWork.Architecture.Domain.Entities.Address", b =>
                {
                    b.HasOne("UnitOfWork.Architecture.Domain.Entities.Person", "Person")
                        .WithMany("Addresses")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("UnitOfWork.Architecture.Domain.Entities.Person", b =>
                {
                    b.Navigation("Addresses");
                });
#pragma warning restore 612, 618
        }
    }
}