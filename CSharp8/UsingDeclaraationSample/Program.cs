using System;

namespace UsingDeclaraationSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Run1();
            Console.WriteLine("fin");
        }

        static void Run1()
        {
            {
                using var r = new Resource();
                r.Foo();
            }
            Console.WriteLine("next scope");
        }

    }
}
