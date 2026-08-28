using OhpnmAutomation.Models.Registration;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Selenium.BaseComponents.Pages;
using SeleniumExtensions.Configurations;
using SeleniumExtensions.Extensions;
using Selenium.BaseComponents.Utilities;

namespace OhpnmAutomation.Pages.Registration
{
    public class HomeOfficeAddress:BasePage
    {
        IWebDriver webDriver;
        string RegID;
        public HomeOfficeAddress(IWebDriver webDriver, string RegID) : base(webDriver)
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
        #region Home Office Address

        public IWebElement? RegistrationTitle
        {
            get
            {
                return Selenium.BaseComponents.Utilities.PageHelper.IsElementExist(webDriver, By.Id("ctl00_MainContent_ucRegistrationNavigation_lblTitle")) ?
                    WebDriver.FindElement(By.Id("ctl00_MainContent_ucRegistrationNavigation_lblTitle")) : null;
            }
        }
        public IWebElement FirstName
        {
            get
            {
                return WebDriver.FindElement(By.Id($"ctl00_MainContent_ucHomeOfficeAddress_{RegID}_ucAddress_txtFirst"));
            }
        }
        public IWebElement MiddleName
        {
            get
            {
                return WebDriver.FindElement(By.Id($"ctl00_MainContent_ucHomeOfficeAddress_{RegID}_ucAddress_txtMiddle"));
            }
        }
        public IWebElement LastName
        {
            get
            {
                return WebDriver.FindElement(By.Id($"ctl00_MainContent_ucHomeOfficeAddress_{RegID}_ucAddress_txtLast"));
            }
        }

        public IWebElement Address1
        {
            get
            {
                return WebDriver.FindElement(By.Id($"ctl00_MainContent_ucHomeOfficeAddress_{RegID}_ucAddress_txtAddress1"));
            }
        }
        public IWebElement Address2
        {
            get
            {
                return WebDriver.FindElement(By.Id($"ctl00_MainContent_ucHomeOfficeAddress_{RegID}_ucAddress_txtAddress2"));
            }
        }
        public IWebElement City
        {
            get
            {
                return WebDriver.FindElement(By.Id($"ctl00_MainContent_ucHomeOfficeAddress_{RegID}_ucAddress_txtCity"));
            }
        }
        public IWebElement ZipCode
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucHomeOfficeAddress_{RegID}_ucAddress_nbZipFirst5"), null);
            }
        }
        public IWebElement ZipCodeExt
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucHomeOfficeAddress_{RegID}_ucAddress_nbZipLast4"), null);
            }
        }
        public IWebElement Phone1
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucHomeOfficeAddress_{RegID}_ucAddress_txtPhoneNo1"), null);
            }
        }
        public IWebElement Phone1Ext
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucHomeOfficeAddress_{RegID}_ucAddress_txtPhoneExt1"), null);
            }
        }
        public IWebElement Phone2
        {
            get
            {
                return WebDriver.FindElement(By.Id($"ctl00_MainContent_ucHomeOfficeAddress_{RegID}_ucAddress_txtPhoneNo2"));
            }
        }
        public IWebElement Phone2Ext
        {
            get
            {
                return WebDriver.FindElement(By.Id($"ctl00_MainContent_ucHomeOfficeAddress_{RegID}_ucAddress_txtPhoneExt2"));
            }
        }

        public IWebElement Email
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucHomeOfficeAddress_{RegID}_ucAddress_txtEmail1"), null);
            }
        }

        public IWebElement SamePracticeLocation
        {
            get
            {
                return WebDriver.FindElement(By.Id($"ctl00_MainContent_ucHomeOfficeAddress_{RegID}_prov_Same"));
            }
        }


        public IWebElement AddressConfirmationbtn
        {
            get
            {
                return webDriver.WaitUntilElementIsVisibleAndReturn(By.Id($"ctl00_MainContent_ucHomeOfficeAddress_{RegID}_ucAddress_btnConfirmAddress"), TimeoutConfiguration.Page);
            }
        }
        public IWebElement AddressConfirmationbtnCancel
        {
            get
            {
                return webDriver.WaitUntilElementIsVisibleAndReturn(By.Id($"ctl00_MainContent_ucHomeOfficeAddress_{RegID}_ucAddress_btnCancelAddressCorrection"), TimeoutConfiguration.Page);
            }
        }


        public void SetState(string item)
        {
            IWebElement PracticeTypeElement = PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucHomeOfficeAddress_{RegID}_ucAddress_ddlState"), null);
            SelectElement PracticeTypeElementDropDown = new SelectElement(PracticeTypeElement);
            PracticeTypeElementDropDown.SelectByText(item);
        }
        public void SetCounty(string item)
        {
            IWebElement PracticeTypeElement = WebDriver.FindElement(By.Id($"ctl00_MainContent_ucHomeOfficeAddress_{RegID}_ucAddress_ddlCounty"));
            SelectElement PracticeTypeElementDropDown = new SelectElement(PracticeTypeElement);
            PracticeTypeElementDropDown.SelectByText(item);
        }
        #endregion

        public void SetHomeOfficeInformation(HomeOfficeAddressDTO info)
        {
            if (!string.IsNullOrEmpty(info.FirstName))
                FirstName.Set(info.FirstName, true);

            if (!string.IsNullOrEmpty(info.MiddleName))
                MiddleName.Set(info.MiddleName, true);

            if (!string.IsNullOrEmpty(info.LastName))
                LastName.Set(info.LastName, true);

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
                Phone1.Set(info.Phone1, true);

            if (!string.IsNullOrEmpty(info.Phone1Ext))
                Phone1Ext.Set(info.Phone1Ext, true);

            if (!string.IsNullOrEmpty(info.Phone2))
                Phone2.Set(info.Phone2, true);

            if (!string.IsNullOrEmpty(info.Phone2Ext))
                Phone2Ext.Set(info.Phone2Ext, true);

            if (!string.IsNullOrEmpty(info.Email))
                Email.Set(info.Email, true);

            if (!string.IsNullOrEmpty(info.Zipcode))
                ZipCode.Set(info.Zipcode, true);

            if (!string.IsNullOrEmpty(info.County))
                SetCounty(info.County);
        }
    }
}
