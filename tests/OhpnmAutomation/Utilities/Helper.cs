using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OhpnmAutomation.Utilities
{
    public static class Helper
    {
        public static byte[] PrintScreenShot(IWebDriver TestWebDriver, string title = "")
        {
            var screenshot = (TestWebDriver as ITakesScreenshot)?.GetScreenshot();
            return screenshot?.AsByteArray ?? Array.Empty<byte>();
        }

    }
}
