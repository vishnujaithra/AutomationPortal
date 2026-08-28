using OpenQA.Selenium.Support.UI;
using Selenium.BaseComponents.Pages;
using SeleniumExtensions.Extensions;
using Selenium.BaseComponents.Utilities;
using OpenQA.Selenium;

namespace OhpnmAutomation.Pages.Registration
{
    public class CLIACertifications : BasePage
    {
        IWebDriver webDriver;
        string RegID;
        public CLIACertifications(IWebDriver webDriver, string RegID) : base(webDriver)
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

        #region CLIA Certifications
        public IWebElement? RegistrationTitle
        {
            get
            {
                return Selenium.BaseComponents.Utilities.PageHelper.IsElementExist(webDriver, By.Id("ctl00_MainContent_ucRegistrationNavigation_lblTitle")) ?
                    WebDriver.FindElement(By.Id("ctl00_MainContent_ucRegistrationNavigation_lblTitle")) : null;
            }
        }
        public IWebElement AddCLIACertification
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucCLIACertification_{RegID}_btnAddCertSecondGrid"), null);
            }
        }
        public IWebElement CLIANumber
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucCLIACertification_{RegID}_prov_Number"), null);
            }
        }
        public IWebElement CLIACertificationType
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucCLIACertification_{RegID}_ddlCliaCertType"), null);
            }
        }
        public IWebElement CLIAEffectiveDate
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucCLIACertification_{RegID}_prov_Start"), null);
            }
        }
        public IWebElement CLIAExpirationDate
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucCLIACertification_{RegID}_prov_End"), null);
            }
        }
        public IWebElement SaveButton
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id("ctl00_MainContent_ucRegistrationNavigation_btnSave"), null);
            }
        }
        #endregion
    }
}
