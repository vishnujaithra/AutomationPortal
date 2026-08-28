using System;
using System.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Threading;
 

namespace Selenium.BaseComponents.Utilities
{

    public class UtilityPage
    {
        public static int PageTimeOut = Convert.ToInt32(ConfigurationManager.AppSettings["ControlTimeout"]);
        public static int ControlTimeOut = Convert.ToInt32(ConfigurationManager.AppSettings["PageTimeout"]);
        public static int SleepTimeOut = Convert.ToInt32(ConfigurationManager.AppSettings["SleepTimeOut"]);
        public static int DBTimeOut = Convert.ToInt32(ConfigurationManager.AppSettings["DBTimeout"]);

        public static void WaitFor(IWebDriver Driver, Func<IWebDriver, bool> waitCondition, int timeout = 100)
        {
            var wait = new WebDriverWait(Driver, new TimeSpan(0, 0, UtilityPage.PageTimeOut));
            wait.Until(waitCondition);
        }

        public static void ExecuteJSScript(IWebDriver Driver, string javaScript, params object[] args)
        {
            var js = Driver as IJavaScriptExecutor;
            js.ExecuteScript(javaScript, args);
        }

    }
}
