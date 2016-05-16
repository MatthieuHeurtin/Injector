using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Injector.TypeExplorer
{
    public class LoadedType
    {
        public static List<Type>  types;
        
        public static void AddTypesFromThisAssembly(Assembly element)
        {
            if (types == null)
            {
                types = new List<Type>();
            }
            foreach(Type t in element.GetTypes())
            {
                if (!t.IsInterface)
                {
                    types.Add(t);
                }
            }
        }
    }
}
