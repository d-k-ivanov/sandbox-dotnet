using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _4_OOP
{
    public class MyStack : IEnumerable
    {
        private object[] _items;

        public int Count { get; private set; } = 0;
        public int Capacity => _items.Length;

        public MyStack()
        {
            const int defaultCapacity = 4;
            _items = new object[defaultCapacity];
        }

        public MyStack(int capacity)
        {
            _items = new object[capacity];
        }

        public void Push(object item)
        {
            if (_items.Length == Count)
            {
                object[] newArray = new object[Count * 2];
                Array.Copy(_items, newArray, Count);

                _items = newArray;
            }

            _items[Count++] = item;
        }

        public object Pop()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }

            object obj = _items[Count-1];
            _items[--Count] = null;

            return obj;
        }

        public object Peek()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }

            return _items[Count-1];
        }

        public void ListStack()
        {
            Console.Write("MyStack: ");
            if (Count == 0)
            {
                Console.Write("empty");
            }

            foreach (var item in _items)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
        }

        // public IEnumerator GetEnumerator()
        // {
        //     return new StackEnumerator<object>(_items);
        // }

        public IEnumerator GetEnumerator()
        {
            for (int i = Count - 1; i >= 0; i--)
            {
                yield return _items[i];
            }
        }
    }
}
