using Lab2;
using System;

namespace TestRingClassLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            void Print(String title, Object obj)
            {
                Console.WriteLine(title);
                Console.WriteLine(obj);
                Console.WriteLine();
            }

            int[] data = new int[] { 10, 20, 30, 40, 50, 60 };
            Ring MyRing1 = new Ring(data);
            Print("Ring creation with an array as a parameter", MyRing1);

            Ring MyRing2 = Ring.CreateRingFromInput();
            Console.WriteLine();
            Print("Ring creation by input", MyRing2);

            ++MyRing1;
            ++MyRing1;
            ++MyRing1;
            Print("Move the pointer clockwise", MyRing1);

            --MyRing1;
            Print("Move the pointer counterclockwise", MyRing1);

            MyRing1 = MyRing1[-2];
            Print("Indexer implementation", MyRing1);

            Print("Inequality operator", MyRing1 != MyRing2);

            MyRing2 = new Ring(new int[] { 10, 20, 30, 40, 50 });
            MyRing2 = MyRing2 >> 60;
            Print("Element addition result", MyRing2);

            Print("Equality operator", MyRing1 == MyRing2);

            int x = 0;
            Print("Return of ring's data without item extraction", MyRing1 < x);

            Print("Ring after operation <", MyRing1);

            Print("Return of ring's data with item extraction", MyRing1 > x);

            Print("Ring after operation >", MyRing1);

            MyRing2 = new Ring();
            var result1 = MyRing1 ? "Not Empty" : "Empty";
            var result2 = MyRing2 ? "Not Empty" : "Empty";
            Print("True/false result", result1);
            Print("True/false result", result2);

            Ring MyRing3 = new Ring(data);
            Print("Ring creation", MyRing3);
            int[] numbers;
            numbers = (int[])MyRing3;
            String arrayData = String.Empty;
            foreach (var item in numbers)
            {
                arrayData+= item + " ";
            }
            Print("Casting Ring to array", arrayData);
            MyRing2 = (Ring)numbers;
            Print("Casting array ro Ring", MyRing2);
        }
    }
}