using System;

namespace CombList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CombList cl = new CombList();
            cl.AddSpineNodeFirst(1);
            cl.AddSpineNodeLast(20);
            cl.AddSpineNodeFirst(5);
            cl.AddSpineNodeLast(26);
            cl.AddSpineNodeFirst(10);
            //Console.WriteLine(cl);
            //Console.WriteLine("\n");

            cl.AddToothNodeLast(0, 9);
            cl.AddToothNodeFirst(0, 14);
            cl.AddToothNodeLast(2, 3);
            cl.AddToothNodeFirst(4, 1);
            cl.AddToothNodeFirst(4, 1);
            cl.AddToothNodeFirst(4, 1);
            cl.AddToothNodeFirst(cl.Count-1, 1);
            cl.AddToothNodeLast(3, 2);
            cl.AddToothNodeFirst(0, 14);
            cl.AddToothNodeFirst(0, 14);
            cl.AddSpineNodeLast(100);
            cl.AddSpineNodeFirst(2);
            cl.AddSpineNodeFirst(1);
            cl.AddToothNodeFirst(4, 1431);
            cl.AddToothNodeFirst(3, 31);
            cl.AddToothNodeFirst(3, 31);
            cl.AddToothNodeFirst(3, 1);
            cl.AddToothNodeFirst(0, 552);
            cl.AddToothNodeFirst(3, 42);
            cl.AddToothNodeFirst(1, 51);
            cl.AddToothNodeFirst(1, 2);
            cl.AddToothNodeFirst(1, 2);
            cl.AddToothNodeFirst(1, 2);
            cl.AddToothNodeFirst(7, 2);
            cl.AddToothNodeFirst(6, 652);
            cl.AddToothNodeFirst(6, 1);
            cl.AddToothNodeFirst(6, 1);
            cl.AddToothNodeFirst(6, 1);
            cl.AddToothNodeFirst(6, 652);
            cl.AddToothNodeFirst(6, 1);
            cl.AddToothNodeFirst(6, 2);
            cl.AddToothNodeFirst(6, 652);
            cl.AddToothNodeFirst(6, 2);
            cl.AddSpineNodeLast(99);
            cl.AddToothNodeLast(cl.Count - 1, 99);
            cl.AddToothNodeLast(cl.Count - 1, 100);

            Console.WriteLine(cl);
            Console.WriteLine("\n");

            Console.WriteLine(cl.IsSpineNodeElement(2));

            cl.RemoveAllSpineNodesByValue(2);
            Console.WriteLine(cl);
            Console.WriteLine("\n");

            cl.RemoveToothNodeByIndex(0, 0);
            Console.WriteLine(cl);
            Console.WriteLine("\n");

            cl.RemoveAllToothNodesByValue(1);
            Console.WriteLine(cl);
            Console.WriteLine("\n");

        }
    }
}
