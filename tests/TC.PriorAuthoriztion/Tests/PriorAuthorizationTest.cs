using NUnit.Framework;
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
using TC.PriorAuthoriztion.Utilities;
using TC.PriorAuthoriztion.Models;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using TC.PriorAuthoriztion.Pages;

namespace TC.PriorAuthoriztion.Tests
{
    [TestFixture("TechAdmin")]
    public class PriorAuthorizationTest : BaseFeatureFixture
    {
        public PriorAuthorizationTest(string profile) : base(profile)
        {

        }


        [Test]
        [Author("Vishnuvardhan Reddy")]
        [Category("IntegrationTests")]
        [System.ComponentModel.Description("Verify new provider creation flow")]
        //[CustomRetry(5)]
        [CancelAfter(600000)]
        public void DentalPA_Submit()
        {
            DentalPA dentalPA = (DentalPA)DataRepository.GetAutomationData("DentalPA");

            SidebarMenu.Click();
            NavigateToSelfService();

            FinancialProviderInformationPage financialProviderInformationPage = new FinancialProviderInformationPage(TestWebDriver);
            financialProviderInformationPage.WaitUntilElementIsVisible();
            financialProviderInformationPage.TxtMedicaid.Set(dentalPA.DentalInformation.RegID);
            financialProviderInformationPage.lnkBtnPriorAuth.Click();

            SearchPriorAuthorizationPage searchPriorAuthorizationPage = new SearchPriorAuthorizationPage(TestWebDriver);
            searchPriorAuthorizationPage.WaitUntilElementIsVisible();
            searchPriorAuthorizationPage.lnkBtnSubmitPriorAuth.Click();


            IJavaScriptExecutor jsExecutor;

            FillDentalPAFields(dentalPA);

            SubmitPriorAuthorizationPage submitPriorAuthorizationPage = new SubmitPriorAuthorizationPage(TestWebDriver);
            jsExecutor = (IJavaScriptExecutor)TestWebDriver;
            jsExecutor.ExecuteScript("arguments[0].click();", submitPriorAuthorizationPage.btnSubmit);

            PageHelper.WaitUntilDocumentIsReady(TestWebDriver, TimeoutConfiguration.Element);
            Thread.Sleep(3000);

            //submitPriorAuthorizationPage.btnSubmit.Click();

            PageHelper.WaitUntilDocumentIsReady(TestWebDriver, TimeoutConfiguration.Element);

            IWebElement messagrWarning = PageHelper.FindElement(TestWebDriver, By.Id("ctl00_MainContent_uc1SubmitPriorAuthorization_pnlWarningAcknowledgment"), null);

            if (messagrWarning.Displayed)
            {
                PageHelper.FindElement(TestWebDriver, By.Id("ctl00_MainContent_uc1SubmitPriorAuthorization_btnWarningAcknowledgmentYes"), null).Click();
            }

            PageHelper.WaitUntilElementNotVisible(TestWebDriver, By.Id("ctl00_MainContent_uc1SubmitPriorAuthorization_pnlWarningAcknowledgment"), TimeoutConfiguration.Element);

            jsExecutor = (IJavaScriptExecutor)TestWebDriver;
            jsExecutor.ExecuteScript("arguments[0].click();", submitPriorAuthorizationPage.btnSubmit);

            messagrWarning = PageHelper.FindElement(TestWebDriver, By.Id("ctl00_MainContent_uc1SubmitPriorAuthorization_pnlWarningAcknowledgment"), null);
            if (messagrWarning.Displayed)
            {
                jsExecutor = (IJavaScriptExecutor)TestWebDriver;
                jsExecutor.ExecuteScript("arguments[0].click();", PageHelper.FindElement(TestWebDriver, By.Id("ctl00_MainContent_uc1SubmitPriorAuthorization_btnWarningAcknowledgmentYes"), null));
            }
            Thread.Sleep(1000);
            OpenQA.Selenium.IWebElement elemtToClick = TestWebDriver.FindElement(By.XPath("//*[@id='ctl00_MainContent_uc1SubmitPriorAuthorization_btnSubmit']"));
            Thread.Sleep(1000);
            var actions = new OpenQA.Selenium.Interactions.Actions(TestWebDriver);
            Thread.Sleep(1000);
            actions = actions.MoveToElement(elemtToClick);
            Thread.Sleep(1000);
            actions = actions.Click();
            Thread.Sleep(1000);
            actions.Perform();

            bool trnxSuccess = submitPriorAuthorizationPage.pnmPATXNSuccess.Displayed;
            bool tXNFailure = submitPriorAuthorizationPage.pnmPATXNFailure.Displayed;

            if (trnxSuccess)
            {

            }
            else if (tXNFailure)
            {
                string failureMessage = PageHelper.FindElement(TestWebDriver, By.XPath("//*[@id='ctl00_MainContent_uc1SubmitPriorAuthorization_grdTXNResponse']/tbody/tr/td[2]"), null).Text;
                PageHelper.FindElement(TestWebDriver, By.Id("ctl00_MainContent_uc1SubmitPriorAuthorization_btnCloseFailure"), null).Click();
               NUnit.Framework.Assert.Fail(failureMessage);
            }
        }

