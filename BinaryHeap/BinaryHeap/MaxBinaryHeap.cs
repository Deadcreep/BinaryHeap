using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryHeap
{
    public class MaxBinaryHeap<T> : BaseBinaryHeap<T>
        where T : IComparable<T>
    {
        public MaxBinaryHeap() : base()
        {
        }

        public MaxBinaryHeap(IEnumerable<T> values) : base(values)
        {
        }

        protected override bool CheckChildPosition(int parent, int child)
        {
            return items[parent].CompareTo(items[child]) < 0;
        }

        protected override bool CompareItems(int x, int y)
        {
            return items[x].CompareTo(items[y]) > 0;
        }
    }
}
