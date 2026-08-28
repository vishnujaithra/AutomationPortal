using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SdetToolbox.Pages;
using Selenium.BaseComponents.Pages;
using SeleniumExtensions.Extensions;
using Selenium.BaseComponents.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumExtensions.Configurations;
using OhpnmAutomation.Models.Registration;

namespace OhpnmAutomation.Pages.Registration
{
    public class ProviderContactInformation : BasePage
    {
        IWebDriver webDriver;
        string RegID;
        public ProviderContactInformation(IWebDriver webDriver, string RegID) : base(webDriver)
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

        #region Primary Contact Information

        public IWebElement? RegistrationTitle
        {
            get
            {
                return Selenium.BaseComponents.Utilities.PageHelper.IsElementExist(webDriver, By.Id("ctl00_MainContent_ucRegistrationNavigation_lblTitle")) ?
                    WebDriver.FindElement(By.Id("ctl00_MainContent_ucRegistrationNavigation_lblTitle")) : null;
            }
        }
        public IWebElement PrimaryContactName
        {
            get
            {
                return WebDriver.FindElement(By.Id($"ctl00_MainContent_ucPrimaryContactAddress_{RegID}_txtPrimaryContactName"));
            }
        }
        public IWebElement Title
        {
            get
            {
                return WebDriver.FindElement(By.Id($"ctl00_MainContent_ucPrimaryContactAddress_{RegID}_ucAddress_txtTitle"));
            }
        }
        public IWebElement Address1
        {
            get
            {
                return WebDriver.FindElement(By.Id($"ctl00_MainContent_ucPrimaryContactAddress_{RegID}_ucAddress_txtAddress1"));
            }
        }
        public IWebElement Address2
        {
            get
            {
                return WebDriver.FindElement(By.Id($"ctl00_MainContent_ucPrimaryContactAddress_{RegID}_ucAddress_txtAddress2"));
            }
        }
        public IWebElement City
        {
            get
            {
                return WebDriver.FindElement(By.Id($"ctl00_MainContent_ucPrimaryContactAddress_{RegID}_ucAddress_txtCity"));
            }
        }
        public IWebElement ZipCode
        {
            get
            {
                return WebDriver.FindElement(By.Id($"ctl00_MainContent_ucPrimaryContactAddress_{RegID}_ucAddress_nbZipFirst5"));
            }
        }
        public IWebElement ZipCodeExt
        {
            get
            {
                return WebDriver.FindElement(By.Id($"ctl00_MainContent_ucPrimaryContactAddress_{RegID}_ucAddress_nbZipLast4"));
            }
        }
        public IWebElement Phone1
        {
            get
            {
                return WebDriver.FindElement(By.Id($"ctl00_MainContent_ucPrimaryContactAddress_{RegID}_ucAddress_txtPhoneNo1"));
            }
        }
        public IWebElement Phone1Ext
        {
            get
            {
                return WebDriver.FindElement(By.Id($"ctl00_MainContent_ucPrimaryContactAddress_{RegID}_ucAddress_txtPhoneExt1"));
            }
        }
        public IWebElement Phone2
        {
            get
            {
                return WebDriver.FindElement(By.Id($"ctl00_MainContent_ucPrimaryContactAddress_{RegID}_ucAddress_txtPhoneNo2"));
            }
        }
        public IWebElement Phone2Ext
        {
            get
            {
                return WebDriver.FindElement(By.Id($"ctl00_MainContent_ucPrimaryContactAddress_{RegID}_ucAddress_txtPhoneExt2"));
            }
        }
        public IWebElement EmailAddress1
        {
            get
            {
                return WebDriver.FindElement(By.Id($"ctl00_MainContent_ucPrimaryContactAddress_{RegID}_ucAddress_txtEmail1"));
            }
        }

        public IWebElement AddressConfirmationbtn
        {
            get
            {
                return webDriver.WaitUntilElementIsVisibleAndReturn(By.Id($"ctl00_MainContent_ucPrimaryContactAddress_{RegID}_ucAddress_btnConfirmAddress"), TimeoutConfiguration.Page);
            }
        }

