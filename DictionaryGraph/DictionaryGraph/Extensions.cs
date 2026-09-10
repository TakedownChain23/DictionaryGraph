namespace DictionaryGraph
{
    internal static class Extensions
    {
        public static void AddRange<T>(this ISet<T> hashSet, IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                hashSet.Add(item);
            }
        }
    }
}
