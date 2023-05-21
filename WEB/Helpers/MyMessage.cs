namespace WEB.Helpers
{
    public static class MyMessage
    {
        static readonly Dictionary<string, List<string>> MessageDict = new Dictionary<string, List<string>>()
        {
            { "Success", new List<string>() },
            { "Warning", new List<string>() },
            { "Danger", new List<string>() },
            { "Info", new List<string>() }
        };

        public static Dictionary<string, List<string>> Get()
        {
            var dict = new Dictionary<string, List<string>>();

            foreach (var key in MessageDict.Keys.ToList())
            {
                if (MessageDict[key].Count > 0)
                {
                    dict[key] = new List<string>(MessageDict[key]);
                    MessageDict[key].Clear();
                }
            }

            return dict;
        }

        public static void Add(string key, string message)
        {
            MessageDict[key].Add(message);
        }

        public static bool Any()
        {
            return MessageDict.Values.Any(list => list.Count > 0);
        }
    }
}
