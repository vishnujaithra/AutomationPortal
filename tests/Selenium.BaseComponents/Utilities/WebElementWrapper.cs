using OpenQA.Selenium;
using Selenium.BaseComponents.Pages;
using System.Collections.ObjectModel;

namespace Selenium.BaseComponents.Utilities
{
    public class WebElementWrapper : BasePage
    {
        public IWebDriver webDriver;


        public WebElementWrapper(IWebDriver webDriver) : base(webDriver)
        {
            this.webDriver = webDriver;
        }

        public IWebElement webElement = null;
        public IWebElement getElement(String locatorType, String locatorValue)
        {
            By by = null;
            IJavaScriptExecutor js = (IJavaScriptExecutor)webDriver;
            switch (locatorType.ToLower())
            {
                case "id":
                    by = By.Id(locatorValue);
                    break;
                case "name":
                    by = By.Name(locatorValue);
                    break;
                case "xpath":
                    by = By.XPath(locatorValue);
                    break;
                case "classname":
                    by = By.ClassName(locatorValue);
                    break;
                case "cssselector":
                    by = By.CssSelector(locatorValue);
                    break;
                case "linktext":
                    by = By.LinkText(locatorValue);
                    break;
            }

            int time = 0;
            while (time < 80)
            {
                try
                {

                    webElement = webDriver.FindElement(by);
                    js.ExecuteScript("arguments[0].style.border='2px solid red';", webElement);
                    Thread.Sleep(200);
                    js.ExecuteScript("arguments[0].style.border='2px solid blue';", webElement);
                    Thread.Sleep(200);
                    js.ExecuteScript("arguments[0].style.border='2px solid black';", webElement);
                    Thread.Sleep(200);
                    js.ExecuteScript("arguments[0].style.border='2px solid green';", webElement);
                    return webElement;
                }
                catch (Exception)
                {
                    System.Console.WriteLine("Wating for the element to visible " + locatorValue);
                    Thread.Sleep(1000);
                    time++;

                }
            }
            return null;
        }



        // Visit Ops

        public IWebElement FindElement(String locatorType, String locatorValue)
        {
            By by = null;
            IJavaScriptExecutor js = (IJavaScriptExecutor)webDriver;
            switch (locatorType.ToLower())
            {
                case "id":
                    by = By.Id(locatorValue);
                    break;
                case "name":
                    by = By.Name(locatorValue);
                    break;
                case "xpath":
                    by = By.XPath(locatorValue);
                    break;
                case "classname":
                    by = By.ClassName(locatorValue);
                    break;
                case "cssselector":
                    by = By.CssSelector(locatorValue);
                    break;
                case "linktext":
                    by = By.LinkText(locatorValue);
                    break;
            }

            int time = 0;
            while (time < 20)
            {
                try
                {
                    if (webDriver.FindElements(By.XPath("//span[text()='Processing...']")).Count > 0)
                    {
                        webElement = webDriver.FindElement(By.XPath("//span[contains(@id,'progressIndicator.start') and contains(@style,'none')]"));
                    }
                    webElement = webDriver.FindElement(by);
                    js.ExecuteScript("arguments[0].style.border='2px solid red';", webElement);
                    Thread.Sleep(200);
                    js.ExecuteScript("arguments[0].style.border='2px solid blue';", webElement);
                    Thread.Sleep(200);
                    js.ExecuteScript("arguments[0].style.border='2px solid black';", webElement);
                    Thread.Sleep(200);
                    js.ExecuteScript("arguments[0].style.border='2px solid green';", webElement);
                    return webElement;
                }
                catch (Exception)
                {
                    System.Console.WriteLine("Wating for the element to visible " + locatorValue);
                    Thread.Sleep(1000);
                    time++;

                }
            }
            return null;
        }


        public void ClickByJS()
        {

            IJavaScriptExecutor js = (IJavaScriptExecutor)webDriver;
            js.ExecuteScript("arguments[0].click()", webElement);
        }
    }

