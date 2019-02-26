using System;

namespace SmallishFeatures
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        // not in preview 2
        static void DefaultLiteralDeconstruction()
        {
            (int i1, string j1) = (default, default); // C# 7

            // (int i2, string j2) = default; // C# 8

        }

        static void AlternativeInterpolatedVerbatimStrings()
        {
            string someFile = "someFile";
            var foo1 = $@"c:\foo\{someFile}"; // C# 7

            var foo2 = @$"c:\foo\{someFile}"; // C# 8

        }

        static void NullCoalescing(Person p)
        {
            if (p == null)
            {
                p = new Person();
            }

            p ??= new Person();

            Console.WriteLine(p.ToString());
        }
    }
}
