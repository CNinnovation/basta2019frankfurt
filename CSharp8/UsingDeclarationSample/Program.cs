using System;

namespace UsingDeclaraationSample
{
    class Program
    {
        static void Main()
        {
            Run1();
            Run2();
            Run3();
            Console.WriteLine("fin");
        }

        static void Run1()
        {
            using var r = new Resource();
            r.Foo();
            Console.WriteLine("end Run1");
        }

        static void Run2()
        {
            {
                using var r = new Resource();
                r.Foo();
            }
            Console.WriteLine("next scope");
        }

        static void Run3()
        {
            {
                using var r = new Resource2();
                r.Foo();
            }
            Console.WriteLine("next scope");
        }

    }
}