    public class RadioButtons
    {
        public RadioButtons(IWebDriver driver, ReadOnlyCollection<IWebElement> webElements)
        {
            Driver = driver;
            WebElements = webElements;
        }

        protected IWebDriver Driver { get; }

        protected ReadOnlyCollection<IWebElement> WebElements { get; }

        public void SelectValue(String value)
        {
            WebElements.Single(we => we.GetAttribute("text") == value).Click();
        }
    }

    /// <summary>
    /// Smart element wrapper that automatically handles stale elements by refreshing them
    /// This allows minimal changes to existing page objects while fixing caching issues
    /// </summary>
    public class SmartElement
    {
        private readonly IWebDriver _driver;
        private readonly By _locator;
        private IWebElement _cachedElement;
        private readonly Func<By> _locatorFunc;
        private const int DefaultTimeoutSeconds = 10;
        private const int DefaultRetryCount = 3;

        public SmartElement(IWebDriver driver, By locator)
        {
            _driver = driver;
            _locator = locator;
        }

        public SmartElement(IWebDriver driver, Func<By> locatorFunc)
        {
            _driver = driver;
            _locatorFunc = locatorFunc;
        }

        /// <summary>
        /// Gets the locator used by this SmartElement
        /// </summary>
        public By Locator => _locatorFunc != null ? _locatorFunc() : _locator;

        /// <summary>
        /// Gets the element, automatically refreshing if stale
        /// </summary>
        public IWebElement Element
        {
            get
            {
                try
                {
                    // Try to use cached element first
                    if (_cachedElement != null)
                    {
                        // Quick check if element is still valid
                        var displayed = _cachedElement.Displayed;
                        return _cachedElement;
                    }
                }
                catch (StaleElementReferenceException)
                {
                    // Element is stale, will refresh below
                }
                catch (NoSuchElementException)
                {
                    // Element not found, will refresh below
                }

                // Refresh the element
                return RefreshElement();
            }
        }

        /// <summary>
        /// Forces a refresh of the element
        /// </summary>
        public IWebElement RefreshElement()
        {
            var locator = Locator;
            _cachedElement = _driver.FindElement(locator);
            return _cachedElement;
        }

        /// <summary>
        /// Waits for the element to be visible before returning it
        /// </summary>
        public IWebElement WaitAndGetElement(int timeoutSeconds = DefaultTimeoutSeconds)
        {
            var locator = Locator;
            WaitForVisible(timeoutSeconds);
            return RefreshElement();
        }

        /// <summary>
        /// Waits for the element to be visible
        /// </summary>
        public void WaitForVisible(int timeoutSeconds = DefaultTimeoutSeconds)
        {
            var locator = Locator;
            var wait = new OpenQA.Selenium.Support.UI.WebDriverWait(_driver, TimeSpan.FromSeconds(timeoutSeconds));
            wait.Until(driver =>
            {
                try
                {
                    var element = driver.FindElement(locator);
                    return element.Displayed;
                }
                catch { return false; }
            });
        }

        /// <summary>
        /// Waits for the element to be clickable (visible and enabled)
        /// </summary>
        public void WaitForClickable(int timeoutSeconds = DefaultTimeoutSeconds)
        {
            var locator = Locator;
            var wait = new OpenQA.Selenium.Support.UI.WebDriverWait(_driver, TimeSpan.FromSeconds(timeoutSeconds));
            wait.Until(driver =>
            {
                try
                {
                    var element = driver.FindElement(locator);
                    return element.Displayed && element.Enabled;
                }
                catch { return false; }
            });
        }

