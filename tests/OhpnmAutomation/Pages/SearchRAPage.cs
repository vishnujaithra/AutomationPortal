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
    public class SearchRAPage : BasePage
    {
        IWebDriver webDriver;
        public SearchRAPage(IWebDriver webDriver) : base(webDriver)
        {
            this.webDriver = webDriver;
            string url = this.webDriver.Url;
        }

        public IWebElement lnkBtnSearchRA
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.XPath($"//span[text()='Search-RA']"), null);
            }
        }
        public void WaitUntilElementIsVisible()
        {
            PageHelper.WaitUntilElementIsVisible(webDriver, By.XPath("//*[@id='ctl00_MainContent_ERemittanceAdvice_sepInstructions']"), TimeoutConfiguration.Element);
        }
        public IWebElement ddlPrimaryDestinationPayer
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id("ctl00_MainContent_ERemittanceAdvice_ddlPrimaryDestinationPayer"), null);
            }
        }

        public IWebElement txtRANumber
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id("ctl00_MainContent_ERemittanceAdvice_txtRANumber"), null);
            }
        }
        public IWebElement txtICN
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id("ctl00_MainContent_ERemittanceAdvice_txtICN"), null);
            }
        }
        public IWebElement txtDateAvailableFrom
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id("ctl00_MainContent_ERemittanceAdvice_txtDateAvailableFrom"), null);
            }
        }
        public IWebElement txtDateAvailableTo
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id("ctl00_MainContent_ERemittanceAdvice_txtDateAvailableTo"), null);
            }
        }
        public IWebElement btnSearch
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id("ctl00_MainContent_ERemittanceAdvice_btnSearch"), null);
            }
        }
        public IWebElement btnClear
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id("ctl00_MainContent_ERemittanceAdvice_btnClear"), null);
            }
        }

        public void SetPrimaryDestinationPayer(string payerType)
        {
            if (!string.IsNullOrEmpty(payerType))
            {
                SelectElement assignedType = new SelectElement(ddlPrimaryDestinationPayer);
                assignedType.SelectByText(payerType);
            }
        }


    }

}
