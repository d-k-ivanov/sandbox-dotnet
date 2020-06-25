using System;
using System.Collections;
using System.Collections.Generic;

namespace _4_OOP
{
    public sealed class StackEnumerator<T> : IEnumerator<T>
    {
        private readonly T[] _array;
        private int _position = -1;

        public StackEnumerator(T[] array)
        {
            _array = array;
        }

        public bool MoveNext()
        {

            _position++;
            if (_position >= 0 && _position < _array.Length && _array[_position] == null )
            {
                return false;
            }
            return _position < _array.Length;
        }

        public void Reset()
        {
            _position = -1;
        }

        public T Current => _array[_position];

        object? IEnumerator.Current => Current;

        public void Dispose()
        {
        }
    }
}
