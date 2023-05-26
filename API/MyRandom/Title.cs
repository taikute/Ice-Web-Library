using System;
using System.Text;

namespace API.MyRandom
{
    public class Title
    {
        private static Random random = new Random();

        private static string[] adjectives = {
            "The", "A", "An", "Incredible", "Fantastic", "Enigmatic", "Mysterious", "Brilliant",
            "Unforgettable", "Captivating", "Whimsical", "Magical", "Spectacular", "Daring", "Epic",
            "Enchanting", "Extraordinary", "Glorious", "Harmonic", "Luminous", "Mythical", "Radiant",
            "Surreal", "Thrilling", "Vibrant", "Wonderful", "Zenith",
            "Exquisite", "Breathtaking", "Mesmerizing", "Awe-inspiring", "Spellbinding", "Stunning"
            // Add more adjectives here
        };

        private static string[] nouns = {
            "Journey", "Adventure", "Secrets", "Dreams", "Destiny", "Wonders", "Mystery",
            "Legends", "Odyssey", "Miracles", "Quest", "Whisper", "Infinity", "Realm",
            "Chronicles", "Exploration", "Legacy", "Reflections", "Imagination", "Harmony", "Eternity",
            "Harmony", "Discovery", "Phenomenon", "Phantasm", "Conquest",
            "Whirlwind", "Whisper", "Enigma", "Essence", "Celestial", "Cascade"
            // Add more nouns here
        };

        private static string[] prefixes = {
            "The", "Chronicles of", "Adventures of", "Journey to", "In Search of",
            "Memoirs of", "Lost in", "Whispers from", "Escape from", "Rise of",
            "Quest for", "Enigma of", "Legends of", "Tales from", "Echoes of",
            "Myth of", "Voices from", "Songs of", "Echoes from", "Whirlwind of"
            // Add more prefixes here
        };

        public static string RandomTitle()
        {
            StringBuilder sb = new StringBuilder();

            // Randomly choose the structure of the title
            int titleStructure = random.Next(4);

            switch (titleStructure)
            {
                case 0:
                    sb.Append(GetRandomElement(adjectives)).Append(' ').Append(GetRandomElement(nouns));
                    break;
                case 1:
                    sb.Append(GetRandomElement(prefixes)).Append(' ').Append(GetRandomElement(nouns));
                    break;
                case 2:
                    sb.Append(GetRandomElement(adjectives)).Append(' ').Append(GetRandomElement(adjectives)).Append(' ').Append(GetRandomElement(nouns));
                    break;
                case 3:
                    sb.Append(GetRandomElement(prefixes)).Append(' ').Append(GetRandomElement(adjectives)).Append(' ').Append(GetRandomElement(nouns));
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
