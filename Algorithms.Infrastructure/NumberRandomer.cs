using System;
using System.Linq;

namespace Algorithms.Infrastructure {
    public class NumberRandomer {
        private static readonly Random Random = new Random();
        /// <summary>
        /// 生成指定长度,指定大小之间不重复随机数(int)
        /// </summary>
        /// <param name="length"></param>
        /// <param name="maxValue"></param>
        /// <param name="minValue"></param>
        /// <returns></returns>
        public static int[] RandomIntNotSame(int length, int minValue = int.MinValue, int maxValue = int.MaxValue) {
            int[] result = new int[length];
            for (int i = 0; i < length;) {
                int next = Random.Next(minValue, maxValue);
                if (!result.Contains(next)) {
                    result[i] = next;
                    i++;
                }
            }
            return result;
        }
        public static int[] RandomInt(int length, int minValue = int.MinValue, int maxValue = int.MaxValue) {
            int[] result = new int[length];
            for (int i = 0; i < length; i++) {
                result[i] = Random.Next(minValue, maxValue);
            }
            return result;
        }
        /// <summary>
        /// 生成指定长度,指定大小之间不重复随机数(double)
        /// </summary>
        /// <param name="length"></param>
        /// <param name="maxValue"></param>
        /// <param name="minValue"></param>
        /// <returns></returns>
        public static double[] RandomDoubleNotSame(int length, double minValue = double.MinValue, double maxValue = double.MaxValue) {
            double[] result = new double[length];
            for (int i = 0; i < length;) {
                double next = Random.NextDouble() * Random.Next();
                if (!result.Contains(next) && next <= maxValue && next >= minValue) {
                    result[i] = next;
                    i++;
                }
            }
            return result;
        }
        /// <summary>
        /// 生成0-1之间不重复随机数.
        /// </summary>
        /// <param name="length">长度.</param>
        /// <returns></returns>
        public static double[] RandomDoubleNotSame(int length) {
            double[] result = new double[length];
            for (int i = 0; i < length;) {
                double next = Random.NextDouble();
                if (!result.Contains(next)) {
                    result[i] = next;
                    i++;
                }
            }
            return result;
        }
        public static double[] RandomDouble(int length) {
            double[] result = new double[length];
            for (int i = 0; i < length; i++) {
                result[i] = Random.NextDouble();
            }
            return result;
        }
    }
}