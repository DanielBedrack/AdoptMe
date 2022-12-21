using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AdoptMe1.Migrations
{
    /// <inheritdoc />
    public partial class AddedImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Comments",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Animals",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 1,
                columns: new[] { "Description", "PictureSrc" },
                values: new object[] { "A dog is a domestic mammal of the family Canidae and the order Carnivora. Its scientific name is Canis lupus familiaris. Dogs are a subspecies of the gray wolf, and they are also related to foxes and jackals. Dogs are one of the two most ubiquitous and most popular domestic animals in the world. (Cats are the other.)", "https://www.bing.com/th?id=OIP.YBuI2pjZcvYZAwnM4SyC_AHaE8&w=306&h=204&c=8&rs=1&qlt=90&o=6&dpr=1.3&pid=3.1&rm=2" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 2,
                column: "Description",
                value: "A cat is a furry animal that has a long tail and sharp claws. Cats are often kept as pets. 2. countable noun. Cats are lions, tigers, and other wild animals in the same family.");

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 4,
                columns: new[] { "CategoryId", "Description" },
                values: new object[] { 2, "In general, frogs have protruding eyes, no tail, and strong, webbed hind feet that are adapted for leaping and swimming. They also possess smooth, moist skins. Many are predominantly aquatic, but some live on land, in burrows, or in trees. A number depart from the typical form." });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 5,
                column: "Description",
                value: "A goose is a large bird with webbed feet. Geese hang out around ponds and lakes, fly in a V formation, and make a distinct honking noise. Geese are classified as waterfowl, birds that live at least part of the time in a body of water.");

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 7,
                column: "PictureSrc",
                value: "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQZyWWFHzHbAd413GbgCcu7wC2xOk26papaIQ&usqp=CAU");

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "AnimalId", "Age", "CategoryId", "Description", "Name", "PictureSrc", "Type" },
                values: new object[,]
                {
                    { 8, 1, 1, "Along with their tubelike bodies, weasels have small flattened heads, long flexible necks, and short limbs. The fur is short but dense, and the slim tail is pointed at the tip. Five toes on each foot end in sharp curved claws. The species can be differentiated by size, colour, and relative length of the tail.", "Buck", "data:image/jpeg;base64,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", "Weasel" },
                    { 9, 3, 2, "In the reptile world, there are some bizarre shapes and colors, but some of the most striking variations are found in the chameleons. These colorful lizards are known for their ability to change their color; their long, sticky tongue; and their eyes, which can be moved independently of each other.", "Dilen", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS_fzDXK8JTrWHYPPFQEQtBvmSbYEAZrL5C3A&usqp=CAU", "Chameleon" },
                    { 10, 1, 3, "The guppy is a small fish. Males are significantly smaller than females, measuring just 0.6-1.4 in (1.5-3.5 cm) long. Females, at about 1.2-2.4 in (3-6 cm) in length, are about twice the size. Males also tend to be more colorful, and extravagant, with ornamental fins absent in the females.", "Gup", "https://i0.wp.com/dumbocart.com/wp-content/uploads/2021/02/IMG_20210207_222851.jpg?fit=490%2C490&ssl=1", "Guppy" },
                    { 11, 1, 1, "Chinchillas are closely related to porcupines a guinea pigs, with strong, muscular hind legs that resemble those of a rabbit. The chinchilla is a common exotic pet, but is also largely used in the fur industry for fashionable clothing. Wild chinchillas are only found in Chile, but historically lived in areas of Argentina, Peru and Bolivia. Read on to learn about the chinchilla.", "Chini", "data:image/jpeg;base64,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", "Chinchilla" },
                    { 12, 1, 1, "The Possum comprises a group of marsupials that live in Australia, Sulawesi, and New Guinea. These furry creatures live in trees, and carry their young in a pouch. Many people incorrectly refer to “ oPossums ,” particularly the Virginia oPossum, as “Possums.” Researchers recognize approximately 70 different species of true Possums.", "Opi", "https://th.bing.com/th/id/OIP.JROgq1G2KzS27wy6pfEIvwHaHa?w=196&h=195&c=7&r=0&o=5&dpr=1.3&pid=1.7", "Opossum" },
                    { 13, 1, 2, "Some geckos are not fond of being handled, but the Leopard Gecko is one of the tamest lizards you can own. Compared to other reptiles, they take less time to adapt to a new environment. As ground dwellers, Leopards do not need a vertical tank with branches, but they require a small enclosure with a substrate so they can burrow. The substrate should be made of recycled paper or reptile carpet. ", "Gecki", "https://petkeen.com/wp-content/uploads/2021/02/Leopard-gecko_Reinhold-Leitner_shutterstock.webp", "Leopard Gecko" },
                    { 14, 1, 2, "This Australian native is light tan with a spiky “beard” around its neck that inflates when it feels threatened, but owners are unlikely to see the aggressive side of the docile creature. They tolerate handling well, and most are calm while they perch on their owner’s shoulder. ", "Chery", "https://petkeen.com/wp-content/uploads/2021/06/hand-carrying-bearded-dragon_tavan150_Shutterstock.webp", "Bearded Dragon" },
                    { 15, 1, 3, "hese extremely popular aquarium fish are very beautiful and effective creatures. They are also distinguished by a complex and interesting disposition, which, unfortunately, is sometimes underestimated.", "Allen", "https://th.bing.com/th/id/OIP.6f7ZtOxUnDGNNYFOnWmzEgHaE7?w=259&h=180&c=7&r=0&o=5&dpr=1.3&pid=1.7", "Skalar" },
                    { 16, 1, 4, "Eagle is the common name for many large birds of prey of the family Accipitridae. Eagles belong to several groups of genera, some of which are closely related. Most of the 68species of eagle are from Eurasia and Africa.[1] Outside this area, just 14 species can be found—2 in North America, 9 in Central and South America, and 3 in Australia.", "Azmel", "https://i.ytimg.com/vi/IhuX4ZUoews/maxresdefault.jpg", "Eagle" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "CommentId", "AnimalId", "Comments" },
                values: new object[,]
                {
                    { 9, 1, "So cute!" },
                    { 10, 1, "Cool!" },
                    { 15, 4, "So cute!" },
                    { 18, 2, "Amazing!" },
                    { 19, 2, "So cute!" },
                    { 1, 13, "So cute!" },
                    { 2, 13, "Adorable!" },
                    { 3, 13, "Cool!" },
                    { 4, 13, "Amazing!" },
                    { 5, 8, "So cute!" },
                    { 6, 8, "Amazing!" },
                    { 7, 8, "Adorable!" },
                    { 8, 8, "He is Beautiful!" },
                    { 12, 15, "So cute!" },
                    { 13, 9, "So cute!" },
                    { 14, 13, "So cute!" },
                    { 16, 9, "Amazing!" },
                    { 17, 11, "So cute!" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 15);

            migrationBuilder.AlterColumn<string>(
                name: "Comments",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Animals",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000);

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 1,
                columns: new[] { "Description", "PictureSrc" },
                values: new object[] { "A dog is a domestic mammal of the family Canidae and the order Carnivora. Its scientific name is Canis lupus familiaris. Dogs are a subspecies of the gray wolf, and they are also related to foxes and jackals. Dogs are one of the two most ubiquitous and most popular domestic animals in the world. (Cats are the other.)\r\n", "https://media-cldnry.s-nbcnews.com/image/upload/rockcms/2022-08/220805-border-collie-play-mn-1100-82d2f1.jpg" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 2,
                column: "Description",
                value: "A cat is a furry animal that has a long tail and sharp claws. Cats are often kept as pets. 2. countable noun. Cats are lions, tigers, and other wild animals in the same family.\r\n");

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 4,
                columns: new[] { "CategoryId", "Description" },
                values: new object[] { 3, "In general, frogs have protruding eyes, no tail, and strong, webbed hind feet that are adapted for leaping and swimming. They also possess smooth, moist skins. Many are predominantly aquatic, but some live on land, in burrows, or in trees. A number depart from the typical form.4 באוק׳ 2022\r\n" });

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 5,
                column: "Description",
                value: "A goose is a large bird with webbed feet. Geese hang out around ponds and lakes, fly in a V formation, and make a distinct honking noise. Geese are classified as waterfowl, birds that live at least part of the time in a body of water.\r\n");

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 7,
                column: "PictureSrc",
                value: "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSszaidfqbsIaV5xOE6y9yasAY3xF-knd92Hg&usqp=CAU");
        }
    }
}
