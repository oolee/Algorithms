using System;
using System.Diagnostics;
using System.Linq;

namespace Algorithms.Sorting {
    public class Selection<T> where T : IComparable<T> {
        public static void Sort(T[] a) {
            for (int i = 0; i < a.Length; i++) {
                int min = i;
                for (int j = i + 1; j < a.Length; j++) {
                    if (Less(a[j], a[min])) min = j;
                }
                Exch(a, i, min);
            }
        }
        public static bool Less(T v, T w) => v.CompareTo(w) < 0;
        public static void Exch(T[] a, int i, int j) {
            T temp = a[i];
            a[i] = a[j];
            a[j] = temp;
        }
        public static void Show(T[] a) => a.ToList().ForEach(e => Console.Write(e.ToString() + " "));
        public static bool IsSorted(T[] a) {
            for (int i = 1; i < a.Length; i++) if (Less(a[i], a[i - 1])) return false;
            return true;
        }
        public static void Test(T[] a) {
            Stopwatch watch = Stopwatch.StartNew();
            Sort(a);
            watch.Stop();
            Console.WriteLine($"排序用时:{watch.ElapsedMilliseconds}毫秒.");
            Debug.Assert(IsSorted(a));
            Show(a);
        }
    }
}