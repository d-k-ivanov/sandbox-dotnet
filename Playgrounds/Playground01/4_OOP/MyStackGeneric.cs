using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _4_OOP
{
    public class MyStackG<T> : IEnumerable<T>
    {
        private T[] _items;

        public int Count { get; private set; } = 0;
        public int Capacity => _items.Length;

        public MyStackG()
        {
            const int defaultCapacity = 4;
            _items = new T[defaultCapacity];
        }

        public MyStackG(int capacity)
        {
            _items = new T[capacity];
        }

        public void Push(T item)
        {
            if (_items.Length == Count)
            {
                T[] newArray = new T[Count * 2];
                Array.Copy(_items, newArray, Count);

                _items = newArray;
            }

            _items[Count++] = item;
        }

        public T Pop()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }

            T obj = _items[Count-1];
            _items[--Count] = default; // default(T)

            return obj;
        }

        public T Peek()
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

        // public IEnumerator<T> GetEnumerator()
        // {
        //     return new StackEnumerator<T>(_items);
        // }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = Count - 1; i >= 0; i--)
            {
                yield return _items[i];
            }
        }


        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
