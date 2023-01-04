namespace CheckDuplicates
{
    public static class HasDuplicates
    {
        #region Publics
        public static bool ForEach<T>(IEnumerable<T> elements)
        {
            HashSet<T> hashSet = new HashSet<T>();

            foreach(T element in elements)
            {
                if(!hashSet.Add(element))
                {
                    return true;
                }
            }

            return false;
        }

        public static bool LinqAny<T>(IEnumerable<T> elements)
        {
            HashSet<T> hashSet = new HashSet<T>();

            return elements.Any(element => !hashSet.Add(element));
        }

        public static bool LinqAll<T>(IEnumerable<T> elements)
        {
            HashSet<T> hashSet = new HashSet<T>();

            return !elements.All(hashSet.Add);
        }

        public static bool LinqDistinctCount<T>(IEnumerable<T> elements)
        {
            elements = elements as T[] ?? elements.ToArray();

            return elements.Distinct().Count() != elements.Count();
        }

        public static bool ToHashSet<T>(IEnumerable<T> elements)
        {
            elements = elements as T[] ?? elements.ToArray();

            return elements.ToHashSet().Count != elements.Count();
        }

        public static bool LinqGroupBy<T>(IEnumerable<T> elements)
        {
            HashSet<T> hashSet = new HashSet<T>();

            return elements.GroupBy(t => t)
                           .Where(g => g.Count() > 1)
                           .Select(g => g.Key)
                           .Any(k => hashSet.Add(k));
        }

        public static bool LinqWhereDistinct<T>(IEnumerable<T> elements)
        {
            HashSet<T> hashSet = new HashSet<T>();

            return elements.Where(element => !hashSet.Add(element)).Distinct().Any();
        }
        #endregion
    }
}