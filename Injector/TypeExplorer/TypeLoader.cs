using System;
using System.IO;
using System.Reflection;

namespace Injector.TypeExplorer
{
    public class TypeLoader : ITypeLoader
    {
        private const string DLLExtension = ".dll";
        private const string EXEExtension = ".exe";

        public void LoadAssemblies()
        {
            foreach (string file in Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory))
            {
                if (IsADll(file) || IsAnExe(file))
                {
                    Assembly assembly = Assembly.LoadFrom(Path.GetFileName(file));
                    LoadedType.AddTypesFromThisAssembly(assembly);
                }
            }
        }

        private static bool IsADll(string file)
        {
            return string.Equals(Path.GetExtension(file), DLLExtension);
        }

        private static bool IsAnExe(string file)
        {
            return String.Equals(Path.GetExtension(file), EXEExtension);
        }
    }
}
