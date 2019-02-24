using System;
using System.Collections.Generic;
using System.Text;

namespace UsingDeclaraationSample
{
    public class Resource // : IDisposable
    {
        public void Foo() => Console.WriteLine("Resource.Foo");
        public void Dispose() => Console.WriteLine("Resource.Dispose");
    }
}
