using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SdetToolbox.Pages;
using Selenium.BaseComponents.Pages;
using SeleniumExtensions.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TC.PriorAuthoriztion.Pages
{
    public class SubmitPriorAuthorizationPage : BasePage
    {
        IWebDriver webDriver;
        public SubmitPriorAuthorizationPage(IWebDriver webDriver) : base(webDriver)
        {
            this.webDriver = webDriver;
            string url = this.webDriver.Url;
        }
        public IWebElement lnkBtnSubmitPriorAuth
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.XPath("//input[@value='dental']"), null);
            }
        }
        public void WaitUntilElementIsVisible()
        {
            PageHelper.WaitUntilElementIsVisible(webDriver, By.XPath("//*[@id='ctl00_MainContent_uc1SubmitPriorAuthorization_rblClaimType']"), TimeoutConfiguration.Element);
        }
        public IWebElement ddlAuthorization
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id("ctl00_MainContent_uc1SubmitPriorAuthorization_ddlAuthorization"), null);
            }
        }
        public IWebElement ddlSubCapitaPayerID
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id("ctl00_MainContent_uc1SubmitPriorAuthorization_ddlSubCapitaPayerIDs"), null);
            }
        }
        public IWebElement ddlAssignment
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id("ctl00_MainContent_uc1SubmitPriorAuthorization_ddlAssignment"), null);
            }
        }
        public IWebElement ddlServiceType
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id("ctl00_MainContent_uc1SubmitPriorAuthorization_ddlServiceType"), null);
            }
        }

        #region Recipient Information

        public IWebElement txtMedicaidBillingNumber
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id("ctl00_MainContent_uc1SubmitPriorAuthorization_txtMedicaidBillingNumber"), null);
            }
        }
        public IWebElement txtBirthDate
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id("ctl00_MainContent_uc1SubmitPriorAuthorization_txtBirthDate"), null);
            }
        }
        public IWebElement txtPatientTrckNum
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id("ctl00_MainContent_uc1SubmitPriorAuthorization_txtPatientTrckNum"), null);
            }
        }

        public IWebElement divpnlRecipientLoader
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id("divpnlRecipientLoader"), null);
            }
        }
        public void WaitUntilLoaderDisappear()
        {
            PageHelper.WaitUntilElementNotAvailable(WebDriver, By.Id("divpnlRecipientLoader"), TimeoutConfiguration.Element);
        }

        #endregion

        #region Requestor Contact Information

        public IWebElement txtContactName
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id("ctl00_MainContent_uc1SubmitPriorAuthorization_txtContactName"), null);
            }
        }
        public IWebElement txtContactLastName
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id("ctl00_MainContent_uc1SubmitPriorAuthorization_txtContactLastName"), null);
            }
        }
        public IWebElement txtContactNumber
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id("ctl00_MainContent_uc1SubmitPriorAuthorization_txtContactNumber"), null);
            }
        }
        public IWebElement txtContactExt
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id("ctl00_MainContent_uc1SubmitPriorAuthorization_txtExt"), null);
            }
        }


        #endregion

        #region  SERVICE INFORMATION

        public IWebElement txtpalceofservice
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id("ctl00_MainContent_uc1SubmitPriorAuthorization_txtpalceofservice"), null);
            }
        }
        public IWebElement txtAccDtService
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id("ctl00_MainContent_uc1SubmitPriorAuthorization_txtAccDtService"), null);
            }
        }
        public IWebElement txtDateOfpatientEvent
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id("ctl00_MainContent_uc1SubmitPriorAuthorization_TextBox3"), null);
            }
        }
        public IWebElement txtProfOnsetIllness
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id("ctl00_MainContent_uc1SubmitPriorAuthorization_txtProfOnsetIllness"), null);
            }
        }
        public IWebElement txtMenDtInst
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id("ctl00_MainContent_uc1SubmitPriorAuthorization_txtMenDtInst"), null);
            }
        }
        public IWebElement txtEstDOB
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id("ctl00_MainContent_uc1SubmitPriorAuthorization_txtEstDOB"), null);
            }
        }
        public IWebElement txtPANumInst
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id("ctl00_MainContent_uc1SubmitPriorAuthorization_txtPANumInst"), null);
            }
        }
        public IWebElement ddlLvlServiceInst
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id("ctl00_MainContent_uc1SubmitPriorAuthorization_ddlLvlServiceInst"), null);
            }
        }
        public IWebElement ddlDelayedInst
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id("ctl00_MainContent_uc1SubmitPriorAuthorization_ddlDelayedInst"), null);
            }
        }
        public IWebElement pnlPlaceofServiceSearchPopup
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id("ctl00_MainContent_uc1SubmitPriorAuthorization_pnlplaceofServiceSearch"), null);
            }
        }

        public void SetDelayReason(string servicetype)
        {

            if (!string.IsNullOrEmpty(servicetype))
            {
                SelectElement assignedType = new SelectElement(ddlDelayedInst);
                assignedType.SelectByText(servicetype);
            }
        }
        public void SetListOfService(string serviceType)
        {

            if (!string.IsNullOrEmpty(serviceType))
            {
                SelectElement assignedType = new SelectElement(ddlLvlServiceInst);
                assignedType.SelectByText(serviceType);
            }
        }

        #endregion

        #region Service Provider Information
        public IWebElement txtSPNPI
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id("ctl00_MainContent_uc1SubmitPriorAuthorization_txtSPNPI"), null);
            }
        }

        public void WaitUntilMedicaidIsFetched()
        {
            PageHelper.WaitUntilElementIsVisible(webDriver, By.Id("ctl00_MainContent_uc1SubmitPriorAuthorization_txtMedicaidID"), TimeoutConfiguration.Element);
        }

        public IWebElement pnlService
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id("ctl00_MainContent_uc1SubmitPriorAuthorization_pnlService"), null);
            }
        }

        #endregion

        #region Ordering Provider Information
        public IWebElement lblseporderproviderinfo
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id("ctl00_MainContent_uc1SubmitPriorAuthorization_lblseporderproviderinfo"), null);
            }
        }

        public IWebElement txtorderingprovidernpi
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id("ctl00_MainContent_uc1SubmitPriorAuthorization_txtorderingprovidernpi"), null);
            }
        }
        public IWebElement pnlorderproviderinfo
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id("ctl00_MainContent_uc1SubmitPriorAuthorization_pnlorderproviderinfo"), null);
            }
        }
        public void WaitUntilOrderingMedicaidIsFetched()
        {
            PageHelper.WaitUntilElementIsVisible(webDriver, By.Id("ctl00_MainContent_uc1SubmitPriorAuthorization_txtOMID"), TimeoutConfiguration.Element);
        }

        //

        #endregion

        #region Diagnosis Information

        public IWebElement btnDiagnosisAdd
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id("ctl00_MainContent_uc1SubmitPriorAuthorization_btnDiagnosisAdd"), null);
            }
        }
        public IWebElement btnDiagnosisAddLine
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id("btnDiagnosisAddLine"), null);
            }
        }
        public IWebElement ddlDiagnosisCodeType
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id("ctl00_MainContent_uc1SubmitPriorAuthorization_ddlDiagnosisCodeType"), null);
            }
        }
        public IWebElement txtLnDiagnosisCode
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id("ctl00_MainContent_uc1SubmitPriorAuthorization_txtLnDiagnosisCode"), null);
            }
        }
        public IWebElement txtDiagnosisDate
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id("ctl00_MainContent_uc1SubmitPriorAuthorization_txtDiagnosisDate"), null);
            }
        }
        public IWebElement btnDiagnosisEditCancel
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id("btnDiagnosisEditCancel"), null);
            }
        }

        public IWebElement DiagnosisExpanderSpan
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id("ctl00_MainContent_uc1SubmitPriorAuthorization_lblsepDiagnosis"), null);
            }
        }

        public IWebElement txtDiagnosisCodeDescription
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id("ctl00_MainContent_uc1SubmitPriorAuthorization_txtDiagnosisCodeDescription"), null);
            }
        }
        #endregion

        #region Service Details
        public IWebElement btnDentalServiceDetailAdd1
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id("ctl00_MainContent_uc1SubmitPriorAuthorization_btnDentalServiceDetailAdd1"), null);
            }
        }
        public IWebElement txtDentalSDProcCode
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id("ctl00_MainContent_uc1SubmitPriorAuthorization_txtDentalSDProcCode"), null);
            }
        }
        public IWebElement txtDentalProcCodeDescription
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id("ctl00_MainContent_uc1SubmitPriorAuthorization_txtDentalProcCodeDescription"), null);
            }
        }
        public IWebElement txtDentalReqUnits
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id("ctl00_MainContent_uc1SubmitPriorAuthorization_txtDentalReqUnits"), null);
            }
        }
        public IWebElement txtDentalReqDollars
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id("ctl00_MainContent_uc1SubmitPriorAuthorization_txtDentalReqDollars"), null);
            }
        }
        public IWebElement txtDentalReqFDOS
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id("ctl00_MainContent_uc1SubmitPriorAuthorization_txtDentalReqFDOS"), null);
            }
        }
        public IWebElement txtDentalReqTDOS
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id("ctl00_MainContent_uc1SubmitPriorAuthorization_txtDentalReqTDOS"), null);
            }
        }
        public IWebElement txtDentalServTrackingNo
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id("ctl00_MainContent_uc1SubmitPriorAuthorization_txtDentalServTrackingNo"), null);
            }
        }
        public IWebElement txtDentalProvServnote
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id("ctl00_MainContent_uc1SubmitPriorAuthorization_txtDentalProvServnote"), null);
            }
        }
        public IWebElement ddDentalToothNumber
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id("ctl00_MainContent_uc1SubmitPriorAuthorization_ddDentalToothNumber"), null);
            }
        }
        public IWebElement ddDentalOralCavity1
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id("ctl00_MainContent_uc1SubmitPriorAuthorization_ddDentalOralCavity1"), null);
            }
        }
        public IWebElement ddToothSurface1
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id("ctl00_MainContent_uc1SubmitPriorAuthorization_ddToothSurface1"), null);
            }
        }
        public IWebElement ddDentalProsthsis
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id("ctl00_MainContent_uc1SubmitPriorAuthorization_ddDentalProsthsis"), null);
            }
        }
        public IWebElement btnServDentalAddUpdate
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id("btnServDentalUpdate"), null);
            }
        }
        public void SetDentalToothNumber(string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                SelectElement assignedType = new SelectElement(ddDentalToothNumber);
                assignedType.SelectByText(text);
            }
        }
        public void SetDentalOralCavity1(string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                SelectElement assignedType = new SelectElement(ddDentalOralCavity1);
                assignedType.SelectByText(text);
            }
        }
        public void SetDentalToothSurface1(string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                SelectElement assignedType = new SelectElement(ddToothSurface1);
                assignedType.SelectByText(text);
            }
        }
        public void SetDentalProsthsis(string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                SelectElement assignedType = new SelectElement(ddDentalProsthsis);
                assignedType.SelectByText(text);
            }
        }
        public void WaituntilProcedureCodeVisible()
        {
            PageHelper.WaitUntilElementIsVisible(webDriver, By.XPath("//*[@id='ctl00_MainContent_uc1SubmitPriorAuthorization_txtDentalSDProcCode']"), TimeoutConfiguration.Element);
        }

        #endregion

        #region Provider Notes

        public IWebElement txtProviderNotes
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id("ctl00_MainContent_uc1SubmitPriorAuthorization_txtProviderNotes"), null);
            }
        }
        public IWebElement btnprovNoteSave
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id("btnprovNoteSave"), null);
            }
        }
        public IWebElement btnprovNoteEdit
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id("btnprovNoteEdit"), null);
            }
        }
        public IWebElement btnprovNoteDelete
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id("btnprovNoteDelete"), null);
            }
        }

        public IWebElement lblsepProvidersNotes
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id("ctl00_MainContent_uc1SubmitPriorAuthorization_lblsepProvidersNotes"), null);
            }
        }


        #endregion

        #region Attachments

        public IWebElement priorDentalAttachmentUpload
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id("ctl00_MainContent_uc1SubmitPriorAuthorization_priorDentalAttachmentUpload"), null);
            }
        }
        public IWebElement ddlPriorDentalAuthDocType
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id("ctl00_MainContent_uc1SubmitPriorAuthorization_ddlPriorDentalAuthDocType"), null);
            }
        }
        public IWebElement txtPriorDentalAttachmentNote
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id("ctl00_MainContent_uc1SubmitPriorAuthorization_txtPriorDentalAttachmentNote"), null);
            }
        }
        public IWebElement btnAddDentalAttachment
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id("ctl00_MainContent_uc1SubmitPriorAuthorization_btnAddDentalAttachment"), null);
            }
        }
        public IWebElement btnAddDentalAttachmentsGrid
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id("ctl00_MainContent_uc1SubmitPriorAuthorization_gvDentalAttachment"), null);
            }
        }

        public IWebElement AttachmentExpanderSpan
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id("ctl00_MainContent_uc1SubmitPriorAuthorization_lblsepDentalAttachment"), null);
            }
        }

        public IWebElement btnSubmit
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id("ctl00_MainContent_uc1SubmitPriorAuthorization_btnSubmit"), null);
            }
        }
        public IWebElement btnSave
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id("ctl00_MainContent_uc1SubmitPriorAuthorization_btnSave"), null);
            }
        }
        public IWebElement btnClearAll
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id("ctl00_MainContent_uc1SubmitPriorAuthorization_btnClearAll"), null);
            }
        }

        public IWebElement pnmPATXNFailure
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id("ctl00_MainContent_uc1SubmitPriorAuthorization_pnmPATXNFailure"), null);
            }
        }
        public IWebElement pnmPATXNSuccess
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id("ctl00_MainContent_uc1SubmitPriorAuthorization_pnmPATXNSuccess"), null);
            }
        }


        //ctl00_MainContent_uc1SubmitPriorAuthorization_pnmPATXNFailure
        //ctl00_MainContent_uc1SubmitPriorAuthorization_pnmPATXNSuccess

        #endregion




        public void SetDocumentType(string documentType)
        {
            if (!string.IsNullOrEmpty(documentType))
            {
                SelectElement assignedType = new SelectElement(ddlPriorDentalAuthDocType);
                assignedType.SelectByText(documentType);
            }
        }
        public void SetAuthorization(string authType)
        {
            if (!string.IsNullOrEmpty(authType))
            {
                SelectElement assignedType = new SelectElement(ddlAuthorization);
                assignedType.SelectByText(authType);
            }
        }
        public void SetAssignment(string assignment)
        {
            string assignmentType = "Dental";

            if (!string.IsNullOrEmpty(assignment))
            {
                SelectElement assignedType = new SelectElement(ddlAssignment);
                assignedType.SelectByText(assignment);
            }
        }
        public void SetServiceType(string serviceType)
        {
            if (!string.IsNullOrEmpty(serviceType))
            {
                SelectElement assignedType = new SelectElement(ddlServiceType);
                assignedType.SelectByText(serviceType);
            }
        }
        public bool VerifyDropdownHasValues(IWebElement drodownElement)
        {
            SelectElement assignedType = new SelectElement(ddlAuthorization);
            IList<IWebElement> options = assignedType.Options;
            return options != null && options.Count > 0 ? true : false;
        }
    }
}
