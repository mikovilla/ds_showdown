namespace ds.Main
{
    public static class Extra
    {
        public static void HelloWorld()
        {
            Console.WriteLine("Hello, World!");
        }
        public static void GetIntroduction(this Dictionary<string, string> englishDictionary)
        {
            Console.WriteLine("SPECIFICATIONS: ");
            int wordCount = 0, wordCharacterCount = 0, definitionCharacterCount = 0, border = 50;
            foreach (KeyValuePair<string, string> kvp in englishDictionary)
            {
                wordCount++;
                wordCharacterCount += kvp.Key.Length;
                definitionCharacterCount += kvp.Value.Length;
            }
            Console.WriteLine($"Total number of words: {wordCount}.");
            Console.WriteLine($"Length of all words combined: {wordCharacterCount}.");
            Console.WriteLine($"Length of all definitions combined: {definitionCharacterCount}");
            Console.WriteLine();
        }

        public static void GetOutro(params string[] statements)
        {
            Console.WriteLine();
            foreach (string statement in statements)
            {
                Console.WriteLine(statement);
            }
        }
    }
}
