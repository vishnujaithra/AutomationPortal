using System;
using System.Collections.Generic;
using System.Text;
 
using System.Threading;
using Selenium.BaseComponents.Utilities;
using Selenium.BaseComponents.Pages;
using OpenQA.Selenium;
using System.Collections.ObjectModel;
using System.Linq;

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
}
