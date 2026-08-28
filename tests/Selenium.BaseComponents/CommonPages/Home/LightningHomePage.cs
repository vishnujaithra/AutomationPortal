using Selenium.BaseComponents.Pages;

using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using OpenQA.Selenium.Interactions;
using System.Collections.ObjectModel;
using Selenium.BaseComponents.Utilities;
using PageHelper = SdetToolbox.Pages.PageHelper;
using Dell.Adept.UI.Web.Support.Extensions.WebDriver;

namespace Selenium.BaseComponents.CommonPages.Home
{
   
    public class LightningHomePage : BasePage
    {
        public LightningHomePage(IWebDriver webDriver): base(webDriver)
        {
            this.webDriver = webDriver;
            Name = "Lightning Home Page";
            Url = this.webDriver.Url;
            this.webDriver.WaitUntilDocumentIsReady(TimeSpan.FromSeconds(PageHelper.PageTimeOut));
            Thread.Sleep(TimeSpan.FromSeconds(10));
            driver = new WebElementWrapper(webDriver);
        }

        public void SwitchToLightning()
        {
            Link_LightningExp.Click();
            webDriver.WaitUntilDocumentIsReady(TimeSpan.FromSeconds(PageHelper.PageTimeOut));
        
        
        }



        #region UI Elements

        public IWebElement _lightning_ProfileTrigger;
        public IWebElement Lightning_ProfileTrigger
        {
            get
            {
                webDriver.WaitUntilElementIsVisible(By.XPath("//*[contains(@class, 'userProfileCardTriggerRoot')]//button"), TimeSpan.FromSeconds(PageHelper.PageTimeOut));
                return webDriver.FindElement(By.XPath("//*[contains(@class, 'userProfileCardTriggerRoot')]//button"), null);
                //  return PageHelper.WaitUntilElementIsClickableAndReturn(webDriver, By.XPath("//li[@class='slds-dropdown-trigger slds-dropdown-trigger--click slds-m-left--x-small']//button"), TimeSpan.FromSeconds(15));              
            }
        }
        public IWebElement Lightning_ProfileUserName
        {
            get
            {
                webDriver.WaitUntilElementIsVisible(By.XPath("//*[@class='profile-card-name']/a[@class='profile-link-label']"), TimeSpan.FromSeconds(PageHelper.PageTimeOut));
                return webDriver.FindElement(By.XPath("//*[@class='profile-card-name']/a[@class='profile-link-label']"), null);
            }
        }
        public IWebElement _lightning_SwitchToClassic;
        public IWebElement Lightning_SwitchToClassic
        {
            get
            {
                if (_lightning_SwitchToClassic == null)
                    _lightning_SwitchToClassic = webDriver.FindElement(By.XPath("//a[@class='profile-link-label switch-to-aloha uiOutputURL'][normalize-space(text()='Switch to Salesforce Classic')]"), null);
                return _lightning_SwitchToClassic;
            }
        }

        public IWebElement _lightning_edit_button;
        public IWebElement Lightning_Edit_Button
        {
            get
            {
                if (_lightning_edit_button == null)
                    _lightning_edit_button = webDriver.FindElement(By.XPath("//a[contains(@title, 'Edit')]"), null);
                return _lightning_edit_button;
            }
        }

        public IWebElement _account_planning_contact_checkBox;
        public IWebElement Account_Planning_Contact_Check_Box
        {
            get
            {
                if (_account_planning_contact_checkBox == null)
                    _account_planning_contact_checkBox = webDriver.FindElement(By.XPath("//span[text()='Account Planning Contact']/../following::input[1]"), null);
                return _account_planning_contact_checkBox;
            }
        }

        public IWebElement _logOut_button;
        public IWebElement Logout_Button
        {
            get
            {
                if (_logOut_button == null)
                    _logOut_button = webDriver.FindElement(By.XPath("//a[text()='Log Out']"), null);
                return _logOut_button;
            }
        }


