﻿// <auto-generated />
using System;
using API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230410191609_lib")]
    partial class lib
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("API.Data.Book", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("AuthorID")
                        .HasColumnType("int");

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<string>("ContentType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("CoverImage")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Edition")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Language")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PageCount")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<string>("PublishYear")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)");

                    b.Property<int>("PublisherID")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("ID");

                    b.HasIndex("AuthorID");

                    b.HasIndex("CategoryID");

                    b.HasIndex("PublisherID");

                    b.ToTable("Book");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            AuthorID = 2,
                            CategoryID = 1,
                            Description = "Unknown",
                            Edition = "Latest Edition",
                            ISBN = "ISBN",
                            Language = "English",
                            PageCount = 1,
                            Price = 1000,
                            PublishYear = "2023",
                            PublisherID = 3,
                            Quantity = 1,
                            Title = "To Kill a Mockingbird"
                        },
                        new
                        {
                            ID = 2,
                            AuthorID = 4,
                            CategoryID = 2,
                            Description = "Unknown",
                            Edition = "Latest Edition",
                            ISBN = "ISBN",
                            Language = "English",
                            PageCount = 1,
                            Price = 1000,
                            PublishYear = "2023",
                            PublisherID = 1,
                            Quantity = 1,
                            Title = "The Great Gatsby"
                        },
                        new
                        {
                            ID = 3,
                            AuthorID = 6,
                            CategoryID = 3,
                            Description = "Unknown",
                            Edition = "Latest Edition",
                            ISBN = "ISBN",
                            Language = "English",
                            PageCount = 1,
                            Price = 1000,
                            PublishYear = "2023",
                            PublisherID = 4,
                            Quantity = 1,
                            Title = "Animal Farm"
                        },
                        new
                        {
                            ID = 4,
                            AuthorID = 7,
                            CategoryID = 2,
                            Description = "Unknown",
                            Edition = "Latest Edition",
                            ISBN = "ISBN",
                            Language = "English",
                            PageCount = 1,
                            Price = 1000,
                            PublishYear = "2023",
                            PublisherID = 2,
                            Quantity = 1,
                            Title = "Nineteen Eighty-Four"
                        },
                        new
                        {
                            ID = 5,
                            AuthorID = 8,
                            CategoryID = 1,
                            Description = "Unknown",
                            Edition = "Latest Edition",
                            ISBN = "ISBN",
                            Language = "English",
                            PageCount = 1,
                            Price = 1000,
                            PublishYear = "2023",
                            PublisherID = 5,
                            Quantity = 1,
                            Title = "The Catcher in the Rye"
                        });
                });

            modelBuilder.Entity("API.Data.BookAuthor", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Bio")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("ID");

                    b.ToTable("BookAuthor");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Bio = "Unknow",
                            Name = "Albert Einstein"
                        },
                        new
                        {
                            ID = 2,
                            Bio = "Unknow",
                            Name = "Jane Austen"
                        },
                        new
                        {
                            ID = 3,
                            Bio = "Unknow",
                            Name = "Stephen Hawking"
                        },
                        new
                        {
                            ID = 4,
                            Bio = "Unknow",
                            Name = "J.K. Rowling"
                        },
                        new
                        {
                            ID = 5,
                            Bio = "Unknow",
                            Name = "Agatha Christie"
                        },
                        new
                        {
                            ID = 6,
                            Bio = "Unknow",
                            Name = "Neil deGrasse Tyson"
                        },
                        new
                        {
                            ID = 7,
                            Bio = "Unknow",
                            Name = "Isaac Asimov"
                        },
                        new
                        {
                            ID = 8,
                            Bio = "Unknow",
                            Name = "Dan Brown"
                        },
                        new
                        {
                            ID = 9,
                            Bio = "Unknow",
                            Name = "Michelle Obama"
                        });
                });

            modelBuilder.Entity("API.Data.BookCategory", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("BookCategory");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Name = "Detective"
                        },
                        new
                        {
                            ID = 2,
                            Name = "Art"
                        },
                        new
                        {
                            ID = 3,
                            Name = "Science"
                        });
                });

            modelBuilder.Entity("API.Data.BookInstance", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("BookCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BookID")
                        .HasColumnType("int");

                    b.Property<int>("StatusID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("BookID");

                    b.HasIndex("StatusID");

                    b.ToTable("BookInstance");
                });

            modelBuilder.Entity("API.Data.BookPublisher", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("BookPublishers");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Description = "One of the largest and most prestigious English-language publishers.",
                            Name = "Penguin Books"
                        },
                        new
                        {
                            ID = 2,
                            Description = "An American publishing company, one of the world's largest.",
                            Name = "HarperCollins"
                        },
                        new
                        {
                            ID = 3,
                            Description = "An American book publisher and the largest general-interest paperback publisher in the world.",
                            Name = "Random House"
                        },
                        new
                        {
                            ID = 4,
                            Description = "An American publishing company and a division of ViacomCBS.",
                            Name = "Simon & Schuster"
                        },
                        new
                        {
                            ID = 5,
                            Description = "A global trade publishing company, owned by Holtzbrinck Publishing Group.",
                            Name = "Macmillan Publishers"
                        });
                });

            modelBuilder.Entity("API.Data.BookStatus", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("BookStatus");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Name = "Available"
                        },
                        new
                        {
                            ID = 2,
                            Name = "On Loan"
                        },
                        new
                        {
                            ID = 3,
                            Name = "Broken"
                        });
                });

            modelBuilder.Entity("API.Data.Loan", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("BookCode")
                        .HasColumnType("int");

                    b.Property<DateTime>("BorrowedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ReaderID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ReturnedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.HasIndex("BookCode");

                    b.HasIndex("ReaderID");

                    b.ToTable("Loan");
                });

            modelBuilder.Entity("API.Data.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleID")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("RoleID");

                    b.ToTable("User");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("API.Data.UserRole", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("UserRole");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Name = "Reader"
                        },
                        new
                        {
                            ID = 2,
                            Name = "Librarian"
                        });
                });

            modelBuilder.Entity("API.Data.Librarian", b =>
                {
                    b.HasBaseType("API.Data.User");

                    b.ToTable("Librarian");
                });

            modelBuilder.Entity("API.Data.Reader", b =>
                {
                    b.HasBaseType("API.Data.User");

                    b.ToTable("Reader");
                });

            modelBuilder.Entity("API.Data.Book", b =>
                {
                    b.HasOne("API.Data.BookAuthor", "BookAuthor")
                        .WithMany("Books")
                        .HasForeignKey("AuthorID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("API.Data.BookCategory", "BookCategory")
                        .WithMany("Books")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("API.Data.BookPublisher", "BookPublisher")
                        .WithMany("Books")
                        .HasForeignKey("PublisherID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("BookAuthor");

                    b.Navigation("BookCategory");

                    b.Navigation("BookPublisher");
                });

            modelBuilder.Entity("API.Data.BookInstance", b =>
                {
                    b.HasOne("API.Data.Book", "Book")
                        .WithMany("BookInstances")
                        .HasForeignKey("BookID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("API.Data.BookStatus", "BookStatus")
                        .WithMany("BookInstances")
                        .HasForeignKey("StatusID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("BookStatus");
                });

            modelBuilder.Entity("API.Data.Loan", b =>
                {
                    b.HasOne("API.Data.BookInstance", "BookInstance")
                        .WithMany("Loans")
                        .HasForeignKey("BookCode")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("API.Data.Reader", "Reader")
                        .WithMany("Loans")
                        .HasForeignKey("ReaderID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("BookInstance");

                    b.Navigation("Reader");
                });

            modelBuilder.Entity("API.Data.User", b =>
                {
                    b.HasOne("API.Data.UserRole", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("API.Data.Librarian", b =>
                {
                    b.HasOne("API.Data.User", null)
                        .WithOne()
                        .HasForeignKey("API.Data.Librarian", "ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("API.Data.Reader", b =>
                {
                    b.HasOne("API.Data.User", null)
                        .WithOne()
                        .HasForeignKey("API.Data.Reader", "ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("API.Data.Book", b =>
                {
                    b.Navigation("BookInstances");
                });

            modelBuilder.Entity("API.Data.BookAuthor", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("API.Data.BookCategory", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("API.Data.BookInstance", b =>
                {
                    b.Navigation("Loans");
                });

            modelBuilder.Entity("API.Data.BookPublisher", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("API.Data.BookStatus", b =>
                {
                    b.Navigation("BookInstances");
                });

            modelBuilder.Entity("API.Data.UserRole", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("API.Data.Reader", b =>
                {
                    b.Navigation("Loans");
                });
#pragma warning restore 612, 618
        }
    }
}