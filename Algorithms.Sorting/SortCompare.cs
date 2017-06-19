using Algorithms.Infrastructure;
using System;
using System.Diagnostics;
using System.Linq;

namespace Algorithms.Sorting {
    public class SortCompare {
        /// <summary>
        /// 计算一个排序算法所用时间.
        /// </summary>
        /// <param name="sortName">排序算法名称.</param>
        /// <param name="a">需要排序的数组</param>
        /// <returns>排序所用时间(毫秒).</returns>
        public static double Time<T>(string sortName, T[] a) where T : IComparable<T> {
            Stopwatch watch = Stopwatch.StartNew();
            switch (sortName.ToLower()) {
                case "selection": Selection<T>.Sort(a); break;
                case "insertion": Insertion<T>.Sort(a); break;
                case "shell": Shell<T>.Sort(a); break;
                case "merge":Merger<T>.Sort(a);break;
                default: throw new Exception($"不存在的排序算法:{sortName}");
            }
            watch.Stop();
            return watch.ElapsedMilliseconds;
        }
        /// <summary>
        /// 生成指定长度随机数(double)用于测试指定排序算法重复指定次数时,总共所用时间.
        /// </summary>
        /// <param name="length">测试排序数组长度.</param>
        /// <param name="counts">重复次数</param>
        /// <param name="sortNames">需要测试的排序算法</param>
        public static void CompareDouble(int length, int counts, params string[] sortNames) {
            foreach (var sortName in sortNames) {
                double totals = 0;
                for (int i = 0; i < counts; i++) {
                    double[] numbers = NumberRandomer.RandomDouble(length);
                    totals += Time(sortName, numbers);
                }
                Console.WriteLine($"排序算法{sortName},排序随机长度{length}的随机数,重复{counts}次,所用时:{totals}毫秒.");
            }
        }
        private static void Show<T>(T[] a) => a.ToList().ForEach(e => Console.WriteLine(e.ToString() + " "));
    }
}