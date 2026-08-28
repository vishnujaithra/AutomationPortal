using OpenQA.Selenium.Support.UI;
using Selenium.BaseComponents.Pages;
using SeleniumExtensions.Extensions;
using Selenium.BaseComponents.Utilities;
using OpenQA.Selenium;
using OhpnmAutomation.Models.Registration;

namespace OhpnmAutomation.Pages.Registration
{
    public class WorkHistory : BasePage
    {
        IWebDriver webDriver;
        string RegID;
        public WorkHistory(IWebDriver webDriver, string RegID) : base(webDriver)
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

        #region Work History
        public IWebElement? RegistrationTitle
        {
            get
            {
                return PageHelper.IsElementExist(webDriver, By.Id("ctl00_MainContent_ucRegistrationNavigation_lblTitle")) ?
                    WebDriver.FindElement(By.Id("ctl00_MainContent_ucRegistrationNavigation_lblTitle")) : null;
            }
        }

        public IWebElement AddWorkHistory
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucWorkHistoryDetails_{RegID}_btnAddWorkItem"), null);
            }
        }
        public IWebElement CurrentEmployer
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucWorkHistoryDetails_{RegID}_chkIsCurrentEmployer"), null);
            }
        }
        public IWebElement EmployerName
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucWorkHistoryDetails_{RegID}_tbOrgName"), null);
            }
        }
        public IWebElement StartDate
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucWorkHistoryDetails_{RegID}_tbFrom"), null);
            }
        }
        public IWebElement EndDate
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucWorkHistoryDetails_{RegID}_txtEndDate"), null);
            }
        }
        public IWebElement OrganizationName
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucWorkHistoryDetails_{RegID}_ucAddress_txtOrgName"), null);
            }
        }
        public IWebElement Address1
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucWorkHistoryDetails_{RegID}_ucAddress_txtAddress1"), null);
            }
        }
        public IWebElement Address2
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucWorkHistoryDetails_{RegID}_ucAddress_txtAddress2"), null);
            }
        }
        public IWebElement City
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucWorkHistoryDetails_{RegID}_ucAddress_txtCity"), null);
            }
        }
        public IWebElement State
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucWorkHistoryDetails_{RegID}_ucAddress_ddlState"), null);
            }
        }
        public IWebElement County
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucWorkHistoryDetails_{RegID}_ucAddress_ddlCounty"), null);
            }
        }
        public IWebElement PhoneExtension
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucWorkHistoryDetails_{RegID}_ucAddress_txtPhoneExt1"), null);
            }
        }
        public IWebElement ZipCode
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucWorkHistoryDetails_{RegID}_ucAddress_nbZipFirst5"), null);
            }
        }
        public IWebElement PhoneNumber
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucWorkHistoryDetails_{RegID}_ucAddress_txtPhoneNo1"), null);
            }
        }
        public IWebElement FaxNumber1
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucWorkHistoryDetails_{RegID}_ucAddress_txtFaxNo1"), null);
            }
        }
        public IWebElement ContactName
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucWorkHistoryDetails_{RegID}_ucAddress_txtContact"), null);
            }
        }
        public IWebElement EmailAddress1
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucWorkHistoryDetails_{RegID}_ucAddress_txtEmail1"), null);
            }
        }
        public IWebElement EmailAddress2
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucWorkHistoryDetails_{RegID}_ucAddress_txtEmail2"), null);
            }
        }
        public IWebElement AdditionalInformation
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucWorkHistoryDetails_{RegID}_tbAdditional"), null);
            }
        }
        public IWebElement ReasonForDeparture
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucWorkHistoryDetails_{RegID}_tbReasonForDepart"), null);
            }
        }
        public IWebElement MilitaryReserve
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucWorkHistoryDetails_{RegID}_ddlmiltaryreserve"), null);
            }
        }
        public IWebElement AddGapHistory
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucWorkHistoryDetails_{RegID}_imgAddGap"), null);
            }
        }
        public IWebElement GapStartDate
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucWorkHistoryDetails_{RegID}_tbGapStartDate"), null);
            }
        }
        public IWebElement GapEndDate
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucWorkHistoryDetails_{RegID}_tbGapEndDate"), null);
            }
        }
        public IWebElement ReasonForGap
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucWorkHistoryDetails_{RegID}_tbGapText"), null);
            }
        }
        #endregion

        #region Work history
        public void SelectDropDownValue(IWebElement element, String value)
        {
            SelectElement dropDownElement = new SelectElement(element);
            dropDownElement.SelectByText(value);
        }

        public void SetWorkHistory(WorkHistoryDTO info)
        {
            if (Convert.ToBoolean(info.currentEmployer))
                CurrentEmployer.Click();

            if (!string.IsNullOrEmpty(info.EmployerName))
                EmployerName.Set(info.EmployerName, true);

            if (!string.IsNullOrEmpty(info.StartDate))
                StartDate.Set(info.StartDate, true);

            if (!string.IsNullOrEmpty(info.OrganizationName))
                OrganizationName.Set(info.OrganizationName, true);

            if (!string.IsNullOrEmpty(info.Address1))
                Address1.SendKeys(info.Address1);

            if (!string.IsNullOrEmpty(info.Address2))
                Address2.Set(info.Address2, true);

            if (!string.IsNullOrEmpty(info.City))
                City.Set(info.City, true);

            if (!string.IsNullOrEmpty(info.State))
                SelectDropDownValue(State, info.State);

            if (!string.IsNullOrEmpty(info.ZipCode))
                ZipCode.Set(info.ZipCode, true);

            if (!string.IsNullOrEmpty(info.Phone))
                PhoneNumber.Set(info.Phone, true);

            if (!string.IsNullOrEmpty(info.PhoneExtension))
                PhoneExtension.Set(info.PhoneExtension, true);

            if (!string.IsNullOrEmpty(info.EmailAddress1))
                EmailAddress1.SendKeys(info.EmailAddress1);

            if (!string.IsNullOrEmpty(info.MilitaryReserve))
                SelectDropDownValue(MilitaryReserve,info.MilitaryReserve);

            if (!string.IsNullOrEmpty(info.EmployerName))
                EmployerName.Set(info.EmployerName, true);

            if (!string.IsNullOrEmpty(info.ZipCode))
                ZipCode.Set(info.ZipCode, true);

            if (!string.IsNullOrEmpty(info.EmailAddress1))
                EmailAddress1.Set(info.EmailAddress1,true);
        }

        public void SetGapHistoryDetails(WorkHistoryDTO info)
        {
            if (!string.IsNullOrEmpty(info.GapStartDate))
                GapStartDate.Set(info.GapStartDate, true);

            if (!string.IsNullOrEmpty(info.GapEndDate))
                GapEndDate.Set(info.GapEndDate, true);

            if (!string.IsNullOrEmpty(info.ReasonForGap))
                ReasonForGap.Set(info.ReasonForGap, true);

        }
        #endregion
    }
}
