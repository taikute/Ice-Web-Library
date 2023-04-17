using Microsoft.EntityFrameworkCore;

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
                new Status { StatusId = 3, Description = "Broken" }
                );

            modelBuilder.Entity<Role>().HasData(
                new Role { RoleId = 1, Name = "Reader" },
                new Role { RoleId = 2, Name = "Librarian" }
                );

            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Detective", Description = "Mystery and crime novels" },
                new Category { CategoryId = 2, Name = "Art", Description = "Books about art, artists and art history" },
                new Category { CategoryId = 3, Name = "Science", Description = "Books about natural science, mathematics, and technology" },
                new Category { CategoryId = 4, Name = "Fiction", Description = "Books about imaginary people and events" },
                new Category { CategoryId = 5, Name = "History", Description = "Books about historical events and figures" }
                );

            modelBuilder.Entity<Author>().HasData(
                new Author { AuthorId = 1, Name = "Albert Einstein", Bio = "German physicist and mathematician who developed the theory of relativity" },
                new Author { AuthorId = 2, Name = "Jane Austen", Bio = "English novelist known for her works of romantic fiction" },
                new Author { AuthorId = 3, Name = "Stephen Hawking", Bio = "English theoretical physicist and cosmologist" },
                new Author { AuthorId = 4, Name = "J.K. Rowling", Bio = "British author, philanthropist, film producer, television producer and screenwriter" },
                new Author { AuthorId = 5, Name = "Agatha Christie", Bio = "English writer known for her detective novels" },
                new Author { AuthorId = 6, Name = "Neil deGrasse Tyson", Bio = "American astrophysicist, planetary scientist, author, and science communicator" },
                new Author { AuthorId = 7, Name = "Isaac Asimov", Bio = "American writer and professor of biochemistry" },
                new Author { AuthorId = 8, Name = "Dan Brown", Bio = "American author known for his thriller novels" },
                new Author { AuthorId = 9, Name = "Michelle Obama", Bio = "American lawyer and author who served as the First Lady of the United States from 2009 to 2017" }
    );

            modelBuilder.Entity<Publisher>().HasData(
                new Publisher { PublisherId = 1, Name = "Penguin Books", Description = "One of the largest and most prestigious English-language publishers." },
                new Publisher { PublisherId = 2, Name = "HarperCollins", Description = "An American publishing company, one of the world's largest." },
                new Publisher { PublisherId = 3, Name = "Random House", Description = "An American book publisher and the largest general-interest paperback publisher in the world." },
                new Publisher { PublisherId = 4, Name = "Simon & Schuster", Description = "An American publishing company and a division of ViacomCBS." },
                new Publisher { PublisherId = 5, Name = "Macmillan Publishers", Description = "A global trade publishing company, owned by Holtzbrinck Publishing Group." });

            modelBuilder.Entity<Book>().HasData(
                new Book { BookId = 1, AuthorId = 2, CategoryId = 1, PublisherId = 3, Title = "To Kill a Mockingbird", Description = "The unforgettable novel of a childhood in a sleepy Southern town and the crisis of conscience that rocked it, To Kill A Mockingbird became both an instant bestseller and a critical success when it was first published in 1960. It went on to win the Pulitzer Prize in 1961 and was later made into an Academy Award-winning film, also a classic.", PublishYear = "1960", Price = 25000, Quantity = 10, ISBN = "0446310786", Language = "English", PageCount = 336, Edition = "1st" },
                new Book { BookId = 2, AuthorId = 4, CategoryId = 2, PublisherId = 1, Title = "The Great Gatsby", Description = "The Great Gatsby is a 1925 novel by American writer F. Scott Fitzgerald. Set in the Jazz Age on Long Island, the novel depicts narrator Nick Carraway's interactions with mysterious millionaire Jay Gatsby and Gatsby's obsession to reunite with his former lover, Daisy Buchanan.", PublishYear = "1925", Price = 20000, Quantity = 15, ISBN = "978-0-7475-8939-6", Language = "English", PageCount = 180, Edition = "1st" },
                new Book { BookId = 3, AuthorId = 6, CategoryId = 3, PublisherId = 4, Title = "Animal Farm", Description = "Animal Farm is an allegorical novella by George Orwell, first published in England on 17 August 1945. The book tells the story of a group of farm animals who rebel against their human farmer, hoping to create a society where the animals can be equal, free, and happy.", PublishYear = "1945", Price = 15000, Quantity = 20, ISBN = "978-0-14-103613-7", Language = "English", PageCount = 112, Edition = "1st" },
                new Book { BookId = 4, AuthorId = 7, CategoryId = 2, PublisherId = 2, Title = "Nineteen Eighty-Four", Description = "Nineteen Eighty-Four is a dystopian novel by English author George Orwell, published in 1949. The novel is set in a totalitarian society where the government has complete control over every aspect of people's lives.", PublishYear = "1949", Price = 18000, Quantity = 25, ISBN = "978-0-452-28424-1", Language = "English", PageCount = 328, Edition = "1st" },
                new Book { BookId = 5, AuthorId = 8, CategoryId = 1, PublisherId = 5, Title = "The Catcher in the Rye", Description = "The story of Holden Caulfield's struggles in New York City after being expelled from his prep school.", PublishYear = "1951", Price = 120000, Quantity = 10, ISBN = "0316769177", Language = "English", PageCount = 277, Edition = "1st" },
                new Book { BookId = 6, AuthorId = 9, CategoryId = 3, PublisherId = 2, Title = "Brave New World", Description = "A dystopian novel set in a future society where people are genetically engineered and conditioned to be happy and conform to social norms.", PublishYear = "1932", Price = 150000, Quantity = 15, ISBN = "0060850523", Language = "English", PageCount = 288, Edition = "1st" },
                new Book { BookId = 7, AuthorId = 1, CategoryId = 2, PublisherId = 1, Title = "Lord of the Flies", Description = "The story of a group of British boys stranded on an uninhabited island and their disastrous attempt to govern themselves.", PublishYear = "1954", Price = 125000, Quantity = 20, ISBN = "0571056865", Language = "English", PageCount = 224, Edition = "1st" },
                new Book { BookId = 8, AuthorId = 3, CategoryId = 1, PublisherId = 3, Title = "Pride and Prejudice", Description = "A novel of manners set in rural England, following the romantic entanglements of the Bennet sisters and their suitors.", PublishYear = "1813", Price = 100000, Quantity = 5, ISBN = "0141439513", Language = "English", PageCount = 480, Edition = "1st" },
                new Book { BookId = 9, AuthorId = 5, CategoryId = 3, PublisherId = 5, Title = "Fahrenheit 451", Description = "A dystopian novel set in a future society where books are outlawed and 'firemen' burn any that are found.", PublishYear = "1953", Price = 130000, Quantity = 12, ISBN = "1451673310", Language = "English", PageCount = 249, Edition = "1st" },
                new Book { BookId = 10, AuthorId = 6, CategoryId = 2, PublisherId = 4, Title = "The Hobbit", Description = "A fantasy novel following the adventures of hobbit Bilbo Baggins as he accompanies a group of dwarves on a quest to reclaim their treasure from a dragon.", PublishYear = "1937", Price = 110000, Quantity = 8, ISBN = "054792822X", Language = "English", PageCount = 310, Edition = "1st" },
                new Book { BookId = 11, AuthorId = 2, CategoryId = 2, PublisherId = 2, Title = "The Sun Also Rises", Description = "A novel about the Lost Generation by Ernest Hemingway", PublishYear = "1926", Price = 150000, Quantity = 5, ISBN = "0743277334", Language = "English", PageCount = 259, Edition = "First Edition" },
                new Book { BookId = 12, AuthorId = 1, CategoryId = 1, PublisherId = 2, Title = "The Hobbit", Description = "A fantasy novel by J.R.R. Tolkien", PublishYear = "1937", Price = 175000, Quantity = 8, ISBN = "9780547928227", Language = "English", PageCount = 310, Edition = "Revised Edition" },
                new Book { BookId = 13, AuthorId = 7, CategoryId = 3, PublisherId = 4, Title = "Brave New World", Description = "A dystopian novel by Aldous Huxley", PublishYear = "1932", Price = 135000, Quantity = 4, ISBN = "0060850523", Language = "English", PageCount = 288, Edition = "First Edition" },
                new Book { BookId = 14, AuthorId = 9, CategoryId = 2, PublisherId = 5, Title = "One Hundred Years of Solitude", Description = "A novel by Gabriel Garcia Marquez", PublishYear = "1967", Price = 120000, Quantity = 6, ISBN = "9780060883287", Language = "Spanish", PageCount = 417, Edition = "First Edition" },
                new Book { BookId = 15, AuthorId = 8, CategoryId = 1, PublisherId = 1, Title = "The God of Small Things", Description = "A novel by Arundhati Roy", PublishYear = "1997", Price = 95000, Quantity = 3, ISBN = "0812979656", Language = "English", PageCount = 369, Edition = "First Edition" },
                new Book { BookId = 16, AuthorId = 4, CategoryId = 3, PublisherId = 4, Title = "The Handmaid's Tale", Description = "A dystopian novel by Margaret Atwood", PublishYear = "1985", Price = 125000, Quantity = 7, ISBN = "9780385490818", Language = "English", PageCount = 311, Edition = "First Edition" },
                new Book { BookId = 17, AuthorId = 1, CategoryId = 2, PublisherId = 2, Title = "The Old Man and the Sea", Description = "A novella by Ernest Hemingway", PublishYear = "1952", Price = 105000, Quantity = 2, ISBN = "0684801221", Language = "English", PageCount = 128, Edition = "First Edition" },
                new Book { BookId = 18, AuthorId = 3, CategoryId = 3, PublisherId = 3, Title = "The Hitchhiker's Guide to the Galaxy", Description = "A hilarious and inventive science fiction series that has become a beloved classic.", PublishYear = "1979", Price = 150000, Quantity = 5, ISBN = "9780345391803", Language = "English", PageCount = 224, Edition = "First Edition" },
                new Book { BookId = 19, AuthorId = 4, CategoryId = 1, PublisherId = 3, Title = "The Lord of the Rings", Description = "One of the most popular and enduring works of fantasy literature.", PublishYear = "1954", Price = 250000, Quantity = 3, ISBN = "9780547928210", Language = "English", PageCount = 1178, Edition = "50th Anniversary Edition" },
                new Book { BookId = 20, AuthorId = 5, CategoryId = 2, PublisherId = 5, Title = "Pride and Prejudice", Description = "A classic novel of manners that explores themes of love, marriage, and social status.", PublishYear = "1813", Price = 120000, Quantity = 8, ISBN = "9780141395203", Language = "English", PageCount = 432, Edition = "Revised Edition" },
                new Book { BookId = 21, AuthorId = 7, CategoryId = 4, PublisherId = 4, Title = "The Da Vinci Code", Description = "A thriller that follows symbologist Robert Langdon as he investigates a murder in the Louvre Museum.", PublishYear = "2003", Price = 180000, Quantity = 10, ISBN = "9780307277671", Language = "English", PageCount = 689, Edition = "Special Illustrated Edition" },
                new Book { BookId = 22, AuthorId = 5, CategoryId = 1, PublisherId = 2, Title = "The Picture of Dorian Gray", Description = "A novel that explores the corruption of youth and the dangers of vanity and decadence.", PublishYear = "1890", Price = 95000, Quantity = 6, ISBN = "9780141442464", Language = "English", PageCount = 256, Edition = "Revised Edition" },
                new Book { BookId = 23, AuthorId = 8, CategoryId = 2, PublisherId = 1, Title = "One Hundred Years of Solitude", Description = "A magical realist novel that tells the story of the Buendía family over several generations.", PublishYear = "1967", Price = 160000, Quantity = 4, ISBN = "9780060883287", Language = "English", PageCount = 422, Edition = "Revised Edition" }
                );
            #endregion
        }
    }
}
