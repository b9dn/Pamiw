using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace P05Shop.API.Migrations
{
    /// <inheritdoc />
    public partial class migracjon : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Address = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ContantEmail = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ContactPhone = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Username = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PasswordHash = table.Column<byte[]>(type: "longblob", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "longblob", nullable: false),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Role = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DateCreated = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Films",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Barcode = table.Column<string>(type: "varchar(12)", maxLength: 12, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Price = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    FilmDetailsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Films", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Films_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FilmDetails",
                columns: table => new
                {
                    FilmId = table.Column<int>(type: "int", nullable: false),
                    Manufactuer = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ManufactureDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmDetails", x => x.FilmId);
                    table.ForeignKey(
                        name: "FK_FilmDetails_Films_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Films",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FilmSuppliers",
                columns: table => new
                {
                    FilmId = table.Column<int>(type: "int", nullable: false),
                    SupplierId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmSuppliers", x => new { x.FilmId, x.SupplierId });
                    table.ForeignKey(
                        name: "FK_FilmSuppliers_Films_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Films",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FilmSuppliers_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Films",
                columns: new[] { "Id", "Barcode", "CategoryId", "Description", "FilmDetailsId", "Price", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { 1, "5", null, "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", null, 709.097133107994m, new DateTime(2023, 2, 20, 2, 52, 20, 639, DateTimeKind.Local).AddTicks(4912), "ut" },
                    { 2, "7", null, "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", null, 395.001609376632m, new DateTime(2023, 5, 31, 22, 13, 23, 377, DateTimeKind.Local).AddTicks(4537), "quo" },
                    { 3, "3", null, "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", null, 702.518694762382m, new DateTime(2023, 7, 7, 10, 31, 52, 135, DateTimeKind.Local).AddTicks(8619), "repudiandae" },
                    { 4, "4", null, "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", null, 693.668755019395m, new DateTime(2023, 1, 11, 2, 27, 43, 504, DateTimeKind.Local).AddTicks(8013), "voluptatem" },
                    { 5, "7", null, "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", null, 526.029559857226m, new DateTime(2024, 1, 2, 18, 47, 32, 909, DateTimeKind.Local).AddTicks(4733), "esse" },
                    { 6, "0", null, "The Football Is Good For Training And Recreational Purposes", null, 245.962609125284m, new DateTime(2023, 1, 11, 18, 3, 47, 264, DateTimeKind.Local).AddTicks(9781), "fuga" },
                    { 7, "5", null, "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", null, 57.7898492826102m, new DateTime(2023, 3, 20, 1, 30, 34, 370, DateTimeKind.Local).AddTicks(8899), "ipsa" },
                    { 8, "9", null, "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", null, 988.892659404265m, new DateTime(2023, 9, 22, 0, 15, 1, 134, DateTimeKind.Local).AddTicks(4939), "fuga" },
                    { 9, "3", null, "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", null, 223.882037785315m, new DateTime(2023, 8, 30, 15, 3, 13, 288, DateTimeKind.Local).AddTicks(2720), "dolor" },
                    { 10, "3", null, "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", null, 476.020144769466m, new DateTime(2023, 6, 12, 13, 45, 37, 738, DateTimeKind.Local).AddTicks(1076), "et" },
                    { 11, "9", null, "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", null, 594.964523955232m, new DateTime(2023, 3, 5, 12, 11, 6, 20, DateTimeKind.Local).AddTicks(8534), "dolore" },
                    { 12, "9", null, "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", null, 312.227141921049m, new DateTime(2023, 5, 17, 0, 42, 17, 210, DateTimeKind.Local).AddTicks(5673), "aspernatur" },
                    { 13, "4", null, "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", null, 618.358974748924m, new DateTime(2023, 11, 9, 10, 15, 17, 923, DateTimeKind.Local).AddTicks(6410), "aspernatur" },
                    { 14, "0", null, "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", null, 80.6260295047546m, new DateTime(2023, 3, 8, 0, 13, 20, 299, DateTimeKind.Local).AddTicks(8570), "fuga" },
                    { 15, "6", null, "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", null, 471.610621951339m, new DateTime(2023, 1, 22, 17, 47, 13, 374, DateTimeKind.Local).AddTicks(1299), "nesciunt" },
                    { 16, "4", null, "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", null, 366.261149519245m, new DateTime(2024, 1, 3, 21, 54, 51, 840, DateTimeKind.Local).AddTicks(4389), "commodi" },
                    { 17, "8", null, "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", null, 271.938482550876m, new DateTime(2023, 1, 27, 1, 44, 28, 524, DateTimeKind.Local).AddTicks(4839), "ut" },
                    { 18, "6", null, "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", null, 461.718092748764m, new DateTime(2023, 1, 20, 23, 57, 28, 25, DateTimeKind.Local).AddTicks(6979), "omnis" },
                    { 19, "4", null, "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", null, 319.251068810584m, new DateTime(2023, 7, 30, 2, 12, 53, 203, DateTimeKind.Local).AddTicks(1185), "earum" },
                    { 20, "0", null, "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", null, 612.278680905364m, new DateTime(2023, 4, 9, 13, 57, 44, 31, DateTimeKind.Local).AddTicks(460), "consequuntur" },
                    { 21, "8", null, "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", null, 814.14169213648m, new DateTime(2023, 6, 4, 14, 34, 39, 26, DateTimeKind.Local).AddTicks(3987), "voluptates" },
                    { 22, "8", null, "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", null, 822.374616404238m, new DateTime(2023, 11, 19, 19, 21, 29, 717, DateTimeKind.Local).AddTicks(5685), "sint" },
                    { 23, "4", null, "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", null, 654.18977049747m, new DateTime(2023, 5, 11, 17, 53, 3, 442, DateTimeKind.Local).AddTicks(1462), "sunt" },
                    { 24, "7", null, "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", null, 738.155003849489m, new DateTime(2023, 12, 22, 6, 58, 39, 490, DateTimeKind.Local).AddTicks(5464), "molestiae" },
                    { 25, "1", null, "The Football Is Good For Training And Recreational Purposes", null, 43.6775831215445m, new DateTime(2023, 7, 18, 2, 22, 51, 108, DateTimeKind.Local).AddTicks(1223), "et" },
                    { 26, "7", null, "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", null, 507.616215421639m, new DateTime(2023, 12, 31, 11, 36, 50, 207, DateTimeKind.Local).AddTicks(9951), "laboriosam" },
                    { 27, "2", null, "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", null, 910.785444308438m, new DateTime(2023, 9, 4, 22, 7, 8, 30, DateTimeKind.Local).AddTicks(2917), "velit" },
                    { 28, "3", null, "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", null, 84.0327789569426m, new DateTime(2023, 1, 28, 3, 55, 59, 430, DateTimeKind.Local).AddTicks(1495), "suscipit" },
                    { 29, "4", null, "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", null, 660.05177966694m, new DateTime(2023, 8, 30, 20, 6, 10, 248, DateTimeKind.Local).AddTicks(4989), "et" },
                    { 30, "4", null, "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", null, 430.155933462156m, new DateTime(2023, 7, 17, 8, 51, 4, 514, DateTimeKind.Local).AddTicks(3762), "nobis" },
                    { 31, "9", null, "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", null, 126.71586487755m, new DateTime(2023, 5, 31, 4, 24, 18, 224, DateTimeKind.Local).AddTicks(5663), "facilis" },
                    { 32, "8", null, "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", null, 150.158714624196m, new DateTime(2023, 1, 16, 17, 11, 32, 155, DateTimeKind.Local).AddTicks(9504), "occaecati" },
                    { 33, "6", null, "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", null, 3.84736985426739m, new DateTime(2023, 4, 1, 16, 9, 30, 202, DateTimeKind.Local).AddTicks(8951), "at" },
                    { 34, "6", null, "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", null, 645.993864636865m, new DateTime(2023, 4, 26, 16, 41, 34, 37, DateTimeKind.Local).AddTicks(9680), "qui" },
                    { 35, "7", null, "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", null, 289.121948837359m, new DateTime(2023, 11, 17, 13, 21, 45, 502, DateTimeKind.Local).AddTicks(5091), "corrupti" },
                    { 36, "3", null, "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", null, 255.49067058018m, new DateTime(2023, 9, 23, 13, 21, 23, 170, DateTimeKind.Local).AddTicks(3058), "maxime" },
                    { 37, "1", null, "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", null, 118.585349240147m, new DateTime(2023, 1, 9, 2, 9, 35, 980, DateTimeKind.Local).AddTicks(9148), "est" },
                    { 38, "4", null, "The Football Is Good For Training And Recreational Purposes", null, 857.801498141979m, new DateTime(2023, 4, 3, 18, 6, 55, 73, DateTimeKind.Local).AddTicks(2146), "tenetur" },
                    { 39, "0", null, "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", null, 456.989796488541m, new DateTime(2023, 4, 6, 8, 47, 55, 940, DateTimeKind.Local).AddTicks(529), "natus" },
                    { 40, "3", null, "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", null, 383.278243241961m, new DateTime(2023, 1, 27, 13, 48, 49, 634, DateTimeKind.Local).AddTicks(533), "impedit" },
                    { 41, "3", null, "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", null, 729.819554187274m, new DateTime(2023, 4, 25, 3, 21, 5, 377, DateTimeKind.Local).AddTicks(2174), "et" },
                    { 42, "7", null, "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", null, 12.9330949308039m, new DateTime(2023, 10, 11, 12, 29, 47, 609, DateTimeKind.Local).AddTicks(1246), "aperiam" },
                    { 43, "7", null, "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", null, 32.5958482886645m, new DateTime(2023, 8, 14, 3, 35, 36, 242, DateTimeKind.Local).AddTicks(638), "officiis" },
                    { 44, "6", null, "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", null, 342.748452510102m, new DateTime(2023, 6, 12, 18, 5, 6, 640, DateTimeKind.Local).AddTicks(3072), "id" },
                    { 45, "2", null, "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", null, 158.364214679396m, new DateTime(2023, 8, 27, 0, 31, 52, 686, DateTimeKind.Local).AddTicks(456), "animi" },
                    { 46, "5", null, "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", null, 515.594907488485m, new DateTime(2023, 6, 7, 4, 37, 43, 674, DateTimeKind.Local).AddTicks(3246), "similique" },
                    { 47, "0", null, "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", null, 927.287084065046m, new DateTime(2023, 9, 25, 16, 4, 23, 80, DateTimeKind.Local).AddTicks(7328), "provident" },
                    { 48, "7", null, "The Football Is Good For Training And Recreational Purposes", null, 674.987207627849m, new DateTime(2023, 1, 24, 0, 39, 27, 481, DateTimeKind.Local).AddTicks(170), "ut" },
                    { 49, "9", null, "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", null, 69.0171712734816m, new DateTime(2023, 3, 28, 1, 37, 23, 208, DateTimeKind.Local).AddTicks(554), "nulla" },
                    { 50, "7", null, "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", null, 890.001594146714m, new DateTime(2023, 9, 4, 6, 36, 43, 451, DateTimeKind.Local).AddTicks(8283), "sint" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DateCreated", "Email", "PasswordHash", "PasswordSalt", "Role", "Username" },
                values: new object[] { 1, new DateTime(2024, 1, 8, 2, 25, 1, 272, DateTimeKind.Local).AddTicks(3187), "root@root", new byte[] { 124, 48, 36, 122, 165, 123, 140, 90, 163, 151, 3, 110, 238, 51, 57, 82, 226, 24, 124, 252, 57, 197, 228, 193, 147, 175, 184, 209, 238, 93, 26, 86, 55, 201, 233, 182, 122, 254, 208, 165, 129, 152, 57, 80, 226, 119, 57, 52, 124, 186, 0, 202, 217, 17, 205, 232, 112, 76, 28, 57, 91, 95, 76, 244 }, new byte[] { 45, 102, 240, 142, 138, 89, 215, 242, 15, 66, 234, 177, 112, 208, 165, 9, 101, 183, 229, 98, 171, 142, 254, 15, 0, 89, 204, 93, 209, 124, 77, 201, 47, 196, 18, 115, 226, 174, 207, 95, 233, 0, 164, 99, 174, 91, 89, 115, 91, 78, 37, 112, 197, 248, 106, 35, 190, 195, 186, 206, 131, 232, 11, 56, 43, 238, 152, 162, 87, 168, 23, 120, 195, 116, 152, 115, 94, 30, 147, 81, 111, 70, 189, 4, 180, 89, 44, 223, 179, 131, 14, 5, 17, 176, 169, 140, 42, 231, 133, 132, 105, 172, 70, 100, 201, 242, 70, 58, 160, 212, 196, 74, 123, 113, 240, 209, 111, 22, 67, 246, 247, 0, 48, 130, 185, 201, 67, 244 }, "Admin", "root" });

            migrationBuilder.CreateIndex(
                name: "IX_Films_CategoryId",
                table: "Films",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_FilmSuppliers_SupplierId",
                table: "FilmSuppliers",
                column: "SupplierId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FilmDetails");

            migrationBuilder.DropTable(
                name: "FilmSuppliers");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Films");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
