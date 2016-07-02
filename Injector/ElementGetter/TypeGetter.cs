using Injector.TypeExplorer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Injector.ElementGetter
{
    public class InstanceGetter
    {
        public object GetInstance<T>()
        {
            return GetInstanceForThisInterface(typeof(T));
        }

        private static IEnumerable<ParameterInfo> GetConstructorParameters(Type t)
        {
            List<ParameterInfo> parameterInfos = new List<ParameterInfo>();
            foreach (ConstructorInfo constructorInfo in t.GetConstructors())
            {
                if (AreAllParametersInterfaces(constructorInfo))
                {
                    foreach (ParameterInfo parameterInfo in constructorInfo.GetParameters())
                    {
                        parameterInfos.Add(parameterInfo);
                    }
                    //take the first constuctor whose all parameters are Interfaces
                    return parameterInfos;
                }
            }
            return parameterInfos;
        }

        private object GetInstanceForThisInterface(Type type)
        {
            IEnumerable<ParameterInfo> parameters = null;
            foreach (Type t in LoadedType._types)
            {
                if (t.GetInterfaces().Where(x => x.FullName == type.FullName).Any())
                {
                    parameters = GetConstructorParameters(t);
                    
                    if (parameters == null || parameters.Count() == 0)
                    {
                        return Activator.CreateInstance(t);
                    }

                    List<object> parametersInstance = new List<object>();
                    foreach (ParameterInfo parameterInfo in parameters)
                    {
                        parametersInstance.Add(GetInstanceForThisInterface(parameterInfo.ParameterType));
                    }
                    return Activator.CreateInstance(t, parametersInstance.ToArray());
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
