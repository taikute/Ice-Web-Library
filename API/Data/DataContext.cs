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
                new Status { Id = 1, Name = "Available" },
                new Status { Id = 2, Name = "On Loan" },
                new Status { Id = 3, Name = "Broken or Lost" }
                );

            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Name = "Reader" },
                new Role { Id = 2, Name = "Librarian" },
                new Role { Id = 3, Name = "Admin" }
                );

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Name = "Admin Name", Email = "admin@gmail.com", Username = "admin", Password = "admin", RoleId = 3 },
                new User { Id = 2, Name = "Librarian Name", Email = "librarian@gmail.com", Username = "librarian", Password = "librarian", RoleId = 2 },
                new User { Id = 3, Name = "User1 Name", Email = "user1@gmail.com", Username = "user1", Password = "user1", RoleId = 1 },
                new User { Id = 4, Name = "User2 Name", Email = "user2@gmail.com", Username = "user2", Password = "user2", RoleId = 1 },
                new User { Id = 5, Name = "User3 Name", Email = "user3@gmail.com", Username = "user3", Password = "user3", RoleId = 1 }
                );

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Detective", Description = "Mystery and crime novels" },
                new Category { Id = 2, Name = "Art", Description = "Books about art, artists and art history" },
                new Category { Id = 3, Name = "Science", Description = "Books about natural science, mathematics, and technology" },
                new Category { Id = 4, Name = "Fiction", Description = "Books about imaginary people and events" },
                new Category { Id = 5, Name = "History", Description = "Books about historical events and figures" },
                new Category { Id = 6, Name = "Biography", Description = "Books about people's lives and experiences" },
                new Category { Id = 7, Name = "Travel", Description = "Books about travel destinations and experiences" },
                new Category { Id = 8, Name = "Business", Description = "Books about business management, entrepreneurship, and finance" },
                new Category { Id = 9, Name = "Cooking", Description = "Books about cooking techniques, recipes, and ingredients" },
                new Category { Id = 10, Name = "Self-help", Description = "Books about personal development, motivation, and success" }
            );

            modelBuilder.Entity<Author>().HasData(
                new Author { Id = 1, Name = "Albert Einstein", Description = "German physicist and mathematician who developed the theory of relativity" },
                new Author { Id = 2, Name = "Jane Austen", Description = "English novelist known for her works of romantic fiction" },
                new Author { Id = 3, Name = "Stephen Hawking", Description = "English theoretical physicist and cosmologist" },
                new Author { Id = 4, Name = "J.K. Rowling", Description = "British author, philanthropist, film producer, television producer and screenwriter" },
                new Author { Id = 5, Name = "Agatha Christie", Description = "English writer known for her detective novels" },
                new Author { Id = 6, Name = "Neil deGrasse Tyson", Description = "American astrophysicist, planetary scientist, author, and science communicator" },
                new Author { Id = 7, Name = "Isaac Asimov", Description = "American writer and professor of biochemistry" },
                new Author { Id = 8, Name = "Dan Brown", Description = "American author known for his thriller novels" },
                new Author { Id = 9, Name = "Michelle Obama", Description = "American lawyer and author who served as the First Lady of the United States from 2009 to 2017" },
                new Author { Id = 10, Name = "George Orwell", Description = "English novelist, essayist, journalist and critic, best known for his dystopian novel 1984 and the allegorical novella Animal Farm" }
            );

            modelBuilder.Entity<Publisher>().HasData(
                new Publisher { Id = 1, Name = "Penguin Books", Description = "One of the largest and most prestigious English-language publishers." },
                new Publisher { Id = 2, Name = "HarperCollins", Description = "An American publishing company, one of the world's largest." },
                new Publisher { Id = 3, Name = "Random House", Description = "An American book publisher and the largest general-interest paperback publisher in the world." },
                new Publisher { Id = 4, Name = "Simon & Schuster", Description = "An American publishing company and a division of ViacomCBS." },
                new Publisher { Id = 5, Name = "Macmillan Publishers", Description = "A global trade publishing company, owned by Holtzbrinck Publishing Group." },
                new Publisher { Id = 6, Name = "Oxford University Press", Description = "The largest university press in the world, publishing in 70 languages and 190 countries." },
                new Publisher { Id = 7, Name = "Cambridge University Press", Description = "The publishing business of the University of Cambridge, one of the world's oldest universities." },
                new Publisher { Id = 8, Name = "Springer Nature", Description = "A global academic publishing company, the product of a merger between Springer Science+Business Media and Nature Publishing Group." },
                new Publisher { Id = 9, Name = "Hachette Livre", Description = "The world's third-largest trade book publisher, headquartered in France." },
                new Publisher { Id = 10, Name = "Bloomsbury Publishing", Description = "A British independent publishing house, best known for publishing the Harry Potter series." }
            );

            static string RandomIsbn()
            {
                const int length = 12;
                const string chars = "0123456789";
                var random = new Random();
                return new string(Enumerable.Repeat(chars, length)
                  .Select(s => s[random.Next(s.Length)]).ToArray());
            }

            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, AuthorId = 1, CategoryId = 3, PublisherId = 1, ISBN = RandomIsbn(), Title = "Relativity: The Special and General Theory", Description = "A theoretical physicist's introduction to the theory of relativity", PublishYear = "1916", Price = 150000, Quantity = 5, Language = "English", PageCount = 160, Edition = "1st edition" },
                new Book { Id = 2, AuthorId = 2, CategoryId = 4, PublisherId = 2, ISBN = RandomIsbn(), Title = "Pride and Prejudice", Description = "A romantic novel about the pride and prejudices of the British upper class in the early 19th century", PublishYear = "1813", Price = 100000, Quantity = 3, Language = "English", PageCount = 279, Edition = "2nd edition" },
                new Book { Id = 3, AuthorId = 3, CategoryId = 3, PublisherId = 3, ISBN = RandomIsbn(), Title = "A Brief History of Time", Description = "A popular science book about cosmology and the universe", PublishYear = "1988", Price = 120000, Quantity = 7, Language = "English", PageCount = 212, Edition = "10th anniversary edition" },
                new Book { Id = 4, AuthorId = 4, CategoryId = 4, PublisherId = 4, ISBN = RandomIsbn(), Title = "Harry Potter and the Philosopher's Stone", Description = "The first book in the Harry Potter series, a fantasy novel about a young wizard and his friends at Hogwarts School of Witchcraft and Wizardry", PublishYear = "1997", Price = 130000, Quantity = 2, Language = "English", PageCount = 223, Edition = "1st edition" },
                new Book { Id = 5, AuthorId = 5, CategoryId = 1, PublisherId = 1, ISBN = RandomIsbn(), Title = "Murder on the Orient Express", Description = "A detective novel about a murder on a train, featuring famous detective Hercule Poirot", PublishYear = "1934", Price = 110000, Quantity = 4, Language = "English", PageCount = 256, Edition = "2nd edition" },
                new Book { Id = 6, AuthorId = 6, CategoryId = 3, PublisherId = 5, ISBN = RandomIsbn(), Title = "Astrophysics for People in a Hurry", Description = "An introduction to astrophysics for laypeople", PublishYear = "2017", Price = 140000, Quantity = 6, Language = "English", PageCount = 224, Edition = "1st edition" },
                new Book { Id = 7, AuthorId = 7, CategoryId = 2, PublisherId = 2, ISBN = RandomIsbn(), Title = "The Annotated Gulliver's Travels", Description = "An annotated edition of the classic satire by Jonathan Swift", PublishYear = "1960", Price = 105000, Quantity = 1, Language = "English", PageCount = 522, Edition = "3rd edition" },
                new Book { Id = 8, AuthorId = 8, CategoryId = 1, PublisherId = 4, ISBN = RandomIsbn(), Title = "The Da Vinci Code", Description = "A thriller novel by American author Dan Brown", PublishYear = "2003", Price = 150000, Quantity = 10, Language = "English", PageCount = 481, Edition = "First edition" },
                new Book { Id = 9, AuthorId = 9, CategoryId = 5, PublisherId = 3, ISBN = RandomIsbn(), Title = "Becoming", Description = "An autobiography by Michelle Obama", PublishYear = "2018", Price = 250000, Quantity = 8, Language = "English", PageCount = 426, Edition = "First edition" },
                new Book { Id = 10, AuthorId = 9, CategoryId = 4, PublisherId = 1, ISBN = RandomIsbn(), Title = "The Hobbit", Description = "A children's fantasy novel by J.R.R. Tolkien", PublishYear = "1937", Price = 120000, Quantity = 12, Language = "English", PageCount = 310, Edition = "Revised edition" },
                new Book { Id = 11, AuthorId = 3, CategoryId = 3, PublisherId = 2, ISBN = RandomIsbn(), Title = "A Brief History of Time", Description = "A popular science book by British physicist Stephen Hawking", PublishYear = "1988", Price = 180000, Quantity = 5, Language = "English", PageCount = 212, Edition = "First edition" },
                new Book { Id = 12, AuthorId = 2, CategoryId = 4, PublisherId = 5, ISBN = RandomIsbn(), Title = "Pride and Prejudice", Description = "A romantic novel by English author Jane Austen", PublishYear = "1813", Price = 90000, Quantity = 15, Language = "English", PageCount = 279, Edition = "First edition" },
                new Book { Id = 13, AuthorId = 3, CategoryId = 3, PublisherId = 4, ISBN = RandomIsbn(), Title = "The Grand Design", Description = "A popular-science book by British physicists Stephen Hawking and Leonard Mlodinow", PublishYear = "2010", Price = 200000, Quantity = 3, Language = "English", PageCount = 198, Edition = "First edition" },
                new Book { Id = 14, AuthorId = 5, CategoryId = 1, PublisherId = 1, ISBN = RandomIsbn(), Title = "The Murder of Roger Ackroyd", Description = "A detective novel by Agatha Christie", PublishYear = "1926", Price = 85000, Quantity = 6, Language = "English", PageCount = 288, Edition = "First edition" },
                new Book { Id = 15, AuthorId = 8, CategoryId = 4, PublisherId = 2, ISBN = RandomIsbn(), Title = "The Fault in Our Stars", Description = "A novel by John Green", PublishYear = "2012", Price = 170000, Quantity = 9, Language = "English", PageCount = 313, Edition = "First edition" }
                );

            //Add Instances
            int id = 1;
            for (int i = 1; i <= 15; i++)
            {
                for (int j = 1; j <= 10; j++)
                {
                    modelBuilder.Entity<Instance>().HasData(
                        new Instance { Id = id, BookId = i, StatusId = 1 }
                        );
                    id++;
                }
            }
            #endregion
        }
    }
}
