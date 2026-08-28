using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using static SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace SeleniumExtensions.Extensions
{
    public static class WebDriverExtensions
    {
        public static IWebElement FindElementWithRetry(this IWebDriver webDriver, By locator, IWait<IWebDriver> elementWait)
        {
            try
            {
                elementWait.Until(ElementExists(locator));
                return webDriver.FindElement(locator);
            }
            catch(WebDriverTimeoutException ex)
            {
                elementWait.Until(ElementExists(locator));
                return webDriver.FindElement(locator);
            }
        }

        public static void SaveScreenshot(this IWebDriver webDriver, string name)
        {
            Screenshot ss = ((ITakesScreenshot)webDriver).GetScreenshot();
            string screenshot = ss.AsBase64EncodedString;
            byte[] screenshotAsByteArray = ss.AsByteArray;
            ss.SaveAsFile(name + ".png");
        }
    }
}
