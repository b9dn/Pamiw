﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using P05Shop.API.Models;

#nullable disable

namespace P05Shop.API.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240108012501_migracjon")]
    partial class migracjon
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("P06Shop.Shared.Auth.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("longblob");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("longblob");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateCreated = new DateTime(2024, 1, 8, 2, 25, 1, 272, DateTimeKind.Local).AddTicks(3187),
                            Email = "root@root",
                            PasswordHash = new byte[] { 124, 48, 36, 122, 165, 123, 140, 90, 163, 151, 3, 110, 238, 51, 57, 82, 226, 24, 124, 252, 57, 197, 228, 193, 147, 175, 184, 209, 238, 93, 26, 86, 55, 201, 233, 182, 122, 254, 208, 165, 129, 152, 57, 80, 226, 119, 57, 52, 124, 186, 0, 202, 217, 17, 205, 232, 112, 76, 28, 57, 91, 95, 76, 244 },
                            PasswordSalt = new byte[] { 45, 102, 240, 142, 138, 89, 215, 242, 15, 66, 234, 177, 112, 208, 165, 9, 101, 183, 229, 98, 171, 142, 254, 15, 0, 89, 204, 93, 209, 124, 77, 201, 47, 196, 18, 115, 226, 174, 207, 95, 233, 0, 164, 99, 174, 91, 89, 115, 91, 78, 37, 112, 197, 248, 106, 35, 190, 195, 186, 206, 131, 232, 11, 56, 43, 238, 152, 162, 87, 168, 23, 120, 195, 116, 152, 115, 94, 30, 147, 81, 111, 70, 189, 4, 180, 89, 44, 223, 179, 131, 14, 5, 17, 176, 169, 140, 42, 231, 133, 132, 105, 172, 70, 100, 201, 242, 70, 58, 160, 212, 196, 74, 123, 113, 240, 209, 111, 22, 67, 246, 247, 0, 48, 130, 185, 201, 67, 244 },
                            Role = "Admin",
                            Username = "root"
                        });
                });

            modelBuilder.Entity("P06Shop.Shared.Shop.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("P06Shop.Shared.Shop.Film", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Barcode")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("varchar(12)");

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("FilmDetailsId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(8,2)");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Films");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Barcode = "5",
                            Description = "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive",
                            Price = 709.097133107994m,
                            ReleaseDate = new DateTime(2023, 2, 20, 2, 52, 20, 639, DateTimeKind.Local).AddTicks(4912),
                            Title = "ut"
                        },
                        new
                        {
                            Id = 2,
                            Barcode = "7",
                            Description = "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit",
                            Price = 395.001609376632m,
                            ReleaseDate = new DateTime(2023, 5, 31, 22, 13, 23, 377, DateTimeKind.Local).AddTicks(4537),
                            Title = "quo"
                        },
                        new
                        {
                            Id = 3,
                            Barcode = "3",
                            Description = "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive",
                            Price = 702.518694762382m,
                            ReleaseDate = new DateTime(2023, 7, 7, 10, 31, 52, 135, DateTimeKind.Local).AddTicks(8619),
                            Title = "repudiandae"
                        },
                        new
                        {
                            Id = 4,
                            Barcode = "4",
                            Description = "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality",
                            Price = 693.668755019395m,
                            ReleaseDate = new DateTime(2023, 1, 11, 2, 27, 43, 504, DateTimeKind.Local).AddTicks(8013),
                            Title = "voluptatem"
                        },
                        new
                        {
                            Id = 5,
                            Barcode = "7",
                            Description = "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J",
                            Price = 526.029559857226m,
                            ReleaseDate = new DateTime(2024, 1, 2, 18, 47, 32, 909, DateTimeKind.Local).AddTicks(4733),
                            Title = "esse"
                        },
                        new
                        {
                            Id = 6,
                            Barcode = "0",
                            Description = "The Football Is Good For Training And Recreational Purposes",
                            Price = 245.962609125284m,
                            ReleaseDate = new DateTime(2023, 1, 11, 18, 3, 47, 264, DateTimeKind.Local).AddTicks(9781),
                            Title = "fuga"
                        },
                        new
                        {
                            Id = 7,
                            Barcode = "5",
                            Description = "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support",
                            Price = 57.7898492826102m,
                            ReleaseDate = new DateTime(2023, 3, 20, 1, 30, 34, 370, DateTimeKind.Local).AddTicks(8899),
                            Title = "ipsa"
                        },
                        new
                        {
                            Id = 8,
                            Barcode = "9",
                            Description = "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality",
                            Price = 988.892659404265m,
                            ReleaseDate = new DateTime(2023, 9, 22, 0, 15, 1, 134, DateTimeKind.Local).AddTicks(4939),
                            Title = "fuga"
                        },
                        new
                        {
                            Id = 9,
                            Barcode = "3",
                            Description = "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients",
                            Price = 223.882037785315m,
                            ReleaseDate = new DateTime(2023, 8, 30, 15, 3, 13, 288, DateTimeKind.Local).AddTicks(2720),
                            Title = "dolor"
                        },
                        new
                        {
                            Id = 10,
                            Barcode = "3",
                            Description = "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients",
                            Price = 476.020144769466m,
                            ReleaseDate = new DateTime(2023, 6, 12, 13, 45, 37, 738, DateTimeKind.Local).AddTicks(1076),
                            Title = "et"
                        },
                        new
                        {
                            Id = 11,
                            Barcode = "9",
                            Description = "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients",
                            Price = 594.964523955232m,
                            ReleaseDate = new DateTime(2023, 3, 5, 12, 11, 6, 20, DateTimeKind.Local).AddTicks(8534),
                            Title = "dolore"
                        },
                        new
                        {
                            Id = 12,
                            Barcode = "9",
                            Description = "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart",
                            Price = 312.227141921049m,
                            ReleaseDate = new DateTime(2023, 5, 17, 0, 42, 17, 210, DateTimeKind.Local).AddTicks(5673),
                            Title = "aspernatur"
                        },
                        new
                        {
                            Id = 13,
                            Barcode = "4",
                            Description = "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit",
                            Price = 618.358974748924m,
                            ReleaseDate = new DateTime(2023, 11, 9, 10, 15, 17, 923, DateTimeKind.Local).AddTicks(6410),
                            Title = "aspernatur"
                        },
                        new
                        {
                            Id = 14,
                            Barcode = "0",
                            Description = "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals",
                            Price = 80.6260295047546m,
                            ReleaseDate = new DateTime(2023, 3, 8, 0, 13, 20, 299, DateTimeKind.Local).AddTicks(8570),
                            Title = "fuga"
                        },
                        new
                        {
                            Id = 15,
                            Barcode = "6",
                            Description = "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients",
                            Price = 471.610621951339m,
                            ReleaseDate = new DateTime(2023, 1, 22, 17, 47, 13, 374, DateTimeKind.Local).AddTicks(1299),
                            Title = "nesciunt"
                        },
                        new
                        {
                            Id = 16,
                            Barcode = "4",
                            Description = "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit",
                            Price = 366.261149519245m,
                            ReleaseDate = new DateTime(2024, 1, 3, 21, 54, 51, 840, DateTimeKind.Local).AddTicks(4389),
                            Title = "commodi"
                        },
                        new
                        {
                            Id = 17,
                            Barcode = "8",
                            Description = "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016",
                            Price = 271.938482550876m,
                            ReleaseDate = new DateTime(2023, 1, 27, 1, 44, 28, 524, DateTimeKind.Local).AddTicks(4839),
                            Title = "ut"
                        },
                        new
                        {
                            Id = 18,
                            Barcode = "6",
                            Description = "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients",
                            Price = 461.718092748764m,
                            ReleaseDate = new DateTime(2023, 1, 20, 23, 57, 28, 25, DateTimeKind.Local).AddTicks(6979),
                            Title = "omnis"
                        },
                        new
                        {
                            Id = 19,
                            Barcode = "4",
                            Description = "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support",
                            Price = 319.251068810584m,
                            ReleaseDate = new DateTime(2023, 7, 30, 2, 12, 53, 203, DateTimeKind.Local).AddTicks(1185),
                            Title = "earum"
                        },
                        new
                        {
                            Id = 20,
                            Barcode = "0",
                            Description = "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design",
                            Price = 612.278680905364m,
                            ReleaseDate = new DateTime(2023, 4, 9, 13, 57, 44, 31, DateTimeKind.Local).AddTicks(460),
                            Title = "consequuntur"
                        },
                        new
                        {
                            Id = 21,
                            Barcode = "8",
                            Description = "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit",
                            Price = 814.14169213648m,
                            ReleaseDate = new DateTime(2023, 6, 4, 14, 34, 39, 26, DateTimeKind.Local).AddTicks(3987),
                            Title = "voluptates"
                        },
                        new
                        {
                            Id = 22,
                            Barcode = "8",
                            Description = "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality",
                            Price = 822.374616404238m,
                            ReleaseDate = new DateTime(2023, 11, 19, 19, 21, 29, 717, DateTimeKind.Local).AddTicks(5685),
                            Title = "sint"
                        },
                        new
                        {
                            Id = 23,
                            Barcode = "4",
                            Description = "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality",
                            Price = 654.18977049747m,
                            ReleaseDate = new DateTime(2023, 5, 11, 17, 53, 3, 442, DateTimeKind.Local).AddTicks(1462),
                            Title = "sunt"
                        },
                        new
                        {
                            Id = 24,
                            Barcode = "7",
                            Description = "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J",
                            Price = 738.155003849489m,
                            ReleaseDate = new DateTime(2023, 12, 22, 6, 58, 39, 490, DateTimeKind.Local).AddTicks(5464),
                            Title = "molestiae"
                        },
                        new
                        {
                            Id = 25,
                            Barcode = "1",
                            Description = "The Football Is Good For Training And Recreational Purposes",
                            Price = 43.6775831215445m,
                            ReleaseDate = new DateTime(2023, 7, 18, 2, 22, 51, 108, DateTimeKind.Local).AddTicks(1223),
                            Title = "et"
                        },
                        new
                        {
                            Id = 26,
                            Barcode = "7",
                            Description = "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart",
                            Price = 507.616215421639m,
                            ReleaseDate = new DateTime(2023, 12, 31, 11, 36, 50, 207, DateTimeKind.Local).AddTicks(9951),
                            Title = "laboriosam"
                        },
                        new
                        {
                            Id = 27,
                            Barcode = "2",
                            Description = "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients",
                            Price = 910.785444308438m,
                            ReleaseDate = new DateTime(2023, 9, 4, 22, 7, 8, 30, DateTimeKind.Local).AddTicks(2917),
                            Title = "velit"
                        },
                        new
                        {
                            Id = 28,
                            Barcode = "3",
                            Description = "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals",
                            Price = 84.0327789569426m,
                            ReleaseDate = new DateTime(2023, 1, 28, 3, 55, 59, 430, DateTimeKind.Local).AddTicks(1495),
                            Title = "suscipit"
                        },
                        new
                        {
                            Id = 29,
                            Barcode = "4",
                            Description = "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality",
                            Price = 660.05177966694m,
                            ReleaseDate = new DateTime(2023, 8, 30, 20, 6, 10, 248, DateTimeKind.Local).AddTicks(4989),
                            Title = "et"
                        },
                        new
                        {
                            Id = 30,
                            Barcode = "4",
                            Description = "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients",
                            Price = 430.155933462156m,
                            ReleaseDate = new DateTime(2023, 7, 17, 8, 51, 4, 514, DateTimeKind.Local).AddTicks(3762),
                            Title = "nobis"
                        },
                        new
                        {
                            Id = 31,
                            Barcode = "9",
                            Description = "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart",
                            Price = 126.71586487755m,
                            ReleaseDate = new DateTime(2023, 5, 31, 4, 24, 18, 224, DateTimeKind.Local).AddTicks(5663),
                            Title = "facilis"
                        },
                        new
                        {
                            Id = 32,
                            Barcode = "8",
                            Description = "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support",
                            Price = 150.158714624196m,
                            ReleaseDate = new DateTime(2023, 1, 16, 17, 11, 32, 155, DateTimeKind.Local).AddTicks(9504),
                            Title = "occaecati"
                        },
                        new
                        {
                            Id = 33,
                            Barcode = "6",
                            Description = "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles",
                            Price = 3.84736985426739m,
                            ReleaseDate = new DateTime(2023, 4, 1, 16, 9, 30, 202, DateTimeKind.Local).AddTicks(8951),
                            Title = "at"
                        },
                        new
                        {
                            Id = 34,
                            Barcode = "6",
                            Description = "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit",
                            Price = 645.993864636865m,
                            ReleaseDate = new DateTime(2023, 4, 26, 16, 41, 34, 37, DateTimeKind.Local).AddTicks(9680),
                            Title = "qui"
                        },
                        new
                        {
                            Id = 35,
                            Barcode = "7",
                            Description = "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support",
                            Price = 289.121948837359m,
                            ReleaseDate = new DateTime(2023, 11, 17, 13, 21, 45, 502, DateTimeKind.Local).AddTicks(5091),
                            Title = "corrupti"
                        },
                        new
                        {
                            Id = 36,
                            Barcode = "3",
                            Description = "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality",
                            Price = 255.49067058018m,
                            ReleaseDate = new DateTime(2023, 9, 23, 13, 21, 23, 170, DateTimeKind.Local).AddTicks(3058),
                            Title = "maxime"
                        },
                        new
                        {
                            Id = 37,
                            Barcode = "1",
                            Description = "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals",
                            Price = 118.585349240147m,
                            ReleaseDate = new DateTime(2023, 1, 9, 2, 9, 35, 980, DateTimeKind.Local).AddTicks(9148),
                            Title = "est"
                        },
                        new
                        {
                            Id = 38,
                            Barcode = "4",
                            Description = "The Football Is Good For Training And Recreational Purposes",
                            Price = 857.801498141979m,
                            ReleaseDate = new DateTime(2023, 4, 3, 18, 6, 55, 73, DateTimeKind.Local).AddTicks(2146),
                            Title = "tenetur"
                        },
                        new
                        {
                            Id = 39,
                            Barcode = "0",
                            Description = "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive",
                            Price = 456.989796488541m,
                            ReleaseDate = new DateTime(2023, 4, 6, 8, 47, 55, 940, DateTimeKind.Local).AddTicks(529),
                            Title = "natus"
                        },
                        new
                        {
                            Id = 40,
                            Barcode = "3",
                            Description = "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016",
                            Price = 383.278243241961m,
                            ReleaseDate = new DateTime(2023, 1, 27, 13, 48, 49, 634, DateTimeKind.Local).AddTicks(533),
                            Title = "impedit"
                        },
                        new
                        {
                            Id = 41,
                            Barcode = "3",
                            Description = "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive",
                            Price = 729.819554187274m,
                            ReleaseDate = new DateTime(2023, 4, 25, 3, 21, 5, 377, DateTimeKind.Local).AddTicks(2174),
                            Title = "et"
                        },
                        new
                        {
                            Id = 42,
                            Barcode = "7",
                            Description = "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart",
                            Price = 12.9330949308039m,
                            ReleaseDate = new DateTime(2023, 10, 11, 12, 29, 47, 609, DateTimeKind.Local).AddTicks(1246),
                            Title = "aperiam"
                        },
                        new
                        {
                            Id = 43,
                            Barcode = "7",
                            Description = "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit",
                            Price = 32.5958482886645m,
                            ReleaseDate = new DateTime(2023, 8, 14, 3, 35, 36, 242, DateTimeKind.Local).AddTicks(638),
                            Title = "officiis"
                        },
                        new
                        {
                            Id = 44,
                            Barcode = "6",
                            Description = "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients",
                            Price = 342.748452510102m,
                            ReleaseDate = new DateTime(2023, 6, 12, 18, 5, 6, 640, DateTimeKind.Local).AddTicks(3072),
                            Title = "id"
                        },
                        new
                        {
                            Id = 45,
                            Barcode = "2",
                            Description = "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive",
                            Price = 158.364214679396m,
                            ReleaseDate = new DateTime(2023, 8, 27, 0, 31, 52, 686, DateTimeKind.Local).AddTicks(456),
                            Title = "animi"
                        },
                        new
                        {
                            Id = 46,
                            Barcode = "5",
                            Description = "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles",
                            Price = 515.594907488485m,
                            ReleaseDate = new DateTime(2023, 6, 7, 4, 37, 43, 674, DateTimeKind.Local).AddTicks(3246),
                            Title = "similique"
                        },
                        new
                        {
                            Id = 47,
                            Barcode = "0",
                            Description = "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016",
                            Price = 927.287084065046m,
                            ReleaseDate = new DateTime(2023, 9, 25, 16, 4, 23, 80, DateTimeKind.Local).AddTicks(7328),
                            Title = "provident"
                        },
                        new
                        {
                            Id = 48,
                            Barcode = "7",
                            Description = "The Football Is Good For Training And Recreational Purposes",
                            Price = 674.987207627849m,
                            ReleaseDate = new DateTime(2023, 1, 24, 0, 39, 27, 481, DateTimeKind.Local).AddTicks(170),
                            Title = "ut"
                        },
                        new
                        {
                            Id = 49,
                            Barcode = "9",
                            Description = "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit",
                            Price = 69.0171712734816m,
                            ReleaseDate = new DateTime(2023, 3, 28, 1, 37, 23, 208, DateTimeKind.Local).AddTicks(554),
                            Title = "nulla"
                        },
                        new
                        {
                            Id = 50,
                            Barcode = "7",
                            Description = "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles",
                            Price = 890.001594146714m,
                            ReleaseDate = new DateTime(2023, 9, 4, 6, 36, 43, 451, DateTimeKind.Local).AddTicks(8283),
                            Title = "sint"
                        });
                });

            modelBuilder.Entity("P06Shop.Shared.Shop.FilmDetails", b =>
                {
                    b.Property<int>("FilmId")
                        .HasColumnType("int");

                    b.Property<string>("Manufactuer")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("ManufactureDate")
                        .HasColumnType("datetime(6)");

                    b.HasKey("FilmId");

                    b.ToTable("FilmDetails");
                });

            modelBuilder.Entity("P06Shop.Shared.Shop.FilmSuppliers", b =>
                {
                    b.Property<int>("FilmId")
                        .HasColumnType("int");

                    b.Property<int>("SupplierId")
                        .HasColumnType("int");

                    b.HasKey("FilmId", "SupplierId");

                    b.HasIndex("SupplierId");

                    b.ToTable("FilmSuppliers");
                });

            modelBuilder.Entity("P06Shop.Shared.Shop.Supplier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ContactPhone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ContantEmail")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("P06Shop.Shared.Shop.Film", b =>
                {
                    b.HasOne("P06Shop.Shared.Shop.Category", "Category")
                        .WithMany("Films")
                        .HasForeignKey("CategoryId");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("P06Shop.Shared.Shop.FilmDetails", b =>
                {
                    b.HasOne("P06Shop.Shared.Shop.Film", "Film")
                        .WithOne("FilmDetails")
                        .HasForeignKey("P06Shop.Shared.Shop.FilmDetails", "FilmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Film");
                });

            modelBuilder.Entity("P06Shop.Shared.Shop.FilmSuppliers", b =>
                {
                    b.HasOne("P06Shop.Shared.Shop.Film", "Film")
                        .WithMany("FilmSuppliers")
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("P06Shop.Shared.Shop.Supplier", "Supplier")
                        .WithMany("FilmSuppliers")
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Film");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("P06Shop.Shared.Shop.Category", b =>
                {
                    b.Navigation("Films");
                });

            modelBuilder.Entity("P06Shop.Shared.Shop.Film", b =>
                {
                    b.Navigation("FilmDetails");

                    b.Navigation("FilmSuppliers");
                });

            modelBuilder.Entity("P06Shop.Shared.Shop.Supplier", b =>
                {
                    b.Navigation("FilmSuppliers");
                });
#pragma warning restore 612, 618
        }
    }
}