        /// <summary>
        /// Clicks the element with automatic wait, scroll, retry, and JavaScript fallback.
        /// This is the safest way to click elements in headless mode.
        /// </summary>
        public void Click(int retryCount = DefaultRetryCount)
        {
            var locator = Locator;
            Exception lastException = null;

            for (int attempt = 0; attempt < retryCount; attempt++)
            {
                try
                {
                    // Wait for element to be clickable
                    WaitForClickable();
                    
                    // Get fresh element reference
                    var element = RefreshElement();
                    
                    // Scroll element into view
                    ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView({block: 'center'});", element);
                    Thread.Sleep(150); // Brief pause for scroll to complete
                    
                    // Try normal click
                    element.Click();
                    return; // Success!
                }
                catch (StaleElementReferenceException ex)
                {
                    lastException = ex;
                    _cachedElement = null; // Clear cache
                    Thread.Sleep(200);
                }
                catch (ElementClickInterceptedException ex)
                {
                    lastException = ex;
                    // Element is covered by another element, try JS click
                    try
                    {
                        var element = RefreshElement();
                        ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", element);
                        return;
                    }
                    catch { }
                    Thread.Sleep(300);
                }
                catch (ElementNotInteractableException ex)
                {
                    lastException = ex;
                    // Try JavaScript click as fallback
                    try
                    {
                        var element = RefreshElement();
                        ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", element);
                        return; // JS click succeeded
                    }
                    catch (Exception jsEx)
                    {
                        lastException = jsEx;
                    }
                }
                catch (Exception ex)
                {
                    lastException = ex;
                    Thread.Sleep(200);
                }
            }

            throw new Exception($"Failed to click element after {retryCount} attempts. Locator: {locator}", lastException);
        }

        /// <summary>
        /// Clicks using JavaScript directly (bypasses all visibility checks)
        /// </summary>
        public void ClickByJS()
        {
            var element = Element;
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", element);
        }

        public void Clear() => Element.Clear();
        
        public void SendKeys(string text)
        {
            WaitForVisible();
            var element = RefreshElement();
            element.Clear();
            element.SendKeys(text);
        }

        public string Text => Element.Text;
        public bool Displayed => Element.Displayed;
        public bool Enabled => Element.Enabled;
        public bool Selected => Element.Selected;
        public string GetAttribute(string name) => Element.GetAttribute(name);
    }

    /// <summary>
    /// A wrapper around IWebElement that provides safe operations for headless mode.
    /// Implements IWebElement so it can be used as a drop-in replacement.
    /// </summary>
    public class SafeWebElement : IWebElement
    {
        private readonly IWebElement _element;
        private readonly IWebDriver _driver;
        private readonly By _locator;
        private const int DefaultRetryCount = 3;

        public SafeWebElement(IWebElement element, IWebDriver driver, By locator = null)
        {
            _element = element;
            _driver = driver;
            _locator = locator;
        }

        private IWebElement GetFreshElement()
        {
            if (_locator != null)
            {
                try
                {
                    return _driver.FindElement(_locator);
                }
                catch
                {
                    return _element;
                }
            }
            return _element;
        }

        /// <summary>
        /// Safe click with scroll, retry, and JS fallback
        /// </summary>
        public void Click()
        {
            Exception lastException = null;

            for (int attempt = 0; attempt < DefaultRetryCount; attempt++)
            {
                try
                {
                    var element = GetFreshElement();
                    
                    // Scroll into view
                    ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView({block: 'center'});", element);
                    Thread.Sleep(150);
                    
                    element.Click();
                    return;
                }
                catch (StaleElementReferenceException ex)
                {
                    lastException = ex;
                    Thread.Sleep(200);
                }
                catch (ElementClickInterceptedException ex)
                {
                    lastException = ex;
                    try
                    {
                        var element = GetFreshElement();
                        ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", element);
                        return;
                    }
                    catch { }
                    Thread.Sleep(300);
                }
                catch (ElementNotInteractableException ex)
                {
                    lastException = ex;
                    try
                    {
                        var element = GetFreshElement();
                        ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", element);
                        return;
                    }
                    catch { }
                }
                catch (Exception ex)
                {
                    lastException = ex;
                    Thread.Sleep(200);
                }
            }

            throw new Exception($"Failed to click element after {DefaultRetryCount} attempts", lastException);
        }

