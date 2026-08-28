using OpenQA.Selenium.Support.UI;
using Selenium.BaseComponents.Pages;
using SeleniumExtensions.Extensions;
using Selenium.BaseComponents.Utilities;
using OpenQA.Selenium;

namespace TC.ProviderDataEntry.Pages.Registration
{
    public class MediCareNumber : BasePage
    {
        IWebDriver webDriver;
        string RegID;
        public MediCareNumber(IWebDriver webDriver, string RegID) : base(webDriver)
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
        #region MediCare Number
        public IWebElement? RegistrationTitle
        {
            get
            {
                return Selenium.BaseComponents.Utilities.PageHelper.IsElementExist(webDriver, By.Id("ctl00_MainContent_ucRegistrationNavigation_lblTitle")) ?
                    WebDriver.FindElement(By.Id("ctl00_MainContent_ucRegistrationNavigation_lblTitle")) : null;
            }
        }
        public IWebElement AddMediCareNumber
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucMiscellaneous_{RegID}_ucMedicare_btnAddMedicare"), null);
            }
        }
        public IWebElement CCNMediCareType
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucMiscellaneous_{RegID}_ucMedicare_rblMedicareNumberType_0"), null);
            }
        }
        public IWebElement PTANMediCareType
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucMiscellaneous_{RegID}_rblMedicareNumberType_1"), null);
            }
        }
        public IWebElement MediCareNum
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucMiscellaneous_{RegID}_ucMedicare_txtMedicareNumber"), null);
            }
        }
        public IWebElement MediCareState
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucMiscellaneous_{RegID}_ucMedicare_ddlProvState"), null);
            }
        }
        public IWebElement MediCareFileUpload
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucMiscellaneous_{RegID}_ucMedicare_1187_RadAsyncUpload1file0"), null);
            }
        }
        #endregion
    }
}
