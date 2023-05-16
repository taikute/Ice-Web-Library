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
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Publishers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
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
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true)
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
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
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
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    PublishYear = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    CoverImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                        principalColumn: "Id",
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
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
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
                    ReturnedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StatusId = table.Column<int>(type: "int", nullable: false)
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
                columns: new[] { "Id", "Description", "Name" },
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
                    { 3, "Broken or Lost" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "CategoryId", "CoverImagePath", "Description", "Edition", "ISBN", "Language", "PageCount", "Price", "PublishYear", "PublisherId", "Quantity", "Title" },
                values: new object[,]
                {
                    { 1, 1, 3, "~/1.jpg", "A theoretical physicist's introduction to the theory of relativity", "1st edition", "558737123944", "English", 160, 150000, "1916", 1, 5, "Relativity: The Special and General Theory" },
                    { 2, 2, 4, "~/1.jpg", "A romantic novel about the pride and prejudices of the British upper class in the early 19th century", "2nd edition", "537149237955", "English", 279, 100000, "1813", 2, 3, "Pride and Prejudice" },
                    { 3, 3, 3, "~/1.jpg", "A popular science book about cosmology and the universe", "10th anniversary edition", "857903604410", "English", 212, 120000, "1988", 3, 7, "A Brief History of Time" },
                    { 4, 4, 4, "~/1.jpg", "The first book in the Harry Potter series, a fantasy novel about a young wizard and his friends at Hogwarts School of Witchcraft and Wizardry", "1st edition", "833307576657", "English", 223, 130000, "1997", 4, 2, "Harry Potter and the Philosopher's Stone" },
                    { 5, 5, 1, "~/1.jpg", "A detective novel about a murder on a train, featuring famous detective Hercule Poirot", "2nd edition", "185584091543", "English", 256, 110000, "1934", 1, 4, "Murder on the Orient Express" },
                    { 6, 6, 3, "~/1.jpg", "An introduction to astrophysics for laypeople", "1st edition", "541417360386", "English", 224, 140000, "2017", 5, 6, "Astrophysics for People in a Hurry" },
                    { 7, 7, 2, "~/1.jpg", "An annotated edition of the classic satire by Jonathan Swift", "3rd edition", "095609968399", "English", 522, 105000, "1960", 2, 1, "The Annotated Gulliver's Travels" },
                    { 8, 8, 1, "~/1.jpg", "A thriller novel by American author Dan Brown", "First edition", "806367510999", "English", 481, 150000, "2003", 4, 10, "The Da Vinci Code" },
                    { 9, 9, 5, "~/1.jpg", "An autobiography by Michelle Obama", "First edition", "882528455548", "English", 426, 250000, "2018", 3, 8, "Becoming" },
                    { 10, 9, 4, "~/1.jpg", "A children's fantasy novel by J.R.R. Tolkien", "Revised edition", "856798075539", "English", 310, 120000, "1937", 1, 12, "The Hobbit" },
                    { 11, 3, 3, "~/1.jpg", "A popular science book by British physicist Stephen Hawking", "First edition", "369164640784", "English", 212, 180000, "1988", 2, 5, "A Brief History of Time" },
                    { 12, 2, 4, "~/1.jpg", "A romantic novel by English author Jane Austen", "First edition", "859926973766", "English", 279, 90000, "1813", 5, 15, "Pride and Prejudice" },
                    { 13, 3, 3, "~/1.jpg", "A popular-science book by British physicists Stephen Hawking and Leonard Mlodinow", "First edition", "827884499151", "English", 198, 200000, "2010", 4, 3, "The Grand Design" },
                    { 14, 5, 1, "~/1.jpg", "A detective novel by Agatha Christie", "First edition", "798110363229", "English", 288, 85000, "1926", 1, 6, "The Murder of Roger Ackroyd" },
                    { 15, 8, 4, "~/1.jpg", "A novel by John Green", "First edition", "086584680771", "English", 313, 170000, "2012", 2, 9, "The Fault in Our Stars" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "IsActived", "IsOnline", "Name", "Password", "RoleId", "Username" },
                values: new object[,]
                {
                    { 1, "admin@gmail.com", true, false, "Admin Name", "jGl25bVBBBW96Qi9Te4V37Fnqchz/Eu4qB9vKrRIqRg=", 3, "admin" },
                    { 2, "librarian@gmail.com", true, false, "Librarian Name", "LEReHATfTiR8IIkkW2j8gR9yj30w/xSm1kpPqsWOYnA=", 2, "librarian" },
                    { 3, "user1@gmail.com", true, false, "User1 Name", "CgQblGLKpKMbrDVn4Lbm/ZEAeH2yq0M9lvbReMq/zpA=", 1, "user1" },
                    { 4, "user2@gmail.com", true, false, "User2 Name", "YCXRj+SKvUUWhSjxioLiZd2Y1CGnCEqgn2GzQXA5AaM=", 1, "user2" },
                    { 5, "user3@gmail.com", true, false, "User3 Name", "WGD68CtrxiIrpaylI1YPDjZMzYtnvuSG/ov3wB1JLMs=", 1, "user3" }
                });

            migrationBuilder.InsertData(
                table: "Instances",
                columns: new[] { "Id", "BookId", "StatusId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 1 },
                    { 3, 1, 1 },
                    { 4, 1, 1 },
                    { 5, 1, 1 },
                    { 6, 1, 1 },
                    { 7, 1, 1 },
                    { 8, 1, 1 },
                    { 9, 1, 1 },
                    { 10, 1, 1 },
                    { 11, 2, 1 },
                    { 12, 2, 1 },
                    { 13, 2, 1 },
                    { 14, 2, 1 },
                    { 15, 2, 1 },
                    { 16, 2, 1 },
                    { 17, 2, 1 },
                    { 18, 2, 1 },
                    { 19, 2, 1 },
                    { 20, 2, 1 },
                    { 21, 3, 1 },
                    { 22, 3, 1 },
                    { 23, 3, 1 },
                    { 24, 3, 1 },
                    { 25, 3, 1 },
                    { 26, 3, 1 },
                    { 27, 3, 1 },
                    { 28, 3, 1 },
                    { 29, 3, 1 },
                    { 30, 3, 1 },
                    { 31, 4, 1 },
                    { 32, 4, 1 },
                    { 33, 4, 1 },
                    { 34, 4, 1 },
                    { 35, 4, 1 },
                    { 36, 4, 1 },
                    { 37, 4, 1 },
                    { 38, 4, 1 },
                    { 39, 4, 1 },
                    { 40, 4, 1 },
                    { 41, 5, 1 },
                    { 42, 5, 1 },
                    { 43, 5, 1 },
                    { 44, 5, 1 },
                    { 45, 5, 1 },
                    { 46, 5, 1 },
                    { 47, 5, 1 },
                    { 48, 5, 1 },
                    { 49, 5, 1 },
                    { 50, 5, 1 },
                    { 51, 6, 1 },
                    { 52, 6, 1 },
                    { 53, 6, 1 },
                    { 54, 6, 1 },
                    { 55, 6, 1 },
                    { 56, 6, 1 },
                    { 57, 6, 1 },
                    { 58, 6, 1 },
                    { 59, 6, 1 },
                    { 60, 6, 1 },
                    { 61, 7, 1 },
                    { 62, 7, 1 },
                    { 63, 7, 1 },
                    { 64, 7, 1 },
                    { 65, 7, 1 },
                    { 66, 7, 1 },
                    { 67, 7, 1 },
                    { 68, 7, 1 },
                    { 69, 7, 1 },
                    { 70, 7, 1 },
                    { 71, 8, 1 },
                    { 72, 8, 1 },
                    { 73, 8, 1 },
                    { 74, 8, 1 },
                    { 75, 8, 1 },
                    { 76, 8, 1 },
                    { 77, 8, 1 },
                    { 78, 8, 1 },
                    { 79, 8, 1 },
                    { 80, 8, 1 },
                    { 81, 9, 1 },
                    { 82, 9, 1 },
                    { 83, 9, 1 },
                    { 84, 9, 1 },
                    { 85, 9, 1 },
                    { 86, 9, 1 },
                    { 87, 9, 1 },
                    { 88, 9, 1 },
                    { 89, 9, 1 },
                    { 90, 9, 1 },
                    { 91, 10, 1 },
                    { 92, 10, 1 },
                    { 93, 10, 1 },
                    { 94, 10, 1 },
                    { 95, 10, 1 },
                    { 96, 10, 1 },
                    { 97, 10, 1 },
                    { 98, 10, 1 },
                    { 99, 10, 1 },
                    { 100, 10, 1 },
                    { 101, 11, 1 },
                    { 102, 11, 1 },
                    { 103, 11, 1 },
                    { 104, 11, 1 },
                    { 105, 11, 1 },
                    { 106, 11, 1 },
                    { 107, 11, 1 },
                    { 108, 11, 1 },
                    { 109, 11, 1 },
                    { 110, 11, 1 },
                    { 111, 12, 1 },
                    { 112, 12, 1 },
                    { 113, 12, 1 },
                    { 114, 12, 1 },
                    { 115, 12, 1 },
                    { 116, 12, 1 },
                    { 117, 12, 1 },
                    { 118, 12, 1 },
                    { 119, 12, 1 },
                    { 120, 12, 1 },
                    { 121, 13, 1 },
                    { 122, 13, 1 },
                    { 123, 13, 1 },
                    { 124, 13, 1 },
                    { 125, 13, 1 },
                    { 126, 13, 1 },
                    { 127, 13, 1 },
                    { 128, 13, 1 },
                    { 129, 13, 1 },
                    { 130, 13, 1 },
                    { 131, 14, 1 },
                    { 132, 14, 1 },
                    { 133, 14, 1 },
                    { 134, 14, 1 },
                    { 135, 14, 1 },
                    { 136, 14, 1 },
                    { 137, 14, 1 },
                    { 138, 14, 1 },
                    { 139, 14, 1 },
                    { 140, 14, 1 },
                    { 141, 15, 1 },
                    { 142, 15, 1 },
                    { 143, 15, 1 },
                    { 144, 15, 1 },
                    { 145, 15, 1 },
                    { 146, 15, 1 },
                    { 147, 15, 1 },
                    { 148, 15, 1 },
                    { 149, 15, 1 },
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