        [Test]
        [Author("Vishnuvardhan Reddy")]
        [Category("IntegrationTests")]
        [System.ComponentModel.Description("Verify new provider creation flow")]
        //[CustomRetry(5)]
        [CancelAfter(600000)]
        public void DentalPA_Save()
        {
             DentalPA dentalPA = (DentalPA)DataRepository.GetAutomationData("DentalPA");

            SidebarMenu.Click();
            NavigateToSelfService();

            FinancialProviderInformationPage financialProviderInformationPage = new FinancialProviderInformationPage(TestWebDriver);
            financialProviderInformationPage.WaitUntilElementIsVisible();
            financialProviderInformationPage.TxtMedicaid.Set(dentalPA.DentalInformation.RegID);
            financialProviderInformationPage.lnkBtnPriorAuth.Click();

            SearchPriorAuthorizationPage searchPriorAuthorizationPage = new SearchPriorAuthorizationPage(TestWebDriver);
            searchPriorAuthorizationPage.WaitUntilElementIsVisible();
            searchPriorAuthorizationPage.lnkBtnSubmitPriorAuth.Click();


            IJavaScriptExecutor jsExecutor;

            FillDentalPAFields(dentalPA);

            SubmitPriorAuthorizationPage submitPriorAuthorizationPage = new SubmitPriorAuthorizationPage(TestWebDriver);
            jsExecutor = (IJavaScriptExecutor)TestWebDriver;
            jsExecutor.ExecuteScript("arguments[0].click();", submitPriorAuthorizationPage.btnSave);


            Thread.Sleep(3000);

            IAlert alert = TestWebDriver.SwitchTo().Alert();

            string textMessage = alert.Text;

            if (!textMessage.Equals("Your unsubmitted prior authorization will be saved in the system for 72 hours."))
            {
                NUnit.Framework.Assert.Fail("Something went wrong while saving the Dental PA");
            }

            alert.Accept();

            PageHelper.WaitUntilDocumentIsReady(TestWebDriver, TimeoutConfiguration.Element);
            PageHelper.WaitUntilElementIsVisible(TestWebDriver, By.Id("ctl00_MainContent_uc1SubmitPriorAuthorization_lblpriorautherror"), TimeoutConfiguration.Element);

            IWebElement messagrWarning = PageHelper.FindElement(TestWebDriver, By.Id("ctl00_MainContent_uc1SubmitPriorAuthorization_lblpriorautherror"), null);

            if (messagrWarning.Displayed && messagrWarning.Text.Equals("PA request has been saved."))
            {
                NUnit.Framework.TestContext.WriteLine($"PA request has been saved with Patient Tracking Number::{dentalPA.DentalRecipientInformation.PatientTrackingNumber}");
            }
        }

