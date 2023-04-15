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
                    AuthorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Bio = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.AuthorId);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Publishers",
                columns: table => new
                {
                    PublisherId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publishers", x => x.PublisherId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    StatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.StatusId);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    PublisherId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    PublishYear = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CoverImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PageCount = table.Column<int>(type: "int", nullable: false),
                    Edition = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookId);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "AuthorId",
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
                        principalColumn: "PublisherId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Instances",
                columns: table => new
                {
                    InstanceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    BookCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instances", x => x.InstanceID);
                    table.ForeignKey(
                        name: "FK_Instances_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Instances_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "StatusId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Loans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstanceId = table.Column<int>(type: "int", nullable: false),
                    ReaderId = table.Column<int>(type: "int", nullable: false),
                    BorrowedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReturnedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Loans_Instances_InstanceId",
                        column: x => x.InstanceId,
                        principalTable: "Instances",
                        principalColumn: "InstanceID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Loans_Users_ReaderId",
                        column: x => x.ReaderId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "AuthorId", "Bio", "Name" },
                values: new object[,]
                {
                    { 1, "Unknow", "Albert Einstein" },
                    { 2, "Unknow", "Jane Austen" },
                    { 3, "Unknow", "Stephen Hawking" },
                    { 4, "Unknow", "J.K. Rowling" },
                    { 5, "Unknow", "Agatha Christie" },
                    { 6, "Unknow", "Neil deGrasse Tyson" },
                    { 7, "Unknow", "Isaac Asimov" },
                    { 8, "Unknow", "Dan Brown" },
                    { 9, "Unknow", "Michelle Obama" }
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
                    { 5, "Books about historical events and figures", "History" }
                });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "PublisherId", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "One of the largest and most prestigious English-language publishers.", "Penguin Books" },
                    { 2, "An American publishing company, one of the world's largest.", "HarperCollins" },
                    { 3, "An American book publisher and the largest general-interest paperback publisher in the world.", "Random House" },
                    { 4, "An American publishing company and a division of ViacomCBS.", "Simon & Schuster" },
                    { 5, "A global trade publishing company, owned by Holtzbrinck Publishing Group.", "Macmillan Publishers" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "Name" },
                values: new object[,]
                {
                    { 1, "Reader" },
                    { 2, "Librarian" }
                });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "StatusId", "Description" },
                values: new object[,]
                {
                    { 1, "Available" },
                    { 2, "On Loan" },
                    { 3, "Broken" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "AuthorId", "CategoryId", "CoverImagePath", "Description", "Edition", "ISBN", "Language", "PageCount", "Price", "PublishYear", "PublisherId", "Quantity", "Title" },
                values: new object[,]
                {
                    { 1, 2, 1, "~/1.jpg", "The unforgettable novel of a childhood in a sleepy Southern town and the crisis of conscience that rocked it, To Kill A Mockingbird became both an instant bestseller and a critical success when it was first published in 1960. It went on to win the Pulitzer Prize in 1961 and was later made into an Academy Award-winning film, also a classic.", "1st", "0446310786", "English", 336, 25000, "1960", 3, 10, "To Kill a Mockingbird" },
                    { 2, 4, 2, "~/1.jpg", "The Great Gatsby is a 1925 novel by American writer F. Scott Fitzgerald. Set in the Jazz Age on Long Island, the novel depicts narrator Nick Carraway's interactions with mysterious millionaire Jay Gatsby and Gatsby's obsession to reunite with his former lover, Daisy Buchanan.", "1st", "978-0-7475-8939-6", "English", 180, 20000, "1925", 1, 15, "The Great Gatsby" },
                    { 3, 6, 3, "~/1.jpg", "Animal Farm is an allegorical novella by George Orwell, first published in England on 17 August 1945. The book tells the story of a group of farm animals who rebel against their human farmer, hoping to create a society where the animals can be equal, free, and happy.", "1st", "978-0-14-103613-7", "English", 112, 15000, "1945", 4, 20, "Animal Farm" },
                    { 4, 7, 2, "~/1.jpg", "Nineteen Eighty-Four is a dystopian novel by English author George Orwell, published in 1949. The novel is set in a totalitarian society where the government has complete control over every aspect of people's lives.", "1st", "978-0-452-28424-1", "English", 328, 18000, "1949", 2, 25, "Nineteen Eighty-Four" },
                    { 5, 8, 1, "~/1.jpg", "The story of Holden Caulfield's struggles in New York City after being expelled from his prep school.", "1st", "0316769177", "English", 277, 120000, "1951", 5, 10, "The Catcher in the Rye" },
                    { 6, 9, 3, "~/1.jpg", "A dystopian novel set in a future society where people are genetically engineered and conditioned to be happy and conform to social norms.", "1st", "0060850523", "English", 288, 150000, "1932", 2, 15, "Brave New World" },
                    { 7, 1, 2, "~/1.jpg", "The story of a group of British boys stranded on an uninhabited island and their disastrous attempt to govern themselves.", "1st", "0571056865", "English", 224, 125000, "1954", 1, 20, "Lord of the Flies" },
                    { 8, 3, 1, "~/1.jpg", "A novel of manners set in rural England, following the romantic entanglements of the Bennet sisters and their suitors.", "1st", "0141439513", "English", 480, 100000, "1813", 3, 5, "Pride and Prejudice" },
                    { 9, 5, 3, "~/1.jpg", "A dystopian novel set in a future society where books are outlawed and 'firemen' burn any that are found.", "1st", "1451673310", "English", 249, 130000, "1953", 5, 12, "Fahrenheit 451" },
                    { 10, 6, 2, "~/1.jpg", "A fantasy novel following the adventures of hobbit Bilbo Baggins as he accompanies a group of dwarves on a quest to reclaim their treasure from a dragon.", "1st", "054792822X", "English", 310, 110000, "1937", 4, 8, "The Hobbit" },
                    { 11, 2, 2, "~/1.jpg", "A novel about the Lost Generation by Ernest Hemingway", "First Edition", "0743277334", "English", 259, 150000, "1926", 2, 5, "The Sun Also Rises" },
                    { 12, 1, 1, "~/1.jpg", "A fantasy novel by J.R.R. Tolkien", "Revised Edition", "9780547928227", "English", 310, 175000, "1937", 2, 8, "The Hobbit" },
                    { 13, 7, 3, "~/1.jpg", "A dystopian novel by Aldous Huxley", "First Edition", "0060850523", "English", 288, 135000, "1932", 4, 4, "Brave New World" },
                    { 14, 9, 2, "~/1.jpg", "A novel by Gabriel Garcia Marquez", "First Edition", "9780060883287", "Spanish", 417, 120000, "1967", 5, 6, "One Hundred Years of Solitude" },
                    { 15, 8, 1, "~/1.jpg", "A novel by Arundhati Roy", "First Edition", "0812979656", "English", 369, 95000, "1997", 1, 3, "The God of Small Things" },
                    { 16, 4, 3, "~/1.jpg", "A dystopian novel by Margaret Atwood", "First Edition", "9780385490818", "English", 311, 125000, "1985", 4, 7, "The Handmaid's Tale" },
                    { 17, 1, 2, "~/1.jpg", "A novella by Ernest Hemingway", "First Edition", "0684801221", "English", 128, 105000, "1952", 2, 2, "The Old Man and the Sea" },
                    { 18, 3, 3, "~/1.jpg", "A hilarious and inventive science fiction series that has become a beloved classic.", "First Edition", "9780345391803", "English", 224, 150000, "1979", 3, 5, "The Hitchhiker's Guide to the Galaxy" },
                    { 19, 4, 1, "~/1.jpg", "One of the most popular and enduring works of fantasy literature.", "50th Anniversary Edition", "9780547928210", "English", 1178, 250000, "1954", 3, 3, "The Lord of the Rings" },
                    { 20, 5, 2, "~/1.jpg", "A classic novel of manners that explores themes of love, marriage, and social status.", "Revised Edition", "9780141395203", "English", 432, 120000, "1813", 5, 8, "Pride and Prejudice" },
                    { 21, 7, 4, "~/1.jpg", "A thriller that follows symbologist Robert Langdon as he investigates a murder in the Louvre Museum.", "Special Illustrated Edition", "9780307277671", "English", 689, 180000, "2003", 4, 10, "The Da Vinci Code" },
                    { 22, 5, 1, "~/1.jpg", "A novel that explores the corruption of youth and the dangers of vanity and decadence.", "Revised Edition", "9780141442464", "English", 256, 95000, "1890", 2, 6, "The Picture of Dorian Gray" },
                    { 23, 8, 2, "~/1.jpg", "A magical realist novel that tells the story of the Buendía family over several generations.", "Revised Edition", "9780060883287", "English", 422, 160000, "1967", 1, 4, "One Hundred Years of Solitude" }
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
                name: "IX_Loans_ReaderId",
                table: "Loans",
                column: "ReaderId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
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
