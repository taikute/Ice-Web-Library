﻿using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DataContext : DbContext
    {
        #region DbSet
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Instance> Instances { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Reader> Readers { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<Librarian> Librarians { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        #endregion

        protected readonly IConfiguration Configuration;
        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
            ChangeTracker.LazyLoadingEnabled = true;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString("IceLibraryConnectionString"));
            options.UseLazyLoadingProxies();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region AddSeedData
            modelBuilder.Entity<Status>().HasData(
                new Status { StatusId = 1, Description = "Available" },
                new Status { StatusId = 2, Description = "On Loan" },
                new Status { StatusId = 3, Description = "Broken" });

            modelBuilder.Entity<Role>().HasData(
                new Role { RoleId = 1, Name = "Reader" },
                new Role { RoleId = 2, Name = "Librarian" });

            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Detective" },
                new Category { CategoryId = 2, Name = "Art" },
                new Category { CategoryId = 3, Name = "Science" });

            modelBuilder.Entity<Author>().HasData(
                new Author { AuthorId = 1, Name = "Albert Einstein" },
                new Author { AuthorId = 2, Name = "Jane Austen" },
                new Author { AuthorId = 3, Name = "Stephen Hawking" },
                new Author { AuthorId = 4, Name = "J.K. Rowling" },
                new Author { AuthorId = 5, Name = "Agatha Christie" },
                new Author { AuthorId = 6, Name = "Neil deGrasse Tyson" },
                new Author { AuthorId = 7, Name = "Isaac Asimov" },
                new Author { AuthorId = 8, Name = "Dan Brown" },
                new Author { AuthorId = 9, Name = "Michelle Obama" });

            modelBuilder.Entity<Publisher>().HasData(
                new Publisher { PublisherId = 1, Name = "Penguin Books", Description = "One of the largest and most prestigious English-language publishers." },
                new Publisher { PublisherId = 2, Name = "HarperCollins", Description = "An American publishing company, one of the world's largest." },
                new Publisher { PublisherId = 3, Name = "Random House", Description = "An American book publisher and the largest general-interest paperback publisher in the world." },
                new Publisher { PublisherId = 4, Name = "Simon & Schuster", Description = "An American publishing company and a division of ViacomCBS." },
                new Publisher { PublisherId = 5, Name = "Macmillan Publishers", Description = "A global trade publishing company, owned by Holtzbrinck Publishing Group." });

            modelBuilder.Entity<Book>().HasData(
                new Book { BookId = 1, AuthorId = 2, CategoryId = 1, PublisherId = 3, Title = "To Kill a Mockingbird" },
                new Book { BookId = 2, AuthorId = 4, CategoryId = 2, PublisherId = 1, Title = "The Great Gatsby" },
                new Book { BookId = 3, AuthorId = 6, CategoryId = 3, PublisherId = 4, Title = "Animal Farm" },
                new Book { BookId = 4, AuthorId = 7, CategoryId = 2, PublisherId = 2, Title = "Nineteen Eighty-Four" },
                new Book { BookId = 5, AuthorId = 8, CategoryId = 1, PublisherId = 5, Title = "The Catcher in the Rye" });
            #endregion
        }
    }
}
