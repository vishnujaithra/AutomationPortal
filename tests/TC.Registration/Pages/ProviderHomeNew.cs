using OpenQA.Selenium;
using SdetToolbox.Pages;
using Selenium.BaseComponents.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TC.ProviderDataEntry.Pages
{
    public class ProviderHomeNew : BasePage
    {
        IWebDriver webDriver;
        string RegID;
        public ProviderHomeNew(IWebDriver webDriver, string RegID) : base(webDriver)
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

        public IWebElement RegIDFilterTextBox
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_gvMyProviders_ctl00_ctl02_ctl02_FilterTextBox_TemplateColumn"), null);
            }
        }

        public IWebElement RegIDFilter
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_gvMyProviders_ctl00_ctl02_ctl02_Filter_TemplateColumn"), null);
            }
        }

        public IWebElement RegIDFilterEqualsTo
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.XPath("//*[@id='ctl00_MainContent_gvMyProviders_rfltMenu_detached']/ul/li[6]/a/span"), null);
            }
        }
    }
}
