using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _4_OOP
{
    public interface IBaseCollection : IEnumerable
    {
        void Add(object obj);
        void RemoveLast(object obj);
        int Size();
        void Extend();
    }

    // public abstract class IBaseCollection
    // {
    //     public abstract void Add(object obj);
    //     public abstract void RemoveLast(object obj);
    // }


    public class BaseList : IBaseCollection
    {
        public object[] Items;
        private int _count = 0;

        public BaseList(int initialCapacity)
        {
            Items = new object[initialCapacity];
        }

        // public override void Add(object obj)
        public void Add(object obj)
        {
            Items[_count] = obj;
            _count++;
            if (_count >= Items.Length)
            {
                Extend();
            }
        }

        // public override void RemoveLast(object obj)
        public void RemoveLast(object obj)
        {
            _count--;
            Items[_count] = null;
        }

        public int Size()
        {
            return Items.Length;
        }

        public void Extend()
        {
            var tmp = Items;
            Items = new object[tmp.Length * 2];
            _count = 0;
            foreach (var obj in tmp)
            {
                Items[_count] = obj;
                _count++;
            }
        }

        public IEnumerator GetEnumerator()
        {
            return this.Items.GetEnumerator();
        }
    }
}
