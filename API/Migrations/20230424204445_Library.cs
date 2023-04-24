using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class Library : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Publishers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publishers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    PublisherId = table.Column<int>(type: "int", nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    PageCount = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PublishYear = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    CoverImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Language = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Edition = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books_Publishers_PublisherId",
                        column: x => x.PublisherId,
                        principalTable: "Publishers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    IsActived = table.Column<bool>(type: "bit", nullable: false),
                    IsOnline = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Username = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Instances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Instances_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Instances_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Loans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstanceId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    BorrowedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReturnedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Loans_Instances_InstanceId",
                        column: x => x.InstanceId,
                        principalTable: "Instances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Loans_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "German physicist and mathematician who developed the theory of relativity", "Albert Einstein" },
                    { 2, "English novelist known for her works of romantic fiction", "Jane Austen" },
                    { 3, "English theoretical physicist and cosmologist", "Stephen Hawking" },
                    { 4, "British author, philanthropist, film producer, television producer and screenwriter", "J.K. Rowling" },
                    { 5, "English writer known for her detective novels", "Agatha Christie" },
                    { 6, "American astrophysicist, planetary scientist, author, and science communicator", "Neil deGrasse Tyson" },
                    { 7, "American writer and professor of biochemistry", "Isaac Asimov" },
                    { 8, "American author known for his thriller novels", "Dan Brown" },
                    { 9, "American lawyer and author who served as the First Lady of the United States from 2009 to 2017", "Michelle Obama" },
                    { 10, "English novelist, essayist, journalist and critic, best known for his dystopian novel 1984 and the allegorical novella Animal Farm", "George Orwell" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Mystery and crime novels", "Detective" },
                    { 2, "Books about art, artists and art history", "Art" },
                    { 3, "Books about natural science, mathematics, and technology", "Science" },
                    { 4, "Books about imaginary people and events", "Fiction" },
                    { 5, "Books about historical events and figures", "History" },
                    { 6, "Books about people's lives and experiences", "Biography" },
                    { 7, "Books about travel destinations and experiences", "Travel" },
                    { 8, "Books about business management, entrepreneurship, and finance", "Business" },
                    { 9, "Books about cooking techniques, recipes, and ingredients", "Cooking" },
                    { 10, "Books about personal development, motivation, and success", "Self-help" }
                });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "One of the largest and most prestigious English-language publishers.", "Penguin Books" },
                    { 2, "An American publishing company, one of the world's largest.", "HarperCollins" },
                    { 3, "An American book publisher and the largest general-interest paperback publisher in the world.", "Random House" },
                    { 4, "An American publishing company and a division of ViacomCBS.", "Simon & Schuster" },
                    { 5, "A global trade publishing company, owned by Holtzbrinck Publishing Group.", "Macmillan Publishers" },
                    { 6, "The largest university press in the world, publishing in 70 languages and 190 countries.", "Oxford University Press" },
                    { 7, "The publishing business of the University of Cambridge, one of the world's oldest universities.", "Cambridge University Press" },
                    { 8, "A global academic publishing company, the product of a merger between Springer Science+Business Media and Nature Publishing Group.", "Springer Nature" },
                    { 9, "The world's third-largest trade book publisher, headquartered in France.", "Hachette Livre" },
                    { 10, "A British independent publishing house, best known for publishing the Harry Potter series.", "Bloomsbury Publishing" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Reader" },
                    { 2, "Librarian" },
                    { 3, "Admin" }
                });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Available" },
                    { 2, "On Loan" },
                    { 3, "Broken" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "CategoryId", "CoverImagePath", "Description", "Edition", "ISBN", "Language", "PageCount", "Price", "PublishYear", "PublisherId", "Quantity", "Title" },
                values: new object[,]
                {
                    { 1, 1, 3, "~/1.jpg", "A theoretical physicist's introduction to the theory of relativity", "1st edition", "812147409117", "English", 160, 150000, "1916", 1, 5, "Relativity: The Special and General Theory" },
                    { 2, 2, 4, "~/1.jpg", "A romantic novel about the pride and prejudices of the British upper class in the early 19th century", "2nd edition", "031578731037", "English", 279, 100000, "1813", 2, 3, "Pride and Prejudice" },
                    { 3, 3, 3, "~/1.jpg", "A popular science book about cosmology and the universe", "10th anniversary edition", "651061038029", "English", 212, 120000, "1988", 3, 7, "A Brief History of Time" },
                    { 4, 4, 4, "~/1.jpg", "The first book in the Harry Potter series, a fantasy novel about a young wizard and his friends at Hogwarts School of Witchcraft and Wizardry", "1st edition", "331976562909", "English", 223, 130000, "1997", 4, 2, "Harry Potter and the Philosopher's Stone" },
                    { 5, 5, 1, "~/1.jpg", "A detective novel about a murder on a train, featuring famous detective Hercule Poirot", "2nd edition", "151983459085", "English", 256, 110000, "1934", 1, 4, "Murder on the Orient Express" },
                    { 6, 6, 3, "~/1.jpg", "An introduction to astrophysics for laypeople", "1st edition", "879969938708", "English", 224, 140000, "2017", 5, 6, "Astrophysics for People in a Hurry" },
                    { 7, 7, 2, "~/1.jpg", "An annotated edition of the classic satire by Jonathan Swift", "3rd edition", "719751729826", "English", 522, 105000, "1960", 2, 1, "The Annotated Gulliver's Travels" },
                    { 8, 8, 1, "~/1.jpg", "A thriller novel by American author Dan Brown", "First edition", "915817301724", "English", 481, 150000, "2003", 4, 10, "The Da Vinci Code" },
                    { 9, 9, 5, "~/1.jpg", "An autobiography by Michelle Obama", "First edition", "814172283437", "English", 426, 250000, "2018", 3, 8, "Becoming" },
                    { 10, 9, 4, "~/1.jpg", "A children's fantasy novel by J.R.R. Tolkien", "Revised edition", "221239864699", "English", 310, 120000, "1937", 1, 12, "The Hobbit" },
                    { 11, 3, 3, "~/1.jpg", "A popular science book by British physicist Stephen Hawking", "First edition", "314467000238", "English", 212, 180000, "1988", 2, 5, "A Brief History of Time" },
                    { 12, 2, 4, "~/1.jpg", "A romantic novel by English author Jane Austen", "First edition", "299561579059", "English", 279, 90000, "1813", 5, 15, "Pride and Prejudice" },
                    { 13, 3, 3, "~/1.jpg", "A popular-science book by British physicists Stephen Hawking and Leonard Mlodinow", "First edition", "608194139567", "English", 198, 200000, "2010", 4, 3, "The Grand Design" },
                    { 14, 5, 1, "~/1.jpg", "A detective novel by Agatha Christie", "First edition", "899539460748", "English", 288, 85000, "1926", 1, 6, "The Murder of Roger Ackroyd" },
                    { 15, 8, 4, "~/1.jpg", "A novel by John Green", "First edition", "297136524734", "English", 313, 170000, "2012", 2, 9, "The Fault in Our Stars" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "IsActived", "IsOnline", "Name", "Password", "RoleId", "Username" },
                values: new object[,]
                {
                    { 1, "ice@gmail.com", true, false, "Ice", "jGl25bVBBBW96Qi9Te4V37Fnqchz/Eu4qB9vKrRIqRg=", 3, "admin" },
                    { 2, "ceri@gmail.com", true, false, "Ceri", "LEReHATfTiR8IIkkW2j8gR9yj30w/xSm1kpPqsWOYnA=", 2, "librarian" },
                    { 3, "user1@gmail.com", true, false, "User1", "CgQblGLKpKMbrDVn4Lbm/ZEAeH2yq0M9lvbReMq/zpA=", 1, "user1" },
                    { 4, "user2@gmail.com", true, false, "User2", "YCXRj+SKvUUWhSjxioLiZd2Y1CGnCEqgn2GzQXA5AaM=", 1, "user2" },
                    { 5, "user3@gmail.com", true, false, "User3", "WGD68CtrxiIrpaylI1YPDjZMzYtnvuSG/ov3wB1JLMs=", 1, "user3" }
                });

            migrationBuilder.InsertData(
                table: "Instances",
                columns: new[] { "Id", "BookId", "StatusId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 1 },
                    { 3, 3, 1 },
                    { 4, 4, 1 },
                    { 5, 5, 1 },
                    { 6, 6, 1 },
                    { 7, 7, 1 },
                    { 8, 8, 1 },
                    { 9, 9, 1 },
                    { 10, 10, 1 },
                    { 11, 11, 1 },
                    { 12, 12, 1 },
                    { 13, 13, 1 },
                    { 14, 14, 1 },
                    { 15, 15, 1 },
                    { 16, 1, 1 },
                    { 17, 2, 1 },
                    { 18, 3, 1 },
                    { 19, 4, 1 },
                    { 20, 5, 1 },
                    { 21, 6, 1 },
                    { 22, 7, 1 },
                    { 23, 8, 1 },
                    { 24, 9, 1 },
                    { 25, 10, 1 },
                    { 26, 11, 1 },
                    { 27, 12, 1 },
                    { 28, 13, 1 },
                    { 29, 14, 1 },
                    { 30, 15, 1 },
                    { 31, 1, 1 },
                    { 32, 2, 1 },
                    { 33, 3, 1 },
                    { 34, 4, 1 },
                    { 35, 5, 1 },
                    { 36, 6, 1 },
                    { 37, 7, 1 },
                    { 38, 8, 1 },
                    { 39, 9, 1 },
                    { 40, 10, 1 },
                    { 41, 11, 1 },
                    { 42, 12, 1 },
                    { 43, 13, 1 },
                    { 44, 14, 1 },
                    { 45, 15, 1 },
                    { 46, 1, 1 },
                    { 47, 2, 1 },
                    { 48, 3, 1 },
                    { 49, 4, 1 },
                    { 50, 5, 1 },
                    { 51, 6, 1 },
                    { 52, 7, 1 },
                    { 53, 8, 1 },
                    { 54, 9, 1 },
                    { 55, 10, 1 },
                    { 56, 11, 1 },
                    { 57, 12, 1 },
                    { 58, 13, 1 },
                    { 59, 14, 1 },
                    { 60, 15, 1 },
                    { 61, 1, 1 },
                    { 62, 2, 1 },
                    { 63, 3, 1 },
                    { 64, 4, 1 },
                    { 65, 5, 1 },
                    { 66, 6, 1 },
                    { 67, 7, 1 },
                    { 68, 8, 1 },
                    { 69, 9, 1 },
                    { 70, 10, 1 },
                    { 71, 11, 1 },
                    { 72, 12, 1 },
                    { 73, 13, 1 },
                    { 74, 14, 1 },
                    { 75, 15, 1 },
                    { 76, 1, 1 },
                    { 77, 2, 1 },
                    { 78, 3, 1 },
                    { 79, 4, 1 },
                    { 80, 5, 1 },
                    { 81, 6, 1 },
                    { 82, 7, 1 },
                    { 83, 8, 1 },
                    { 84, 9, 1 },
                    { 85, 10, 1 },
                    { 86, 11, 1 },
                    { 87, 12, 1 },
                    { 88, 13, 1 },
                    { 89, 14, 1 },
                    { 90, 15, 1 },
                    { 91, 1, 1 },
                    { 92, 2, 1 },
                    { 93, 3, 1 },
                    { 94, 4, 1 },
                    { 95, 5, 1 },
                    { 96, 6, 1 },
                    { 97, 7, 1 },
                    { 98, 8, 1 },
                    { 99, 9, 1 },
                    { 100, 10, 1 },
                    { 101, 11, 1 },
                    { 102, 12, 1 },
                    { 103, 13, 1 },
                    { 104, 14, 1 },
                    { 105, 15, 1 },
                    { 106, 1, 1 },
                    { 107, 2, 1 },
                    { 108, 3, 1 },
                    { 109, 4, 1 },
                    { 110, 5, 1 },
                    { 111, 6, 1 },
                    { 112, 7, 1 },
                    { 113, 8, 1 },
                    { 114, 9, 1 },
                    { 115, 10, 1 },
                    { 116, 11, 1 },
                    { 117, 12, 1 },
                    { 118, 13, 1 },
                    { 119, 14, 1 },
                    { 120, 15, 1 },
                    { 121, 1, 1 },
                    { 122, 2, 1 },
                    { 123, 3, 1 },
                    { 124, 4, 1 },
                    { 125, 5, 1 },
                    { 126, 6, 1 },
                    { 127, 7, 1 },
                    { 128, 8, 1 },
                    { 129, 9, 1 },
                    { 130, 10, 1 },
                    { 131, 11, 1 },
                    { 132, 12, 1 },
                    { 133, 13, 1 },
                    { 134, 14, 1 },
                    { 135, 15, 1 },
                    { 136, 1, 1 },
                    { 137, 2, 1 },
                    { 138, 3, 1 },
                    { 139, 4, 1 },
                    { 140, 5, 1 },
                    { 141, 6, 1 },
                    { 142, 7, 1 },
                    { 143, 8, 1 },
                    { 144, 9, 1 },
                    { 145, 10, 1 },
                    { 146, 11, 1 },
                    { 147, 12, 1 },
                    { 148, 13, 1 },
                    { 149, 14, 1 },
                    { 150, 15, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_CategoryId",
                table: "Books",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_ISBN",
                table: "Books",
                column: "ISBN",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Books_PublisherId",
                table: "Books",
                column: "PublisherId");

            migrationBuilder.CreateIndex(
                name: "IX_Instances_BookId",
                table: "Instances",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Instances_StatusId",
                table: "Instances",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Loans_InstanceId",
                table: "Loans",
                column: "InstanceId");

            migrationBuilder.CreateIndex(
                name: "IX_Loans_UserId",
                table: "Loans",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                table: "Users",
                column: "Username",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Loans");

            migrationBuilder.DropTable(
                name: "Instances");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Publishers");
        }
    }
}
