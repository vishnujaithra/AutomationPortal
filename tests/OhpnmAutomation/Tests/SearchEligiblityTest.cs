
using NUnit.Framework;
using OhpnmAutomation.Pages;
using OhpnmAutomation.Pages.Registration;
using OpenQA.Selenium;
using SdetToolbox.Pages;
using Selenium.BaseComponents;
using Selenium.BaseComponents.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumExtensions.Extensions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtensions.Configurations;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;
using System.Diagnostics;
using OhpnmAutomation.Utilities;
using OhpnmAutomation.Models.PA;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace OhpnmAutomation.Tests
{
    [TestFixture("TechAdmin")]
    public class SearchEligiblityTest : BaseFeatureFixture
    {
        public SearchEligiblityTest(string profile) : base(profile)
        {

        }


        [Test]
        [Author("Vishnuvardhan Reddy")]
        [Category("IntegrationTests")]
        [CancelAfter(600000)]
        public void SearchMemberEligibility()
        {
            Models.SearchEligibility searchEligibility = (Models.SearchEligibility)DataRepository.GetAutomationData("SearchMemberEligiblity");

            SidebarMenu.Click();
            Thread.Sleep(4000);
            NavigateToSelfService();

            FinancialProviderInformationPage financialProviderInformationPage = new FinancialProviderInformationPage(TestWebDriver);
            financialProviderInformationPage.WaitUntilElementIsVisible();
            financialProviderInformationPage.TxtMedicaid.Set(searchEligibility != null && !string.IsNullOrEmpty(searchEligibility.RegID) ? 
                searchEligibility.RegID : "0005987");

            financialProviderInformationPage.lnkBtnPriorAuth.Click();

            SearchEligibility searchEligibilityPage = new SearchEligibility(TestWebDriver);
            searchEligibilityPage.lnkBtnSearchEligibility.Click();
            searchEligibilityPage.WaitUntilElementIsVisible();

            if (searchEligibility != null)
            {

                if (!string.IsNullOrEmpty(searchEligibility.MedicaidBillingNumber))
                    searchEligibilityPage.txtMedicaidBillingNumber.Set(searchEligibility.MedicaidBillingNumber);

                if (!string.IsNullOrEmpty(searchEligibility.DateOfBirth))
                    searchEligibilityPage.txtBirthDate.Set(searchEligibility.DateOfBirth);

                if (!string.IsNullOrEmpty(searchEligibility.FromDOS))
                    searchEligibilityPage.txtFromDos.Set(searchEligibility.FromDOS);

                if (!string.IsNullOrEmpty(searchEligibility.ToDOS))
                    searchEligibilityPage.txtToDos.Set(searchEligibility.ToDOS);

                if (!string.IsNullOrEmpty(searchEligibility.SSN))
                    searchEligibilityPage.txtSSN.Set(searchEligibility.SSN);

            }

            Thread.Sleep(3000);

            IJavaScriptExecutor jsExecutor;

            jsExecutor = (IJavaScriptExecutor)TestWebDriver;
            jsExecutor.ExecuteScript("arguments[0].click();", searchEligibilityPage.btnSearch);
            Thread.Sleep(3000);

            if (searchEligibilityPage.lblErrorMsg.Displayed)
            {
                Assert.Fail($"No data found with the search criteria.");
            }

            string medicaidBillingNumber = searchEligibilityPage.txtRecinfoMedicaidbillNumber.GetAttribute("value");
            string lastName = searchEligibilityPage.txtLast.GetAttribute("value");
            string firstname = searchEligibilityPage.txtFirstName.GetAttribute("value");
            string dob = searchEligibilityPage.txtDOB.GetAttribute("value");

            if (!string.IsNullOrEmpty(medicaidBillingNumber) && !string.IsNullOrEmpty(lastName) && !string.IsNullOrEmpty(firstname)
                && !string.IsNullOrEmpty(dob))
            {
                TestContext.WriteLine($"Member eligibility data found.");
            }
        }

        public IWebElement SidebarMenu
        {
            get
            {
                return PageHelper.FindElement(TestWebDriver, By.XPath("//button[contains(@class,'hamburger is-closed')]"), null);
            }
        }
        public void NavigateToSelfService()
        {
            if (SelfService != null)
            {
                SelfService.Click();
            }
        }
        public IWebElement SelfService
        {
            get
            {
                return PageHelper.FindElement(TestWebDriver, By.XPath($"//a[@title='Self Service']"), null);

            }
        }
    }
}