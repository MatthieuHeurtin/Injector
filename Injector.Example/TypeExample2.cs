using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Injector.Example
{
    public class TypeExample2 : ITypeExample2
    {

        public int _propertyExample2 { get; private set; }

        ITypeExample3 _typeExample3;



        public TypeExample2(ITypeExample3 typeExample3)
        {
            Console.WriteLine("I am the constuctor of typeExample2");
            _typeExample3 = typeExample3;
            _typeExample3.SomeMethod();
            _propertyExample2 = 69;
        }


        public void Amethod()
        {
            Console.WriteLine("I am method from type 2");
        }

    }
}
