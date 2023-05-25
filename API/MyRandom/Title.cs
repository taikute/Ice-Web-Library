using System.Text;

namespace API.MyRandom
{
    public class Title
    {
        private static Random random = new Random();

        private static string[] adjectives = {
        "The", "A", "An", "Incredible", "Fantastic", "Enigmatic", "Mysterious", "Brilliant",
        "Unforgettable", "Captivating", "Whimsical", "Magical", "Spectacular", "Daring", "Epic"
    };

        private static string[] nouns = {
        "Journey", "Adventure", "Secrets", "Dreams", "Destiny", "Wonders", "Mystery",
        "Legends", "Odyssey", "Miracles", "Quest", "Whisper", "Infinity", "Realm"
    };

        private static string[] genres = {
        "Romance", "Mystery", "Thriller", "Fantasy", "Science Fiction", "Historical Fiction",
        "Horror", "Adventure", "Biography", "Self-Help", "Humor", "Young Adult", "Drama"
    };

        private static string[] prefixes = {
        "The", "Chronicles of", "Adventures of", "Journey to", "In Search of",
        "Memoirs of", "Lost in", "Whispers from", "Escape from", "Rise of"
    };

        public static string RandomTitle()
        {
            StringBuilder sb = new StringBuilder();

            // Randomly choose the structure of the title
            int titleStructure = random.Next(3);

            switch (titleStructure)
            {
                case 0:
                    sb.Append(GetRandomElement(adjectives)).Append(' ').Append(GetRandomElement(nouns));
                    break;
                case 1:
                    sb.Append(GetRandomElement(prefixes)).Append(' ').Append(GetRandomElement(nouns));
                    break;
                case 2:
                    sb.Append(GetRandomElement(adjectives)).Append(' ').Append(GetRandomElement(genres));
                    break;
            }

            return sb.ToString();
        }

        private static string GetRandomElement(string[] array)
        {
            return array[random.Next(array.Length)];
        }
    }
}
