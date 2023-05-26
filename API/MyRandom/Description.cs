using System.Text;

namespace API.MyRandom
{
    public static class Description
    {
        private static readonly Random random = new Random();

        private static List<string> adjectives = new List<string>()
    {
        "captivating", "thought-provoking", "exhilarating", "compelling", "insightful",
        "enchanting", "gripping", "provocative", "inspiring", "mesmerizing",
        "engaging", "mind-bending", "poignant", "suspenseful", "innovative",
        "evocative", "heartwarming", "powerful", "fascinating", "haunting",
        "thrilling", "uplifting", "intense", "magical", "rousing",
        "breathtaking", "unforgettable", "profound", "dynamic", "mesmerizing"
        // Add more adjectives here
    };

        private static List<string> genres = new List<string>()
    {
        "mystery", "romance", "science fiction", "fantasy", "thriller",
        "historical fiction", "biography", "self-help", "horror", "adventure",
        "young adult", "dystopian", "contemporary", "crime", "humor",
        "memoir", "spirituality", "classic", "graphic novel", "travel",
        "philosophy", "satire", "western", "children's", "paranormal"
        // Add more genres here
    };

        private static List<string> authors = new List<string>()
    {
        "John Smith", "Emily Johnson", "Michael Davis", "Emma Wilson", "David Thompson",
        "Olivia Anderson", "James Martinez", "Sophia Taylor", "Daniel Clark", "Isabella White",
        "Alexander Harris", "Ava Martin", "Benjamin Lewis", "Charlotte Turner", "Ethan Walker",
        "Grace Scott", "Henry Hall", "Lily Parker", "Matthew Allen", "Nora Young",
        "Oliver Turner", "Scarlett Brown", "Gabriel Adams", "Hannah Roberts", "William Hall"
        // Add more authors here
    };

        private static List<string> verbs = new List<string>()
    {
        "explore", "discover", "uncover", "navigate", "experience",
        "journey through", "delve into", "confront", "reveal", "conquer",
        "immerse in", "escape to", "witness", "encounter", "embrace",
        "grapple with", "challenge", "transcend", "emerge from", "transform",
        "seek", "follow", "encounter", "emerge", "face"
        // Add more verbs here
    };

        private static List<string> settings = new List<string>()
    {
        "enchanted forest", "futuristic city", "medieval kingdom", "remote island", "cosmic universe",
        "magical realm", "small town", "haunted mansion", "underground labyrinth", "ancient civilization",
        "post-apocalyptic world", "dream-like landscape", "underwater world", "space colony", "time-traveling dimension",
        "wilderness", "vibrant metropolis", "hidden sanctuary", "virtual reality", "parallel universe"
        // Add more settings here
    };

        private static List<string> characters = new List<string>()
    {
        "a brave hero", "a mysterious detective", "an ambitious scientist", "a determined explorer", "a troubled artist",
        "a lost soul", "a fearless warrior", "an unlikely friendship", "a cunning thief", "a wise mentor",
        "a tormented vampire", "a misunderstood outcast", "a strong-willed princess", "a relentless rebel", "a charming con artist",
        "a resilient survivor", "a legendary creature", "a quirky inventor", "a resilient underdog", "a conflicted protagonist"
        // Add more characters here
    };

        private static List<string> themes = new List<string>()
    {
        "betrayal", "redemption", "forgiveness", "identity", "love",
        "courage", "ambition", "freedom", "hope", "self-discovery",
        "justice", "revenge", "sacrifice", "loyalty", "resilience",
        "power", "fate", "truth", "transformation", "prejudice"
        // Add more themes here
    };

        private static List<string> emotions = new List<string>()
    {
        "heartache", "joy", "fear", "excitement", "awe",
        "despair", "wonder", "tension", "laughter", "dread",
        "intrigue", "passion", "surprise", "anticipation", "reflection",
        "curiosity", "thrill", "melancholy", "hope", "regret"
        // Add more emotions here
    };

        private static List<string> positiveAdjectives = new List<string>()
    {
        "captivating", "inspiring", "uplifting", "engrossing", "enlightening",
        "enthralling", "remarkable", "exhilarating", "compelling", "insightful",
        "enchanting", "gripping", "provocative", "fascinating", "mesmerizing",
        "thought-provoking", "powerful", "heartwarming", "unforgettable", "intriguing"
        // Add more positive adjectives here
    };

        private static List<string> readerTypes = new List<string>()
    {
        "avid readers", "bookworms", "literary enthusiasts", "adventure seekers", "romance lovers",
        "mystery buffs", "science fiction fans", "fantasy aficionados", "young adults", "history buffs",
        "self-help seekers", "horror enthusiasts", "biography readers", "thriller fans", "creative minds"
        // Add more reader types here
    };

        public static string RandomDescription()
        {
            string adjective = GetRandomItem(adjectives);
            string genre = GetRandomItem(genres);
            string author = GetRandomItem(authors);
            string verb = GetRandomItem(verbs);
            string setting = GetRandomItem(settings);
            string character = GetRandomItem(characters);

            StringBuilder descriptionBuilder = new StringBuilder();
            descriptionBuilder.Append("In a ");
            descriptionBuilder.Append(setting);
            descriptionBuilder.Append(", ");
            descriptionBuilder.Append(adjective);
            descriptionBuilder.Append(" ");
            descriptionBuilder.Append(genre);
            descriptionBuilder.Append(" book, ");
            descriptionBuilder.Append(author);
            descriptionBuilder.Append(" invites readers on a ");
            descriptionBuilder.Append(verb);
            descriptionBuilder.Append(" journey, following the story of ");
            descriptionBuilder.Append(character);
            descriptionBuilder.Append(". This ");
            descriptionBuilder.Append(genre);
            descriptionBuilder.Append(" novel is filled with ");
            descriptionBuilder.Append(GetRandomItem(themes));
            descriptionBuilder.Append(" and ");
            descriptionBuilder.Append(GetRandomItem(emotions));
            descriptionBuilder.Append(", making it a ");
            descriptionBuilder.Append(GetRandomItem(positiveAdjectives));
            descriptionBuilder.Append(" read for ");
            descriptionBuilder.Append(GetRandomItem(readerTypes));
            descriptionBuilder.Append(".");

            string description = descriptionBuilder.ToString();
            if (description.Length > 199)
            {
                description = description.Substring(0, 199);
            }

            return description;
        }

        private static string GetRandomItem(List<string> list)
        {
            int index = random.Next(list.Count);
            return list[index];
        }
    }
}
