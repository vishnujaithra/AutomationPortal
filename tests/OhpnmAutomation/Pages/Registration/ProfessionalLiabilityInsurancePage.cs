using OpenQA.Selenium.Support.UI;
using Selenium.BaseComponents.Pages;
using SeleniumExtensions.Extensions;
using Selenium.BaseComponents.Utilities;
using OpenQA.Selenium;
using OhpnmAutomation.Models.Registration;
using System.Security.Cryptography;

namespace OhpnmAutomation.Pages.Registration
{
    public class ProfessionalLiabilityInsurancePage : BasePage
    {
        IWebDriver webDriver;
        string RegID;
        public ProfessionalLiabilityInsurancePage(IWebDriver webDriver, string RegID) : base(webDriver)
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
        #region Professional Liability Insurance
        public IWebElement? RegistrationTitle
        {
            get
            {
                return PageHelper.IsElementExist(webDriver, By.Id("ctl00_MainContent_ucRegistrationNavigation_lblTitle")) ?
                    WebDriver.FindElement(By.Id("ctl00_MainContent_ucRegistrationNavigation_lblTitle")) : null;
            }
        }
        public IWebElement AddNewInsurance
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucInsurance_{RegID}_btnAddWorkItem"), null);
            }
        }
        public IWebElement MalPracticeInsurance_Yes
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucInsurance_{RegID}_rblMalpracticeInsurace_0"), null);
            }
        }
        public IWebElement MalPracticeInsurance_No
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucInsurance_{RegID}_rblMalpracticeInsurace_1"), null);
            }
        }
        public IWebElement SelfInsured
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucInsurance_{RegID}_ddlSelfInsured"), null);
            }
        }
        public IWebElement PolicyNumber
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucInsurance_{RegID}_txtPolicyNumber"), null);
            }
        }
        public IWebElement EffectiveDate
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucInsurance_{RegID}_txtEffectiveDate"), null);
            }
        }
        public IWebElement OriginalEffectiveDate
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucInsurance_{RegID}_txtOrginaEffDate"), null);
            }
        }
        public IWebElement ExpirationDate
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucInsurance_{RegID}_txtExpirationDate"), null);
            }
        }
        public IWebElement TypeOfCoverage
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucInsurance_{RegID}_ddlTypeofCoverage"), null);
            }
        }
        public IWebElement UnlimitedCoverage
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucInsurance_{RegID}_ddlIsUnlimitedCoverage"), null);
            }
        }
        public IWebElement TailCoverage
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucInsurance_{RegID}_ddlIsPolicyTailCoverageInclude"), null);
            }
        }
        public IWebElement CarrierName
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucInsurance_{RegID}_txtCarrierName"), null);
            }
        }
        public IWebElement Address1
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucInsurance_{RegID}_ucAddress_txtAddress1"), null);
            }
        }
        public IWebElement Address2
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucInsurance_{RegID}_ucAddress_txtAddress2"), null);
            }
        }
        public IWebElement City
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucInsurance_{RegID}_ucAddress_txtCity"), null);
            }
        }
        public IWebElement State
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucInsurance_{RegID}_ucAddress_ddlState"), null);
            }
        }
        public IWebElement County
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucInsurance_{RegID}_ucAddress_ddlCounty"), null);
            }
        }
        public IWebElement Zip
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucInsurance_{RegID}_ucAddress_nbZipFirst5"), null);
            }
        }
        public IWebElement PolicyHolder
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucInsurance_{RegID}_txtPolicyHolder"), null);
            }
        }
        public IWebElement AmountPerOccurence
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucInsurance_{RegID}_txtAmtPerOccurrence"), null);
            }
        }
        public IWebElement AmountPerAggregate
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucInsurance_{RegID}_txtAmtPerAggregate"), null);
            }
        }
        public IWebElement MalpracticeReason
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucInsurance_{RegID}_txtMalpracticeReason"), null);
            }
        }
        #endregion

        #region Functions
        public void SelectValuefromDropDown(IWebElement element,String value)
        {
            SelectElement dropDownElement = new SelectElement(element);
            dropDownElement.SelectByText(value);
        }
        public IWebElement geCarrytMalPracticeInsurance(String value)
        {
            return value == "Yes" ? MalPracticeInsurance_Yes : MalPracticeInsurance_No;
        }

        public void SetProfessionalLiabilityInsurance(ProfessionalLiabilityInsurance info)
        {
            if (!string.IsNullOrEmpty(info.MalpracticeInsurance))
                geCarrytMalPracticeInsurance(info.MalpracticeInsurance).Click();
            if (info.MalpracticeInsurance == "Yes")
            {
                if (!string.IsNullOrEmpty(info.SelfInsurance))
                    SelectValuefromDropDown(SelfInsured,info.SelfInsurance);

                if (!string.IsNullOrEmpty(info.PolicyNumber))
                    PolicyNumber.Set(info.PolicyNumber,true);

                if (!string.IsNullOrEmpty(info.EffectiveDate))
                    EffectiveDate.Set(info.EffectiveDate, true);

                if (!string.IsNullOrEmpty(info.OrifinalEffectiveDate))
                    OriginalEffectiveDate.Set(info.OrifinalEffectiveDate, true);

                if (!string.IsNullOrEmpty(info.ExpirationDate))
                    ExpirationDate.Set(info.ExpirationDate, true);

                if (!string.IsNullOrEmpty(info.TypeOfCoverage))
                    SelectValuefromDropDown(TypeOfCoverage,info.TypeOfCoverage);

                if (!string.IsNullOrEmpty(info.UnlimitedCoverage))
                    SelectValuefromDropDown(UnlimitedCoverage, info.UnlimitedCoverage);

                if (!string.IsNullOrEmpty(info.TailCoverage))
                    SelectValuefromDropDown(TailCoverage, info.TailCoverage);

                if (!string.IsNullOrEmpty(info.SelfInsuredName))
                    CarrierName.Set(info.SelfInsuredName, true);

                if (!string.IsNullOrEmpty(info.CarrierAddress1))
                    Address1.Set(info.CarrierAddress1, true);

                if (!string.IsNullOrEmpty(info.CarrierAddress2))
                    Address2.Set(info.CarrierAddress2, true);

                if (!string.IsNullOrEmpty(info.City))
                    City.Set(info.City, true);

                if (!string.IsNullOrEmpty(info.State))
                    SelectValuefromDropDown(State, info.State);

                if (!string.IsNullOrEmpty(info.Zip))
                    Zip.Set(info.Zip, true);

                if (!string.IsNullOrEmpty(info.CoverageAmountPerAggregrate))
                    AmountPerAggregate.Set(info.CoverageAmountPerAggregrate, true);

                if (!string.IsNullOrEmpty(info.PolicyHolder))
                    PolicyHolder.Set(info.PolicyHolder, true);

                if (!string.IsNullOrEmpty(info.CoverageAmountPerOccurance))
                    AmountPerOccurence.Set(info.CoverageAmountPerOccurance, true);

                if (!string.IsNullOrEmpty(info.County))
                    SelectValuefromDropDown(County, info.County);
            }
            else if (info.MalpracticeInsurance == "No")
            {
                if (!string.IsNullOrEmpty(info.ExplanationMalPraticeInsurance))
                    MalpracticeReason.Set(info.ExplanationMalPraticeInsurance, true);
            }
        }
        #endregion
    }
}
