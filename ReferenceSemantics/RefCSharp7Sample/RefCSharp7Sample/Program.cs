using System;

namespace RefCSharp7Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 2, 3, 4, 5 };
            var container = new Container(arr);
            ref readonly int n = ref container.GetByIndex(2);
            // n = 42;
            Console.WriteLine(arr[2]);

            int x = 42;
            container.PassByRef(x);
        }
    }
}
