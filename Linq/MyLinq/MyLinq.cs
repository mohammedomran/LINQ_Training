namespace LinqProject.MyLinq
{
    public static class MyLinq
    {
        // simple extension methods
        public static int CountItems<T>(this IEnumerable<T> Items)
        {
            int Count = 0;
            foreach (var item in Items)
                Count++;
            return Count;
        }

        public static T GetFirst<T>(this IEnumerable<T> Items)
        {
            foreach (var item in Items)
                return item;
            return Items.GetFirst();
        }

        public static T GetLast<T>(this IEnumerable<T> Items)
        {
            T lastItem = Items.GetFirst();
            foreach (var item in Items)
                lastItem = item;

            return lastItem;
        }

        // extension method using func and predicate
        // yield return = deffered excution
        // tolist, count = immediate excution
        // select, where, take = deffered excution
        public static IEnumerable<T> Filter<T>(this IEnumerable<T> items,
            Func<T, bool> predicate)
        { 

            foreach (var item in items)
            {
                if(predicate(item))
                    yield return item;
            }
        }

        // pitfalls of deffered excution
        // 1- becareful where to put try catch because a query could be excuted outside the try block later
        // 2- sometimes it's bad if we write a query then count then loop as a full iteration will occure twice

    }
}
