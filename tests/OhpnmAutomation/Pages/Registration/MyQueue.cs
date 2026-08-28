using System;
using OpenQA.Selenium.Support.UI;
using Selenium.BaseComponents.Pages;
using SeleniumExtensions.Extensions;
using Selenium.BaseComponents.Utilities;
using OpenQA.Selenium;
using OhpnmAutomation.Models.Registration;
using SeleniumExtensions.Configurations;
using Selenium.BaseComponents.Data;

namespace OhpnmAutomation.Pages.Registration
{
 
    public class MyQueue: BasePage
    {
        IWebDriver webDriver;
        string RegID;

        public MyQueue(IWebDriver webDriver, string RegID) : base(webDriver)
        {

            this.webDriver = webDriver;

            string url = this.webDriver.Url;

            if (!string.IsNullOrEmpty(RegID))
            {
                this.RegID = RegID;
            }
            else
            {
                var regIDTag = url.Split('?').Last();
                var regID = regIDTag.Split('=').Last();
                this.RegID = regID;
            }
        }

        public IWebElement QueuePageHeader
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.XPath($"//*[@id='ctl00_pnlPageHeader']/div/h1"), null);
            }
        }

        public IWebElement SidebarMenu
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"menu"), null);
            }
        }

        public IWebElement ProviderSearch
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.XPath($"//a[@title='Provider Search']"), null);
            }
        }

        public void WaitUntilElementIsVisible()
        {
            PageHelper.WaitUntilElementIsVisible(webDriver, By.XPath("//*[@id='ctl00_pnlPageHeader']/div/h1"), TimeoutConfiguration.Element);
        }
    }
}
