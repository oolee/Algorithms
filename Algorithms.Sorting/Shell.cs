using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Sorting {
    public class Shell<T> where T : IComparable<T> {
        public static void Sort(T[] a) {
            int h = 1;
            while (h < a.Length / 3) h = h * 3 + 1;
            while (h >= 1) {
                for(int i = h; i < a.Length; i++) {
                    for (int j = i; j >= h && Less(a[j], a[j - h]); j -= h) Exch(a, j, j - h);                    
                }
                h /= 3;
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
            var watch = Stopwatch.StartNew();
            Sort(a);
            watch.Stop();
            Debug.Assert(IsSorted(a));
            Show(a);
            Console.WriteLine($"排序{a.Length}个元素数组,所用时{watch.ElapsedMilliseconds}毫秒.");
        }
    }
}