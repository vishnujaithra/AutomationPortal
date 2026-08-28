using OpenQA.Selenium;
using SdetToolbox.Pages;
using Selenium.BaseComponents.Pages;
using SeleniumExtensions.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TC.PriorAuthSearch.Pages
{
    public class FinancialProviderInformationPage : BasePage
    {
        IWebDriver webDriver;

        public FinancialProviderInformationPage(IWebDriver webDriver) : base(webDriver)
        {
            this.webDriver = webDriver;
            string url = this.webDriver.Url;
        }

        public IWebElement lblTitle
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"lblTitle"), null);
            }
        }

        public IWebElement TxtMedicaid
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_txtMedicaidNumber"), null);
            }
        }

        public IWebElement lnkBtnPriorAuth
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_lnkBtnPriorAuth"), null);
            }
        }
        public void WaitUntilElementIsVisible()
        {
            PageHelper.WaitUntilElementIsVisible(webDriver, By.XPath("//*[@id='lblTitle']"), TimeoutConfiguration.Element);
        }
    }
}
