using System;
using System.Collections.Generic;

namespace Sort
{
    class Program
    {
        static void Main()
        {

        }
    }
    interface sort
    {
        public delegate int comparator<T>(T a, T b);

        public static void qsort(int[] a, uint l, uint r)
        {
            if (l < r)
            {
                uint q = partition(a, l, r, cmp_int);
                qsort(a, l, q);
                qsort(a, q + 1, r);
            }
        }
        public static void qsort(char[] a, uint l, uint r)
        {
            if (l < r)
            {
                uint q = partition(a, l, r, cmp_char);
                qsort(a, l, q);
                qsort(a, q + 1, r);
            }
        }
        public static void qsort(double[] a, uint l, uint r)
        {
            if (l < r)
            {
                uint q = partition(a, l, r, cmp_double);
                qsort(a, l, q);
                qsort(a, q + 1, r);
            }
        }
        public static void qsort<T>(T[] a, uint l, uint r, comparator<T> cmp)
        {
            if (l < r)
            {
                uint q = partition(a, l, r, cmp);
                qsort(a, l, q, cmp);
                qsort(a, q + 1, r, cmp);
            }
        }
        private static uint partition<T>(T[] a, uint l, uint r, comparator<T> cmp)
        {
            T v = a[(l + r) >> 1];
            uint i = l;
            uint j = r;
            while (i <= j)
            {
                while (cmp(a[i], v) < 0)
                {
                    ++i;
                }
                while (cmp(a[j], v) > 0)
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
        private static int cmp_int(int a, int b)
        {
            return (a - b);
        }
        private static int cmp_char(char a, char b)
        {
            return (a - b);
        }
        private static int cmp_double(double a, double b)
        {
            return Math.Sign((a - b));
        }
    }
}