        public void Clear() => _element.Clear();
        
        public void SendKeys(string text)
        {
            var element = GetFreshElement();
            try
            {
                ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView({block: 'center'});", element);
                Thread.Sleep(100);
            }
            catch { }
            element.SendKeys(text);
        }

        public void Submit() => _element.Submit();
        public string GetAttribute(string attributeName) => GetFreshElement().GetAttribute(attributeName);
        public string GetDomAttribute(string attributeName) => GetFreshElement().GetDomAttribute(attributeName);
        public string GetDomProperty(string propertyName) => GetFreshElement().GetDomProperty(propertyName);
        public string GetCssValue(string propertyName) => GetFreshElement().GetCssValue(propertyName);
        public ISearchContext GetShadowRoot() => GetFreshElement().GetShadowRoot();
        public string TagName => GetFreshElement().TagName;
        public string Text => GetFreshElement().Text;
        public bool Enabled => GetFreshElement().Enabled;
        public bool Selected => GetFreshElement().Selected;
        public System.Drawing.Point Location => GetFreshElement().Location;
        public System.Drawing.Size Size => GetFreshElement().Size;
        public bool Displayed => GetFreshElement().Displayed;
        
        public IWebElement FindElement(By by) => new SafeWebElement(_element.FindElement(by), _driver, by);
        public ReadOnlyCollection<IWebElement> FindElements(By by) => _element.FindElements(by);
    }

    /// <summary>
    /// Extension methods to create smart wrappers with minimal code changes
    /// </summary>
    public static class SmartElementExtensions
    {
        /// <summary>
        /// Creates a smart wrapper from a locator function
        /// Usage: var smartElement = driver.CreateSmartElement(() => By.Id("myElement"));
        /// </summary>
        public static SmartElement CreateSmartElement(this IWebDriver driver, Func<By> locatorFunc)
        {
            return new SmartElement(driver, locatorFunc);
        }

        /// <summary>
        /// Creates a smart wrapper from a static locator
        /// Usage: var smartElement = driver.CreateSmartElement(By.Id("myElement"));
        /// </summary>
        public static SmartElement CreateSmartElement(this IWebDriver driver, By locator)
        {
            return new SmartElement(driver, locator);
        }

        /// <summary>
        /// Wraps an existing IWebElement property with smart refresh logic
        /// Usage: var smartElement = existingElementProperty.AsSmartElement(driver, () => By.Id("myElement"));
        /// </summary>
        public static SmartElement AsSmartElement(this IWebElement element, IWebDriver driver, Func<By> locatorFunc)
        {
            return new SmartElement(driver, locatorFunc);
        }

        /// <summary>
        /// Finds an element and wraps it in SafeWebElement for headless-safe operations.
        /// Usage: var element = driver.FindElementSafe(By.Id("myElement"));
        /// </summary>
        public static SafeWebElement FindElementSafe(this IWebDriver driver, By locator)
        {
            var element = driver.FindElement(locator);
            return new SafeWebElement(element, driver, locator);
        }

        /// <summary>
        /// Finds an element with wait and wraps it in SafeWebElement.
        /// Usage: var element = driver.FindElementSafeWithWait(By.Id("myElement"), 10);
        /// </summary>
        public static SafeWebElement FindElementSafeWithWait(this IWebDriver driver, By locator, int timeoutSeconds = 10)
        {
            var wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSeconds));
            wait.Until(d =>
            {
                try
                {
                    var el = d.FindElement(locator);
                    return el.Displayed;
                }
                catch { return false; }
            });
            
            var element = driver.FindElement(locator);
            return new SafeWebElement(element, driver, locator);
        }

        /// <summary>
        /// Wraps an existing IWebElement in SafeWebElement for safe operations.
        /// Usage: element.AsSafe(driver);
        /// </summary>
        public static SafeWebElement AsSafe(this IWebElement element, IWebDriver driver, By locator = null)
        {
            return new SafeWebElement(element, driver, locator);
        }
    }
}
