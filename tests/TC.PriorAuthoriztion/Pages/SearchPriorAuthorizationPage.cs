using OpenQA.Selenium;
using SdetToolbox.Pages;
using Selenium.BaseComponents.Pages;
using SeleniumExtensions.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 

namespace TC.PriorAuthoriztion.Pages
{
    public class SearchPriorAuthorizationPage : BasePage
    {
        IWebDriver webDriver;

        public SearchPriorAuthorizationPage(IWebDriver webDriver) : base(webDriver)
        {
            this.webDriver = webDriver;
            string url = this.webDriver.Url;
        }
 

        public IWebElement lnkBtnSubmitPriorAuth
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.XPath($"//span[text()='Submit PA']"), null);
            }
        }
        public void WaitUntilElementIsVisible()
        {
            PageHelper.WaitUntilElementIsVisible(webDriver, By.XPath("//*[@id='ctl00_MainContent_ucRegProgressBar_lblPRONPI2']"), TimeoutConfiguration.Element);
        }
    }
}

