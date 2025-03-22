using ds.Application;

namespace ds.Utility
{
    public static class Enumerable
    {
        public static void IterateInsert(this BinarySearchTree bst, Dictionary<string, string> englishDictionary)
        {
            foreach (KeyValuePair<string, string> kvp in englishDictionary)
            {
                bst.Insert(kvp.Key, kvp.Value);
            }
        }

        public static void IterateInsert(this Dictionary<string, string> dictionary, Dictionary<string, string> englishDictionary)
        {
            foreach (KeyValuePair<string, string> kvp in englishDictionary)
            {
                dictionary.TryAdd(kvp.Key, kvp.Value);
            }
        }
    }
}