        private void FillDentalPAFields(DentalPA dentalPA)
        {
            IJavaScriptExecutor jsExecutor;
            SubmitPriorAuthorizationPage submitPriorAuthorizationPage;
            submitPriorAuthorizationPage = new SubmitPriorAuthorizationPage(TestWebDriver);
            submitPriorAuthorizationPage.WaitUntilElementIsVisible();
            submitPriorAuthorizationPage.lnkBtnSubmitPriorAuth.Click();

            submitPriorAuthorizationPage.SetAuthorization(dentalPA.DentalInformation.DestinationPayerName);

            while (!submitPriorAuthorizationPage.VerifyDropdownHasValues(submitPriorAuthorizationPage.ddlSubCapitaPayerID))
            {
                Thread.Sleep(2000);
            }

            submitPriorAuthorizationPage.SetAssignment(dentalPA.DentalInformation.Assignment);
            submitPriorAuthorizationPage.SetServiceType(dentalPA.DentalInformation.ServiceType);

            #region Recipient Information

            submitPriorAuthorizationPage.txtMedicaidBillingNumber.Set(dentalPA.DentalRecipientInformation.MedicaidBillingNumber);
            submitPriorAuthorizationPage.txtBirthDate.Set(dentalPA.DentalRecipientInformation.DateOfBirth);
            submitPriorAuthorizationPage.txtPatientTrckNum.Click();

            IWebElement firstnameElement = PageHelper.FindElement(TestWebDriver, By.Id("ctl00_MainContent_uc1SubmitPriorAuthorization_txtfrstmi2"), null);

            string valuee = firstnameElement.GetAttribute("value");

            bool isLoaded = !string.IsNullOrEmpty(valuee) ? true : false;

            while (!isLoaded)
            {
                Thread.Sleep(2000);
                firstnameElement = PageHelper.FindElement(TestWebDriver, By.Id("ctl00_MainContent_uc1SubmitPriorAuthorization_txtfrstmi2"), null);
                valuee = firstnameElement.GetAttribute("value");
                isLoaded = !string.IsNullOrEmpty(valuee) ? true : false;
            }

            //ctl00_MainContent_uc1SubmitPriorAuthorization_txtfrstmi2

            submitPriorAuthorizationPage.txtPatientTrckNum.Set(dentalPA.DentalRecipientInformation.PatientTrackingNumber);

            #endregion

            #region Requestor Contact Information

            submitPriorAuthorizationPage.txtContactName.Set(dentalPA.DentalContactInformation.ContactFirstName);
            submitPriorAuthorizationPage.txtContactLastName.Set(dentalPA.DentalContactInformation.ContactLastName);
            submitPriorAuthorizationPage.txtContactNumber.Click();

            Thread.Sleep(2000);

            jsExecutor = (IJavaScriptExecutor)TestWebDriver;
            jsExecutor.ExecuteScript($"arguments[0].value = '{dentalPA.DentalContactInformation.ContactNumber}'", submitPriorAuthorizationPage.txtContactNumber);


            submitPriorAuthorizationPage.txtContactExt.Set(dentalPA.DentalContactInformation.ContactExtension);


            #endregion

            #region  SERVICE INFORMATION

            submitPriorAuthorizationPage.txtpalceofservice.Set(dentalPA.DentalServiceInformation.PlaceOfService);
            submitPriorAuthorizationPage.SetDelayReason(dentalPA.DentalServiceInformation.DelayReason);
            submitPriorAuthorizationPage.SetListOfService(dentalPA.DentalServiceInformation.LevelOfService);
            submitPriorAuthorizationPage.txtAccDtService.Set(dentalPA.DentalServiceInformation.AccidentDate);


            #endregion

            #region Service Provider Information

            submitPriorAuthorizationPage.txtSPNPI.Set(dentalPA.DentalServiceProviderInformation.ServiceProviderNPI);
            submitPriorAuthorizationPage.pnlService.Click();
            submitPriorAuthorizationPage.WaitUntilMedicaidIsFetched();

            #endregion

            #region Ordering Provider Information

            string orderingProvExp = submitPriorAuthorizationPage.lblseporderproviderinfo.Text;
            if (orderingProvExp.Equals("+"))
                PageHelper.FindElement(TestWebDriver, By.Id("ctl00_MainContent_uc1SubmitPriorAuthorization_pnlseporderproviderinfo"), null).Click();

            submitPriorAuthorizationPage.txtorderingprovidernpi.Set(dentalPA.DentalOrderingProviderInformation.OrderingProviderNPI);

            IWebElement medicaidElement = TestWebDriver.FindElement(By.XPath("//div[@id='ctl00_MainContent_uc1SubmitPriorAuthorization_pnlorderproviderinfo']//td[text()='Medicaid ID']"));

            if (medicaidElement != null)
                medicaidElement.Click();

            submitPriorAuthorizationPage.WaitUntilOrderingMedicaidIsFetched();


            #endregion

            #region Diagnosis Information
            try
            {
                string diagnosisExp = submitPriorAuthorizationPage.DiagnosisExpanderSpan.Text;
                if (diagnosisExp.Equals("+"))
                    PageHelper.FindElement(TestWebDriver, By.Id("ctl00_MainContent_uc1SubmitPriorAuthorization_pnlsepDiagnosis"), null).Click();

                Thread.Sleep(2000);

                submitPriorAuthorizationPage.btnDiagnosisAdd.Click();
            }
            catch (Exception ex)
            {
                submitPriorAuthorizationPage.btnDiagnosisAdd.Click();
            }

            PageHelper.WaitUntilElementIsVisible(TestWebDriver, By.Id("ctl00_MainContent_uc1SubmitPriorAuthorization_txtLnDiagnosisCode"), TimeoutConfiguration.Element);
            submitPriorAuthorizationPage.txtLnDiagnosisCode.Set(dentalPA.DentalDiagnosisInformation.DiagnosisCode);
            PageHelper.FindElement(TestWebDriver, By.Id("ctl00_MainContent_uc1SubmitPriorAuthorization_txtDiagnosisCodeDescription"), null).Click();

            Thread.Sleep(3000);

            DiagnosisPopupSearch(dentalPA.DentalDiagnosisInformation.DiagnosisCode);

            submitPriorAuthorizationPage.txtDiagnosisDate.Set(dentalPA.DentalDiagnosisInformation.DiagnosisDate);
            submitPriorAuthorizationPage.txtDiagnosisCodeDescription.Click();
            Thread.Sleep(2000);
            submitPriorAuthorizationPage.btnDiagnosisAddLine.Click();
            Thread.Sleep(5000);

            #endregion

            #region Service Details

            submitPriorAuthorizationPage.btnDentalServiceDetailAdd1.Click();
            submitPriorAuthorizationPage.txtDentalSDProcCode.Set(dentalPA.DentalServiceDetails.ProcedureCode);

            submitPriorAuthorizationPage.txtDentalProcCodeDescription.Click();

            Thread.Sleep(3000);

            IWebElement lblDentalProcMessage = PageHelper.FindElement(TestWebDriver, By.Id("ctl00_MainContent_uc1SubmitPriorAuthorization_txtDiagnosisCodeDescription"), null);

            if (lblDentalProcMessage.Displayed && lblDentalProcMessage.Text.Equals("Procedure code is invalid"))
            {
                PageHelper.FindElement(TestWebDriver, By.Id("ctl00_MainContent_uc1SubmitPriorAuthorization_lnkDentalSDProcCodeSearchLink"), null).Click();
                PageHelper.WaitUntilElementIsVisible(TestWebDriver, By.Id("ctl00_MainContent_uc1SubmitPriorAuthorization_pnlSubmitPriorAuthSearchProcPop"), TimeoutConfiguration.Element);

                PageHelper.FindElement(TestWebDriver, By.Id("ctl00_MainContent_uc1SubmitPriorAuthorization_txtCode"), null).Set(dentalPA.DentalServiceDetails.ProcedureCode);
                PageHelper.FindElement(TestWebDriver, By.Id("ctl00_MainContent_uc1SubmitPriorAuthorization_Button9"), null).Click();

                Thread.Sleep(5000);

                IWebElement procedureCodeOutput = PageHelper.FindElement(TestWebDriver, By.XPath("//*[@id='procedureCodeOutput']/div"), null);

                if (procedureCodeOutput.Displayed)
                {
                    if (!procedureCodeOutput.Text.Equals("No data found."))
                        PageHelper.FindElement(TestWebDriver, By.XPath("//*[@id='tableData']/tbody/tr[2]/td[1]/a"), null).Click();
                    else
                        NUnit.Framework.Assert.Fail("no procedure code data found with the given code.");
                }
            }

            submitPriorAuthorizationPage.txtDentalProcCodeDescription.Set(dentalPA.DentalServiceDetails.ProcedureCodeDescription);



            submitPriorAuthorizationPage.SetDentalToothNumber(dentalPA.DentalServiceDetails.ToothNumber);
            submitPriorAuthorizationPage.SetDentalOralCavity1(dentalPA.DentalServiceDetails.OralCavity);
            submitPriorAuthorizationPage.SetDentalToothSurface1(dentalPA.DentalServiceDetails.ToothSurface);
            submitPriorAuthorizationPage.txtDentalProvServnote.Set(dentalPA.DentalServiceDetails.ProviderServiceNote);
            submitPriorAuthorizationPage.txtDentalReqUnits.Set(dentalPA.DentalServiceDetails.RequestedUnits);

            submitPriorAuthorizationPage.txtDentalReqDollars.Set(dentalPA.DentalServiceDetails.RequestedDollars);
            submitPriorAuthorizationPage.txtDentalReqFDOS.Set(dentalPA.DentalServiceDetails.RequestedFDOS);
            submitPriorAuthorizationPage.txtDentalReqTDOS.Set(dentalPA.DentalServiceDetails.RequestedTDOS);
            Random random = new Random();
            int randomNumber = random.Next(1, 9999);
            submitPriorAuthorizationPage.txtDentalServTrackingNo.Set($"AUTH{randomNumber}");
            submitPriorAuthorizationPage.btnServDentalAddUpdate.Click();

            Thread.Sleep(5000);

            #endregion

            #region Provider Notes

            string providerNotesExp = submitPriorAuthorizationPage.lblsepProvidersNotes.Text;
            if (providerNotesExp.Equals("+"))
                submitPriorAuthorizationPage.lblsepProvidersNotes.Click();

            submitPriorAuthorizationPage.txtProviderNotes.Set(dentalPA.DentalProviderNotes.ProviderNotes);

            TestWebDriver.FindElement(By.Id("ctl00_MainContent_uc1SubmitPriorAuthorization_Div17")).Click();

            PageHelper.WaitUntilElementIsVisible(TestWebDriver, By.Id("btnprovNoteSave"), TimeoutConfiguration.Element);

            submitPriorAuthorizationPage.btnprovNoteSave.Click();

            PageHelper.WaitUntilElementIsVisible(TestWebDriver, By.Id("btnprovNoteEdit"), TimeoutConfiguration.Element);

            #endregion

            #region Attachments


            string attachmentExp = submitPriorAuthorizationPage.AttachmentExpanderSpan.Text;
            if (attachmentExp.Equals("+"))
                PageHelper.FindElement(TestWebDriver, By.Id("ctl00_MainContent_uc1SubmitPriorAuthorization_pnlSepDentalAttachment"), null).Click();

            Thread.Sleep(2000);


            string filePath = dentalPA.DentalAttachments.FileName;

            submitPriorAuthorizationPage.priorDentalAttachmentUpload.SendKeys(filePath);

            Thread.Sleep(3000);

            submitPriorAuthorizationPage.SetDocumentType(dentalPA.DentalAttachments.DocumentType);

            submitPriorAuthorizationPage.txtPriorDentalAttachmentNote.Set(dentalPA.DentalAttachments.AttachmentNotes);

            submitPriorAuthorizationPage.btnAddDentalAttachment.Click();

            PageHelper.WaitUntilDocumentIsReady(TestWebDriver, TimeoutConfiguration.Element);

            PageHelper.WaitUntilElementIsVisible(TestWebDriver, By.Id("ctl00_MainContent_uc1SubmitPriorAuthorization_gvDentalAttachment"), TimeoutConfiguration.Element);

            PageHelper.WaitUntilDocumentIsReady(TestWebDriver, TimeoutConfiguration.Element);

            #endregion
        }

