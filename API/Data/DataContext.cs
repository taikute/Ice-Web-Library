using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<BookCategory> Categories { get; set; }
        public DbSet<BookAuthor> Authors { get; set; }
        public DbSet<BookStatus> Statuss { get; set; }
        public DbSet<Reader> Readers { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<Librarian> Librarian { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> Roles { get; set; }

        //public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        protected readonly IConfiguration Configuration;
        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sql server with connection string from app settings
            options.UseSqlServer(Configuration.GetConnectionString("MyConnectionString"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region AddRelationShip
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Category)
                .WithMany(c => c.Books)
                .HasForeignKey(b => b.CategoryID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Book>()
                .HasOne(b => b.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(b => b.AuthorID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Book>()
                .HasOne(b => b.Status)
                .WithMany(a => a.Books)
                .HasForeignKey(b => b.StatusID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Loan>()
                .HasOne(l => l.Book)
                .WithMany(b => b.Loans)
                .HasForeignKey(l => l.BookID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Loan>()
                .HasOne(l => l.Reader)
                .WithMany(r => r.Loans)
                .HasForeignKey(l => l.ReaderID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .HasOne(l => l.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(l => l.RoleID)
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

            modelBuilder.Entity<Book>().HasData(
                new Book { ID = 1, Title = "The Da Vinci Code", AuthorID = 8, CategoryID = 1, StatusID = 1 },
                new Book { ID = 2, Title = "The Hitchhiker's Guide to the Galaxy", AuthorID = 3, CategoryID = 3, StatusID = 1 },
                new Book { ID = 3, Title = "Pride and Prejudice", AuthorID = 2, CategoryID = 2, StatusID = 1 }
                );

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
            #endregion
        }
    }
}
