using Microsoft.EntityFrameworkCore;
using System;
using System.Text;

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
                new Category { Id = 9, Name = "Cooking", Description = "Books about cooking techniques, recipes, and ingredients" }
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
                new Author { Id = 9, Name = "Michelle Obama", Description = "American lawyer and author who served as the First Lady of the United States from 2009 to 2017" }
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
                new Publisher { Id = 9, Name = "Hachette Livre", Description = "The world's third-largest trade book publisher, headquartered in France." }
                );

            //Add Book and Instance Data
            {
                Random random = new Random();
                const int length = 12;
                const string chars = "0123456789";
                const int maxCharacterCount = 200;

                List<string> titleWords = new List<string>
                {
                    "The", "Art", "Science", "Adventures", "Secrets", "Mysteries", "Journey", "In", "Into", "Out", "Beyond",
                    "From", "With", "Without", "Life", "World", "Universe", "Quest", "Power", "Legend", "Dreams", "Hope",
                    "Kingdom", "Magic", "Truth", "Wisdom", "Heart", "Soul", "Mind", "Essence", "Eternal", "Lost", "Found",
                    "Heroes", "Dark", "Light", "Chaos", "Order", "Rise", "Fall", "Song", "Echoes", "Whispers", "Silence"
                };
                List<string> descriptionWords = new List<string>
                {
                    "A", "theoretical", "physicist's", "introduction", "to", "the", "theory", "of", "relativity",
                    "exploring", "its", "fundamental", "concepts", "and", "principles", "in", "an", "accessible", "way",
                    "covering", "both", "special", "and", "general", "relativity",
                    "with", "real-world", "examples", "and", "applications",
                    "comprehensive", "and", "insightful", "reading", "for", "anyone", "interested", "in", "the", "subject",
                    "delves", "deep", "into", "the", "mathematical", "framework", "and", "physical", "implications",
                    "provides", "a", "fresh", "perspective", "on", "our", "understanding", "of", "space", "and", "time",
                    "and", "its", "relation", "to", "gravity", "and", "the", "structure", "of", "the", "universe"
                };
                List<string> languages = new List<string>
                {
                    "English", "Spanish", "French", "German", "Italian", "Japanese", "Chinese", "Russian", "Arabic", "Portuguese"
                };
                List<string> editions = new List<string>
                {
                    "1st edition", "2nd edition", "3rd edition", "4th edition", "5th edition", "Special edition", "Collector's edition"
                };

                string RandomIsbn()
                {
                    return new string(Enumerable.Repeat(chars, length)
                        .Select(s => s[random.Next(s.Length)]).ToArray());
                }
                int RandomNext(int num)
                {
                    return random.Next(1, num + 1);
                }
                int RandomPrice()
                {
                    return RandomNext(4) * 50000;
                }
                string RandomDescription()
                {
                    StringBuilder descriptionBuilder = new StringBuilder();
                    int currentCharacterCount = 0;

                    while (currentCharacterCount < maxCharacterCount)
                    {
                        string randomWord = descriptionWords[random.Next(descriptionWords.Count)];

                        if (currentCharacterCount + randomWord.Length + 1 <= maxCharacterCount)
                        {
                            descriptionBuilder.Append(randomWord).Append(" ");
                            currentCharacterCount += randomWord.Length + 1;
                        }
                        else
                        {
                            break;
                        }
                    }

                    string randomDescription = descriptionBuilder.ToString().TrimEnd();
                    return randomDescription;
                }
                string RandomPublishYear()
                {
                    int randomYear = random.Next(1900, 2001);
                    return randomYear.ToString();
                }
                string RandomTitle()
                {
                    StringBuilder titleBuilder = new StringBuilder();
                    int currentLength = 0;

                    while (currentLength < 20)
                    {
                        string randomWord = titleWords[random.Next(titleWords.Count)];

                        if (currentLength + randomWord.Length + 1 <= 20)
                        {
                            if (currentLength > 0)
                            {
                                titleBuilder.Append(' ');
                                currentLength++;
                            }
                            titleBuilder.Append(randomWord);
                            currentLength += randomWord.Length;
                        }
                        else
                        {
                            break;
                        }
                    }

                    string bookTitle = titleBuilder.ToString();
                    return bookTitle;
                }
                string RandomLanguage()
                {
                    int randomIndex = random.Next(languages.Count);
                    string randomLanguage = languages[randomIndex];
                    return randomLanguage;
                }
                string RandomEdition()
                {
                    int randomIndex = random.Next(editions.Count);
                    string randomEdition = editions[randomIndex];
                    return randomEdition;
                }
                int[] RandomNumImg(int count)
                {
                    int[] arr = new int[count];
                    int[] group6 = new int[6];
                    for (int i = 0; i < count; i++)
                    {
                        int num = RandomNext(25);
                        while (group6.Contains(num))
                        {
                            num = RandomNext(25);
                        }
                        group6[i % 6] = num;
                        arr[i] = num;
                    }
                    return arr;
                }


                int instanceId = 1;
                int[] imagePathNum = RandomNumImg(300);
                for (int i = 0; i < imagePathNum.Length; i++)
                {
                    modelBuilder.Entity<Book>().HasData(new Book
                    {
                        Id = i + 1,
                        AuthorId = RandomNext(9),
                        CategoryId = RandomNext(9),
                        PublisherId = RandomNext(9),
                        ISBN = RandomIsbn(),
                        Title = RandomTitle(),
                        Description = RandomDescription(),
                        PublishYear = RandomPublishYear(),
                        Price = RandomPrice(),
                        Quantity = 10,
                        Language = RandomLanguage(),
                        PageCount = RandomNext(999),
                        Edition = RandomEdition(),
                        CoverImagePath = $"~/{imagePathNum[i]}.jpg"
                    });

                    int instanceQuantity = RandomNext(9);
                    for (int j = 1; j <= instanceQuantity; j++)
                    {
                        modelBuilder.Entity<Instance>().HasData(
                            new Instance { Id = instanceId, BookId = i + 1, StatusId = 1 }
                            );
                        instanceId++;
                    }
                }
            }
            #endregion
        }
    }
}
