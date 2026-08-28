using TC.ProviderDataEntry.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Selenium.BaseComponents.Pages;
using SeleniumExtensions.Extensions;
using Selenium.BaseComponents.Utilities;
using SeleniumExtensions.Configurations;

namespace TC.ProviderDataEntry.Pages.Registration
{
    public class BoardCertificate :BasePage
    {
        IWebDriver webDriver;
        string RegID;
        public BoardCertificate(IWebDriver webDriver, string RegID) : base(webDriver)
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

        #region Board Certificate
        public IWebElement? RegistrationTitle
        {
            get
            {
                return Selenium.BaseComponents.Utilities.PageHelper.IsElementExist(webDriver, By.Id("ctl00_MainContent_ucRegistrationNavigation_lblTitle")) ?
                    WebDriver.FindElement(By.Id("ctl00_MainContent_ucRegistrationNavigation_lblTitle")) : null;
            }
        }
        public IWebElement AddBoardCertificate
        {
            get
            {
                return PageHelper.FindElement(webDriver,By.Id($"ctl00_MainContent_ucBoardCertification_{RegID}_btnAddBoardCertification"),null);
            }
        }
        public IWebElement BoardCertificateNo
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucBoardCertification_{RegID}_rblBoardCertified_0"), null);
            }
        }
        public IWebElement BoardCertificateYes
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucBoardCertification_{RegID}_rblBoardCertified_1"), null);
            }
        }
        public IWebElement BoardCertification
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucBoardCertification_{RegID}_ddlBoardCertification"), null);
            }
        }
        public IWebElement BoardSpecialty
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucBoardCertification_{RegID}_ddlBoardSpecialty"), null);
            }
        }
        public IWebElement CertificationNumber
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucBoardCertification_{RegID}_txtCertificationNumber"), null);
            }
        }
        public IWebElement EffectiveDate
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucBoardCertification_{RegID}_txtEffectiveDate"), null);
            }
        }
        public IWebElement ExpirationDate
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucBoardCertification_{RegID}_txtExpirationDate"), null);
            }
        }
        #endregion
    }
}
