using System;
using System.Diagnostics;
using System.Linq;

namespace Algorithms.Infrastructure {
    public class Example<T> where T:IComparable<T> {
        public static void Sort(T[] a) { }
        public static bool Less(T v, T w)  => v.CompareTo(w) < 0;
        public static void Exch(T[]a,int i,int j) {
            T temp = a[i];
            a[i] = a[j];
            a[j] = temp;
        }
        public static void Show(T[] a) => a.ToList().ForEach(e=>Console.Write(e.ToString()+" "));
        public static bool IsSorted(T[] a) {
            for (int i = 1; i < a.Length; i++) if (Less(a[i], a[i - 1])) return false;
            return true;
        }
        public static void Test(T[] a) {
            var watch = Stopwatch.StartNew();
            Sort(a);
            watch.Stop();
            Debug.Assert(IsSorted(a));
            Show(a);
            Console.WriteLine($"排序{a.Length}个元素数组,所用时{watch.ElapsedMilliseconds}毫秒.");
        }
    }
}