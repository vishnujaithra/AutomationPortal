using OpenQA.Selenium.Support.UI;
using Selenium.BaseComponents.Pages;
using SeleniumExtensions.Extensions;
using Selenium.BaseComponents.Utilities;
using OpenQA.Selenium;
using TC.ProviderDataEntry.Models;

namespace TC.ProviderDataEntry.Pages.Registration
{
    public class FederalDEARegistration : BasePage
    {
        IWebDriver webDriver;
        string RegID;
        public FederalDEARegistration(IWebDriver webDriver, string RegID) : base(webDriver)
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
        #region Federal DEA Registration
        public IWebElement? RegistrationTitle
        {
            get
            {
                return PageHelper.IsElementExist(webDriver, By.Id("ctl00_MainContent_ucRegistrationNavigation_lblTitle")) ?
                    WebDriver.FindElement(By.Id("ctl00_MainContent_ucRegistrationNavigation_lblTitle")) : null;
            }
        }
        public IWebElement DEARegistration_No
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucDEACertification_{RegID}_rblCurrentDEARegistration_1"), null);
            }
        }
        public IWebElement DEARegistration_Yes
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucDEACertification_{RegID}_rblCurrentDEARegistration_0"), null);
            }
        }
        public IWebElement DEANumber
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucDEACertification_{RegID}_prov_Number"), null);
            }
        }
        public IWebElement DEAState
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucDEACertification_{RegID}_prov_State"), null);
            }
        }
        public IWebElement IssueDate
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucDEACertification_{RegID}_prov_Start"), null);
            }
        }
        public IWebElement ExpirationDate
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucDEACertification_{RegID}_prov_End"), null);
            }
        }
        public IWebElement DEAStatus
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucDEACertification_{RegID}_ddldeastatus"), null);
            }
        }
        public IWebElement DEAProviderName
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucDEACertification_{RegID}_txtPrescribeProvider"), null);
            }
        }
        public IWebElement DEAProviderNumber
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucDEACertification_{RegID}_txtPrescribeProviderDEA"), null);
            }
        }
        public IWebElement DEAProviderState
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucDEACertification_{RegID}_ddlPrecribeProviderState"), null);
            }
        }
        public IWebElement DEAComments
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucDEACertification_{RegID}_txtPrecibeComments"), null);
            }
        }
        #endregion
        #region Functions
        public void SetState(string item)
        {
            SelectElement DEAStateElementDropDown = new SelectElement(DEAState);
            DEAStateElementDropDown.SelectByText(item);
        }
        public void SetStatus(string item)
        {
            SelectElement DEAStatusElementDropDown = new SelectElement(DEAStatus);
            DEAStatusElementDropDown.SelectByText(item);
        }
        public void SetDEAProviderState(string item)
        {
            SelectElement DEAStateElementDropDown = new SelectElement(DEAProviderState);
            DEAStateElementDropDown.SelectByText(item);
        }
        public IWebElement getDEAregistration(String value)
        {
            return value == "Yes" ? DEARegistration_Yes : DEARegistration_No;
        }
        public void SetFederalDEARegistrationInformation(FederalDEARegistrationDTO info)
        {
            if (!string.IsNullOrEmpty(info.DEARegistration))
                getDEAregistration(info.DEARegistration).Click();
            if(info.DEARegistration == "Yes")
            {
                if (!string.IsNullOrEmpty(info.DEANumber))
                    DEANumber.Set(info.DEANumber, true);

                if (!string.IsNullOrEmpty(info.DEAState))
                    SetState(info.DEAState);

                if (!string.IsNullOrEmpty(info.IssueDate))
                    IssueDate.Set(info.IssueDate, true);

                if (!string.IsNullOrEmpty(info.ExpirationDate))
                    ExpirationDate.Set(info.ExpirationDate, true);

                if (!string.IsNullOrEmpty(info.DEAStatus))
                    SetStatus(info.DEAStatus);
            }
            else if (info.DEARegistration == "No")
            {
                if (!string.IsNullOrEmpty(info.NameOfProvider))
                    DEAProviderName.Set(info.NameOfProvider, true);

                if (!string.IsNullOrEmpty(info.DEANumber))
                    DEAProviderNumber.Set(info.DEANumber, true);

                if (!string.IsNullOrEmpty(info.DEAState))
                    SetDEAProviderState(info.DEAState);

                if (!string.IsNullOrEmpty(info.Comments))
                    DEAComments.Set(info.Comments, true);
            } 
        }
            #endregion
        }
}
