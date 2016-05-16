using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Injector.Example
{
    public class TypeExample2 : ITypeExample2
    {

        public void Amethod()
        {
            Console.WriteLine("I am method from type 2");
        }

    }
}
