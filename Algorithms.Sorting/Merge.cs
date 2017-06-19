using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Sorting {
    public class Merger<T> where T : IComparable<T> {
        private static T[] aux;
        public static void Sort(T[] a) {
            aux = new T[a.Length];
            Sort(a, 0, a.Length - 1);
        }
        private static void Sort(T[]a ,int lo,int hi) {//递归归并,自顶向下,将需要排序的数组不断的缩小一半,最终变成2个元素归并,4个...最终完成排序.
            if (hi <= lo) return;

            int mid = lo + (hi - lo) / 2;
            Sort(a, lo, mid);//将左半部分排序
            Sort(a, mid + 1, hi);//将右半部分排序
            Merge(a, lo, mid, hi);//归并
        }
        private static void Merge(T[] a, int lo, int mid, int hi) {//原地归并
            for (int k = lo; k <= hi; k++) aux[k] = a[k];//将a[lo...hi]复制到数组aux中.

            int i = lo, j = mid + 1;
            for (int k = lo; k <= hi; k++) {//将a[lo...mid]与a[mid+1...hi]归并(数组的前后2部分已经有序)
                if (i > mid) a[k] = aux[j++];//i>mid说明数组前半部分已经取完,直接取后半部分
                else if (j > hi) a[k] = aux[i++];//同上
                else if (Less(aux[j], aux[i])) a[k] = aux[j++];//2部分都还剩余元素,取较小的
                else a[k] = aux[i++];//同上
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