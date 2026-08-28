using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SdetToolbox.Pages;
using Selenium.BaseComponents.Pages;
using SeleniumExtensions.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace TC.ProviderDataEntry.Pages.Registration
{
    public class RegistrationPage : BasePage
    {
        IWebDriver webDriver;
        public string RegID;

        public RegistrationPage(IWebDriver webDriver) : base(webDriver)
        {

            this.webDriver = webDriver;

            string url = this.webDriver.Url;
            var regIDTag = url.Split('?').Last();
            var regID = regIDTag.Split('=').Last();

            RegID = regID;
        }

        #region Provider Information 

        public bool isRequiredMessageAppear
        {
            get
            {
                return webDriver.IsElementExist(By.Id("ctl00_MainContent_ucRegistrationNavigation_lblRequired"));
            }
        }

        public IWebElement RequiredMessage
        {
            get
            {
                return webDriver.FindElement(By.Id("ctl00_MainContent_ucRegistrationNavigation_lblRequired"));
            }
        }

        public void SetResident(string isResident)
        {
            IWebElement webElement = null;
            switch (isResident)
            {
                case "Yes":
                    webElement = WebDriver.FindElement(By.XPath($"//*[@id='ctl00_MainContent_ucOrgInfo_{RegID}_rblIsOhioResident_0']"));
                    break;
                case "No":
                    webElement = WebDriver.FindElement(By.XPath($"//*[@id='ctl00_MainContent_ucOrgInfo_{RegID}_rblIsOhioResident_1']"));
                    break;
            }
            if (webElement != null)
            {
                webElement.Click();
            }
        }

        public IWebElement BtnNext
        {
            get
            {
                return WebDriver.FindElement(By.Id("ctl00_MainContent_ucRegistrationNavigation_btnSaveNext"));
            }
        }
        public IWebElement BtnSubmitForReview
        {
            get
            {
                return WebDriver.FindElement(By.Id("ctl00_rptWorkflowActions_ctl00_btnAction"));
            }
        }

        public void SetPracticeType(string item, WebDriverWait wait)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id($"ctl00_MainContent_ucOrgInfo_{RegID}_ddlPracticeType")));
            IWebElement PracticeTypeElement = WebDriver.FindElement(By.Id($"ctl00_MainContent_ucOrgInfo_{RegID}_ddlPracticeType"));
            SelectElement PracticeTypeElementDropDown = new SelectElement(PracticeTypeElement);
            PracticeTypeElementDropDown.SelectByText(item);
        }

        public void SetOwnershipType(string item, WebDriverWait wait)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id($"ctl00_MainContent_ucOrgInfo_{RegID}_ddlOwnershiptype")));
            IWebElement OwnershipTypeElement = WebDriver.FindElement(By.Id($"ctl00_MainContent_ucOrgInfo_{RegID}_ddlOwnershiptype"));
            SelectElement OwnershipTypeElementDropDown = new SelectElement(OwnershipTypeElement);
            OwnershipTypeElementDropDown.SelectByText(item);
        }

        #endregion


        public void WaitUntilPageLoad()
        {
            PageHelper.WaitUntilElementIsVisible(webDriver, By.XPath($"//*[@id='ctl00_MainContent_ucRegistrationNavigation_lblTitlePS']"), TimeoutConfiguration.Element);
        }

        public IWebElement More
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.XPath($"//a[contains(@class,'btn btn-primary btn-md') and text()='More ...']"), null);

            }
        }

        public IWebElement BtnApprove
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.XPath($"//*[@id='ctl00_MainContent_ucRegistrationNavigation_btnTakeActionApprove']"), null);

            }
        }

        public IWebElement TakeAction
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.XPath($"//*[@id='ctl00_rptWorkflowActions_ctl00_btnAction']"), null);
            }
        }

        public string GetLoggedInUser()
        {
            return webDriver.FindElement(By.Id("ctl00_LoginView2_LoginName1")).Text;
        }

        public IWebElement AssignedTo
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id("ctl00_ddlAssignedTo"), null);
            }
        }

        public void SetAssignmentUser()
        {
            string loggedInUser = GetLoggedInUser();

            if (!string.IsNullOrEmpty(loggedInUser))
            {
                SelectElement assignedType = new SelectElement(AssignedTo);
                assignedType.SelectByText(loggedInUser);
            }
        }

        public IWebElement SidebarMenu
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.XPath("//button[contains(@class,'hamburger is-closed')]"), null);
            }
        }

        public void NavigateToMyQueue()
        {
            if (MyQueueLink != null)
            {
                MyQueueLink.Click();
            }
        }

        public IWebElement MyQueueLink
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.XPath($"//a[@title='My Queue']"), null);
               
            }
        }
    }
}