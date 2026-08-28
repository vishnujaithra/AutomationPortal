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
    public class SearchPAPage : BasePage
    {
        IWebDriver webDriver;
        public SearchPAPage(IWebDriver webDriver) : base(webDriver)
        {
            this.webDriver = webDriver;
            string url = this.webDriver.Url;
        }

        public IWebElement lnkBtnSearchPA
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.XPath($"//span[text()='Search PA']"), null);
            }
        }
        public void WaitUntilElementIsVisible()
        {
            PageHelper.WaitUntilElementIsVisible(webDriver, By.XPath("//*[@id='priorauthSearch']"), TimeoutConfiguration.Element);
        }
        public IWebElement ddlStatus
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id("ctl00_MainContent_SearchPriorAuthorization_ddlStatus"), null);
            }
        }
        public IWebElement ddlPayerName
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id("ctl00_MainContent_SearchPriorAuthorization_ddlPayerName"), null);
            }
        }
        public IWebElement ddlAssignment
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id("ctl00_MainContent_SearchPriorAuthorization_ddlAssignment"), null);
            }
        }
        public IWebElement txtPriorAuthNumber
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id("ctl00_MainContent_SearchPriorAuthorization_txtPriorAuthNumber"), null);
            }
        }

        public IWebElement txtSubmissiondate
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id("ctl00_MainContent_SearchPriorAuthorization_txtSubmissiondate"), null);
            }
        }

 
        public IWebElement txtPatientTrackingNumber
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id("ctl00_MainContent_SearchPriorAuthorization_txtPatientTrackingNumber"), null);
            }
        }
        public IWebElement txtMedicaidBillingNumber
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id("ctl00_MainContent_SearchPriorAuthorization_txtMedicaidBillingNumber"), null);
            }
        }
        public IWebElement txtICDCode
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id("ctl00_MainContent_SearchPriorAuthorization_txtICDCode"), null);
            }
        }

        public IWebElement txtProcedureCode
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id("ctl00_MainContent_SearchPriorAuthorization_txtProcedureCode"), null);
            }
        }
        public IWebElement txtRevenuecode
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id("ctl00_MainContent_SearchPriorAuthorization_txtRevenuecode"), null);
            }
        }
        public IWebElement txtBirthDate
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id("ctl00_MainContent_SearchPriorAuthorization_txtBirthDate"), null);
            }
        }
        public IWebElement txtDiagnoisCode
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id("ctl00_MainContent_SearchPriorAuthorization_txtDiagnoisCode"), null);
            }
        }
        public IWebElement txtorderProvnpi
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id("ctl00_MainContent_SearchPriorAuthorization_txtorderProvnpi"), null);
            }
        }
        public IWebElement txtPAEffDate
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id("ctl00_MainContent_SearchPriorAuthorization_txtPAEffDate"), null);
            }
        }
        public IWebElement txtPAExpDate
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id("ctl00_MainContent_SearchPriorAuthorization_txtPAExpDate"), null);
            }
        }
        public IWebElement btnSearch
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id("ctl00_MainContent_SearchPriorAuthorization_btnSearch"), null);
            }
        }
        public IWebElement btnClear
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id("ctl00_MainContent_SearchPriorAuthorization_btnClear"), null);
            }
        }

        public void SetPayerName(string payerType)
        {
            if (!string.IsNullOrEmpty(payerType))
            {
                SelectElement assignedType = new SelectElement(ddlPayerName);
                assignedType.SelectByText(payerType);
            }
        }
        public void SetSearchPAStatus(string status)
        {
            if (!string.IsNullOrEmpty(status))
            {
                SelectElement assignedType = new SelectElement(ddlStatus);
                assignedType.SelectByText(status);
            }
        }
        public void SetAssignment(string assignmentType)
        {
            if (!string.IsNullOrEmpty(assignmentType))
            {
                SelectElement assignedType = new SelectElement(ddlAssignment);
                assignedType.SelectByText(assignmentType);
            }
        }
    }

}
