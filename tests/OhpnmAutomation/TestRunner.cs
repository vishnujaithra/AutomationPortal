using OhpnmAutomation.Tests;
using Selenium.BaseComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OhpnmAutomation
{
    public class TestRunner
    {
        [CustomRetry(1)]
        public void GetTestcases()
        {
            MethodInfo[] methodInfo = typeof(RegistrationTest).GetMethods(BindingFlags.Public | BindingFlags.Static);

            if (methodInfo != null && methodInfo.Count() > 0)
            {
                foreach (MethodInfo method in methodInfo)
                {
                    var attribute = method.Attributes;
                }
            }
        }
    }
}
