using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Injector.TypeExplorer
{
    public class TypeLoader
    {
        private const string DLLExtension = ".dll";
        private const string EXEExtension = ".exe";
        public void Load()
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
