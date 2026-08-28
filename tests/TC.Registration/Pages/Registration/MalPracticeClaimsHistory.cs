using OpenQA.Selenium.Support.UI;
using Selenium.BaseComponents.Pages;
using SeleniumExtensions.Extensions;
using Selenium.BaseComponents.Utilities;
using OpenQA.Selenium;
using TC.ProviderDataEntry.Models;
using System.Diagnostics.Metrics;

namespace TC.ProviderDataEntry.Pages.Registration
{
    public class MalPracticeClaimsHistory : BasePage
    {
        IWebDriver webDriver;
        string RegID;
        public MalPracticeClaimsHistory(IWebDriver webDriver, string RegID) : base(webDriver)
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

        #region Malpractice Claims History
        public IWebElement? RegistrationTitle
        {
            get
            {
                return PageHelper.IsElementExist(webDriver, By.Id("ctl00_MainContent_ucRegistrationNavigation_lblTitle")) ?
                    WebDriver.FindElement(By.Id("ctl00_MainContent_ucRegistrationNavigation_lblTitle")) : null;
            }
        }

        public IWebElement AddNewClaims
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucMalpracticeClaim_{RegID}_btnMalpracticeClaims"), null);
            }
        }
        public IWebElement ProfessionalLiabilityPast10Years_Yes
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucMalpracticeClaim_{RegID}_rblMalpractice_1"), null);
            }
        }
        public IWebElement ProfessionalLiabilityPast10Years_No
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucMalpracticeClaim_{RegID}_rblMalpractice_0"), null);
            }
        }
        public IWebElement DateOfOccurence
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucMalpracticeClaim_{RegID}_txtDateOccurence"), null);
            }
        }
        public IWebElement DateClaimFiled
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucMalpracticeClaim_{RegID}_txtDateClaimFiled"), null);
            }
        }
        public IWebElement ClaimStatus
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucMalpracticeClaim_{RegID}_ddlClaimStatus"), null);
            }
        }
        public IWebElement DateClaimSettled
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucMalpracticeClaim_{RegID}_txtDateSettled"), null);
            }
        }
        public IWebElement ProfessionalLiabilityCarrierInvolved
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucMalpracticeClaim_{RegID}_txtProfessionalLiability"), null);
            }
        }
        public IWebElement Address1
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucMalpracticeClaim_{RegID}_ucAddress_txtAddress1"), null);
            }
        }
        public IWebElement Address2
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucMalpracticeClaim_{RegID}_ucAddress_txtAddress2"), null);
            }
        }
        public IWebElement City
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucMalpracticeClaim_{RegID}_ucAddress_txtCity"), null);
            }
        }
        public IWebElement State
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucMalpracticeClaim_{RegID}_ucAddress_ddlState"), null);
            }
        }
        public IWebElement PhoneExtension
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucMalpracticeClaim_{RegID}_ucAddress_txtPhoneExt1"), null);
            }
        }
        public IWebElement ZipCode
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucMalpracticeClaim_{RegID}_ucAddress_nbZipFirst5"), null);
            }
        }
        public IWebElement PhoneNumber
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucMalpracticeClaim_{RegID}_ucAddress_txtPhoneNo1"), null);
            }
        }
        public IWebElement PolicyNumber
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucMalpracticeClaim_{RegID}_txtPolicyNumber"), null);
            }
        }
        public IWebElement MethodOfResolution
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucMalpracticeClaim_{RegID}_ddlMethodofResoultion"), null);
            }
        }
        public IWebElement SettledAmount
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucMalpracticeClaim_{RegID}_txtSettledAmount"), null);
            }
        }
        public IWebElement DescribeAllegationAgainstYou
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucMalpracticeClaim_{RegID}_txtAllegations"), null);
            }
        }
        public IWebElement WereYou_Primary
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucMalpracticeClaim_{RegID}_rblDefendant_0"), null);
            }
        }
        public IWebElement WereYou_Co
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucMalpracticeClaim_{RegID}_rblDefendant_1"), null);
            }
        }
        public IWebElement NoOfOtherDefendants
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucMalpracticeClaim_{RegID}_txtnoofOtherDefendents"), null);
            }
        }
        public IWebElement YourRoleInCase
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucMalpracticeClaim_{RegID}_txtRoleinCase"), null);
            }
        }
        public IWebElement AllegedInjuryToPatient
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucMalpracticeClaim_{RegID}_txtAllegedInjury"), null);
            }
        }
        public IWebElement AllegedInjuryResultInDeath
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucMalpracticeClaim_{RegID}_ddlIsDead"), null);
            }
        }
        public IWebElement KnowledgeOnNPDB
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucMalpracticeClaim_{RegID}_ddlIsNPDB"), null);
            }
        }
        #endregion

        #region Functions
        public void SelectDropDownValue(IWebElement element, String value)
        {
            SelectElement dropDownElement = new SelectElement(element);
            dropDownElement.SelectByText(value);
        }

        public IWebElement getProfessionalLiabilityActions(string value)
        {
            return value == "Yes" ? ProfessionalLiabilityPast10Years_Yes : ProfessionalLiabilityPast10Years_No;
        }

        public IWebElement getWereYou(string value)
        {
            return value == "Primary Defendant" ? WereYou_Primary : WereYou_Co;
        }

        public void SetMalPracticeClaimsHistory(MalPracticeClaimsHistoryDTO info)
        {
            if(info.ProfessionalLiabilityPast10Years == "Yes")
            {
                if (!string.IsNullOrEmpty(info.ProfessionalLiabilityPast10Years))
                    getProfessionalLiabilityActions(info.ProfessionalLiabilityPast10Years).Click();

                if (!string.IsNullOrEmpty(info.DateOfOccurence))
                    DateOfOccurence.Set(info.DateOfOccurence, true);

                if (!string.IsNullOrEmpty(info.DateClaimFiled))
                    DateClaimFiled.Set(info.DateClaimFiled, true);

                if (!string.IsNullOrEmpty(info.StatusOfTheClaim))
                    SelectDropDownValue(ClaimStatus,info.StatusOfTheClaim);

                if (!string.IsNullOrEmpty(info.ProfessionalLiabilityCarrier))
                    ProfessionalLiabilityCarrierInvolved.Set(info.ProfessionalLiabilityCarrier, true);

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
                    PhoneExtension.Set(info.PhoneExtension,true);

                if (!string.IsNullOrEmpty(info.AllegationAgainstYou))
                    DescribeAllegationAgainstYou.SendKeys(info.AllegationAgainstYou);

                if (!string.IsNullOrEmpty(info.Address2))
                    Address2.Set(info.Address2, true);

                if (!string.IsNullOrEmpty(info.WereYou))
                    getWereYou(info.WereYou).Click();

                if (!string.IsNullOrEmpty(info.YourRoleInCase))
                    YourRoleInCase.Set(info.YourRoleInCase, true);

                if (!string.IsNullOrEmpty(info.KnowledgeCaseInNPDB))
                    SelectDropDownValue(KnowledgeOnNPDB, info.KnowledgeCaseInNPDB);
            }
            else
            {
                if (!string.IsNullOrEmpty(info.ProfessionalLiabilityPast10Years))
                    getProfessionalLiabilityActions(info.ProfessionalLiabilityPast10Years).Click();
            }
           

        }
        #endregion
    }
}
