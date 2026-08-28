using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SdetToolbox.Pages;
using Selenium.BaseComponents.Pages;
using SeleniumExtensions.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace TC.ProviderDataEntry.Pages.Registration
{
    public class NPIAndMedID : BasePage
    {
        IWebDriver webDriver;
        string RegID;

        public NPIAndMedID(IWebDriver webDriver, string RegID) : base(webDriver)
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

        public IWebElement NPIGridEditToUpdateTheDate
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.XPath($"//*[@id='ctl00_MainContent_ucNPIandMedId_{RegID}_ucEnrollmentData_rgApplicationType_ctl00_ctl04_EditButton']"), null);

            }
        }

        public IWebElement txtProviderEffectiveDate
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.XPath($"//*[@id='ctl00_MainContent_ucNPIandMedId_{RegID}_ucEnrollmentData_rgApplicationType_ctl00_ctl05_txtProviderEffectiveDate']"), null);

            }
        }
        public IWebElement btnUpdate
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.XPath($"//*[@id='ctl00_MainContent_ucNPIandMedId_{RegID}_ucEnrollmentData_rgApplicationType_ctl00_ctl05_btnUpdate']"), null);

            }
        }


        public void WaitUntilPageLoad()
        {
            PageHelper.WaitUntilElementIsVisible(webDriver,
                                  By.XPath($"//*[@id='ctl00_MainContent_ucNPIandMedId_{RegID}_ucEnrollmentData_rgApplicationType_ctl00_ctl05_txtProviderEffectiveDate']"), TimeoutConfiguration.Element);
        }

        public void UpdateEffectiveDate()
        {
            NPIGridEditToUpdateTheDate.Click();
            WaitUntilPageLoad();


            txtProviderEffectiveDate.SendKeys(DateTime.Now.ToString("MM/dd/yyyy"));
            btnUpdate.Click();

            PageHelper.WaitUntilElementNotAvailable(webDriver, By.XPath($"//*[@id='ctl00_MainContent_ucNPIandMedId_{RegID}_ucEnrollmentData_rgApplicationType_ctl00_ctl05_btnUpdate']"),
                TimeoutConfiguration.Element);
        }
    }
}
