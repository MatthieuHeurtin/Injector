using System;

namespace Injector.Example
{
    public class TypeExample   : ITypeExample
    {
        public int _propertyExample { get; private set; }


        public TypeExample(ITypeExample2 example2 , ITypeExample3 exmaple3)
        {
            Console.WriteLine("I am the constuctor of typeExample1");
            exmaple3.SomeMethod();
            example2.Amethod();
        }

        public void MethodExample()
        {
            _propertyExample = 50;
        }

    }
}
