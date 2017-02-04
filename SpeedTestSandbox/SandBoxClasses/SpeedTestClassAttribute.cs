using System;
using System.Collections.Generic;
using System.Linq;

namespace SpeedTestSandbox.SandBoxClasses
{
    public class SpeedTestClassAttribute : Attribute
    {
    }

    public static class SpeedTestAttributeUtility
    {
        public static IList<Type> GetTestClasses()
        {
            //TODO: Pull types by Interface instead of assigning an attribute.
            var returnList = new List<Type>();

            var assemblies = AppDomain.CurrentDomain.GetAssemblies();

            foreach (var a in assemblies)
            {
                returnList.AddRange(a.GetTypes().Where(type => type.GetCustomAttributes(typeof(SpeedTestClassAttribute), true).Length > 0));
            }

            return returnList;
        }
    }
}