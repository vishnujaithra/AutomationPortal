using TC.ProviderDataEntry.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Selenium.BaseComponents.Pages;
using SeleniumExtensions.Configurations;
using SeleniumExtensions.Extensions;
using static SeleniumExtras.WaitHelpers.ExpectedConditions;
using PageHelper = SdetToolbox.Pages.PageHelper;

namespace TC.ProviderDataEntry.Pages.Registration
{
    public class NewProviderPage : BasePage
    {
        public NewProviderPage(IWebDriver webDriver) : base(webDriver)
        {

        }

        public IWebElement NewProviderBtn()
        {
            By locator = By.XPath("//button[@id='ctl00_MainContent_divNewProvider']");
            ElementWait.Until(ElementExists(locator));
            return WebDriver.FindElement(locator);
        }

        public IWebElement StandardType()
        {
            By locator = By.XPath("//button[@id='ctl00_MainContent_rptApplication_ctl00_SelectAppType']");
            ElementWait.Until(ElementExists(locator));
            return WebDriver.FindElement(locator);
        }

        public IWebElement IndividualType()
        {
            By locator = By.XPath("//button[@id='ctl00_MainContent_rptCategory_ctl00_btnCat']");
            ElementWait.Until(ElementExists(locator));
            return WebDriver.FindElement(locator);
        }

        public bool isNewProviderloaded()
        {
            By locator = By.XPath("//*[@id='ctl00_MainContent_div10DayMessage']");
            ElementWait.Until(ElementExists(locator));
            return PageHelper.IsElementExist(WebDriver, locator) ? true : false;
        }

        #region New provider Information

        public IWebElement Firstname
        {
            get
            {
                return WebDriver.FindElement(By.Id("ctl00_MainContent_txtFirstName"));
            }
        }

        public IWebElement MiddleName
        {
            get
            {
                return WebDriver.FindElement(By.Id("ctl00_MainContent_txtMI"));
            }
        }


        public IWebElement LastName
        {
            get
            {
                return WebDriver.FindElement(By.Id("ctl00_MainContent_txtLastName"));
            }
        }


        public IWebElement TaxID
        {
            get
            {
                return WebDriver.FindElement(By.Id("ctl00_MainContent_txtTaxID"));
            }
        }

        public IWebElement NPI
        {
            get
            {
                return WebDriver.FindElement(By.Id("ctl00_MainContent_txtNPI"));
            }
        }

        public IWebElement DateofBirth
        {
            get
            {
                return WebDriver.FindElement(By.Id("ctl00_MainContent_txtBirthDate"));
            }
        }

        public IWebElement ZipCode
        {
            get
            {
                return WebDriver.FindElement(By.Id("ctl00_MainContent_txtZipCode"));
            }
        }

        public IWebElement ZipCodeExtension
        {
            get
            {
                return WebDriver.FindElement(By.Id("ctl00_MainContent_txtZipCodeExt"));
            }
        }

        public IWebElement ProviderType
        {
            get
            {
                return WebDriver.FindElement(By.XPath("//*[@id='ctl00_MainContent_ddlProviderType']"));
            }
        }

        public IWebElement Taxonomy
        {
            get
            {
                return WebDriver.FindElement(By.Id("ctl00_MainContent_ddlTaxonomyNPPES"));
            }
        }

        public IWebElement ProviderSavebtn
        {
            get
            {
                return WebDriver.FindElement(By.Id("ctl00_MainContent_btnSave"));
            }
        }


        public IWebElement Gender(string gender)
        {
            switch (gender)
            {
                case "Female":
                    return WebDriver.FindElement(By.XPath("//*[@id=\"ctl00_MainContent_ddlGender\"]/option[2]"));
                    break;
                case "Male":
                    return WebDriver.FindElement(By.XPath("//*[@id=\"ctl00_MainContent_ddlGender\"]/option[3]"));
                    break;
                case "unknown":
                    return WebDriver.FindElement(By.XPath("//*[@id=\"ctl00_MainContent_ddlGender\"]/option[4]"));
                    break;
                case "Undisclosed":
                    return WebDriver.FindElement(By.XPath("//*[@id=\"ctl00_MainContent_ddlGender\"]/option[5]"));
                    break;
                case "Unspecified":
                    return WebDriver.FindElement(By.XPath("//*[@id=\"ctl00_MainContent_ddlGender\"]/option[2]"));
                    break;
            }
            return null;
        }

        public void WaitUntilTaxonomyVisible()
        {
            PageHelper.WaitUntilElementIsVisible(WebDriver, By.Id("ctl00_MainContent_ddlTaxonomyNPPES"), TimeoutConfiguration.Element);
        }

        public void WaitUntilLoaderDisappear()
        {
            PageHelper.WaitUntilElementNotAvailable(WebDriver, By.Id("ctl00_MainContent_imgSaving"), TimeoutConfiguration.Element);
        }

        public void WaitUntilImgProgressDisappear()
        {
            PageHelper.WaitUntilElementNotAvailable(WebDriver, By.Id("imgProgress"), TimeoutConfiguration.Element);
        }


        public void SetProviderType(string item)
        {
            SelectElement PracticeTypeElementDropDown = new SelectElement(ProviderType);
            PracticeTypeElementDropDown.SelectByValue("64");
        }

        public void SetTaxonomy(string item)
        {
            SelectElement PracticeTypeElementDropDown = new SelectElement(Taxonomy);
            PracticeTypeElementDropDown.SelectByIndex(Convert.ToInt16(item));
        }

        #endregion

        public void SetNewProviderPage(NewProviderDTO info)
        {

            SetProviderType(info.ProviderType);

            Thread.Sleep(2000);

            if (!string.IsNullOrEmpty(info.FirstName))
                Firstname.Set(info.FirstName, true);

            if (!string.IsNullOrEmpty(info.MiddleName))
                MiddleName.Set(info.MiddleName, true);

            if (!string.IsNullOrEmpty(info.LastName))
                LastName.Set(info.LastName, true);

            if (!string.IsNullOrEmpty(info.TaxID))
                TaxID.Set(info.TaxID, true);

            if (!string.IsNullOrEmpty(info.NPI))
                NPI.Set(info.NPI, true);

            Gender(info.Gender).Click();
            Thread.Sleep(3000);

            if (!string.IsNullOrEmpty(info.DateofBirth))
                DateofBirth.Set(info.DateofBirth, true);

            if (!string.IsNullOrEmpty(info.Zipcode))
            {
                if (PageHelper.IsElementExist(WebDriver, By.Id("ctl00_MainContent_txtZipCode")))
                {
                    ZipCode.Set(info.Zipcode, true);
                }
            }

            //if (!string.IsNullOrEmpty(info.ZipcodeExt))
            //{
            //    if (PageHelper.IsElementExist(WebDriver, By.Id("ctl00_MainContent_txtZipCodeExt")))
            //    {
            //        ZipCodeExtension.Set(info.ZipcodeExt, true);
            //    }
            //}


            //if (!string.IsNullOrEmpty(info.ZipcodeExt))
            //    ZipCodeExtension.Set(info.ZipcodeExt, true);

            if (!string.IsNullOrEmpty(info.FirstName))
                Firstname.Set(info.FirstName, true);

        }

    }
}
