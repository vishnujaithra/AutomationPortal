using OpenQA.Selenium.Support.UI;
using Selenium.BaseComponents.Pages;
using SeleniumExtensions.Extensions;
using Selenium.BaseComponents.Utilities;
using OpenQA.Selenium;

namespace TC.ProviderDataEntry.Pages.Registration
{
    public class MCPAffiliation : BasePage
    {
        IWebDriver webDriver;
        string RegID;
        public MCPAffiliation(IWebDriver webDriver, string RegID) : base(webDriver)
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
        #region MCP Affiliation
        public IWebElement? RegistrationTitle
        {
            get
            {
                return PageHelper.IsElementExist(webDriver, By.Id("ctl00_MainContent_ucRegistrationNavigation_lblTitle")) ?
                    WebDriver.FindElement(By.Id("ctl00_MainContent_ucRegistrationNavigation_lblTitle")) : null;
            }
        }
        public IWebElement ManagedCarePlans_Yes
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucMCOAffiliation_{RegID}_rblIsContracting_0"), null);
            }
        }
        public IWebElement ManagedCarePlans_No
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucMCOAffiliation_{RegID}_rblIsContracting_0"), null);
            }
        }
        public IWebElement AmeriHealthCaritas
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucMCOAffiliation_{RegID}_chkPossibleParticipation_0"), null);
            }
        }
        public IWebElement AnthemBlueCross
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucMCOAffiliation_{RegID}_chkPossibleParticipation_1"), null);
            }
        }
        public IWebElement Aetna
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucMCOAffiliation_{RegID}_chkPossibleParticipation_2"), null);
            }
        }
        public IWebElement Buckeye
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucMCOAffiliation_{RegID}_chkPossibleParticipation_3"), null);
            }
        }
        public IWebElement CareSource
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucMCOAffiliation_{RegID}_chkPossibleParticipation_4"), null);
            }
        }
        public IWebElement Humana
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucMCOAffiliation_{RegID}_chkPossibleParticipation_5"), null);
            }
        }
        public IWebElement Molina
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucMCOAffiliation_{RegID}_chkPossibleParticipation_6"), null);
            }
        }
        public IWebElement UnitedHealthCare
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucMCOAffiliation_{RegID}_chkPossibleParticipation_1"), null);
            }
        }
        #endregion
    }
}
