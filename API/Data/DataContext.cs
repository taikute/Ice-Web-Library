using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DataContext : DbContext
    {
        public DbSet<BookPublisher> BookPublishers { get; set; }
        public DbSet<BookInstance> BookInstances { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookCategory> BookCategories { get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }
        public DbSet<BookStatus> BookStatuses { get; set; }
        public DbSet<Reader> Readers { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<Librarian> Librarians { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        //public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        protected readonly IConfiguration Configuration;
        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sql server with connection string from app settings
            options.UseSqlServer(Configuration.GetConnectionString("IceLibraryConnectionString"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region AddRelationShip
            modelBuilder.Entity<Book>()
                .HasOne(b => b.BookPublisher)
                .WithMany(c => c.Books)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Book>()
                .HasOne(b => b.BookCategory)
                .WithMany(c => c.Books)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Book>()
                .HasOne(b => b.BookAuthor)
                .WithMany(a => a.Books)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<BookInstance>()
                .HasOne(b => b.BookStatus)
                .WithMany(a => a.BookInstances)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<BookInstance>()
                .HasOne(b => b.Book)
                .WithMany(a => a.BookInstances)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Loan>()
                .HasOne(l => l.BookInstance)
                .WithMany(b => b.Loans)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Loan>()
                .HasOne(l => l.Reader)
                .WithMany(r => r.Loans)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .HasOne(l => l.Role)
                .WithMany(r => r.Users)
                .OnDelete(DeleteBehavior.Restrict);
            #endregion

            #region AddSeedData
            modelBuilder.Entity<BookStatus>().HasData(
                new BookStatus { ID = 1, Name = "Available" },
                new BookStatus { ID = 2, Name = "On Loan" },
                new BookStatus { ID = 3, Name = "Broken" });

            modelBuilder.Entity<UserRole>().HasData(
                new UserRole { ID = 1, Name = "Reader" },
                new UserRole { ID = 2, Name = "Librarian" });

            modelBuilder.Entity<BookCategory>().HasData(
                new BookCategory { ID = 1, Name = "Detective" },
                new BookCategory { ID = 2, Name = "Art" },
                new BookCategory { ID = 3, Name = "Science" });

            modelBuilder.Entity<BookAuthor>().HasData(
                new BookAuthor { ID = 1, Name = "Albert Einstein" },
                new BookAuthor { ID = 2, Name = "Jane Austen" },
                new BookAuthor { ID = 3, Name = "Stephen Hawking" },
                new BookAuthor { ID = 4, Name = "J.K. Rowling" },
                new BookAuthor { ID = 5, Name = "Agatha Christie" },
                new BookAuthor { ID = 6, Name = "Neil deGrasse Tyson" },
                new BookAuthor { ID = 7, Name = "Isaac Asimov" },
                new BookAuthor { ID = 8, Name = "Dan Brown" },
                new BookAuthor { ID = 9, Name = "Michelle Obama" });

            modelBuilder.Entity<BookPublisher>().HasData(
                new BookPublisher { ID = 1, Name = "Penguin Books", Description = "One of the largest and most prestigious English-language publishers." },
                new BookPublisher { ID = 2, Name = "HarperCollins", Description = "An American publishing company, one of the world's largest." },
                new BookPublisher { ID = 3, Name = "Random House", Description = "An American book publisher and the largest general-interest paperback publisher in the world." },
                new BookPublisher { ID = 4, Name = "Simon & Schuster", Description = "An American publishing company and a division of ViacomCBS." },
                new BookPublisher { ID = 5, Name = "Macmillan Publishers", Description = "A global trade publishing company, owned by Holtzbrinck Publishing Group." }
            );

            modelBuilder.Entity<Book>().HasData(
                new Book { ID = 1, AuthorID = 2, CategoryID = 1, PublisherID = 3, Title = "To Kill a Mockingbird" },
                new Book { ID = 2, AuthorID = 4, CategoryID = 2, PublisherID = 1, Title = "The Great Gatsby" },
                new Book { ID = 3, AuthorID = 6, CategoryID = 3, PublisherID = 4, Title = "Animal Farm" },
                new Book { ID = 4, AuthorID = 7, CategoryID = 2, PublisherID = 2, Title = "Nineteen Eighty-Four" },
                new Book { ID = 5, AuthorID = 8, CategoryID = 1, PublisherID = 5, Title = "The Catcher in the Rye" }
            );

            #endregion
        }
    }
}
