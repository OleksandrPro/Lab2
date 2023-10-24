using System;
using System.Collections.Generic;

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
            _current = null;

            if (data != null)
            {
                foreach (int item in data)
                {
                    Node newNode = new Node(item);

                    if (_current == null)
                    {
                        newNode.Next = newNode;
                        newNode.Previous = newNode;
                        _current = newNode;
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
        public static Ring CreateRingFromInput()
        {
            Console.WriteLine("Enter numbers of ring separating them with space:");
            string input = Console.ReadLine();
            string[] inputNumbers = input.Split(' ');
            if (inputNumbers.Length == 0)
            {
                return new Ring();
            }
            int[] data = new int[inputNumbers.Length];
            for (int i = 0; i < inputNumbers.Length; i++)
            {
                try
                {
                    int newElement = int.Parse(inputNumbers[i]);
                    data[i] = newElement;
                }
                catch (Exception)
                {
                    return new Ring();
                }
            }
            return new Ring(data);
        }
        public static int operator <(Ring ring, int result)
        {
            if (ring._current == null)
            {
                throw new InvalidOperationException("It's not possible to extract data from empty ring.");
            }
            return ring._current._data;
        }
        public static int operator >(Ring ring, int result)
        {
            if (ring._current == null)
            {
                throw new InvalidOperationException("It's not possible to extract data from empty ring.");
            }
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
            return result;
        }
        public static Ring operator >>(Ring ring, int item)
        {
            Node newNode = new Node(item);

            if (ring._current == null)
            {
                newNode.Next = newNode;
                newNode.Previous = newNode;
                ring._current = newNode;
            }
            else
            {
                Node updatePrev = ring._current.Previous;
                ring._current.Previous = newNode;
                newNode.Next = ring._current;
                updatePrev.Next = newNode;
                newNode.Previous = updatePrev;
            }

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
            return ring._current != null;
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
            return !(ring1 == ring2);
        }
        public static implicit operator Ring(int[] data)
        {
            return new Ring(data);
        }
        public static explicit operator int[](Ring ring)
        {
            if (ring == null)
            {
                return new int[0];
            }
            Ring copy = new Ring(ring);
            int size = copy.Count();
            int[] result = new int[size];
            int counter = 0;
            while (copy._current != null)
            {
                int newElement = copy > 0;
                result[counter++] = newElement;
            }
            return result;
        }
        public Ring this[int n]
        {
            get
            {
                n = n % Count();
                Ring result = new Ring(this);
                if (n > 0)
                {
                    for (int i = 0; i < n; i++)
                    {
                        ++result;
                    }
                }
                else if (n < 0)
                {
                    for (int i = 0; i > n; i--)
                    {
                        --result;
                    }
                }
                return result;
            }
        }
    }
}