using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class Ring
    {
        private class Node
        {
            public int _data;
            public Node Next { get; set; }
            public Node Previous { get; set; }
            public Node(int data)
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
        public Ring(int[] data)
        {
            if (data == null)
            {
                _current = null;
            }
            else
            {
                foreach (int item in data)
                {
                    AddItem(item);
                }
            }
        }
        public Ring(Ring originalRing)
        {
            if (originalRing._current == null)
            {
                _current = null;
            }
            else
            {
                _current = new Node(originalRing._current._data);
                Node originalNode = originalRing._current.Next;
                Node currentNode = _current;

                while (originalNode != originalRing._current)
                {
                    Node newNode = new Node(originalNode._data);
                    currentNode.Next = newNode;
                    newNode.Previous = currentNode;
                    currentNode = newNode;
                    originalNode = originalNode.Next;
                }
                currentNode.Next = _current;
                _current.Previous = currentNode;
            }
        }
        public void AddItem(int item)
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

        private int Count()
        {
            if (_current == null)
            {
                return 0;
            }
            int count = 1;
            Node currentNode = _current.Next;
            while (currentNode != _current)
            {
                count++;
                currentNode = currentNode.Next;
            }
            return count;
        }
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            Ring otherRing = (Ring)obj;
            if (Count() != otherRing.Count())
            {
                return false;
            }
            Node thisNode = _current;
            Node otherNode = otherRing._current;
            do
            {
                if (thisNode._data != otherNode._data)
                {
                    return false;
                }
                thisNode = thisNode.Next;
                otherNode = otherNode.Next;
            } while (thisNode != _current && otherNode != otherRing._current);
            return true;
        }
        public override int GetHashCode()
        {
            return -1359422401 + EqualityComparer<Node>.Default.GetHashCode(_current);
        }
        public override string ToString()
        {
            String result = String.Empty;
            if (_current != null)
            {
                Node currentIterable = _current;
                do
                {
                    result += currentIterable._data + " ";
                    currentIterable = currentIterable.Next;
                }
                while (currentIterable != _current);
            }
            return result;
        }
        public static int operator <(Ring ring, int result)
        {
            if (ring._current != null)
            {
                result = ring._current._data;
            }
            return result;
        }
        public static int operator >(Ring ring, int result)
        {
            if (ring._current != null)
            {
                result = ring._current._data;
                if (ring._current.Next == ring._current)
                {
                    ring._current = null;
                }
                else
                {
                    ring._current.Previous.Next = ring._current.Next;
                    ring._current.Next.Previous = ring._current.Previous;
                    ring._current = ring._current.Next;
                }
            }
            return result;
        }
        public static Ring operator >>(Ring ring, int item)
        {
            ring.AddItem(item);
            return ring;
        }
        public static Ring operator ++(Ring ring1)
        {
            Ring result = new Ring(ring1);
            result._current = result._current.Next;
            return result;
        }
        public static Ring operator --(Ring ring1)
        {
            Ring result = new Ring(ring1);
            result._current = result._current.Previous;
            return result;
        }
        public static bool operator true(Ring ring)
        {
            return ring._current == null;
        }
        public static bool operator false(Ring ring)
        {
            return ring._current == null;
        }
        public static bool operator ==(Ring ring1, Ring ring2)
        {
            return ring1.Equals(ring2);
        }
        public static bool operator !=(Ring ring1, Ring ring2)
        {
            return ring1 == ring2;
        }
        public static implicit operator Ring(int[] data)
        {
            return new Ring(data);
        }
        public static explicit operator Array(Ring ring)
        {
            if (ring == null)
            {
                return new int[0];
            }
            Ring copy = new Ring(ring);
            int size = copy.Count();
            int[] result = new int[size];
            do
            {
                int counter = 0;
                int newElement = 0;
                newElement = copy > newElement;
                result[counter++] = newElement;
            }
            while (copy._current != null);
            return result;
        }
    }
}