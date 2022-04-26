using System;
using CustomLinkedList;

namespace Test
{
    static class Program
    {
        static void Main(string[] args)
        {
            //Please, add CustomLinkedList.dll to Project Dependencies and write the full path to the test file before running the program
            string path = @"path";

            // testing constructor without parameters and constructor copying IEnumerable<T>
            ConstructorTesting(path);

            // testing properties of CustomLinkedList.LinkedList<T>: Count, First, Last
            PropertyTesting(path);

            // testing methods of CustomLinkedList.LinkedList<T>
            MethodTesting(path);

            // testing methods of CustomLinkedList.LinkedList<T>
            TestingExtensionMethods(path);
        }

        static void ConstructorTesting(string path) // testing constructor without parameters and constructor copying IEnumerable<T>
        {
            Console.WriteLine("Constructor testing:");
            using (StreamReader Input = new StreamReader(path))
            {
                CustomLinkedList.LinkedList<char> ll1 = new CustomLinkedList.LinkedList<char>();
                Console.WriteLine("ll1:");
                foreach(char c in ll1)
                {
                    Console.Write(c + " ");
                }
                Console.WriteLine();

                int num = int.Parse(Input.ReadLine());
                char[] data = new char[num];
                for (int i = 0; i < num; i++)
                {
                    data[i] = char.Parse(Input.ReadLine());
                }
                CustomLinkedList.LinkedList<char> ll2 = new CustomLinkedList.LinkedList<char>(data);
                Console.WriteLine("ll2:");
                foreach (char c in ll2)
                {
                    Console.Write(c + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("------------------------\n");
        }

        static void PropertyTesting(string path) // testing properties of CustomLinkedList.LinkedList<T>: Count, First, Last
        {
            Console.WriteLine("Property testing:");
            using (StreamReader Input = new StreamReader(path))
            {
                int num = int.Parse(Input.ReadLine());
                char[] data = new char[num];
                for (int i = 0; i < num; i++)
                {
                    data[i] = char.Parse(Input.ReadLine());
                }
                CustomLinkedList.LinkedList<char> ll = new CustomLinkedList.LinkedList<char>(data);
                Console.WriteLine("ll:");
                foreach (char c in ll)
                {
                    Console.Write(c + " ");
                }
                Console.WriteLine();

                Console.WriteLine("Count of nodes: " + ll.Count);

                Console.WriteLine($"First and second node values: {ll.First.Value}, {ll.First.Next.Value}");

                Console.WriteLine($"Last and penult node values: {ll.Last.Value}, {ll.Last.Prev.Value}");
            }
            Console.WriteLine("------------------------\n");
        }

        static void MethodTesting(string path) // testing methods of CustomLinkedList.LinkedList<T>
        {
            Console.WriteLine("Method testing:");
            using (StreamReader Input = new StreamReader(path))
            {
                int num = int.Parse(Input.ReadLine());
                char[] data = new char[num];
                for (int i = 0; i < num; i++)
                {
                    data[i] = char.Parse(Input.ReadLine());
                }
                CustomLinkedList.LinkedList<char> ll = new CustomLinkedList.LinkedList<char>(data);
                Console.WriteLine("ll:");
                foreach (char c in ll)
                {
                    Console.Write(c + " ");
                }
                Console.WriteLine("\n");

                ll.AddFirst(new CustomLinkedList.LinkedListNode<char>('F'));
                ll.AddFirst('X');
                ll.AddLast(new CustomLinkedList.LinkedListNode<char>('L'));
                ll.AddLast('l');
                Console.WriteLine("ll after adding nodes:");
                foreach (char c in ll)
                {
                    Console.Write(c + " ");
                }
                Console.WriteLine("\n");

                ll.AddAfter(ll.First, new CustomLinkedList.LinkedListNode<char>('C'));
                ll.AddAfter(ll.Last, 'e');
                ll.AddBefore(ll.Last, new CustomLinkedList.LinkedListNode<char>('R'));
                ll.AddBefore(ll.First, 'Z');
                Console.WriteLine("ll after adding nodes:");
                foreach (char c in ll)
                {
                    Console.Write(c + " ");
                }
                Console.WriteLine("\n");

                CustomLinkedList.LinkedList<char> llcopy = new CustomLinkedList.LinkedList<char>(ll);
                Console.WriteLine("llcopy:");
                foreach (char c in llcopy)
                {
                    Console.Write(c + " ");
                }
                Console.WriteLine();
                llcopy.Clear();
                Console.WriteLine("count of llcopy nodes after clearing: " + llcopy.Count);
                Console.WriteLine("\n");

                if (ll.Contains('a'))
                {
                    Console.WriteLine("ll contains 'a'");
                }
                if (!ll.Contains('V'))
                {
                    Console.WriteLine("ll doesn't contain 'V'");
                }
                Console.WriteLine("\n");

                char[] arr = new char[ll.Count + 1];
                arr[0] = '#';
                ll.CopyTo(arr, 1);
                Console.WriteLine("Array with copy of ll:");
                foreach (char c in arr)
                {
                    Console.Write(c + " ");
                }
                Console.WriteLine("\n");

                if (!ll.Equals(llcopy))
                {
                    Console.WriteLine("ll doesn't equal llcopy");
                }
                if (ll.Equals(ll))
                {
                    Console.WriteLine("ll equals itself");
                }
                Console.WriteLine("\n");

                Console.WriteLine("Search 'a' with using Find: found and previous values");
                Console.WriteLine($"{ll.Find('a').Value}, {ll.Find('a').Prev.Value}");
                Console.WriteLine("Search 'a' with using FindLast: found and previous values");
                Console.WriteLine($"{ll.FindLast('a').Value}, {ll.FindLast('a').Prev.Value}");
                Console.WriteLine("\n");

                //method 'CustomLinkedList.LinkedList<T>.GetEnumerator' is used implicitly by construction 'foreach'

                Console.WriteLine(ll.GetType().ToString());
                Console.WriteLine("\n");

                Console.WriteLine("ll:");
                foreach (char c in ll)
                {
                    Console.Write(c + " ");
                }
                Console.WriteLine();
                ll.Remove(ll.Last.Prev);
                Console.WriteLine("ll after deleting penult node:");
                foreach (char c in ll)
                {
                    Console.Write(c + " ");
                }
                Console.WriteLine();
                ll.Remove('F');
                Console.WriteLine("ll after deleting node with value 'F':");
                foreach (char c in ll)
                {
                    Console.Write(c + " ");
                }
                Console.WriteLine();
                ll.RemoveFirst();
                Console.WriteLine("ll after deleting first node:");
                foreach (char c in ll)
                {
                    Console.Write(c + " ");
                }
                Console.WriteLine();
                ll.RemoveLast();
                Console.WriteLine("ll after deleting last node:");
                foreach (char c in ll)
                {
                    Console.Write(c + " ");
                }
                Console.WriteLine();
                Console.WriteLine("\n");

                Console.WriteLine(ll.ToString());
            }
            Console.WriteLine("------------------------\n");
        }

        static void TestingExtensionMethods(string path)
        {
            Console.WriteLine("Testing extension methods:");
            using (StreamReader Input = new StreamReader(path))
            {
                int num = int.Parse(Input.ReadLine());
                char[] data = new char[num];
                for (int i = 0; i < num; i++)
                {
                    data[i] = char.Parse(Input.ReadLine());
                }
                CustomLinkedList.LinkedList<char> ll = new CustomLinkedList.LinkedList<char>(data);
                Console.WriteLine("ll:");
                foreach (char c in ll)
                {
                    Console.Write(c + " ");
                }
                Console.WriteLine("\n");

                if(ll.All(it => it >= 'a'))
                {
                    Console.WriteLine("Every element of ll isn't less then 'a'");
                }
                if(ll.Any())
                {
                    Console.WriteLine("ll isn't empty");
                }
                if(ll.Any(it => it == 'a'))
                {
                    Console.WriteLine("There is node in ll with value 'a'");
                }
                Console.WriteLine("\n");

                Console.WriteLine("new linked list with last element 'L':");
                foreach (char c in ll.Append('L'))
                {
                    Console.Write(c + " ");
                }
                Console.WriteLine();
                Console.WriteLine("new linked list with first element 'F':");
                foreach (char c in ll.Prepend('F'))
                {
                    Console.Write(c + " ");
                }
                Console.WriteLine("\n");

                Console.WriteLine("concatenation of ll and data:");
                foreach (char c in ll.Concat(data))
                {
                    Console.Write(c + " ");
                }
                Console.WriteLine("\n");

                if (!ll.Contains('Y'))
                {
                    Console.WriteLine("ll doesn't contain 'Y'");
                }
                Console.WriteLine($"Count of nodes: {ll.Count()}");
                Console.WriteLine($"type of long count: {ll.LongCount().GetType()}");
                Console.WriteLine($"Count of elements 'a': {ll.Count(it => it == 'a')}");
                Console.WriteLine("\n");

                Console.WriteLine("list of various elements from ll");
                foreach (char c in ll.Distinct())
                {
                    Console.Write(c + " ");
                }
                Console.WriteLine("\n");

                Console.WriteLine("ll:");
                foreach (char c in ll)
                {
                    Console.Write(c + " ");
                }
                Console.WriteLine();
                Console.WriteLine($"element at position 0: {ll.ElementAt(new Index(0))}");
                Console.WriteLine($"element at position 2: {ll.ElementAt(2)}");
                Console.WriteLine($"element or defaukt at position -1: {ll.ElementAtOrDefault(new Index(ll.Count() + 1, true))}");
                Console.WriteLine($"element or defaukt at position 15: {ll.ElementAtOrDefault(15)}");
                Console.WriteLine("\n");

                char[] arr = { 'a', 'b', 'X' };
                Console.WriteLine("ll except arr:");
                foreach (char c in ll.Except(arr))
                {
                    Console.Write(c + " ");
                }
                Console.WriteLine();
                Console.WriteLine("Intersection of ll and arr:");
                foreach (char c in ll.Intersect(arr))
                {
                    Console.Write(c + " ");
                }
                Console.WriteLine();
                Console.WriteLine("Union of ll and arr:");
                foreach (char c in ll.Union(arr))
                {
                    Console.Write(c + " ");
                }
                Console.WriteLine("\n");

                Console.WriteLine($"First element of ll: {ll.First()}");
                Console.WriteLine($"First or default element in an empty linked list: {ll.Except(ll).FirstOrDefault()}");
                Console.WriteLine($"Last element of ll: {ll.Last()}");
                Console.WriteLine($"Last or default element in an empty linked list: {ll.Except(ll).LastOrDefault()}");
                Console.WriteLine("\n");

                Console.WriteLine($"Maximum of ll: {ll.Max()}");
                Console.WriteLine($"Minimum of ll: {ll.Min()}");
                Console.WriteLine("\n");

                Console.WriteLine("ordered ll:");
                foreach (char c in ll.OrderBy(it => (int)it))
                {
                    Console.Write(c + " ");
                }
                Console.WriteLine();
                Console.WriteLine("ordered with using custom comparer of keys ll:");
                foreach (char c in ll.OrderBy((it => (int)it), new MyIntComparer()))
                {
                    Console.Write(c + " ");
                }
                Console.WriteLine();
                Console.WriteLine("ordered by descending ll:");
                foreach (char c in ll.OrderByDescending(it => (int)it))
                {
                    Console.Write(c + " ");
                }
                Console.WriteLine();
                Console.WriteLine("ordered by desceding with using custom comparer of keys ll:");
                foreach (char c in ll.OrderByDescending((it => (int)it), new MyIntComparer()))
                {
                    Console.Write(c + " ");
                }
                Console.WriteLine("\n");

                Console.WriteLine("reversed ll:");
                foreach (char c in ll.Reverse())
                {
                    Console.Write(c + " ");
                }
                Console.WriteLine("\n");

                if (ll.SequenceEqual(data))
                {
                    Console.WriteLine("ll coincides data");
                }
                Console.WriteLine("\n");

                CustomLinkedList.LinkedList<char> sll = new CustomLinkedList.LinkedList<char>();
                sll.AddFirst('S');
                Console.WriteLine($"Single element of sll: {sll.Single()}");
                sll.Clear();
                Console.WriteLine($"Single element or default of sll: {sll.SingleOrDefault()}");
                Console.WriteLine("\n");

                Console.WriteLine("ll:");
                foreach (char c in ll)
                {
                    Console.Write(c + " ");
                }
                Console.WriteLine();
                Console.WriteLine("first 6 elements of ll:");
                foreach (char c in ll.Take(6))
                {
                    Console.Write(c + " ");
                }
                Console.WriteLine();
                Console.WriteLine("last 3 elements of ll:");
                foreach (char c in ll.TakeLast(3))
                {
                    Console.Write(c + " ");
                }
                Console.WriteLine();
                Console.WriteLine("elements of ll in range from 2 to 6:");
                foreach (char c in ll.Take(new Range(2, 6)))
                {
                    Console.Write(c + " ");
                }
                Console.WriteLine("\n");
            }
            Console.WriteLine("------------------------\n");
        }
        class MyIntComparer : IComparer<int>
        {
            public int Compare(int x, int y)
            {
                return x - y;
            }
        }
    }
}