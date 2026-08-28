using Microsoft.Extensions.Primitives;
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

namespace OhpnmAutomation.Pages
{
    public class SearchEligibility : BasePage
    {
        IWebDriver webDriver;
        public SearchEligibility(IWebDriver webDriver) : base(webDriver)
        {
            this.webDriver = webDriver;
            string url = this.webDriver.Url;
        }

        public IWebElement lnkBtnSearchEligibility
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.XPath($"//span[text()='Search Eligibility']"), null);
            }
        }
        public void WaitUntilElementIsVisible()
        {
            PageHelper.WaitUntilElementIsVisible(webDriver, By.XPath("//*[@id='eligibilitysearch']"), TimeoutConfiguration.Element);
        }
        public IWebElement txtMedicaidBillingNumber
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id("ctl00_MainContent_ucRecipientEligibilitySearch_txtMedicaidBillingNumber"), null);
            }
        }

        public IWebElement txtBirthDate
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id("ctl00_MainContent_ucRecipientEligibilitySearch_txtBirthDate"), null);
            }
        }
        public IWebElement txtFromDos
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id("ctl00_MainContent_ucRecipientEligibilitySearch_txtFromDos"), null);
            }
        }
        public IWebElement txtToDos
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id("ctl00_MainContent_ucRecipientEligibilitySearch_txtToDos"), null);
            }
        }
        public IWebElement txtProcedureCode
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id("ctl00_MainContent_ucRecipientEligibilitySearch_txtProcedureCode"), null);
            }
        }
        public IWebElement txtSSN
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id("ctl00_MainContent_ucRecipientEligibilitySearch_txtSSN"), null);
            }
        }
        public IWebElement lblErrorMsg
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id("ctl00_MainContent_ucRecipientEligibilitySearch_lblErrorMsg"), null);
            }
        }

        public IWebElement btnSearch
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id("ctl00_MainContent_ucRecipientEligibilitySearch_btnSearch"), null);
            }
        }
        public IWebElement btnClear
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id("ctl00_MainContent_ucRecipientEligibilitySearch_btnClear"), null);
            }
        }
        public IWebElement txtRecinfoMedicaidbillNumber
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id("ctl00_MainContent_ucRecipientEligibilitySearch_txtRecinfoMedicaidbillNumber"), null);
            }
        }
        public IWebElement txtFirstName
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id("ctl00_MainContent_ucRecipientEligibilitySearch_txtFirstName"), null);
            }
        }
        public IWebElement txtLast
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id("ctl00_MainContent_ucRecipientEligibilitySearch_txtLast"), null);
            }
        }
        public IWebElement txtDOB
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id("ctl00_MainContent_ucRecipientEligibilitySearch_txtDOB"), null);
            }
        }
       
    }

}
