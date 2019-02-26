using System;

namespace UsingDeclarationSample
{
    class Program
    {
        static void Main()
        {
            Run1();
            Run2();
            Run3();
            Run4();
            Console.WriteLine("fin");
        }

        static void Run1()
        {
            // using statement
            using (var r = new Resource())
            {
                r.Foo();
                Console.WriteLine("end Run1");
            }
        }

        static void Run2()
        {
            // using declaration
            using var r = new Resource();
            r.Foo();
            Console.WriteLine("end Run2");
        }

        static void Run3()
        {
            // using declaration with inner scope
            {
                using var r = new Resource();
                r.Foo();
            }
            Console.WriteLine("next scope");
        }

        static void Run4()
        {
            // pattern-based using with ref struct
            {
                using var r = new Resource2();
                r.Foo();
            }
            Console.WriteLine("next scope");
        }
    }
}
