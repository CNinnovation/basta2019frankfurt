using System;
using System.Linq;

namespace SpanSample1
{
    ref struct MyStruct
    {
        public MyStruct(int x)
        {
            X = x;
        }
        public int X { get; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //Span<int> span1 = new Span<int>();
            //span1.ToString();

            string mystring = "the quick brown fox jumped ";
            ReadOnlySpan<char> span1 = mystring.AsSpan();
            int[] data = Enumerable.Range(1, 100).ToArray();
            Span<int> span2 = data.AsSpan();
            Span<int> slice = span2.Slice(8, 10);
            foreach (int item in slice)
            {
                Console.WriteLine(item);
            }
        }
    }
}
