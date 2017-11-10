using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace StackCafe.Common.AppDomainScanner
{
    public static class AppDomainScanner
    {
        static AppDomainScanner()
        {
            ForceLoadReferencedAssemblies(AppDomain.CurrentDomain.GetAssemblies());
            MyAssemblies = ScanForMyAssemblies();
        }

        public static Assembly[] MyAssemblies { get; }

        private static void ForceLoadReferencedAssemblies(Assembly[] assembliesToTraverse)
        {
            var alreadySeen = new List<AssemblyName>();
            foreach (var assembly in assembliesToTraverse)
            {
                ForceLoadReferencedAssemblies(assembly, alreadySeen);
            }
        }

        private static void ForceLoadReferencedAssemblies(Assembly assembly, List<AssemblyName> alreadySeen)
        {
            var assemblyNamesToLoad = assembly.GetReferencedAssemblies()
                .Where(a => a.Name.Contains("StackCafe"))
                .Except(alreadySeen)
                .ToArray();

            foreach (var assemblyName in assemblyNamesToLoad)
            {
                alreadySeen.Add(assemblyName);
                var referencedAssembly = Assembly.Load(assemblyName);
                ForceLoadReferencedAssemblies(referencedAssembly, alreadySeen);
            }
        }

        private static Assembly[] ScanForMyAssemblies()
        {
            var myAssemblies = AppDomain.CurrentDomain.GetAssemblies()
                .Where(a => a.GetName().FullName.Contains("StackCafe"))
                .ToArray();
            return myAssemblies;
        }
    }
}