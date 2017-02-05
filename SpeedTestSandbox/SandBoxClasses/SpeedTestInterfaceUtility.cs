using System;
using System.Collections.Generic;
using System.Linq;

namespace SpeedTestSandbox.SandBoxClasses
{
    public static class SpeedTestInterfaceUtility
    {
        public static IList<Type> GetTestClasses()
        {
            var returnList = new List<Type>();

            var assemblies = AppDomain.CurrentDomain.GetAssemblies();

            foreach (var a in assemblies)
            {
                var testInterface = typeof(ISpeedTest);
                var assemblytypes = a.GetTypes();

                // Pull classes that implement the ISpeedTest interface.
                var t = assemblytypes.Where(x => testInterface.IsAssignableFrom(x) && x.IsClass);
                returnList.AddRange(t);
            }

            return returnList;
        }
    }
}