        public IWebElement Lightning_Logout_Button_Element;
        public IWebElement Lightning_Logout_Button
        {
            get
            {
                if (Lightning_Logout_Button_Element == null)
                    Lightning_Logout_Button_Element = webDriver.FindElement(By.XPath("//a[text()='Log Out'] | //a[contains(text(),'logout')]"), null);
                return Lightning_Logout_Button_Element;
            }
        }

        // Added by Basker Subramaniyan

        private IWebElement _lnk_CodeOfConduct;
        public IWebElement Lightning_link_CodeOfConduct
        {
            get
            {
                if (_lnk_CodeOfConduct == null)

                    _lnk_CodeOfConduct = driver.getElement("xpath", "//em[text()='Code of Conduct']/ancestor::a");
                return _lnk_CodeOfConduct;
            }
        }




        private IWebElement _pageCodeOfConduct;
        public IWebElement CodeOfConductTitle
        {
            get
            {
                if (_pageCodeOfConduct == null)
                    _pageCodeOfConduct = driver.getElement("xpath", "//h2[text()='Global Ethics & Compliance']");
                return _pageCodeOfConduct;
            }
        }

        private IWebElement _tipsForMonthTitle;
        public IWebElement TipsContent_1
        {
            get
            {
                if (_tipsForMonthTitle == null)
                    _tipsForMonthTitle = driver.getElement("xpath", "//span[text()='Tip For The Month!']");
                return _tipsForMonthTitle;
            }
        }

        private IWebElement _tipsForMonthInNewsSection;
        public IWebElement TipsContent_NewsSection
        {
            get
            {
                if (_tipsForMonthInNewsSection == null)
                    _tipsForMonthInNewsSection = driver.getElement("xpath", "//span[text()='News' and @title]");
                return _tipsForMonthInNewsSection;
            }
        }




        private IWebElement _tipsForMonthInEventSection;
        public IWebElement TipsContentEventSection
        {
            get
            {
                if (_tipsForMonthInEventSection == null)
                    _tipsForMonthInEventSection = driver.getElement("xpath", "//span[contains(text(),'Events') and @title]");
                return _tipsForMonthInEventSection;
            }
        }


        private IWebElement _tipsForMonthInTasksSection;
        public IWebElement TipsContentTaskSection
        {
            get
            {
                if (_tipsForMonthInTasksSection == null)
                    _tipsForMonthInTasksSection = driver.getElement("xpath", "//span[contains(text(),'Tasks') and @title]");
                return _tipsForMonthInTasksSection;
            }
        }

        private IWebElement _tipsForMonthInItemsToApproveSection;
        public IWebElement TipsContentItemsToApproveSection
        {
            get
            {
                if (_tipsForMonthInItemsToApproveSection == null)
                    _tipsForMonthInItemsToApproveSection = driver.getElement("xpath", "//span[contains(text(),'Items to Approve') and @title]");
                return _tipsForMonthInItemsToApproveSection;
            }
        }

        private IWebElement _tipsForMonthContent;
        public IWebElement TipsContent_2
        {
            get
            {
                if (_tipsForMonthContent == null)
                    _tipsForMonthContent = driver.getElement("xpath", " //span[text()='Dell Main SFDC has just gotten better ']");
                return _tipsForMonthContent;
            }
        }


        private IWebElement _sideBarLink;
        public IWebElement SideBarAppLink(String linkText)
        {
            //_sideBarLink = driver.getElement("xpath","//a[contains(@class, 'app-launcher')]//span[text()='" + linkText +"']");
            _sideBarLink = webDriver.FindElement(By.XPath("//ul//*[text()='" + linkText + "']"));
            return _sideBarLink;
        }

        private IWebElement _cSTLText;
        public IWebElement CSTLHeading
        {
            get
            {
                if (_cSTLText == null)
                    _cSTLText = driver.getElement("xpath", "//div[text()='Catalog Sales Tool Portal']");
                return _cSTLText;
            }

        }



        private IWebElement _GlobalBMS;
        public IWebElement GlobalBusinessManagementSystem
        {
            get
            {
                if (_GlobalBMS == null)
                    _GlobalBMS = driver.getElement("xpath", "//p[text()='BMS']");
                return _GlobalBMS;
            }

        }



