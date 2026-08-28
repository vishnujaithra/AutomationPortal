using OpenQA.Selenium.Support.UI;
using Selenium.BaseComponents.Pages;
using SeleniumExtensions.Extensions;
using Selenium.BaseComponents.Utilities;
using OpenQA.Selenium;
using TC.ProviderDataEntry.Models;
using SeleniumExtensions.Configurations;

namespace TC.ProviderDataEntry.Pages.Registration
{
    public class W9Form : BasePage
    {
        IWebDriver webDriver;
        string RegID;
        public W9Form(IWebDriver webDriver, string RegID) : base(webDriver)
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
        public IWebElement? RegistrationTitle
        {
            get
            {
                return PageHelper.IsElementExist(webDriver, By.Id("ctl00_MainContent_ucRegistrationNavigation_lblTitle")) ?
                    WebDriver.FindElement(By.Id("ctl00_MainContent_ucRegistrationNavigation_lblTitle")) : null;
            }
        }

        public IWebElement IndividualProprietor
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucTaxInfo_{RegID}_rptTaxClassification_ctl01_rbTaxClass"), null);
            }
        }
        public IWebElement C_Corporation
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucTaxInfo_{RegID}_rptTaxClassification_ctl02_rbTaxClass"), null);
            }
        }
        public IWebElement S_Corporation
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucTaxInfo_{RegID}_rptTaxClassification_ctl03_rbTaxClass"), null);
            }
        }
        public IWebElement PartnerShip
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucTaxInfo_{RegID}_rptTaxClassification_ctl04_rbTaxClass"), null);
            }
        }
        public IWebElement TrustOrEstate
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucTaxInfo_{RegID}_rptTaxClassification_ctl05_rbTaxClass"), null);
            }
        }
        public IWebElement LimitedLiabilityC_Corporation
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucTaxInfo_{RegID}_rptTaxClassification_ctl06_rbTaxClass"), null);
            }
        }
        public IWebElement LimitedLiabilityS_Corporation
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucTaxInfo_{RegID}_rptTaxClassification_ctl07_rbTaxClass"), null);
            }
        }
        public IWebElement LimitedLiabilityPartnerShip
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucTaxInfo_{RegID}_rptTaxClassification_ctl08_rbTaxClass"), null);
            }
        }
        public IWebElement Other
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucTaxInfo_{RegID}_rptTaxClassification_ctl09_rbTaxClass"), null);
            }
        }
        public IWebElement W9
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucTaxInfo_{RegID}_rbIndicate_0"), null);
            }
        }
        public IWebElement Form149
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucTaxInfo_{RegID}_rbIndicate_1"), null);
            }
        }
        public IWebElement FileUpload
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucTaxInfo_{RegID}_174_RadAsyncUpload1file0"), null);
            }
        }
        public IWebElement FileDownload
        {
            get
            {
                return webDriver.FindElement(By.XPath("//a[contains(@id,'_LnkButtonDownload')]"));
            }
        }

        //Temporary Navigation
        public IWebElement ETFBankingImage
        {
            get
            {
                return webDriver.FindElement(By.XPath("//span[text()='EFT Banking']/ancestor::span[1]/img"));
            }
        }
        public IWebElement PopUp_Confirmation
        {
            get
            {
                return webDriver.FindElement(By.XPath("//span[text()='Ok']/ancestor::button"));
            }
        }
        public IWebElement getFormType(string value)
        {
            return value == "W9" ? W9 : Form149;
        }

        public void SetW9FormDetails(W9FormDTO form)
        {
            switch (form.CategoryType)
            {
                case "Individual/sole proprietor":
                    IndividualProprietor.Click();
                    break;
                case "C Corporation":
                    C_Corporation.Click();
                    break;
                case "S Corporation":
                    S_Corporation.Click();
                    break;
                case "Partnership":
                    PartnerShip.Click(); break;
                case "Trust/Estate":
                    TrustOrEstate.Click(); break;
                case "Limited Liability C Corporation":
                    LimitedLiabilityC_Corporation.Click(); break;
                case ",Limited Liability S Corporation":
                    LimitedLiabilityS_Corporation.Click(); break;
                case "Limited Liability Partnership":
                    LimitedLiabilityPartnerShip.Click(); break;
                case "Other":
                    Other.Click(); break;
            }

            Thread.Sleep(3000);

            if (!string.IsNullOrEmpty(form.FormType))
                getFormType(form.FormType).Click();

            Thread.Sleep(3000);

            if (!string.IsNullOrEmpty(form.FilePath))
            {
                FileUpload.SendKeys(form.FilePath);
            }
            Console.WriteLine("Form Is uploaded Succesfully");
            Thread.Sleep(3000);
        }

        public void WaitUntilImgProgressDisappear()
        {
            PageHelper.WaitUntilElementNotAvailable(WebDriver, By.Id("imgProgress"), TimeoutConfiguration.Element);
        }
    }
}
