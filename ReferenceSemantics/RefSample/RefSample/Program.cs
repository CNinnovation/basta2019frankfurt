using System;

namespace RefSample
{
    struct X
    {
        public int A { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            X obj = new X();
            obj.A = 1;
            ChangeX(ref obj);
            Console.WriteLine(obj.A);
        }

        static void ChangeX(ref X x1)
        {
            x1.A = 2;
        }
    }
}
