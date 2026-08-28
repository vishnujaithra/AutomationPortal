using OpenQA.Selenium.Support.UI;
using Selenium.BaseComponents.Pages;
using SeleniumExtensions.Extensions;
using Selenium.BaseComponents.Utilities;
using OpenQA.Selenium;
using TC.ProviderDataEntry.Models;
using SeleniumExtensions.Configurations;

namespace TC.ProviderDataEntry.Pages.Registration
{
    public class RequiredDocuments : BasePage
    {
        IWebDriver webDriver;
        string RegID;
        WebDriverWait wait;
        public RequiredDocuments(IWebDriver webDriver, string RegID) : base(webDriver)
        {
            wait = new WebDriverWait(webDriver, TimeoutConfiguration.Element);

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

        #region Required Documents

        public IWebElement? RegistrationTitle
        {
            get
            {
                return PageHelper.IsElementExist(webDriver, By.Id("ctl00_MainContent_ucRegistrationNavigation_lblTitle")) ?
                    WebDriver.FindElement(By.Id("ctl00_MainContent_ucRegistrationNavigation_lblTitle")) : null;
            }
        }

        public IWebElement FileUpload
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id("ctl00_MainContent_ucUploadDocument_filUploadFile"), null);
            }
        }
        public IWebElement FileName
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id("ctl00_MainContent_ucUploadDocument_txtName"), null);
            }
        }
        public IWebElement FileDescription
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id("ctl00_MainContent_ucUploadDocument_txtDescription"), null);
            }
        }

        public IWebElement FileUploadButton
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id("ctl00_MainContent_ucUploadDocument_UploadButton"), null);
            }
        }
        public IWebElement FileUploadTable
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id("ctl00_MainContent_ucUploadDocument_gvUploadedDocs"), null);
            }
        }
        #endregion

        #region Functions
        public void SetRequiredDocument(RequiredDocumentsDTO document)
        {
            if (!string.IsNullOrEmpty(document.FilePath))
                FileUpload.Set(document.FilePath, true);

            if (!string.IsNullOrEmpty(document.Name))
                FileName.Set(document.Name, true);

            if (!string.IsNullOrEmpty(document.Description))
                FileDescription.Set(document.Description, true);

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FileUploadButton)).Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FileUploadTable));
        }
        #endregion
    }
}
