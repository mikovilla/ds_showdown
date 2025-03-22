namespace ds.Utility
{
    public static class StringExtensions
    {
        public static void DisplayInfo(this string result, Action<string> splitResult, char delimiter = '|')
        {
            foreach(var r in result.Split(delimiter))
            {
                splitResult.Invoke(r);
            }
        }
    }
}