        private void DiagnosisPopupSearch(string diagnosisCode)
        {
            IWebElement searchPopup = PageHelper.FindElement(TestWebDriver, By.Id("ctl00_MainContent_uc1SubmitPriorAuthorization_pnlDiagnosisSearch1"), null);

            if (searchPopup.Displayed)
            {
                PageHelper.FindElement(TestWebDriver, By.Id("ctl00_MainContent_uc1SubmitPriorAuthorization_pnlDiagnosisSearch1"), null);
                PageHelper.FindElement(TestWebDriver, By.Id("ctl00_MainContent_uc1SubmitPriorAuthorization_txtDiagnosisCodeSearch1"), null).Set(diagnosisCode);
                PageHelper.FindElement(TestWebDriver, By.Id("ctl00_MainContent_uc1SubmitPriorAuthorization_btndiagnosiscodeSearch"), null).Click();

                Thread.Sleep(5000);

                IWebElement diagnosisOutput = PageHelper.FindElement(TestWebDriver, By.Id("DiagnosisOutput"), null);

                if (diagnosisOutput.Displayed)
                {
                    if (!diagnosisOutput.Text.Equals("No Diagnosis Found."))
                        PageHelper.FindElement(TestWebDriver, By.XPath("//*[@id='DiagnosisOutput']/table/tbody/tr[2]/td[1]/a"), null).Click();
                    else
                        NUnit.Framework.Assert.Fail("no diagnosis data found with the given code.");

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