        public void SetState(string item)
        {
            IWebElement PracticeTypeElement = WebDriver.FindElement(By.Id($"ctl00_MainContent_ucPrimaryContactAddress_{RegID}_ucAddress_ddlState"));
            SelectElement PracticeTypeElementDropDown = new SelectElement(PracticeTypeElement);
            PracticeTypeElementDropDown.SelectByText(item);
        }
        public void SetCounty(string item)
        {
            IWebElement PracticeTypeElement = WebDriver.FindElement(By.Id($"ctl00_MainContent_ucPrimaryContactAddress_{RegID}_ucAddress_ddlCounty"));
            SelectElement PracticeTypeElementDropDown = new SelectElement(PracticeTypeElement);
            PracticeTypeElementDropDown.SelectByText(item);
        }
        public void SetPhone1MessageDisclaimer(string isYesorNo)
        {
            IWebElement webElement = null;
            switch (isYesorNo)
            {
                case "Yes":
                    webElement = WebDriver.FindElement(By.Id($"ctl00_MainContent_ucPrimaryContactAddress_{RegID}_ucAddress_rbCell1_0"));
                    break;
                case "No":
                    webElement = WebDriver.FindElement(By.XPath($"ctl00_MainContent_ucPrimaryContactAddress_{RegID}_ucAddress_rbCell1_1"));
                    break;
            }
            if (webElement != null)
            {
                webElement.Click();
            }
        }
        public void SetPhone2MessageDisclaimer(string isYesorNo)
        {
            IWebElement webElement = null;
            switch (isYesorNo)
            {
                case "Yes":
                    webElement = WebDriver.FindElement(By.Id($"ctl00_MainContent_ucPrimaryContactAddress_{RegID}_ucAddress_rbCell2_0"));
                    break;
                case "No":
                    webElement = WebDriver.FindElement(By.XPath($"ctl00_MainContent_ucPrimaryContactAddress_{RegID}_ucAddress_rbCell2_1"));
                    break;
            }
            if (webElement != null)
            {
                webElement.Click();
            }
        }

        #endregion

        #region Functions

        public void SetProviderContactInformation(ProviderContactInfo info)
        {
            if (!string.IsNullOrEmpty(info.PrimaryContactName))
                PrimaryContactName.Set(info.PrimaryContactName, true);

            if (!string.IsNullOrEmpty(info.Address1))
                Address1.Set(info.Address1, true);

            if (!string.IsNullOrEmpty(info.Address2))
                Address2.Set(info.Address2, true);

            if (!string.IsNullOrEmpty(info.City))
                City.Set(info.City, true);

            if (!string.IsNullOrEmpty(info.County))
                SetState(info.State);

            Thread.Sleep(2000);

            if (!string.IsNullOrEmpty(info.Zipcode))
                ZipCode.Set(info.Zipcode, true);

            if (!string.IsNullOrEmpty(info.ZipcodeExt))
                ZipCodeExt.Set(info.ZipcodeExt, true);

            if (!string.IsNullOrEmpty(info.Phone1))
                Phone1.Set(info.Phone1, true);

            if (!string.IsNullOrEmpty(info.Phone1Ext))
                Phone1Ext.Set(info.Phone1Ext, true);

            if (!string.IsNullOrEmpty(info.Phone2))
                Phone2.Set(info.Phone2, true);

            if (!string.IsNullOrEmpty(info.Phone2Ext))
                Phone2Ext.Set(info.Phone2Ext, true);

            if (!string.IsNullOrEmpty(info.EmailAddress1))
                EmailAddress1.Set(info.EmailAddress1, true);

            if (!string.IsNullOrEmpty(info.Phone1MessageDisclaimer))
                SetPhone1MessageDisclaimer(info.Phone1MessageDisclaimer);

            if (!string.IsNullOrEmpty(info.Phone2MessageDisclaimer))
                SetPhone2MessageDisclaimer(info.Phone2MessageDisclaimer);



            if (!string.IsNullOrEmpty(info.County))
                SetCounty(info.County);

        }

        #endregion
    }
}