        private IWebElement _DellGiftShop;
        public IWebElement DellGiftShop
        {
            get
            {
                if (_DellGiftShop == null)
                    _DellGiftShop = driver.getElement("xpath", "//td[text()='BMS']");
                return _DellGiftShop;
            }

        }

        private IWebElement _DellLogo;
        public IWebElement DellLogoGiftShop
        {
            get
            {
                if (_DellLogo == null)
                    _DellLogo = driver.getElement("xpath", "//a[@id='logo']");
                return _DellLogo;
            }

        }

        private IWebElement _GlobalAccountManagementSystem;
        public IWebElement GlobalAccountManagementSystem
        {
            get
            {
                if (_GlobalAccountManagementSystem == null)
                    _GlobalAccountManagementSystem = driver.getElement("xpath", "//span[text()='Global Account Management and Assignments']");
                return _GlobalAccountManagementSystem;
            }
        }

        private IWebElement _CustomerProgramApp;
        public IWebElement CustomerProgramApplication
        {
            get
            {
                if (_CustomerProgramApp == null)
                    _CustomerProgramApp = driver.getElement("xpath", "//a[text()='Customer Programs']");
                return _CustomerProgramApp;
            }
        }


        private IWebElement _GlobalSalesLearningAndDevelopementApp;
        public IWebElement GlobalSalesLearningDevelopment
        {
            get
            {
                if (_GlobalSalesLearningAndDevelopementApp == null)
                    _GlobalSalesLearningAndDevelopementApp = driver.getElement("xpath", "//a[text()='Global Sales Learning & Development' and @id]");
                return _GlobalSalesLearningAndDevelopementApp;
            }
        }



        private IWebElement _GlobalSalesOperations;
        public IWebElement GlobalSalesOperations
        {
            get
            {
                if (_GlobalSalesOperations == null)
                    _GlobalSalesOperations = driver.getElement("xpath", "//img[@id='gso-header-logo']");
                return _GlobalSalesOperations;
            }
        }

        private IWebElement _HelpCustomer;
        public IWebElement HelpCustomer
        {
            get
            {
                if (_HelpCustomer == null)
                    _HelpCustomer = driver.getElement("xpath", "//strong[text()=' Help A Customer | HAC']");
                return _HelpCustomer;
            }
        }


        private IWebElement _onsiteToolsApp;
        public IWebElement OnsiteTools
        {
            get
            {
                if (_onsiteToolsApp == null)
                    _onsiteToolsApp = driver.getElement("id", "Lbl_Heading");
                return _onsiteToolsApp;
            }
        }


        private IWebElement _serviceNavigatorApp;
        public IWebElement ServiceNavigator

        {
            get
            {
                if (_serviceNavigatorApp == null)
                    _serviceNavigatorApp = driver.getElement("xpath", "//h1[text()='Services Navigator']");
                return _serviceNavigatorApp;
            }
        }

        private IWebElement _recentOpportunities;
        public IWebElement RecentOpportunities
        {
            get
            {
                if (_recentOpportunities == null)
                    _recentOpportunities = driver.getElement("xpath", "//div[contains(@class,'flexipageRecentItemStencil forceRecordLayout')]");
                return _recentOpportunities;
            }
        }

        private IWebElement _clickAddbutton;
        public IWebElement ClickAddBut
        {
            get
            {
                if (_clickAddbutton == null)
                    _clickAddbutton = webDriver.FindElement(By.XPath("//*[name()='svg' and @data-key='add']"));
                return _clickAddbutton;
            }
        }

        private IWebElement _clickConsentScript;
        public IWebElement ClickConsentScrpt
        {
            get
            {
                if (_clickConsentScript == null)
                    _clickConsentScript = webDriver.FindElement(By.XPath("//div[@class='globalCreateMenuList']/ul//span[text()='Consent Script']"));
                return _clickConsentScript;
            }
        }

