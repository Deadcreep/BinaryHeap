using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryHeap
{
    public abstract class BaseBinaryHeap<T>
        where T : IComparable<T>
    {
        protected List<T> items;

        public int HeapSize
        {
            get { return this.items.Count(); }
        }

        protected BaseBinaryHeap()
        {
            items = new List<T>();
        }

        protected BaseBinaryHeap(IEnumerable<T> values)
        {
            
            items = values.Distinct().ToList();
            for (var i = HeapSize / 2; i >= 0; i--)
            {
                Heapify(i);
            }
        }

        public void Heapify(int i)
        {
            int leftChild;
            int rightChild;
            int topChild;

            leftChild = 2 * i + 1;
            rightChild = 2 * i + 2;
            topChild = i;

            if (leftChild < HeapSize && CompareItems(leftChild, topChild))
            {
                topChild = leftChild;
            }

            if (rightChild < HeapSize && CompareItems(rightChild, topChild))
            {
                topChild = rightChild;
            }

            if (topChild != i)
            {
                var temp = items[i];
                items[i] = items[topChild];
                items[topChild] = temp;
                i = topChild;
            }
        }

        protected abstract bool CompareItems(int x, int y);

        public void Insert(T newItem)
        {
            if (items.Contains(newItem))
                throw new ArgumentException("Item has already been added");

            items.Add(newItem);
            var i = HeapSize - 1;
            var parent = (i - 1) / 2;

            while (i > 0 && CheckChildPosition(parent, i))
            {
                var temp = items[i];
                items[i] = items[parent];
                items[parent] = temp;

                i = parent;
                parent = (i - 1) / 2;
            }
        }

        protected abstract bool CheckChildPosition(int parent, int child);

        public T Extract()
        {
            if(HeapSize == 0)
                throw new Exception("Empty heap");

            var result = items[0];
            items[0] = items[HeapSize - 1];
            items.RemoveAt(HeapSize - 1);
            Heapify(0);
            return result;
        }
    }
}
