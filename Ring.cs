using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class Ring<T>
    {
        private class Node
        {
            public T _data;
            public Node Next { get; set; }
            public Node Previous { get; set; }
            public Node(T data)
            {
                _data = data;
                Next = null;
                Previous = null;
            }
        }
        Node _current;

        public Ring()
        {
            _current = null;
        }
        public void AddItem(T item)
        {
            Node newNode = new Node(item);
            if (_current == null)
            {
                _current = newNode;
                _current.Next = newNode;
                _current.Previous = newNode;
            }
            else
            {
                Node updatePrev = _current.Previous;
                _current.Previous = newNode;
                newNode.Next = _current;
                updatePrev.Next = newNode;
                newNode.Previous = updatePrev;
            }
        }
        public void PrintAllElements()
        {
            if (_current == null)
            {
                return;
            }
            Node currentIterable = _current;
            do
            {
                Console.WriteLine(currentIterable._data);
                currentIterable = currentIterable.Next;
            }
            while (currentIterable != _current);
        }
        public static T operator >(Ring<T> ring, T item)
        {
            return ring._current._data;
        }
        public static T operator <(Ring<T> ring, T item)
        {
            return ring._current._data;
        }
        public static Ring<T> operator <(Ring<T> ring, T item)
        {
            Ring<T> result = new Ring<T>();
            return result;
        }
        public static Ring<T> operator +(Ring<T> ring1, Ring<T> ring2)
        {
            Ring<T> result = new Ring<T>();
            Node currentIterable1 = ring1._current;
            Node currentIterable2 = ring1._current;
            do
            {
                T item = currentIterable1._data + currentIterable2._data;
                result.AddItem(item);
                currentIterable1 = currentIterable1.Next;
                currentIterable2 = currentIterable2.Next;
            }
            while (currentIterable1 != null);
            return result;
        }
        public static Ring<T> operator -(Ring<T> ring1, Ring<T> ring2)
        {
            Ring<T> result = new Ring<T>();
            return result;
        }
    }
}


