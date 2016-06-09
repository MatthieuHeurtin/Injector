using System;
using System.Collections.Generic;
using System.Reflection;

namespace Injector.TypeExplorer
{
    public class LoadedType
    {
        public static List<Type> _types { get; set; }
        
        public static void AddTypesFromThisAssembly(Assembly element)
        {
            if (_types == null)
            {
                _types = new List<Type>();
            }
            foreach(Type t in element.GetTypes())
            {
                if (!t.IsInterface)
                {
                    _types.Add(t);
                }
            }
        }
    }
}
