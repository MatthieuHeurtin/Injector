using Injector.ElementGetter;
using Injector.TypeExplorer;

namespace Injector.Example.User
{
    class Program
    {
        static void Main(string[] args)
        {
            new TypeLoader().Load();
            ITypeExample myType = new TypeGetter<ITypeExample>().GetInstanceNamed("TypeExample") as ITypeExample;
            myType.MethodExample();

        }
    }
}
