using Injector.ElementGetter;
using Injector.TypeExplorer;

namespace Injector.Example.User
{
    class Program
    {
        static void Main(string[] args)
        {
            ITypeLoader typeLoader = new TypeLoader();
            typeLoader.LoadAssemblies();

            ITypeExample myType = new InstanceGetter().GetInstance<ITypeExample>();
                myType.MethodExample();

        }
    }
}
