using Injector.TypeExplorer;
using System;
using System.Linq;
using System.Reflection;

namespace Injector.ElementGetter
{
    public class TypeGetter<T>
    {
        public object GetInstanceForType()
        {
            foreach (Type t in LoadedType.types)
            {
                if (t.GetInterfaces().Contains(typeof(T)))
                {
                    return Activator.CreateInstance(t);
                }
            }
            return null;
        }

        public object GetInstanceNamed(string typeName)
        {
            foreach (Type t in LoadedType.types)
            {
                if (t.GetInterfaces().Contains(typeof(T)) && Equals(t.Name, typeName))
                {
                    foreach (ConstructorInfo constructorInfo in t.GetConstructors())
                    {
                        if (AreAllParametersInterfaces(constructorInfo))
                        {
                            object[] parameters = new object[constructorInfo.GetParameters().Count()];
                            for (int i =0; i < constructorInfo.GetParameters().Count(); i++)
                            {
                                parameters[i] = GetInstanceForThisType(constructorInfo.GetParameters()[i].ParameterType);
                            }
                            return Activator.CreateInstance(t, parameters);
                        }
                        return null;
                    }
                    return null;
                }
            }
            return null;
        }

        private object GetInstanceForThisType(Type type)
        {
            foreach (Type t in LoadedType.types)
            {
                if (t.GetInterfaces().Where(x => x.FullName == type.FullName).Any())
                {
                    return Activator.CreateInstance(t);
                }
            }
            return null;
        }

        private static bool AreAllParametersInterfaces(ConstructorInfo constructorInfo)
        {
            return !constructorInfo.GetParameters().Where(x => !x.ParameterType.IsInterface).Any();
        }
    }
}
