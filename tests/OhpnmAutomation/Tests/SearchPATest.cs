
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
    public class SearchPATest : BaseFeatureFixture
    {
        public SearchPATest(string profile) : base(profile)
        {

        }


        [Test]
        [Author("Vishnuvardhan Reddy")]
        [Category("IntegrationTests")]
        [CancelAfter(600000)]
        public void SearchPA()
        {
            Models.SearchPA searchPA = (Models.SearchPA)DataRepository.GetAutomationData("SearchPA");

            SidebarMenu.Click();
            Thread.Sleep(4000);
            NavigateToSelfService();

            FinancialProviderInformationPage financialProviderInformationPage = new FinancialProviderInformationPage(TestWebDriver);
            financialProviderInformationPage.WaitUntilElementIsVisible();
            financialProviderInformationPage.TxtMedicaid.Set(searchPA != null && !string.IsNullOrEmpty(searchPA.RegID) ? searchPA.RegID : "0005987");
            financialProviderInformationPage.lnkBtnPriorAuth.Click();

            SearchPAPage SearchPAPage = new SearchPAPage(TestWebDriver);
            SearchPAPage.lnkBtnSearchPA.Click();
            SearchPAPage.WaitUntilElementIsVisible();

            if (searchPA != null)
            {

                if (!string.IsNullOrEmpty(searchPA.PriorAuthorizationNumber))
                    SearchPAPage.txtPriorAuthNumber.Set(searchPA.PriorAuthorizationNumber);

                if (!string.IsNullOrEmpty(searchPA.PatientTrackingNumber))
                    SearchPAPage.txtPatientTrackingNumber.Set(searchPA.PatientTrackingNumber);

                if (!string.IsNullOrEmpty(searchPA.MedicaidBillingNumber))
                    SearchPAPage.txtMedicaidBillingNumber.Set(searchPA.MedicaidBillingNumber);

                if (!string.IsNullOrEmpty(searchPA.ICDProcedureCode))
                    SearchPAPage.txtICDCode.Set(searchPA.ICDProcedureCode);

                if (!string.IsNullOrEmpty(searchPA.DateofBirth))
                {
                    SearchPAPage.txtBirthDate.Click();
                    SearchPAPage.txtBirthDate.Set(searchPA.DateofBirth);
                }

                if (!string.IsNullOrEmpty(searchPA.ProcedureCode))
                    SearchPAPage.txtProcedureCode.Set(searchPA.ProcedureCode);

                if (!string.IsNullOrEmpty(searchPA.PASubmissionDate))
                {
                    SearchPAPage.txtSubmissiondate.Click();
                    SearchPAPage.txtSubmissiondate.Set(searchPA.PASubmissionDate);
                }


                if (!string.IsNullOrEmpty(searchPA.RevenueCode))
                    SearchPAPage.txtRevenuecode.Set(searchPA.RevenueCode);

                if (!string.IsNullOrEmpty(searchPA.Status))
                    SearchPAPage.SetSearchPAStatus(searchPA.Status);

                if (!string.IsNullOrEmpty(searchPA.DiagnosisCode))
                    SearchPAPage.txtDiagnoisCode.Set(searchPA.DiagnosisCode);

                if (!string.IsNullOrEmpty(searchPA.OrderingProviderNPI))
                    SearchPAPage.txtorderProvnpi.Set(searchPA.OrderingProviderNPI);

                if (!string.IsNullOrEmpty(searchPA.PAEffectiveDate))
                {
                    SearchPAPage.txtPAEffDate.Click();
                    SearchPAPage.txtPAEffDate.Set(searchPA.PAEffectiveDate);
                }


                if (!string.IsNullOrEmpty(searchPA.PayerName))
                    SearchPAPage.SetPayerName(searchPA.PayerName);

                if (!string.IsNullOrEmpty(searchPA.PAExpirationDate))
                {
                    SearchPAPage.txtPAExpDate.Click();
                    SearchPAPage.txtPAExpDate.Set(searchPA.PAExpirationDate);
                }


                if (!string.IsNullOrEmpty(searchPA.AssignmentType))
                    SearchPAPage.SetAssignment(searchPA.AssignmentType);
            }

            Thread.Sleep(3000);

            IJavaScriptExecutor jsExecutor;

            jsExecutor = (IJavaScriptExecutor)TestWebDriver;
            jsExecutor.ExecuteScript("arguments[0].click();", SearchPAPage.btnSearch);
            Thread.Sleep(3000);

            IWebElement searchTable = TestWebDriver.FindElement(By.Id("ctl00_MainContent_SearchPriorAuthorization_gvPasearch"));

            if (searchTable.Displayed)
            {
                IWebElement tbody = searchTable.FindElement(By.TagName("tbody"));
                if (tbody.Displayed)
                {
                    IWebElement emptydataRow = tbody.FindElement(By.ClassName("gridViewEmptyRow"));

                    if (emptydataRow.Displayed)
                    {
                        IWebElement emptytd = emptydataRow.FindElement(By.TagName("td"));

                        if (emptytd.Displayed)
                        {
                            string searchMessage = emptytd.Text;
                            TestContext.WriteLine($"No data found with the search criteria.");
                        }
                    }
                    else
                    {
                        IWebElement gridViewRow = tbody.FindElement(By.ClassName("gridViewRow"));
                        if (gridViewRow.Displayed)
                        {
                            List<IWebElement> tdList = gridViewRow.FindElements(By.TagName("td")).ToList();
                            if (tdList != null && tdList.Count() > 0)
                            {
                                tdList[0].Click();
                            }
                        }
                    }
                }
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
