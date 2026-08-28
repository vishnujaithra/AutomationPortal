using TC.ProviderDataEntry.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Selenium.BaseComponents.Pages;
using Selenium.BaseComponents.Utilities;
using SeleniumExtensions.Configurations;
using SeleniumExtensions.Extensions;

namespace TC.ProviderDataEntry.Pages.Registration
{
    public class Taxonomies:BasePage
    {
        IWebDriver webDriver;
        string RegID;
        public Taxonomies(IWebDriver webDriver, string RegID) : base(webDriver)
        {

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
        #region Address 1099

        public IWebElement? RegistrationTitle
        {
            get
            {
                return Selenium.BaseComponents.Utilities.PageHelper.IsElementExist(webDriver, By.Id("ctl00_MainContent_ucRegistrationNavigation_lblTitle")) ?
                    WebDriver.FindElement(By.Id("ctl00_MainContent_ucRegistrationNavigation_lblTitle")) : null;
            }
        }
        public IWebElement TaxonomyTable
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucTaxonomies_{RegID}_grdTaxonomies"), null);
            }
        }
        public IWebElement IsPrimaryTaxonomy
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucTaxonomies_{RegID}_chkIsPrimary"), null);
            }
        }

        public IWebElement Taxonomy
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucTaxonomies_{RegID}_ddlTaxonomy"), null);
            }
        }

        public IWebElement StartDate
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucTaxonomies_{RegID}_txtTaxonomyStart"), null);
            }
        }
        public IWebElement EndDate
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucTaxonomies_{RegID}_txtTaxonomyEnd"), null);
            }
        }
        public IWebElement AddTaxonomyBtn
        {
            get
            {
                return PageHelper.FindElement(webDriver, By.Id($"ctl00_MainContent_ucTaxonomies_{RegID}_btnAddTaxonomies"), null);
            }
        }
        #endregion

        public void SelectTaxonomy(string item)
        {
            SelectElement TaxonomyElementDropDown = new SelectElement(Taxonomy);
            TaxonomyElementDropDown.SelectByText(item);
        }

        public void SetTaxonomyInformation(TaxonomiesDTO info)
        {
            PageHelper.WaitUntilDocumentIsReady(webDriver, TimeoutConfiguration.Page);

            if (Convert.ToBoolean(info.IsPrimaryTaxonomy))
                IsPrimaryTaxonomy.Click();

            if (!string.IsNullOrEmpty(info.StartDate))
                StartDate.Set(info.StartDate, true);

            if (!string.IsNullOrEmpty(info.EndDate))
                EndDate.Set(info.EndDate, true);

            if (!string.IsNullOrEmpty(info.Taxonomy))
                SelectTaxonomy(info.Taxonomy);
        }
    }
}
