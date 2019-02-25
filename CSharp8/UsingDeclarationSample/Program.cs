using System;

namespace UsingDeclaraationSample
{
    class Program
    {
        static void Main()
        {
            Run1();
            Run2();
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

        static void Run2()
        {
            {
                using var r = new Resource2();
                r.Foo();
            }
            Console.WriteLine("next scope");
        }

    }
}
