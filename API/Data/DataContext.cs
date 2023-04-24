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
        public DbSet<Loan> Loans { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        #endregion

        protected readonly IConfiguration Configuration;
        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString("IceLibraryConnectionString"));
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
                new Role { RoleId = 2, Name = "Librarian" },
                new Role { RoleId = 3, Name = "Admin" }
                );

            modelBuilder.Entity<User>().HasData(
                new User { UserId = 1, Name = "Ice", Email = "ice@gmail.com", Username = "admin", Password = "admin", RoleId = 3 },
                new User { UserId = 2, Name = "Ceri", Email = "ceri@gmail.com", Username = "librarian", Password = "librarian", RoleId = 2 },
                new User { UserId = 3, Name = "User1", Email = "user1@gmail.com", Username = "user1", Password = "user1", RoleId = 1 },
                new User { UserId = 4, Name = "User2", Email = "user2@gmail.com", Username = "user2", Password = "user2", RoleId = 1 },
                new User { UserId = 5, Name = "User3", Email = "user3@gmail.com", Username = "user3", Password = "user3", RoleId = 1 }
                );

            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Detective", Description = "Mystery and crime novels" },
                new Category { CategoryId = 2, Name = "Art", Description = "Books about art, artists and art history" },
                new Category { CategoryId = 3, Name = "Science", Description = "Books about natural science, mathematics, and technology" },
                new Category { CategoryId = 4, Name = "Fiction", Description = "Books about imaginary people and events" },
                new Category { CategoryId = 5, Name = "History", Description = "Books about historical events and figures" },
                new Category { CategoryId = 6, Name = "Biography", Description = "Books about people's lives and experiences" },
                new Category { CategoryId = 7, Name = "Travel", Description = "Books about travel destinations and experiences" },
                new Category { CategoryId = 8, Name = "Business", Description = "Books about business management, entrepreneurship, and finance" },
                new Category { CategoryId = 9, Name = "Cooking", Description = "Books about cooking techniques, recipes, and ingredients" },
                new Category { CategoryId = 10, Name = "Self-help", Description = "Books about personal development, motivation, and success" }
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
                new Author { AuthorId = 9, Name = "Michelle Obama", Bio = "American lawyer and author who served as the First Lady of the United States from 2009 to 2017" },
                new Author { AuthorId = 10, Name = "George Orwell", Bio = "English novelist, essayist, journalist and critic, best known for his dystopian novel 1984 and the allegorical novella Animal Farm" }
            );

            modelBuilder.Entity<Publisher>().HasData(
                new Publisher { PublisherId = 1, Name = "Penguin Books", Description = "One of the largest and most prestigious English-language publishers." },
                new Publisher { PublisherId = 2, Name = "HarperCollins", Description = "An American publishing company, one of the world's largest." },
                new Publisher { PublisherId = 3, Name = "Random House", Description = "An American book publisher and the largest general-interest paperback publisher in the world." },
                new Publisher { PublisherId = 4, Name = "Simon & Schuster", Description = "An American publishing company and a division of ViacomCBS." },
                new Publisher { PublisherId = 5, Name = "Macmillan Publishers", Description = "A global trade publishing company, owned by Holtzbrinck Publishing Group." },
                new Publisher { PublisherId = 6, Name = "Oxford University Press", Description = "The largest university press in the world, publishing in 70 languages and 190 countries." },
                new Publisher { PublisherId = 7, Name = "Cambridge University Press", Description = "The publishing business of the University of Cambridge, one of the world's oldest universities." },
                new Publisher { PublisherId = 8, Name = "Springer Nature", Description = "A global academic publishing company, the product of a merger between Springer Science+Business Media and Nature Publishing Group." },
                new Publisher { PublisherId = 9, Name = "Hachette Livre", Description = "The world's third-largest trade book publisher, headquartered in France." },
                new Publisher { PublisherId = 10, Name = "Bloomsbury Publishing", Description = "A British independent publishing house, best known for publishing the Harry Potter series." }
            );

            modelBuilder.Entity<Book>().HasData(
                new Book { BookId = 1, AuthorId = 1, CategoryId = 3, PublisherId = 1, Title = "Relativity: The Special and General Theory", Description = "A theoretical physicist's introduction to the theory of relativity", PublishYear = "1916", Price = 150000, Quantity = 5, Language = "English", PageCount = 160, Edition = "1st edition" },
                new Book { BookId = 2, AuthorId = 2, CategoryId = 4, PublisherId = 2, Title = "Pride and Prejudice", Description = "A romantic novel about the pride and prejudices of the British upper class in the early 19th century", PublishYear = "1813", Price = 100000, Quantity = 3, Language = "English", PageCount = 279, Edition = "2nd edition" },
                new Book { BookId = 3, AuthorId = 3, CategoryId = 3, PublisherId = 3, Title = "A Brief History of Time", Description = "A popular science book about cosmology and the universe", PublishYear = "1988", Price = 120000, Quantity = 7, Language = "English", PageCount = 212, Edition = "10th anniversary edition" },
                new Book { BookId = 4, AuthorId = 4, CategoryId = 4, PublisherId = 4, Title = "Harry Potter and the Philosopher's Stone", Description = "The first book in the Harry Potter series, a fantasy novel about a young wizard and his friends at Hogwarts School of Witchcraft and Wizardry", PublishYear = "1997", Price = 130000, Quantity = 2, Language = "English", PageCount = 223, Edition = "1st edition" },
                new Book { BookId = 5, AuthorId = 5, CategoryId = 1, PublisherId = 1, Title = "Murder on the Orient Express", Description = "A detective novel about a murder on a train, featuring famous detective Hercule Poirot", PublishYear = "1934", Price = 110000, Quantity = 4, Language = "English", PageCount = 256, Edition = "2nd edition" },
                new Book { BookId = 6, AuthorId = 6, CategoryId = 3, PublisherId = 5, Title = "Astrophysics for People in a Hurry", Description = "An introduction to astrophysics for laypeople", PublishYear = "2017", Price = 140000, Quantity = 6, Language = "English", PageCount = 224, Edition = "1st edition" },
                new Book { BookId = 7, AuthorId = 7, CategoryId = 2, PublisherId = 2, Title = "The Annotated Gulliver's Travels", Description = "An annotated edition of the classic satire by Jonathan Swift", PublishYear = "1960", Price = 105000, Quantity = 1, Language = "English", PageCount = 522, Edition = "3rd edition" },
                new Book { BookId = 8, AuthorId = 8, CategoryId = 1, PublisherId = 4, Title = "The Da Vinci Code", Description = "A thriller novel by American author Dan Brown", PublishYear = "2003", Price = 150000, Quantity = 10, Language = "English", PageCount = 481, Edition = "First edition" },
                new Book { BookId = 9, AuthorId = 9, CategoryId = 5, PublisherId = 3, Title = "Becoming", Description = "An autobiography by Michelle Obama", PublishYear = "2018", Price = 250000, Quantity = 8, Language = "English", PageCount = 426, Edition = "First edition" },
                new Book { BookId = 10, AuthorId = 9, CategoryId = 4, PublisherId = 1, Title = "The Hobbit", Description = "A children's fantasy novel by J.R.R. Tolkien", PublishYear = "1937", Price = 120000, Quantity = 12, Language = "English", PageCount = 310, Edition = "Revised edition" },
                new Book { BookId = 11, AuthorId = 3, CategoryId = 3, PublisherId = 2, Title = "A Brief History of Time", Description = "A popular science book by British physicist Stephen Hawking", PublishYear = "1988", Price = 180000, Quantity = 5, Language = "English", PageCount = 212, Edition = "First edition" },
                new Book { BookId = 12, AuthorId = 2, CategoryId = 4, PublisherId = 5, Title = "Pride and Prejudice", Description = "A romantic novel by English author Jane Austen", PublishYear = "1813", Price = 90000, Quantity = 15, Language = "English", PageCount = 279, Edition = "First edition" },
                new Book { BookId = 13, AuthorId = 3, CategoryId = 3, PublisherId = 4, Title = "The Grand Design", Description = "A popular-science book by British physicists Stephen Hawking and Leonard Mlodinow", PublishYear = "2010", Price = 200000, Quantity = 3, Language = "English", PageCount = 198, Edition = "First edition" },
                new Book { BookId = 14, AuthorId = 5, CategoryId = 1, PublisherId = 1, Title = "The Murder of Roger Ackroyd", Description = "A detective novel by Agatha Christie", PublishYear = "1926", Price = 85000, Quantity = 6, Language = "English", PageCount = 288, Edition = "First edition" },
                new Book { BookId = 15, AuthorId = 8, CategoryId = 4, PublisherId = 2, Title = "The Fault in Our Stars", Description = "A novel by John Green", PublishYear = "2012", Price = 170000, Quantity = 9, Language = "English", PageCount = 313, Edition = "First edition" }
                );

            modelBuilder.Entity<Instance>().HasData(
                new Instance { InstanceID = 1, BookId = 1, StatusId = 1}
                );
            #endregion
        }
    }
}
