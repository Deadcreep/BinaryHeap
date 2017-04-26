using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryHeap
{
    class Program
    {
        static void Main(string[] args)
        {
            var testHeap = new MaxBinaryHeap<int>();
            testHeap.Insert(15);
            testHeap.Insert(5);
            testHeap.Insert(10);
            var temp = testHeap.Extract();
            Console.WriteLine(temp);
            testHeap.Insert(30);
            testHeap.Insert(1);
            temp = testHeap.Extract();
            Console.WriteLine(temp);
        }
    }
}
