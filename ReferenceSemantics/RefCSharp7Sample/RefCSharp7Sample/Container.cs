using System;
using System.Collections.Generic;
using System.Text;

namespace RefCSharp7Sample
{
    class Container
    {
        private int[] _data;
        public Container(int[] data) => _data = data;

        public ref readonly int GetByIndex(int index) => ref _data[index];


        public void PassByRef(in int x)
        {

        }
    }
}
