using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TestFramework;

namespace CommonTestFramework
{
    public static  class TestFramework
    {
        public static void Start(string assemblyFile)
        {
            var assembly = Assembly.LoadFrom(assemblyFile);
            var types = assembly.GetExportedTypes();
            DateTime maxTime = DateTime.MinValue;
            Type targetType = null;
            foreach (var type in types)
            {
                var executingAttr = type.GetCustomAttribute<ExecutingAttribute>();
                if (executingAttr != null)
                {
                    if (executingAttr.Time > maxTime)
                    {
                        maxTime = executingAttr.Time;
                        targetType = type;
                    }
                }
            }
            if (targetType != null)
            {
                try
                {
                    var instance = Activator.CreateInstance(targetType);
                    targetType.GetMethod("Start").Invoke(instance, null);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message + Environment.NewLine + ex.StackTrace);
                }
            }
        }
    }
}
