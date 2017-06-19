using Algorithms.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Sorting {
    class Program {
        static void Main(string[] args) {
            var numbers = NumberRandomer.RandomInt(100000,1,100000);
            //Selection<int>.Test(numbers);
            //Insertion<int>.Test(numbers);
            //Shell<int>.Test(numbers);
            //Merger<int>.Test(numbers);
            //SortCompare.CompareDouble(10000, 100, "selection", "insertion","Shell");
            SortCompare.CompareDouble(100000, 100, "Shell", "Merge");
        }
    }
}
