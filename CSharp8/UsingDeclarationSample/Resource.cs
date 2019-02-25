using System;

namespace UsingDeclarationSample
{
    public class Resource : IDisposable
    {
        public void Foo() => Console.WriteLine("Resource.Foo");
        public void Dispose() => Console.WriteLine("Resource.Dispose");
    }

    public ref struct Resource2 // : IDisposable - ref structs cannot imlpement interfaces
    {
        public Resource2(int value1) => Value1 = value1;

        public int Value1 { get; }

        public void Foo() => Console.WriteLine("Resource2.Foo");

        public void Dispose() => Console.WriteLine("Resource2.Dipose");
    }
}
