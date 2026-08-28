using OpenQA.Selenium.Support.UI;
using Selenium.BaseComponents.Pages;
using SeleniumExtensions.Extensions;
using Selenium.BaseComponents.Utilities;
using OpenQA.Selenium;
using TC.ProviderDataEntry.Models;

namespace TC.ProviderDataEntry.Pages.Registration
{
    public class Education : BasePage
    {
        IWebDriver webDriver;
        string RegID;
        public Education(IWebDriver webDriver, string RegID) : base(webDriver)
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
        #region Education
        public IWebElement? RegistrationTitle
        {
            get
            {
                return PageHelper.IsElementExist(webDriver, By.Id("ctl00_MainContent_ucRegistrationNavigation_lblTitle")) ?
                    WebDriver.FindElement(By.Id("ctl00_MainContent_ucRegistrationNavigation_lblTitle")) : null;
            }
        }

        public IWebElement AddEducation
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucEducation_{RegID}_btnAddEducationItem"), null);
            }
        }
        public IWebElement EducationType
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucEducation_{RegID}_ddlEducationType"), null);
            }
        }
        public IWebElement NameOfSchool
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucEducation_{RegID}_tbSchool"), null);
            }
        }
        public IWebElement StartDate
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucEducation_{RegID}_tbStartYear"), null);
            }
        }
        public IWebElement EndDate
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucEducation_{RegID}_tbEndYear"), null);
            }
        }
        public IWebElement CertificateAwarded
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucEducation_{RegID}_ddlDegreeAward"), null);
            }
        }
        public IWebElement Speciality
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucEducation_{RegID}_ddlSpeciality"), null);
            }
        }
        public IWebElement Address1
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucEducation_{RegID}_tbAddress1"), null);
            }
        }
        public IWebElement Address2
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucEducation_{RegID}_tbAddress2"), null);
            }
        }
        public IWebElement City
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucEducation_{RegID}_tbCity"), null);
            }
        }
        public IWebElement State
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucEducation_{RegID}_ddlState"), null);
            }
        }
        public IWebElement Country
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucEducation_{RegID}_ddlCountry"), null);
            }
        }
        public IWebElement ZipCode
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucEducation_{RegID}_tbZipCode"), null);
            }
        }
        public IWebElement PhoneNumber
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucEducation_{RegID}_tbPhone"), null);
            }
        }
        public IWebElement Fax
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucEducation_{RegID}_tbFax"), null);
            }
        }
        public IWebElement AdditionalInformation
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucEducation_{RegID}_tbAdditional"), null);
            }
        }
        #endregion

        #region Education
        public void SelectDropDownValue(IWebElement element,String value)
        {
            SelectElement dropDownElement = new SelectElement(element);
            dropDownElement.SelectByText(value);
        }

        public void SetEducationDetails(EducationDTO info)
        {
            if (!string.IsNullOrEmpty(info.EducationType))
                SelectDropDownValue(EducationType, info.EducationType);

            if (!string.IsNullOrEmpty(info.NameOfSchool))
                NameOfSchool.Set(info.NameOfSchool,true);

            if (!string.IsNullOrEmpty(info.StartDate))
                StartDate.Set(info.StartDate, true);

            if (!string.IsNullOrEmpty(info.EndDate))
                EndDate.Set(info.EndDate, true);

            if (!string.IsNullOrEmpty(info.CertificateAwarded))
                SelectDropDownValue(CertificateAwarded, info.CertificateAwarded);

            if (!string.IsNullOrEmpty(info.Address1))
                Address1.SendKeys(info.Address1);

            if (!string.IsNullOrEmpty(info.Address2))
                Address2.Set(info.Address2, true);

            if (!string.IsNullOrEmpty(info.City))
                City.Set(info.City, true);

            if (!string.IsNullOrEmpty(info.State))
                SelectDropDownValue(State,info.State);

            if (!string.IsNullOrEmpty(info.ZipCode))
                ZipCode.Set(info.ZipCode, true);

            if (!string.IsNullOrEmpty(info.PhoneNumber))
                PhoneNumber.Set(info.PhoneNumber, true);

            if (!string.IsNullOrEmpty(info.Country))
                SelectDropDownValue(Country, info.Country);

            if (!string.IsNullOrEmpty(info.Address1))
                Address1.SendKeys(info.Address1);

            if (!string.IsNullOrEmpty(info.Address2))
                Address2.Set(info.Address2, true);

            if (!string.IsNullOrEmpty(info.NameOfSchool))
                NameOfSchool.Set(info.NameOfSchool, true);

            if (!string.IsNullOrEmpty(info.ZipCode))
                ZipCode.Set(info.ZipCode, true);

        }
        #endregion

    }
}
