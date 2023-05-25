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
                new User { Id = 1, Name = "Admin Name", Email = "admin@gmail.com", Username = "admin", Password = "Admin123", RoleId = 3 },
                new User { Id = 2, Name = "Librarian Name", Email = "librarian@gmail.com", Username = "librarian", Password = "Lib123", RoleId = 2 },
                new User { Id = 3, Name = "User1 Name", Email = "user1@gmail.com", Username = "user1", Password = "User1", RoleId = 1 },
                new User { Id = 4, Name = "User2 Name", Email = "user2@gmail.com", Username = "user2", Password = "User2", RoleId = 1 },
                new User { Id = 5, Name = "User3 Name", Email = "user3@gmail.com", Username = "user3", Password = "User3", RoleId = 1 },
                new User { Id = 6, Name = "UserNotActive Name", Email = "notactiveuser@gmail.com", Username = "usernotactive", Password = "User123", RoleId = 1, IsLocked = true }
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
                const int bookCount = 1000;
                Random random = new();
                const int length = 12;
                const string chars = "0123456789";

                List<string> languages = new()
                {
                    "English", "Spanish", "French", "German", "Italian", "Japanese", "Chinese", "Russian", "Arabic", "Portuguese"
                };
                List<string> editions = new()
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
                    string[] descriptionPhrases = {
                        "A gripping tale of", "An enchanting exploration into", "A thrilling journey through",
                        "A captivating story about", "An intriguing look at", "A mesmerizing adventure in",
                        "A thought-provoking examination of", "An exhilarating quest to uncover",
                        "A hauntingly beautiful portrayal of", "A fascinating account of",
                        "A compelling narrative that delves into", "A vivid depiction of",
                        "A heartwarming story that celebrates", "An epic saga of",
                        "A poignant reflection on", "A mesmerizing blend of",
                        "A riveting exploration of", "An extraordinary tale of",
                        "A spellbinding odyssey through", "A breathtaking escapade into",
                        "A stunning portrayal of", "An introspective journey through",
                        "A thrilling saga of", "A dazzling tapestry of",
                        "A profound exploration of", "A gripping account of",
                        "A haunting tale of", "A captivating journey into",
                        "A remarkable story that unravels", "An evocative examination of"
                    };

                    string[] themes = {
                        "love and loss", "courage and resilience", "mystery and intrigue",
                        "history and heritage", "friendship and betrayal", "identity and self-discovery",
                        "adventure and discovery", "hope and redemption", "power and corruption",
                        "family and secrets", "nature and the environment", "war and conflict",
                        "art and creativity", "science and innovation", "faith and spirituality",
                        "dreams and aspirations", "justice and injustice", "fate and destiny",
                        "triumph over adversity", "the human condition", "the pursuit of knowledge",
                        "the struggle for freedom", "the meaning of life", "the depths of the human soul",
                        "the clash of civilizations", "the complexity of relationships",
                        "the enigma of existence", "the price of ambition", "the search for truth"
                    };

                    string descriptionPhrase = descriptionPhrases[random.Next(descriptionPhrases.Length)];
                    string theme = themes[random.Next(themes.Length)];

                    string description = $"{descriptionPhrase} {theme}.";

                    // Truncate description to a maximum of 200 characters
                    if (description.Length > 200)
                    {
                        description = description.Substring(0, 200);
                    }

                    return description;
                }
                string RandomPublishYear()
                {
                    int randomYear = random.Next(1900, 2001);
                    return randomYear.ToString();
                }
                string RandomTitle()
                {
                    string[] words = { "The", "Adventures", "Journey", "Mystery", "Secrets", "Lost", "Discovery",
                           "Forgotten", "Chaos", "Whisper", "Silent", "Echoes", "Shadow", "Eternal",
                           "Fire", "Ice", "Storm", "Twilight", "Moonlight", "Starlight", "Dreams",
                           "Reflections", "Enigma", "Serenity", "Endless", "Infinite", "Captive",
                           "Beyond", "Crimson", "Golden", "Silver", "Scarlet", "Amber", "Emerald",
                           "Obsidian", "Opal", "Sapphire", "Ruby", "Diamond", "Amethyst", "Topaz",
                           "Midnight", "Sunrise", "Sunset", "Dusk", "Dawn", "Legacy", "Destiny",
                           "Quest", "Fate", "Legend", "Tales", "Whispers", "Chronicles", "Visions",
                           "Essence", "Labyrinth", "Myth", "Realm", "Wanderer", "Luminary", "Oracle",
                           "Puzzle", "Conundrum", "Paradox", "Inception", "Reflection", "Illusion",
                           "Imagination", "Muse", "Voyage", "Odyssey", "Prophecy", "Enchantment",
                           "Suspicion", "Betrayal", "Revelation", "Obsession", "Desire", "Passion",
                           "Yearning", "Temptation", "Sacrifice", "Perception", "Deception",
                           "Whirlwind", "Phoenix", "Mirage", "Escape", "Forgiveness", "Retribution",
                           "Resurrection", "Purgatory", "Salvation", "Sanctuary", "Genesis",
                           "Apocalypse", "Eclipse" };

                    // Generate a random title by selecting random words
                    string title = "";

                    for (int i = 0; i < 3; i++)
                    {
                        int index = random.Next(words.Length);
                        string word = words[index];

                        title += word + " ";
                    }

                    title = title.Trim(); // Remove trailing whitespace

                    return title;
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
                int[] imagePathNum = RandomNumImg(bookCount);
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
