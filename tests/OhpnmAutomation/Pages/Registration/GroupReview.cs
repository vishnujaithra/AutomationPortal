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
    public class GroupReview : BasePage
    {
        IWebDriver webDriver;
        string RegID;

        public GroupReview(IWebDriver webDriver, string RegID) : base(webDriver)
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

        public IWebElement txtRegID
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucGroupReview_txtRegID"), null);
            }
        }

        public IWebElement Search
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucGroupReview_btnSearch"), null);
            }
        }

        public IWebElement ProviderSearch
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.XPath($"//a[@title='Provider Search']"), null);
            }
        }
       
        public void WaitUntilRowCountIsVisible()
        {
            PageHelper.WaitUntilElementIsVisible(webDriver, By.Id("ctl00_MainContent_ucGroupReview_lnkRowCount"), TimeoutConfiguration.Element);
        }

        public IWebElement Review
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.XPath($"//table[@id='ctl00_MainContent_ucGroupReview_gvProviders']//a[text()='Review']"), null);
            }
        }
        public IWebElement SidebarMenu
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"menu"), null);
            }
        }

    }
}
