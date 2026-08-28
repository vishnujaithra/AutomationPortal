using OpenQA.Selenium;
using Selenium.BaseComponents.Pages;
using SeleniumExtensions.Extensions;
using Selenium.BaseComponents.Utilities;
using OhpnmAutomation.Models.Registration;
using OpenQA.Selenium.Support.UI;
using SeleniumExtensions.Configurations;
using System.Net.Mail;

namespace OhpnmAutomation.Pages.Registration
{
    public class OtherServiceLocations : BasePage
    {
        IWebDriver webDriver;
        string RegID;
        public OtherServiceLocations(IWebDriver webDriver, string RegID) : base(webDriver)
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

        #region Other Service Locations.

        public IWebElement? RegistrationTitle
        {
            get
            {
                return Selenium.BaseComponents.Utilities.PageHelper.IsElementExist(webDriver, By.Id("ctl00_MainContent_ucRegistrationNavigation_lblTitle")) ?
                    WebDriver.FindElement(By.Id("ctl00_MainContent_ucRegistrationNavigation_lblTitle")) : null;
            }
        }
        public IWebElement Name
        {
            get
            {
                return WebDriver.FindElement(By.Id($"ctl00_MainContent_ucSatellitePracticeLocations_{RegID}_prov_Name"));
            }
        }

        public IWebElement Address1
        {
            get
            {
                return WebDriver.FindElement(By.Id($"ctl00_MainContent_ucSatellitePracticeLocations_{RegID}_ucAddress_txtAddress1"));
            }
        }
        public IWebElement Address2
        {
            get
            {
                return WebDriver.FindElement(By.Id($"ctl00_MainContent_ucSatellitePracticeLocations_{RegID}_ucAddress_txtAddress2"));
            }
        }
        public IWebElement City
        {
            get
            {
                return WebDriver.FindElement(By.Id($"ctl00_MainContent_ucSatellitePracticeLocations_{RegID}_ucAddress_txtCity"));
            }
        }
        public IWebElement ZipCode
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucSatellitePracticeLocations_{RegID}_ucAddress_nbZipFirst5"), null);
            }
        }
        public IWebElement ZipCodeExt
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucSatellitePracticeLocations_{RegID}_ucAddress_nbZipLast4"), null);
            }
        }
        public IWebElement Phone1
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucSatellitePracticeLocations_{RegID}_ucAddress_txtPhoneNo1"), null);
            }
        }
        public IWebElement Phone1Ext
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucSatellitePracticeLocations_{RegID}_ucAddress_txtPhoneExt1"), null);
            }
        }
        public IWebElement Phone2
        {
            get
            {
                return WebDriver.FindElement(By.Id($"ctl00_MainContent_ucSatellitePracticeLocations_{RegID}_ucAddress_txtPhoneNo2"));
            }
        }
        public IWebElement Phone2Ext
        {
            get
            {
                return WebDriver.FindElement(By.Id($"ctl00_MainContent_ucSatellitePracticeLocations_{RegID}_ucAddress_txtPhoneExt2"));
            }
        }
        public IWebElement EffetiveDate
        {
            get
            {
                return WebDriver.FindElement(By.Id($"ctl00_MainContent_ucSatellitePracticeLocations_{RegID}_ucAddress_txtEffectiveDate"));
            }
        }

        public IWebElement EndDate
        {
            get
            {
                return WebDriver.FindElement(By.Id($"ctl00_MainContent_ucSatellitePracticeLocations_{RegID}_ucAddress_txtEndDate"));
            }
        }


        public IWebElement AddressConfirmationbtn
        {
            get
            {
                return webDriver.WaitUntilElementIsVisibleAndReturn(By.Id($"ctl00_MainContent_ucSatellitePracticeLocations_{RegID}_ucAddress_btnConfirmAddress"), TimeoutConfiguration.Page);
            }
        }
        public IWebElement AddressConfirmationbtnCancel
        {
            get
            {
                return webDriver.WaitUntilElementIsVisibleAndReturn(By.Id($"ctl00_MainContent_ucSatellitePracticeLocations_{RegID}_ucAddress_btnCancelAddressCorrection"), TimeoutConfiguration.Page);
            }
        }
        public IWebElement AddOtherLocationBtn
        {
            get
            {
                return webDriver.WaitUntilElementIsVisibleAndReturn(By.Id($"ctl00_MainContent_ucSatellitePracticeLocations_{RegID}_btnAddSatellitePracticeLocations"), TimeoutConfiguration.Page);
            }
        }

        public void SetState(string item)
        {
            IWebElement PracticeTypeElement = WebDriver.FindElement(By.Id($"ctl00_MainContent_ucSatellitePracticeLocations_{RegID}_ucAddress_ddlState"));
            SelectElement PracticeTypeElementDropDown = new SelectElement(PracticeTypeElement);
            PracticeTypeElementDropDown.SelectByText(item);
        }
        public void SetCounty(string item)
        {
            IWebElement PracticeTypeElement = WebDriver.FindElement(By.Id($"ctl00_MainContent_ucSatellitePracticeLocations_{RegID}_ucAddress_ddlCounty"));
            SelectElement PracticeTypeElementDropDown = new SelectElement(PracticeTypeElement);
            PracticeTypeElementDropDown.SelectByText(item);
        }

        #endregion

        public void SetOtherServiceLocations(OtherServiceLocationsDTO info)
        {
            if (!string.IsNullOrEmpty(info.Name))
                Name.Set(info.Name, true);

            if (!string.IsNullOrEmpty(info.Address1))
                Address1.Set(info.Address1, true);

            if (!string.IsNullOrEmpty(info.Address2))
                Address2.Set(info.Address2, true);

            if (!string.IsNullOrEmpty(info.City))
                City.Set(info.City, true);

            if (!string.IsNullOrEmpty(info.State))
                SetState(info.State);

            Thread.Sleep(3000);

            if (!string.IsNullOrEmpty(info.Zipcode))
                ZipCode.Set(info.Zipcode, true);

            if (!string.IsNullOrEmpty(info.ZipcodeExt))
                ZipCodeExt.Set(info.ZipcodeExt, true);

            if (!string.IsNullOrEmpty(info.Phone1))
                Phone1.SendKeys(info.Phone1);
            Thread.Sleep(2000);
            if (!string.IsNullOrEmpty(info.Phone1Ext))
                Phone1Ext.Set(info.Phone1Ext, true);

            if (!string.IsNullOrEmpty(info.Phone2))
                Phone2.Set(info.Phone2, true);

            if (!string.IsNullOrEmpty(info.Phone2Ext))
                Phone2Ext.Set(info.Phone2Ext, true);

            if (!string.IsNullOrEmpty(info.Zipcode))
                ZipCode.Set(info.Zipcode, true);

            if (!string.IsNullOrEmpty(info.County))
                SetCounty(info.County);
        }
    }
}