        public IWebElement Link_LightningExp
        {
            get
            {
                webDriver.WaitUntilElementIsVisible(By.XPath("//div[@class='linkElements']/a[text()='Switch to Lightning Experience' or @class='switch-to-lightning']"), TimeSpan.FromSeconds(PageHelper.PageTimeOut));
                return webDriver.FindElement(By.XPath("//div[@class='linkElements']/a[text()='Switch to Lightning Experience' or @class='switch-to-lightning']"), null);
            }
        }

        public IWebElement _userNav;
        public IWebElement UserNav
        {
            get
            {
                if (_userNav == null)
                    _userNav = webDriver.FindElement(By.XPath("//div[contains(@id, 'userNav')]"));
                return _userNav;
            }
        }

        public IWebElement __SwitchTolightning;
        public IWebElement SwitchTolightning
        {
            get
            {
                if (__SwitchTolightning == null)
                    __SwitchTolightning = webDriver.FindElement(By.XPath("//div[@id='userNavMenu']/div[@class='mbrMenuItems']/a[@title='Switch to Lightning Experience']"), null);
                return __SwitchTolightning;
            }
        }
        public IWebElement Button_AppLauncher
        {
            get
            {
                var wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(15));
                return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//div[@class='slds-icon-waffle']")));/*//div[@class='bBottom']//button[@class='slds-button'] */
                //return PageHelper.WaitUntilElementIsClickableAndReturn(webDriver, By.XPath("//div[@class='bBottom']//button[@class='slds-button']"), TimeSpan.FromSeconds(15));
            }
        }
        public IWebElement Button_ViewAll
        {
            get
            {
                var wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(15));
                return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//button[text()='View All']")));
                //return PageHelper.WaitUntilElementIsClickableAndReturn(webDriver, By.XPath("//div[@class='bBottom']//button[@class='slds-button']"), TimeSpan.FromSeconds(15));
            }
        }
        public IWebElement AppLauncher_Opportunities
        {
            get
            {
                return webDriver.FindElement(By.XPath("//div[contains(@class,'slds-modal__content')]//span[text()='Opportunities']"), null);
            }
        }

        public IWebElement Contacts_Link
        {
            get
            {
                return webDriver.FindElement(By.XPath("//a[@title='Contacts']"), null);
            }
        }




        private IWebElement helpIcon;
        public IWebElement HelpIcon
        {
            get
            {
                if (helpIcon == null)
                    helpIcon = webDriver.FindElement(By.XPath("//span[text()='Salesforce Help']//ancestor::button"));
                return helpIcon;
            }
        }

        private IWebElement exploreSFDCResourceCenter;
        public IWebElement ExploreSFDCResourceCenter
        {
            get
            {
                exploreSFDCResourceCenter = null;
                if (exploreSFDCResourceCenter == null)
                    exploreSFDCResourceCenter = webDriver.FindElement(By.XPath("//span[@title='Explore SFDC Resource Center']"));
                return exploreSFDCResourceCenter;
            }
        }

        public void VerifyResourceCenter()
        {

            string Currenthandle = webDriver.CurrentWindowHandle;
            List<String> tabs2 = new List<String>(webDriver.WindowHandles);
            foreach (String handles in tabs2)
            {
                if (handles != Currenthandle)
                {
                    webDriver.SwitchTo().Window(handles);
                    break;
                }
            }

            bool status = webDriver.ElementExists(By.XPath("//a[text()='Confirm']"));
            if (status)
            {
                webDriver.FindElement(By.XPath("//a[text()='Confirm']")).Click();
            }

            var URL = webDriver.Url;
            Assert.IsTrue(URL.Equals("https://it.one.dell.com/sites/SFDCResourceCentre/Home.html"), "SFDC Resource Center url is mismatched");
        }

        private IWebElement personalizeNavBar;
        public IWebElement PersonalizeNavBar
        {
            get
            {
                if (personalizeNavBar == null)
                    personalizeNavBar = webDriver.FindElement(By.XPath("//button[@title='Personalize your nav bar']"));
                return personalizeNavBar;
            }
        }

        private IWebElement resetNavigationDefault;
        public IWebElement ResetNavigationDefault
        {
            get
            {
                resetNavigationDefault = null;
                if (resetNavigationDefault == null)
                    resetNavigationDefault = webDriver.FindElement(By.XPath("//*[text()='Reset Navigation to Default']"));
                return resetNavigationDefault;
            }
        }

        private IWebElement resetNavigationDefaultSave;
        public IWebElement ResetNavigationDefaultSave
        {
            get
            {
                resetNavigationDefaultSave = null;
                if (resetNavigationDefaultSave == null)
                    resetNavigationDefaultSave = webDriver.FindElement(By.XPath("(//span[text()='Save']/parent::button)[2]"));
                return resetNavigationDefaultSave;
            }
        }

        private IWebElement resetNavigationDefaultCancel;
        public IWebElement ResetNavigationDefaultCancel
        {
            get
            {
                resetNavigationDefaultCancel = null;
                if (resetNavigationDefaultCancel == null)
                    resetNavigationDefaultCancel = webDriver.FindElement(By.XPath("(//span[text()='Cancel']/parent::button)[2]"));
                return resetNavigationDefaultCancel;
            }
        }

        public int NavBarCount()
        {
            int navBarCount = webDriver.FindElements(By.XPath("//div[contains(@class,'truncate navUL')]/one-app-nav-bar-item-root")).Count;
            Assert.IsTrue(navBarCount == 6, "Default Navbar Count is mismatched");
            return navBarCount;
        }

        private IWebElement navBarTabName;
        public String NavBarTabName(int tagno)
        {
            navBarTabName = null;
            if (navBarTabName == null)
                navBarTabName = webDriver.FindElement(By.XPath("(//div[contains(@class,'truncate navUL')]/one-app-nav-bar-item-root/a)[" + tagno + "]"));
            return navBarTabName.GetAttribute("title");
        }

        public IWebElement topTenOpportunities;
        public IWebElement TopTenOpportunities
        {
            get
            {
                topTenOpportunities = null;
                Utilities.PageHelper.WaitUntilElementIsVisible(WebDriver, By.XPath("//div[@data-component-id='flexipage_filterListCard']//following::div[@data-component-id='Carousel']"), TimeSpan.FromSeconds(PageHelper.PageTimeOut));
                if (topTenOpportunities == null)
                    topTenOpportunities = webDriver.FindElement(By.XPath("//div[@data-component-id='flexipage_filterListCard']//following::div[@data-component-id='Carousel']"));
                return topTenOpportunities;
            }
        }

        private IWebElement appLauncher_button;
        public IWebElement AppLauncher_button
        {
            get
            {
                appLauncher_button = null;
                Utilities.PageHelper.WaitUntilElementIsVisible(WebDriver, By.XPath("//span[text()='App Launcher']/ancestor::button"), TimeSpan.FromSeconds(PageHelper.PageTimeOut));
                if (appLauncher_button == null)
                    appLauncher_button = webDriver.FindElement(By.XPath("//span[text()='App Launcher']/ancestor::button"));
                return appLauncher_button;
            }
        }

        private IWebElement searchAppsorItems;
        public IWebElement SearchAppsorItems
        {
            get
            {
                searchAppsorItems = null;
                Utilities.PageHelper.WaitUntilElementIsVisible(WebDriver, By.XPath("//*[@class='al-menu-search-bar']//input"), TimeSpan.FromSeconds(PageHelper.PageTimeOut));
                if (searchAppsorItems == null)
                    searchAppsorItems = webDriver.FindElement(By.XPath("//*[@class='al-menu-search-bar']//input"));
                return searchAppsorItems;
            }
        }

        private IWebElement viewAllButton;
        public IWebElement ViewAllButton
        {
            get
            {
                viewAllButton = null;
                Utilities.PageHelper.WaitUntilElementIsVisible(WebDriver, By.XPath("//button[text()='View All']"), TimeSpan.FromSeconds(PageHelper.PageTimeOut));
                if (viewAllButton == null)
                    viewAllButton = webDriver.FindElement(By.XPath("//button[text()='View All']"));
                return viewAllButton;
            }
        }

      /*  private IWebElement navigateToApps;
        public IWebElement NavigateToApps(String AppName)
        {
            AppLauncher_button.Click();
            Thread.Sleep(5000);
            ViewAllButton.Click();
            Thread.Sleep(5000);
            //AppName = AppName.ToLower();
            navigateToApps = null;
            //Utilities.PageHelper.WaitUntilElementIsVisible(WebDriver, By.XPath("//div[@data-name='" + AppName + "']//a"), TimeSpan.FromSeconds(PageHelper.PageTimeOut));
            if (navigateToApps == null)
                navigateToApps = webDriver.FindElement(By.XPath("//div[@data-name='" + AppName + "']//a"));
            LightningOpportunityDetailsPage _LightningOpportunityDetailsPage = new LightningOpportunityDetailsPage(webDriver);
            _LightningOpportunityDetailsPage.ClickAsyncJS(navigateToApps);
            Thread.Sleep(10000);
            return navigateToApps;
        } */

        private IWebElement Link_RMA_Tracking(bool correctPage)
        {
            int index = 1;
            if (!correctPage)
            {
                index = 2;
            }
            return webDriver.FindElement(By.XPath("(//a[contains(@class, 'app-launcher')]//span[text()='RMA Tracking'])[" + index + "]"));
        }


        public IWebElement homePageRelatedItems;
        public IWebElement HomePageRelatedItems
        {
            get
            {
                homePageRelatedItems = null;
                webDriver.WaitUntilElementIsVisible(By.XPath("//div[contains(@class,'oneUtilityBarItem')]//span[text()='Recent Items']"), TimeSpan.FromSeconds(PageHelper.PageTimeOut));
                if (homePageRelatedItems == null)
                    homePageRelatedItems = webDriver.FindElement(By.XPath("//div[contains(@class,'oneUtilityBarItem')]//span[text()='Recent Items']"));
                return homePageRelatedItems;
            }
        }

        public IWebElement homePageNotesItems;
        public IWebElement HomePageNotesItems
        {
            get
            {
                homePageNotesItems = null;
                webDriver.WaitUntilElementIsVisible(By.XPath("//div[contains(@class,'oneUtilityBarItem')]//span[text()='Notes']"), TimeSpan.FromSeconds(PageHelper.PageTimeOut));
                if (homePageNotesItems == null)
                    homePageNotesItems = webDriver.FindElement(By.XPath("//div[contains(@class,'oneUtilityBarItem')]//span[text()='Notes']"));
                return homePageNotesItems;
            }
        }

        public IWebElement homePageSalesToolItems;
        public IWebElement HomePageSalesToolItems
        {
            get
            {
                homePageSalesToolItems = null;
                webDriver.WaitUntilElementIsVisible(By.XPath("//div[contains(@class,'oneUtilityBarItem')]//span[text()='Sales Tools']"), TimeSpan.FromSeconds(PageHelper.PageTimeOut));
                if (homePageSalesToolItems == null)
                    homePageSalesToolItems = webDriver.FindElement(By.XPath("//div[contains(@class,'oneUtilityBarItem')]//span[text()='Sales Tools']"));
                return homePageSalesToolItems;
            }
        }

        private IWebElement navigateToTabs;
        public IWebElement NavigateToTabs(String TabName)
        {
            AppLauncher_button.Click();
            navigateToTabs = null;
            Utilities.PageHelper.WaitUntilElementIsVisible(WebDriver, By.XPath("//input[@placeholder='Search apps and items...']"), TimeSpan.FromSeconds(PageHelper.PageTimeOut));
            webDriver.FindElement(By.XPath("//input[@placeholder='Search apps and items...']")).SendKeys(TabName);
            Utilities.PageHelper.WaitUntilElementIsVisible(WebDriver, By.XPath("//a[@role='option']//p"), TimeSpan.FromSeconds(PageHelper.PageTimeOut));
            var options = webDriver.FindElements(By.XPath("//a[@role='option']//p"));
            bool found = false;
            foreach (var listItem in options)
            {
                if (listItem.Text.ToLower().Equals(TabName.ToLower()))
                {
                    found = true;
                    listItem.Click();
                    break;
                }
            }
            Thread.Sleep(10000);
            Assert.IsTrue(found, TabName + " doesn't exists");
            return navigateToTabs;
        }

        public IWebElement prodadv;
        public IWebElement Prodadv()
        {
            prodadv = null;
            try
            {
                Utilities.PageHelper.WaitUntilElementIsVisible(WebDriver, By.XPath("//*[text()='Close']"), TimeSpan.FromSeconds(PageHelper.PageTimeOut));
                if (prodadv == null)
                    prodadv = webDriver.FindElement(By.XPath("//*[text()='Close']"));
                return prodadv;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return prodadv;
            }
        }

        public IWebElement Field_SearchSalesforce
        {
            get
            {
                return webDriver.FindElement(By.XPath("//input[contains(@title,'Search')]"));
            }
        }

        public IWebElement Link_SearchedTerm(string term)
        {
            return webDriver.WaitUntilElementIsVisibleAndReturn(By.XPath(string.Format("//div[contains(@class,'forceSearchResultsRegion')]/descendant::a[text()='{0}']", term)), TimeSpan.FromSeconds(5));
        }


        private IWebElement _globalStandardLinks;
        public IWebElement GlobalStandardLinks(String GlobalStndrdlink)
        {
            return _globalStandardLinks = webDriver.FindElement(By.XPath("//h2[text()='Global Standard Links']/parent::div/parent::div/following-sibling::div//li/a[@title = '" + GlobalStndrdlink + "']"));
        }

        private IWebElement _globalStandardLink;
        public IWebElement GlobalStandardLink(String GlobalStndrdlink)
        {
            _globalStandardLink = webDriver.FindElement(By.XPath("//h2[text()='Global Standard Links']/parent::div/ul//li/a[text()='" + GlobalStndrdlink + "']"));
            return _globalStandardLink;
        }

        private IWebElement _searchByObject;
        public IWebElement SearchByObject
        {
            get
            {
                _searchByObject = webDriver.FindElement(By.XPath("//div[@data-aura-class='forceSearchInputEntitySelector']"), TimeSpan.FromSeconds(30));
                return _searchByObject;
            }
        }

        private IWebElement _selectSearchObject;
        public IWebElement SelectSearchByObject(String objectName)
        {
            By locator = By.XPath("//div/ul[@aria-label='All Searchable Items']/li/lightning-base-combobox-item[contains(@data-value,'" + objectName + "')]/parent::li");
            _selectSearchObject = webDriver.FindElement(locator, TimeSpan.FromSeconds(30));
            return _selectSearchObject;

            //div/ul[@aria-label='All Searchable Items']/li/lightning-base-combobox-item[@data-value='ALL:Contact:Contacts']/parent::li
            //div/ul[@aria-label='All Searchable Items']/li/lightning-base-combobox-item/span/span[text()='" + objectName + "']/parent::span
        }

        private IWebElement _searchBox;
        public IWebElement SearchInputBox
        {
            get
            {
                _searchBox = webDriver.FindElement(By.XPath("//div/div/input[@placeholder='Search...']"), TimeSpan.FromSeconds(30));
                return _searchBox;
            }
        }

        public IWebElement _searchResult;
        public IWebElement SelectSearchResult
        {
            get
            {
                _searchBox = webDriver.FindElement(By.XPath("//li/a/div[2]"), TimeSpan.FromSeconds(30));
                return _searchBox;
            }
        }

        public IWebElement _lightning_UserLink;
        private IWebDriver webDriver;
        private WebElementWrapper driver;

        public IWebElement lightning_UserLink
        {
            get
            {
                if (_lightning_UserLink == null)
                    _lightning_UserLink = webDriver.FindElement(By.XPath("(//a[@class='profile-link-label'][normalize-space(text()='Lightning Test IT TA')])[1]"), null);
                return _lightning_UserLink;
            }
        }

        #endregion
    }
}
