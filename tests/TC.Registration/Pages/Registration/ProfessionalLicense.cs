using TC.ProviderDataEntry.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Selenium.BaseComponents.Pages;
using SeleniumExtensions.Configurations;
using SeleniumExtensions.Extensions;
using Selenium.BaseComponents.Utilities;

namespace TC.ProviderDataEntry.Pages.Registration
{
    public class ProfessionalLicense :BasePage
    {
        IWebDriver webDriver;
        string RegID;
        public ProfessionalLicense(IWebDriver webDriver, string RegID) : base(webDriver)
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

        #region Professional License

        public IWebElement? RegistrationTitle
        {
            get
            {
                return Selenium.BaseComponents.Utilities.PageHelper.IsElementExist(webDriver, By.Id("ctl00_MainContent_ucRegistrationNavigation_lblTitle")) ?
                    WebDriver.FindElement(By.Id("ctl00_MainContent_ucRegistrationNavigation_lblTitle")) : null;
            }
        }
        public IWebElement AddLicenseBtn
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucLicenses_{RegID}_btnAddLicenses"), null);
            }
        }
        public IWebElement LicenseState
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucLicenses_{RegID}_ddlLicenseState"), null);
            }
        }

        public IWebElement LicenseBoard
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucLicenses_{RegID}_ddlBoardName"), null);
            }
        }

        public IWebElement LicenseNumber
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucLicenses_{RegID}_prov_Number"), null);
            }
        }
        public IWebElement LicenseEffectiveDate
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucLicenses_{RegID}_prov_Effective"), null);
            }
        }
        public IWebElement LicenseExpirationDate
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucLicenses_{RegID}_prov_End"), null);
            }
        }
        public IWebElement LicenseAddress1
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucLicenses_{RegID}_ucLicenseAddress_txtAddress1"), null);
            }
        }
        public IWebElement LicenseAddress2
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucLicenses_{RegID}_ucLicenseAddress_txtAddress2"), null);
            }
        }
        public IWebElement LicenseCity
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucLicenses_{RegID}_ucLicenseAddress_txtCity"), null);
            }
        }
        public IWebElement State
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucLicenses_{RegID}_ucLicenseAddress_ddlState"), null);
            }
        }
        public IWebElement LicenseCountry
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucLicenses_{RegID}_ucLicenseAddress_ddlCounty"), null);
            }
        }
        public IWebElement LicenseZip
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucLicenses_{RegID}_ucLicenseAddress_nbZipFirst5"), null);
            }
        }
        public IWebElement EndorsementNumber
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucLicenses_{RegID}_ucSpecialtyFocus_tbEndorsemnetNumber"), null);
            }
        }
        public IWebElement EndorsementStatus
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucLicenses_{RegID}_ucSpecialtyFocus_tbEndorsemnetStatus"), null);
            }
        }
        public IWebElement EndorsementFocus
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucLicenses_{RegID}_ucSpecialtyFocus_tbFocus"), null);
            }
        }
        public IWebElement EndorsementSpecality
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucLicenses_{RegID}_ucSpecialtyFocus_tbSpecialty"), null);
            }
        }
        public IWebElement CertifyingOrganization
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucLicenses_{RegID}_ucSpecialtyFocus_tbCertifyingOrg"), null);
            }
        }
        public IWebElement CertificationDate
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucLicenses_{RegID}_ucSpecialtyFocus_tbCertificationDate"), null);
            }
        }
        public IWebElement CertificationExpiration
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucLicenses_{RegID}_ucSpecialtyFocus_tbCertificationEndDate"), null);
            }
        }
        #endregion
        #region Functions
        public void SelectPickListvalue(IWebElement element,String item)
        {
            SelectElement dropDownElement = new SelectElement(element);
            dropDownElement.SelectByText(item);
        }

        public void SetProfessionalLicense(ProfessionalLicenses info)
        {
            PageHelper.WaitUntilDocumentIsReady(webDriver, TimeoutConfiguration.Page);

            if (!string.IsNullOrEmpty(info.State))
                SelectPickListvalue(LicenseState, info.State);

            if (!string.IsNullOrEmpty(info.LicenseNumber))
                LicenseNumber.Set(info.LicenseNumber, true);

            if (!string.IsNullOrEmpty(info.EffectiveDate))
                LicenseEffectiveDate.Set(info.EffectiveDate, true);

            if (!string.IsNullOrEmpty(info.ExpirationDate))
                LicenseExpirationDate.Set(info.ExpirationDate);

            if (!string.IsNullOrEmpty(info.LicenseBoardName))
                SelectPickListvalue(LicenseBoard, info.LicenseBoardName);

        }
        #endregion
    }
}
