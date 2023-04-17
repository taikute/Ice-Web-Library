﻿// <auto-generated />
using System;
using API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("API.Data.Author", b =>
                {
                    b.Property<int>("AuthorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AuthorId"));

                    b.Property<string>("Bio")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("AuthorId");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            AuthorId = 1,
                            Bio = "German physicist and mathematician who developed the theory of relativity",
                            Name = "Albert Einstein"
                        },
                        new
                        {
                            AuthorId = 2,
                            Bio = "English novelist known for her works of romantic fiction",
                            Name = "Jane Austen"
                        },
                        new
                        {
                            AuthorId = 3,
                            Bio = "English theoretical physicist and cosmologist",
                            Name = "Stephen Hawking"
                        },
                        new
                        {
                            AuthorId = 4,
                            Bio = "British author, philanthropist, film producer, television producer and screenwriter",
                            Name = "J.K. Rowling"
                        },
                        new
                        {
                            AuthorId = 5,
                            Bio = "English writer known for her detective novels",
                            Name = "Agatha Christie"
                        },
                        new
                        {
                            AuthorId = 6,
                            Bio = "American astrophysicist, planetary scientist, author, and science communicator",
                            Name = "Neil deGrasse Tyson"
                        },
                        new
                        {
                            AuthorId = 7,
                            Bio = "American writer and professor of biochemistry",
                            Name = "Isaac Asimov"
                        },
                        new
                        {
                            AuthorId = 8,
                            Bio = "American author known for his thriller novels",
                            Name = "Dan Brown"
                        },
                        new
                        {
                            AuthorId = 9,
                            Bio = "American lawyer and author who served as the First Lady of the United States from 2009 to 2017",
                            Name = "Michelle Obama"
                        });
                });

            modelBuilder.Entity("API.Data.Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookId"));

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("CoverImagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Edition")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ISBN")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Language")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PageCount")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<string>("PublishYear")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)");

                    b.Property<int>("PublisherId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("BookId");

                    b.HasIndex("AuthorId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("PublisherId");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            BookId = 1,
                            AuthorId = 2,
                            CategoryId = 1,
                            CoverImagePath = "~/1.jpg",
                            Description = "The unforgettable novel of a childhood in a sleepy Southern town and the crisis of conscience that rocked it, To Kill A Mockingbird became both an instant bestseller and a critical success when it was first published in 1960. It went on to win the Pulitzer Prize in 1961 and was later made into an Academy Award-winning film, also a classic.",
                            Edition = "1st",
                            ISBN = "0446310786",
                            Language = "English",
                            PageCount = 336,
                            Price = 25000,
                            PublishYear = "1960",
                            PublisherId = 3,
                            Quantity = 10,
                            Title = "To Kill a Mockingbird"
                        },
                        new
                        {
                            BookId = 2,
                            AuthorId = 4,
                            CategoryId = 2,
                            CoverImagePath = "~/1.jpg",
                            Description = "The Great Gatsby is a 1925 novel by American writer F. Scott Fitzgerald. Set in the Jazz Age on Long Island, the novel depicts narrator Nick Carraway's interactions with mysterious millionaire Jay Gatsby and Gatsby's obsession to reunite with his former lover, Daisy Buchanan.",
                            Edition = "1st",
                            ISBN = "978-0-7475-8939-6",
                            Language = "English",
                            PageCount = 180,
                            Price = 20000,
                            PublishYear = "1925",
                            PublisherId = 1,
                            Quantity = 15,
                            Title = "The Great Gatsby"
                        },
                        new
                        {
                            BookId = 3,
                            AuthorId = 6,
                            CategoryId = 3,
                            CoverImagePath = "~/1.jpg",
                            Description = "Animal Farm is an allegorical novella by George Orwell, first published in England on 17 August 1945. The book tells the story of a group of farm animals who rebel against their human farmer, hoping to create a society where the animals can be equal, free, and happy.",
                            Edition = "1st",
                            ISBN = "978-0-14-103613-7",
                            Language = "English",
                            PageCount = 112,
                            Price = 15000,
                            PublishYear = "1945",
                            PublisherId = 4,
                            Quantity = 20,
                            Title = "Animal Farm"
                        },
                        new
                        {
                            BookId = 4,
                            AuthorId = 7,
                            CategoryId = 2,
                            CoverImagePath = "~/1.jpg",
                            Description = "Nineteen Eighty-Four is a dystopian novel by English author George Orwell, published in 1949. The novel is set in a totalitarian society where the government has complete control over every aspect of people's lives.",
                            Edition = "1st",
                            ISBN = "978-0-452-28424-1",
                            Language = "English",
                            PageCount = 328,
                            Price = 18000,
                            PublishYear = "1949",
                            PublisherId = 2,
                            Quantity = 25,
                            Title = "Nineteen Eighty-Four"
                        },
                        new
                        {
                            BookId = 5,
                            AuthorId = 8,
                            CategoryId = 1,
                            CoverImagePath = "~/1.jpg",
                            Description = "The story of Holden Caulfield's struggles in New York City after being expelled from his prep school.",
                            Edition = "1st",
                            ISBN = "0316769177",
                            Language = "English",
                            PageCount = 277,
                            Price = 120000,
                            PublishYear = "1951",
                            PublisherId = 5,
                            Quantity = 10,
                            Title = "The Catcher in the Rye"
                        },
                        new
                        {
                            BookId = 6,
                            AuthorId = 9,
                            CategoryId = 3,
                            CoverImagePath = "~/1.jpg",
                            Description = "A dystopian novel set in a future society where people are genetically engineered and conditioned to be happy and conform to social norms.",
                            Edition = "1st",
                            ISBN = "0060850523",
                            Language = "English",
                            PageCount = 288,
                            Price = 150000,
                            PublishYear = "1932",
                            PublisherId = 2,
                            Quantity = 15,
                            Title = "Brave New World"
                        },
                        new
                        {
                            BookId = 7,
                            AuthorId = 1,
                            CategoryId = 2,
                            CoverImagePath = "~/1.jpg",
                            Description = "The story of a group of British boys stranded on an uninhabited island and their disastrous attempt to govern themselves.",
                            Edition = "1st",
                            ISBN = "0571056865",
                            Language = "English",
                            PageCount = 224,
                            Price = 125000,
                            PublishYear = "1954",
                            PublisherId = 1,
                            Quantity = 20,
                            Title = "Lord of the Flies"
                        },
                        new
                        {
                            BookId = 8,
                            AuthorId = 3,
                            CategoryId = 1,
                            CoverImagePath = "~/1.jpg",
                            Description = "A novel of manners set in rural England, following the romantic entanglements of the Bennet sisters and their suitors.",
                            Edition = "1st",
                            ISBN = "0141439513",
                            Language = "English",
                            PageCount = 480,
                            Price = 100000,
                            PublishYear = "1813",
                            PublisherId = 3,
                            Quantity = 5,
                            Title = "Pride and Prejudice"
                        },
                        new
                        {
                            BookId = 9,
                            AuthorId = 5,
                            CategoryId = 3,
                            CoverImagePath = "~/1.jpg",
                            Description = "A dystopian novel set in a future society where books are outlawed and 'firemen' burn any that are found.",
                            Edition = "1st",
                            ISBN = "1451673310",
                            Language = "English",
                            PageCount = 249,
                            Price = 130000,
                            PublishYear = "1953",
                            PublisherId = 5,
                            Quantity = 12,
                            Title = "Fahrenheit 451"
                        },
                        new
                        {
                            BookId = 10,
                            AuthorId = 6,
                            CategoryId = 2,
                            CoverImagePath = "~/1.jpg",
                            Description = "A fantasy novel following the adventures of hobbit Bilbo Baggins as he accompanies a group of dwarves on a quest to reclaim their treasure from a dragon.",
                            Edition = "1st",
                            ISBN = "054792822X",
                            Language = "English",
                            PageCount = 310,
                            Price = 110000,
                            PublishYear = "1937",
                            PublisherId = 4,
                            Quantity = 8,
                            Title = "The Hobbit"
                        },
                        new
                        {
                            BookId = 11,
                            AuthorId = 2,
                            CategoryId = 2,
                            CoverImagePath = "~/1.jpg",
                            Description = "A novel about the Lost Generation by Ernest Hemingway",
                            Edition = "First Edition",
                            ISBN = "0743277334",
                            Language = "English",
                            PageCount = 259,
                            Price = 150000,
                            PublishYear = "1926",
                            PublisherId = 2,
                            Quantity = 5,
                            Title = "The Sun Also Rises"
                        },
                        new
                        {
                            BookId = 12,
                            AuthorId = 1,
                            CategoryId = 1,
                            CoverImagePath = "~/1.jpg",
                            Description = "A fantasy novel by J.R.R. Tolkien",
                            Edition = "Revised Edition",
                            ISBN = "9780547928227",
                            Language = "English",
                            PageCount = 310,
                            Price = 175000,
                            PublishYear = "1937",
                            PublisherId = 2,
                            Quantity = 8,
                            Title = "The Hobbit"
                        },
                        new
                        {
                            BookId = 13,
                            AuthorId = 7,
                            CategoryId = 3,
                            CoverImagePath = "~/1.jpg",
                            Description = "A dystopian novel by Aldous Huxley",
                            Edition = "First Edition",
                            ISBN = "0060850523",
                            Language = "English",
                            PageCount = 288,
                            Price = 135000,
                            PublishYear = "1932",
                            PublisherId = 4,
                            Quantity = 4,
                            Title = "Brave New World"
                        },
                        new
                        {
                            BookId = 14,
                            AuthorId = 9,
                            CategoryId = 2,
                            CoverImagePath = "~/1.jpg",
                            Description = "A novel by Gabriel Garcia Marquez",
                            Edition = "First Edition",
                            ISBN = "9780060883287",
                            Language = "Spanish",
                            PageCount = 417,
                            Price = 120000,
                            PublishYear = "1967",
                            PublisherId = 5,
                            Quantity = 6,
                            Title = "One Hundred Years of Solitude"
                        },
                        new
                        {
                            BookId = 15,
                            AuthorId = 8,
                            CategoryId = 1,
                            CoverImagePath = "~/1.jpg",
                            Description = "A novel by Arundhati Roy",
                            Edition = "First Edition",
                            ISBN = "0812979656",
                            Language = "English",
                            PageCount = 369,
                            Price = 95000,
                            PublishYear = "1997",
                            PublisherId = 1,
                            Quantity = 3,
                            Title = "The God of Small Things"
                        },
                        new
                        {
                            BookId = 16,
                            AuthorId = 4,
                            CategoryId = 3,
                            CoverImagePath = "~/1.jpg",
                            Description = "A dystopian novel by Margaret Atwood",
                            Edition = "First Edition",
                            ISBN = "9780385490818",
                            Language = "English",
                            PageCount = 311,
                            Price = 125000,
                            PublishYear = "1985",
                            PublisherId = 4,
                            Quantity = 7,
                            Title = "The Handmaid's Tale"
                        },
                        new
                        {
                            BookId = 17,
                            AuthorId = 1,
                            CategoryId = 2,
                            CoverImagePath = "~/1.jpg",
                            Description = "A novella by Ernest Hemingway",
                            Edition = "First Edition",
                            ISBN = "0684801221",
                            Language = "English",
                            PageCount = 128,
                            Price = 105000,
                            PublishYear = "1952",
                            PublisherId = 2,
                            Quantity = 2,
                            Title = "The Old Man and the Sea"
                        },
                        new
                        {
                            BookId = 18,
                            AuthorId = 3,
                            CategoryId = 3,
                            CoverImagePath = "~/1.jpg",
                            Description = "A hilarious and inventive science fiction series that has become a beloved classic.",
                            Edition = "First Edition",
                            ISBN = "9780345391803",
                            Language = "English",
                            PageCount = 224,
                            Price = 150000,
                            PublishYear = "1979",
                            PublisherId = 3,
                            Quantity = 5,
                            Title = "The Hitchhiker's Guide to the Galaxy"
                        },
                        new
                        {
                            BookId = 19,
                            AuthorId = 4,
                            CategoryId = 1,
                            CoverImagePath = "~/1.jpg",
                            Description = "One of the most popular and enduring works of fantasy literature.",
                            Edition = "50th Anniversary Edition",
                            ISBN = "9780547928210",
                            Language = "English",
                            PageCount = 1178,
                            Price = 250000,
                            PublishYear = "1954",
                            PublisherId = 3,
                            Quantity = 3,
                            Title = "The Lord of the Rings"
                        },
                        new
                        {
                            BookId = 20,
                            AuthorId = 5,
                            CategoryId = 2,
                            CoverImagePath = "~/1.jpg",
                            Description = "A classic novel of manners that explores themes of love, marriage, and social status.",
                            Edition = "Revised Edition",
                            ISBN = "9780141395203",
                            Language = "English",
                            PageCount = 432,
                            Price = 120000,
                            PublishYear = "1813",
                            PublisherId = 5,
                            Quantity = 8,
                            Title = "Pride and Prejudice"
                        },
                        new
                        {
                            BookId = 21,
                            AuthorId = 7,
                            CategoryId = 4,
                            CoverImagePath = "~/1.jpg",
                            Description = "A thriller that follows symbologist Robert Langdon as he investigates a murder in the Louvre Museum.",
                            Edition = "Special Illustrated Edition",
                            ISBN = "9780307277671",
                            Language = "English",
                            PageCount = 689,
                            Price = 180000,
                            PublishYear = "2003",
                            PublisherId = 4,
                            Quantity = 10,
                            Title = "The Da Vinci Code"
                        },
                        new
                        {
                            BookId = 22,
                            AuthorId = 5,
                            CategoryId = 1,
                            CoverImagePath = "~/1.jpg",
                            Description = "A novel that explores the corruption of youth and the dangers of vanity and decadence.",
                            Edition = "Revised Edition",
                            ISBN = "9780141442464",
                            Language = "English",
                            PageCount = 256,
                            Price = 95000,
                            PublishYear = "1890",
                            PublisherId = 2,
                            Quantity = 6,
                            Title = "The Picture of Dorian Gray"
                        },
                        new
                        {
                            BookId = 23,
                            AuthorId = 8,
                            CategoryId = 2,
                            CoverImagePath = "~/1.jpg",
                            Description = "A magical realist novel that tells the story of the Buendía family over several generations.",
                            Edition = "Revised Edition",
                            ISBN = "9780060883287",
                            Language = "English",
                            PageCount = 422,
                            Price = 160000,
                            PublishYear = "1967",
                            PublisherId = 1,
                            Quantity = 4,
                            Title = "One Hundred Years of Solitude"
                        });
                });

            modelBuilder.Entity("API.Data.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            Description = "Mystery and crime novels",
                            Name = "Detective"
                        },
                        new
                        {
                            CategoryId = 2,
                            Description = "Books about art, artists and art history",
                            Name = "Art"
                        },
                        new
                        {
                            CategoryId = 3,
                            Description = "Books about natural science, mathematics, and technology",
                            Name = "Science"
                        },
                        new
                        {
                            CategoryId = 4,
                            Description = "Books about imaginary people and events",
                            Name = "Fiction"
                        },
                        new
                        {
                            CategoryId = 5,
                            Description = "Books about historical events and figures",
                            Name = "History"
                        });
                });

            modelBuilder.Entity("API.Data.Instance", b =>
                {
                    b.Property<int>("InstanceID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InstanceID"));

                    b.Property<string>("BookCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.HasKey("InstanceID");

                    b.HasIndex("BookId");

                    b.HasIndex("StatusId");

                    b.ToTable("Instances");
                });

            modelBuilder.Entity("API.Data.Loan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("BorrowedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("InstanceId")
                        .HasColumnType("int");

                    b.Property<int>("ReaderId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ReturnedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("InstanceId");

                    b.HasIndex("ReaderId");

                    b.ToTable("Loans");
                });

            modelBuilder.Entity("API.Data.Publisher", b =>
                {
                    b.Property<int>("PublisherId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PublisherId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("PublisherId");

                    b.ToTable("Publishers");

                    b.HasData(
                        new
                        {
                            PublisherId = 1,
                            Description = "One of the largest and most prestigious English-language publishers.",
                            Name = "Penguin Books"
                        },
                        new
                        {
                            PublisherId = 2,
                            Description = "An American publishing company, one of the world's largest.",
                            Name = "HarperCollins"
                        },
                        new
                        {
                            PublisherId = 3,
                            Description = "An American book publisher and the largest general-interest paperback publisher in the world.",
                            Name = "Random House"
                        },
                        new
                        {
                            PublisherId = 4,
                            Description = "An American publishing company and a division of ViacomCBS.",
                            Name = "Simon & Schuster"
                        },
                        new
                        {
                            PublisherId = 5,
                            Description = "A global trade publishing company, owned by Holtzbrinck Publishing Group.",
                            Name = "Macmillan Publishers"
                        });
                });

            modelBuilder.Entity("API.Data.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleId"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            RoleId = 1,
                            Name = "Reader"
                        },
                        new
                        {
                            RoleId = 2,
                            Name = "Librarian"
                        });
                });

            modelBuilder.Entity("API.Data.Status", b =>
                {
                    b.Property<int>("StatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StatusId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StatusId");

                    b.ToTable("Statuses");

                    b.HasData(
                        new
                        {
                            StatusId = 1,
                            Description = "Available"
                        },
                        new
                        {
                            StatusId = 2,
                            Description = "On Loan"
                        },
                        new
                        {
                            StatusId = 3,
                            Description = "Broken"
                        });
                });

            modelBuilder.Entity("API.Data.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");

                    b.HasDiscriminator<string>("Discriminator").HasValue("User");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("API.Data.Librarian", b =>
                {
                    b.HasBaseType("API.Data.User");

                    b.HasDiscriminator().HasValue("Librarian");
                });

            modelBuilder.Entity("API.Data.Reader", b =>
                {
                    b.HasBaseType("API.Data.User");

                    b.HasDiscriminator().HasValue("Reader");
                });

            modelBuilder.Entity("API.Data.Book", b =>
                {
                    b.HasOne("API.Data.Author", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Data.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Data.Publisher", "Publisher")
                        .WithMany()
                        .HasForeignKey("PublisherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Category");

                    b.Navigation("Publisher");
                });

            modelBuilder.Entity("API.Data.Instance", b =>
                {
                    b.HasOne("API.Data.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Data.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("API.Data.Loan", b =>
                {
                    b.HasOne("API.Data.Instance", "Instance")
                        .WithMany()
                        .HasForeignKey("InstanceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Data.Reader", "Reader")
                        .WithMany()
                        .HasForeignKey("ReaderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Instance");

                    b.Navigation("Reader");
                });

            modelBuilder.Entity("API.Data.User", b =>
                {
                    b.HasOne("API.Data.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });
#pragma warning restore 612, 618
        }
    }
}
