using System;

namespace UsingDeclarationSample
{
    public class Resource : IDisposable
    {
        public void Foo() => Console.WriteLine("Resource.Foo");
        public void Dispose() => Console.WriteLine("Resource.Dispose");
    }
}
