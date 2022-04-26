using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CustomLinkedList
{
    public static class LinkedListExtensionMethods
    {
        public static bool All<TSource>(this LinkedList<TSource> source, Func<TSource, bool> predicate)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            if (predicate == null)
            {
                throw new ArgumentNullException("predicate");
            }
            bool f = true;
            foreach (TSource it in source)
            {
                f = f && predicate(it);
            }
            return f;
        }

        public static bool Any<TSource>(this LinkedList<TSource> source)
        {

            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            if (source.Count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static bool Any<TSource>(this LinkedList<TSource> source, Func<TSource, bool> predicate)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            if (predicate == null)
            {
                throw new ArgumentNullException("predicate");
            }
            bool f = false;
            foreach (TSource it in source)
            {
                f = f || predicate(it);
            }
            return f;
        }

        public static LinkedList<TSource> Append<TSource>(this LinkedList<TSource> source, TSource element)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            LinkedList<TSource> list = new LinkedList<TSource>();
            foreach (TSource it in source)
            {
                list.AddLast(it);
            }
            list.AddLast(element);
            return list;
        }

        public static LinkedList<TSource> Concat<TSource>(this LinkedList<TSource> first, IEnumerable<TSource> second)
        {
            if (first == null)
            {
                throw new ArgumentNullException("first");
            }
            if (second == null)
            {
                throw new ArgumentNullException("second");
            }
            LinkedList<TSource> list = new LinkedList<TSource>();
            foreach (TSource it in first)
            {
                list.AddLast(it);
            }
            foreach (TSource it in second)
            {
                list.AddLast(it);
            }
            return list;
        }

        public static bool Contains<TSource>(this LinkedList<TSource> source, TSource value)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            return source.Contains(value);
        }

        public static int Count<TSource>(this LinkedList<TSource> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            return source.Count;
        }
        public static int Count<TSource>(this LinkedList<TSource> source, Func<TSource, bool> predicate)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            if (predicate == null)
            {
                throw new ArgumentNullException("predicate");
            }
            int count = 0;
            foreach (TSource it in source)
            {
                if (predicate(it))
                {
                    ++count;
                }
            }
            return count;
        }

        public static LinkedList<TSource> Distinct<TSource>(this LinkedList<TSource> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            LinkedList<TSource> list = new LinkedList<TSource>();
            foreach (TSource it in source)
            {
                if (!list.Contains(it))
                {
                    list.AddLast(it);
                }
            }
            return list;
        }

        public static TSource ElementAt<TSource>(this LinkedList<TSource> source, Index index)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            int offset = index.GetOffset(source.Count);
            if ((offset < 0) || (offset >= source.Count))
            {
                throw new ArgumentOutOfRangeException("index");
            }
            LinkedListNode<TSource> curr = source.First;
            for (int i = 0; i < offset; i++, curr = curr.next) { }
            return curr.Value;
        }
        public static TSource ElementAt<TSource>(this LinkedList<TSource> source, int index)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            int offset = index;
            if ((offset < 0) || (offset >= source.Count))
            {
                throw new ArgumentOutOfRangeException("index");
            }
            LinkedListNode<TSource> curr = source.First;
            for (int i = 0; i < offset; i++, curr = curr.next) { }
            return curr.Value;
        }

        public static TSource? ElementAtOrDefault<TSource>(this LinkedList<TSource> source, Index index)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            int offset = index.GetOffset(source.Count);
            if ((offset < 0) || (offset >= source.Count))
            {
                return default;
            }
            LinkedListNode<TSource> curr = source.First;
            for (int i = 0; i < offset; i++, curr = curr.next) { }
            return curr.Value;
        }
        public static TSource? ElementAtOrDefault<TSource>(this LinkedList<TSource> source, int index)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            int offset = index;
            if ((offset < 0) || (offset >= source.Count))
            {
                return default;
            }
            LinkedListNode<TSource> curr = source.First;
            for (int i = 0; i < offset; i++, curr = curr.next) { }
            return curr.Value;
        }

        public static LinkedList<TSource> Except<TSource>(this LinkedList<TSource> first, IEnumerable<TSource> second)
        {
            if (first == null)
            {
                throw new ArgumentNullException("first");
            }
            if (second == null)
            {
                throw new ArgumentNullException("second");
            }
            first = first.Distinct();
            LinkedList<TSource> list = new LinkedList<TSource>();
            foreach (TSource it in first)
            {
                if (!second.Contains(it))
                {
                    list.AddLast(it);
                }
            }
            return list;
        }

        public static LinkedList<TSource> Intersect<TSource>(this LinkedList<TSource> first, IEnumerable<TSource> second)
        {
            if (first == null)
            {
                throw new ArgumentNullException("first");
            }
            if (second == null)
            {
                throw new ArgumentNullException("second");
            }
            first = first.Distinct();
            LinkedList<TSource> list = new LinkedList<TSource>();
            foreach (TSource it in first)
            {
                if (second.Contains(it))
                {
                    list.AddLast(it);
                }
            }
            return list;
        }

        public static TSource First<TSource>(this LinkedList<TSource> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            if (source.Count == 0)
            {
                throw new InvalidOperationException("LinkedList is empty.");
            }
            return source.First.Value;
        }
        public static TSource? FirstOrDefault<TSource>(this LinkedList<TSource> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            if (source.Count == 0)
            {
                return default;
            }
            return source.First.Value;
        }

        public static TSource Last<TSource>(this LinkedList<TSource> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            if (source.Count == 0)
            {
                throw new InvalidOperationException("LinkedList is empty.");
            }
            return source.Last.Value;
        }
        public static TSource? LastOrDefault<TSource>(this LinkedList<TSource> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            if (source.Count == 0)
            {
                return default;
            }
            return source.Last.Value;
        }

        public static long LongCount<TSource>(this LinkedList<TSource> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            return (long)source.Count;
        }
        public static long LongCount<TSource>(this LinkedList<TSource> source, Func<TSource, bool> predicate)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            if (predicate == null)
            {
                throw new ArgumentNullException("predicate");
            }
            long count = 0;
            foreach (TSource it in source)
            {
                if (predicate(it))
                {
                    ++count;
                }
            }
            return count;
        }

        public static TSource? Max<TSource>(this LinkedList<TSource> source) where TSource : IComparable<TSource>
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            TSource? max = source.First();
            foreach (TSource it in source)
            {
                if (max.CompareTo(it) < 0)
                {
                    max = it;
                }
            }
            return max;
        }
        public static TSource? Max<TSource>(this LinkedList<TSource> source, IComparer<TSource>? comparer)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            if (comparer == null)
            {
                throw new ArgumentNullException("comparer");
            }
            TSource? max = source.First();
            foreach (TSource it in source)
            {
                if (comparer.Compare(max, it) < 0)
                {
                    max = it;
                }
            }
            return max;
        }
        public static TSource? Min<TSource>(this LinkedList<TSource> source) where TSource : IComparable<TSource>
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            TSource? min = source.First();
            foreach (TSource it in source)
            {
                if (min.CompareTo(it) > 0)
                {
                    min = it;
                }
            }
            return min;
        }
        public static TSource? Min<TSource>(this LinkedList<TSource> source, IComparer<TSource>? comparer)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            if (comparer == null)
            {
                throw new ArgumentNullException("comparer");
            }
            TSource? min = source.First();
            foreach (TSource it in source)
            {
                if (comparer.Compare(min, it) > 0)
                {
                    min = it;
                }
            }
            return min;
        }

        private interface sort
        {
            public static void qsort<T, TKey>(T[] a, int l, int r, Func<T, TKey> keySelector, bool descending) where TKey : IComparable<TKey>
            {
                if (l < r)
                {
                    int q = partition(a, l, r, keySelector, descending);
                    qsort(a, l, q, keySelector, descending);
                    qsort(a, q + 1, r, keySelector, descending);
                }
            }
            private static int partition<T, TKey>(T[] a, int l, int r, Func<T, TKey> keySelector, bool descending) where TKey : IComparable<TKey>
            {
                TKey v = keySelector(a[(l + r) >> 1]);
                int i = l;
                int j = r;
                while (i <= j)
                {
                    while ((descending ^ (keySelector(a[i]).CompareTo(v) < 0)) && (keySelector(a[i]).CompareTo(v) != 0))
                    {
                        ++i;
                    }
                    while ((descending ^ (keySelector(a[j]).CompareTo(v) > 0)) && (keySelector(a[j]).CompareTo(v) != 0))
                    {
                        --j;
                    }
                    if (i >= j)
                    {
                        break;
                    }
                    swap(ref a[i++], ref a[j--]);
                }
                return j;
            }
            public static void qsort<T, TKey>(T[] a, int l, int r, Func<T, TKey> keySelector, IComparer<TKey> comparer, bool descending)
            {
                if (l < r)
                {
                    int q = partition(a, l, r, keySelector, comparer, descending);
                    qsort(a, l, q, keySelector, comparer, descending);
                    qsort(a, q + 1, r, keySelector, comparer, descending);
                }
            }
            private static int partition<T, TKey>(T[] a, int l, int r, Func<T, TKey> keySelector, IComparer<TKey> comparer, bool descending)
            {
                TKey v = keySelector(a[(l + r) >> 1]);
                int i = l;
                int j = r;
                while (i <= j)
                {
                    while ((descending ^ (comparer.Compare(keySelector(a[i]), v) < 0)) && (comparer.Compare(keySelector(a[i]), v) != 0))
                    {
                        ++i;
                    }
                    while ((descending ^ (comparer.Compare(keySelector(a[j]), v) > 0)) && (comparer.Compare(keySelector(a[j]), v) != 0))
                    {
                        --j;
                    }
                    if (i >= j)
                    {
                        break;
                    }
                    swap(ref a[i++], ref a[j--]);
                }
                return j;
            }
            private static void swap<T>(ref T a, ref T b)
            {
                T temp = a;
                a = b;
                b = temp;
            }
        }

        private class CustomOrderedEnumerable<T> : IOrderedEnumerable<T>
        {
            LinkedList<T> source;
            internal CustomOrderedEnumerable(IEnumerable<T> _source)
            {
                source = new LinkedList<T>(_source);
            }

            public IOrderedEnumerable<T> CreateOrderedEnumerable<TKey>(Func<T, TKey> keySelector, IComparer<TKey>? comparer, bool descending)
            {
                if (descending)
                {
                    return source.OrderByDescending(keySelector, comparer);
                }
                else
                {
                    return source.OrderBy(keySelector, comparer);
                }
            }

            public IEnumerator<T> GetEnumerator()
            {
                return source.GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }

        public static IOrderedEnumerable<TSource> OrderBy<TSource, TKey>(this LinkedList<TSource> source, Func<TSource, TKey> keySelector) where TKey : IComparable<TKey>
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            if (keySelector == null)
            {
                throw new ArgumentNullException("keySelector");
            }
            TSource[] sourceArray = new TSource[source.Count()];
            int i = 0;
            foreach (TSource it in source)
            {
                sourceArray[i++] = it;
            }
            sort.qsort(sourceArray, 0, sourceArray.Count() - 1, keySelector, false);
            return new CustomOrderedEnumerable<TSource>(sourceArray);
        }
        public static IOrderedEnumerable<TSource> OrderBy<TSource, TKey>(this LinkedList<TSource> source, Func<TSource, TKey> keySelector, IComparer<TKey>? comparer)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            if (keySelector == null)
            {
                throw new ArgumentNullException("keySelector");
            }
            if (comparer == null)
            {
                throw new ArgumentNullException("comparer");
            }
            TSource[] sourceArray = new TSource[source.Count()];
            int i = 0;
            foreach (TSource it in source)
            {
                sourceArray[i++] = it;
            }
            sort.qsort(sourceArray, 0, sourceArray.Count() - 1, keySelector, comparer, false);
            return new CustomOrderedEnumerable<TSource>(sourceArray);
        }

        public static IOrderedEnumerable<TSource> OrderByDescending<TSource, TKey>(this LinkedList<TSource> source, Func<TSource, TKey> keySelector) where TKey : IComparable<TKey>
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            if (keySelector == null)
            {
                throw new ArgumentNullException("keySelector");
            }
            TSource[] sourceArray = new TSource[source.Count()];
            int i = 0;
            foreach (TSource it in source)
            {
                sourceArray[i++] = it;
            }
            sort.qsort(sourceArray, 0, sourceArray.Count() - 1, keySelector, true);
            return new CustomOrderedEnumerable<TSource>(sourceArray);
        }
        public static IOrderedEnumerable<TSource> OrderByDescending<TSource, TKey>(this LinkedList<TSource> source, Func<TSource, TKey> keySelector, IComparer<TKey>? comparer)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            if (keySelector == null)
            {
                throw new ArgumentNullException("keySelector");
            }
            if (comparer == null)
            {
                throw new ArgumentNullException("comparer");
            }
            TSource[] sourceArray = new TSource[source.Count()];
            int i = 0;
            foreach (TSource it in source)
            {
                sourceArray[i++] = it;
            }
            sort.qsort(sourceArray, 0, sourceArray.Count() - 1, keySelector, comparer, true);
            return new CustomOrderedEnumerable<TSource>(sourceArray);
        }

        public static LinkedList<TSource> Prepend<TSource>(this LinkedList<TSource> source, TSource element)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            LinkedList<TSource> result = new LinkedList<TSource>(source);
            result.AddFirst(element);
            return result;
        }

        public static LinkedList<TSource> Reverse<TSource>(this LinkedList<TSource> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            LinkedList<TSource> result = new LinkedList<TSource>();
            foreach (TSource it in source)
            {
                result.AddFirst(it);
            }
            return result;
        }

        public static bool SequenceEqual<TSource>(this LinkedList<TSource> first, IEnumerable<TSource> second)
        {
            if (first == null)
            {
                throw new ArgumentNullException("first");
            }
            if (second == null)
            {
                throw new ArgumentNullException("second");
            }
            if (first.Count() != second.Count())
            {
                return false;
            }
            else
            {
                var it1 = first.GetEnumerator();
                var it2 = second.GetEnumerator();
                while(it1.MoveNext() && it2.MoveNext())
                {
                    if (!it1.Current.Equals(it2.Current))
                    {
                        return false;
                    }
                }
                return true;
            }
        }
        public static bool SequenceEqual<TSource>(this LinkedList<TSource> first, IEnumerable<TSource> second, IEqualityComparer<TSource>? comparer)
        {
            if (first == null)
            {
                throw new ArgumentNullException("first");
            }
            if (second == null)
            {
                throw new ArgumentNullException("second");
            }
            if (comparer == null)
            {
                throw new ArgumentNullException("comparer");
            }
            if (first.Count() != second.Count())
            {
                return false;
            }
            else
            {
                var it1 = first.GetEnumerator();
                var it2 = second.GetEnumerator();
                while (it1.MoveNext() && it2.MoveNext())
                {
                    if (!comparer.Equals(it1.Current, it2.Current))
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        public static TSource Single<TSource>(this LinkedList<TSource> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            if (source.Count() != 1)
            {
                throw new InvalidOperationException();
            }
            else
            {
                return source.First();
            }
        }
        public static TSource? SingleOrDefault<TSource>(this LinkedList<TSource> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            if (source.Count() > 1)
            {
                throw new InvalidOperationException();
            }
            else
            {
                return source.Count() == 1 ? source.First() : default;
            }
        }

        public static LinkedList<TSource> Take<TSource>(this LinkedList<TSource> source, int count)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            if ((count < 0) || (count > source.Count()))
            {
                throw new ArgumentOutOfRangeException("count");
            }
            LinkedList<TSource> result = new LinkedList<TSource>();
            var it = source.GetEnumerator();
            while(count-- > 0)
            {
                it.MoveNext();
                result.AddLast(it.Current);
            }
            return result;
        }
        public static LinkedList<TSource> Take<TSource>(this LinkedList<TSource> source, Range range)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            int start = range.Start.GetOffset(source.Count());
            int end = range.End.GetOffset(source.Count());
            if (start > end)
            {
                if ((start >= source.Count()) || (end < -1))
                {
                    throw new ArgumentOutOfRangeException("range");
                }
                LinkedList<TSource> result = new LinkedList<TSource>();
                var it = source.GetEnumerator();
                int i = 0;
                while (i <= end)
                {
                    it.MoveNext();
                    ++i;
                }
                while (i <= start)
                {
                    it.MoveNext();
                    result.AddFirst(it.Current);
                    ++i;
                }
                return result;
            }
            else
            {
                if ((start < 0) || (end > source.Count()))
                {
                    throw new ArgumentOutOfRangeException("range");
                }
                LinkedList<TSource> result = new LinkedList<TSource>();
                var it = source.GetEnumerator();
                int i = 0;
                while (i < start)
                {
                    it.MoveNext();
                    ++i;
                }
                while (i < end)
                {
                    it.MoveNext();
                    result.AddLast(it.Current);
                    ++i;
                }
                return result;
            }
        }
        public static LinkedList<TSource> TakeLast<TSource>(this LinkedList<TSource> source, int count)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            if ((count < 0) || (count > source.Count()))
            {
                throw new ArgumentOutOfRangeException("count");
            }
            LinkedList<TSource> result = new LinkedList<TSource>();
            LinkedListNode<TSource> curr = source.Last;
            while (count-- > 0)
            {
                result.AddFirst(curr.Value);
                curr = curr.Prev;
            }
            return result;
        }

        public static LinkedList<TSource> Union<TSource>(this LinkedList<TSource> first, IEnumerable<TSource> second)
        {
            if (first == null)
            {
                throw new ArgumentNullException("first");
            }
            if (second == null)
            {
                throw new ArgumentNullException("second");
            }
            LinkedList<TSource> result = new LinkedList<TSource> (first);
            foreach (TSource it in second)
            {
                result.AddLast(it);
            }
            return result.Distinct();
        }
    }
}
