using OpenQA.Selenium;
using Selenium.BaseComponents.Data;
using Selenium.BaseComponents.Utilities;
using SeleniumExtensions.Extensions;

namespace Selenium.BaseComponents.Services
{
    /// <summary>
    /// Service for login functionality
    /// Separates login concerns from BaseFeatureFixture
    /// </summary>
    public class LoginService
    {
        private IWebDriver _webDriver;
        private readonly string _environment;

        public LoginService(IWebDriver webDriver, string environment = null)
        {
            _webDriver = webDriver;
            _environment = environment ?? Users.CurrentEnvironment;
        }

        public void SetWebDriver(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        /// <summary>
        /// Gets the login URL based on environment
        /// </summary>
        public string GetLoginUrl()
        {
            switch (_environment)
            {
                case Users.Environment.INT01P3:
                    return "https://ohpnm-dev.omes.maximus.com/OH_PNM_INT01P3/Account/Login.aspx";
                case Users.Environment.INT01:
                    return "https://ohpnm-dev.omes.maximus.com/OH_PNM_INT01/Account/Login.aspx";
                case Users.Environment.DEV01:
                    return "https://ohpnm-dev.omes.maximus.com/OH_PNM_DEV/Account/Login.aspx";
                case Users.Environment.DEV01P3:
                    return "https://ohpnm-dev.omes.maximus.com/OH_PNM_DEVP3/Account/Login.aspx";
                case Users.Environment.E2E:
                    return "https://ohpnm-e2e.omes.maximus.com/OH_PNM_E2E/Account/Login.aspx";
                case Users.Environment.E2EP3:
                    return "https://ohpnm-e2e.omes.maximus.com/OH_PNM_E2E/Account/Login.aspx";
                case Users.Environment.PROD:
                    return "https://ohpnm.omes.maximus.com/OH_PNM_PROD/Account/Login.aspx";
                default:
                    return "https://ohpnm-dev.omes.maximus.com/OH_PNM_DEV/Account/Login.aspx";
            }
        }

        /// <summary>
        /// Performs login with URL, username, and password
        /// </summary>
        public void Login(string loginUrl, string userName, string password)
        {
            try
            {
                _webDriver.Navigate().GoToUrl(loginUrl);
                _webDriver.WaitUntilDocumentIsReady(TimeSpan.FromSeconds(10));

                // Step 1: Enter username and click Next
                var userNameLocator = By.XPath("//input[@id='ctl00_MainContent_Login1_UserName']");
                var nextButtonLocator = By.XPath("//input[@id='ctl00_MainContent_Login1_btnNext']");
                
                _webDriver.WaitUntilElementIsVisible(userNameLocator, TimeSpan.FromSeconds(10));
                var userNameElement = _webDriver.FindElement(userNameLocator);
                userNameElement.Set(userName);
                
                var nextButton = _webDriver.FindElement(nextButtonLocator);
                nextButton.ClickSafe(_webDriver);

                // Step 2: Enter password and click Login (elements appear after Next click)
                var passwordLocator = By.XPath("//input[@id='ctl00_MainContent_Login1_Password']");
                var loginButtonLocator = By.XPath("//input[@id='ctl00_MainContent_Login1_LoginButton']");
                
                _webDriver.WaitUntilElementIsVisible(passwordLocator, TimeSpan.FromSeconds(10));
                var passwordElement = _webDriver.FindElement(passwordLocator);
                passwordElement.Set(password);
                
                var loginButton = _webDriver.FindElement(loginButtonLocator);
                loginButton.ClickSafe(_webDriver);

                // Step 3: Accept terms (checkbox appears after login - wait for page to load)
                var chkTermsLocator = By.XPath("//input[@id='ctl00_MainContent_chkTerms']");
                _webDriver.WaitUntilDocumentIsReady(TimeSpan.FromSeconds(10));
                _webDriver.WaitUntilElementIsVisible(chkTermsLocator, TimeSpan.FromSeconds(10));
                
                // Re-find element fresh to avoid stale reference
                var chkTerms = _webDriver.FindElement(chkTermsLocator);
                chkTerms.ClickSafe(_webDriver);

                if (_webDriver.Url.Contains("EmailVerification"))
                {
                    throw new Exception("Login requires two-factor authentication. " +
                        $"User Name: {userName}, Password: {password}. Please try running the test again.");
                }

                if (IsActive())
                {
                    ClickCancelButton();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Login failed: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Performs login with username and password (uses default URL)
        /// </summary>
        public void Login(string userName, string password)
        {
            Login(GetLoginUrl(), userName, password);
        }

        /// <summary>
        /// Checks if user is on change password page
        /// </summary>
        public bool IsActive()
        {
            return _webDriver.Url.Contains("ChangePassword");
        }

        /// <summary>
        /// Clicks cancel button on change password page
        /// </summary>
        private void ClickCancelButton()
        {
            try
            {
                var cancelButtonLocator = By.Id("cancel-button");
                _webDriver.WaitUntilElementIsVisible(cancelButtonLocator, TimeSpan.FromSeconds(5));
                var cancelButton = _webDriver.FindElement(cancelButtonLocator);
                cancelButton.ClickSafe(_webDriver);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error clicking cancel button: {e.Message}");
            }
        }

        /// <summary>
        /// Logs out of the application
        /// </summary>
        public void Logout()
        {
            var logoutLocator = By.Id("ctl00_LoginView2_lnkLogout");
            _webDriver.WaitUntilElementIsVisible(logoutLocator, TimeSpan.FromSeconds(5));
            var logoutButton = _webDriver.FindElement(logoutLocator);
            logoutButton.ClickSafe(_webDriver);
        }
    }
}
