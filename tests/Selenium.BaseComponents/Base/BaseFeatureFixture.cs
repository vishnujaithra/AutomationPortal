using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using Selenium.BaseComponents.CommonPages;
using Selenium.BaseComponents.Utilities;
using System.IO;
using System.Reflection;
using Selenium.BaseComponents.Data;
using SeleniumExtensions.Extensions;
using NUnit.Framework.Internal;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
//using OpenQA.Selenium.DevTools.V117.Page;
using OpenQA.Selenium.Support.UI;
using SeleniumExtensions.Configurations;
using OpenQA.Selenium.Edge;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;


namespace Selenium.BaseComponents.Pages
{
    //[Parallelizable]
    public abstract class BaseFeatureFixture : ILoginPage
    {
        

        public IWebDriver TestWebDriver;
        private IWebElement _userName;
        private IWebElement _password;
        private IWebElement _loginButton;
        private string Username;
        private string pswd;
        private string environment = Users.CurrentEnvironment;


        //  public TestContext TestContext { get; set; }


        public IWebElement UserName
        {
            get
            {
                return TestWebDriver.FindElement(By.XPath("//input[@id='ctl00_MainContent_Login1_UserName']"));
            }
        }

        public IWebElement Password
        {
            get
            {
                return TestWebDriver.FindElement(By.XPath("//input[@id='ctl00_MainContent_Login1_Password']"));
            }

        }


        public IWebElement ChkLoginTerms
        {
            get
            {
                return TestWebDriver.FindElement(By.XPath("//input[@id='ctl00_MainContent_chkTerms']"));
            }

        }

        public IWebElement NextButton
        {
            get
            {
                return TestWebDriver.FindElement(By.XPath("//input[@id='ctl00_MainContent_Login1_btnNext']"));
            }

        }

        public IWebElement LogOutButton
        {
            get
            {
                return TestWebDriver.FindElement(By.Id("ctl00_LoginView2_lnkLogout"));
            }

        }

        public IWebElement LoginButton
        {
            get
            {
                return TestWebDriver.FindElement(By.XPath("//input[@id='ctl00_MainContent_Login1_LoginButton']"));
            }

        }
        public string Url
        {
            get
            {
                switch (environment)
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
        }

        public BaseFeatureFixture(string username = null, string password = null)
        {
            Username = username;
            pswd = password;
        }

        public BaseFeatureFixture(string profile = null)
        {
            if (profile != null)
            {
                Username = UserCredentials.UserNameGenerator.GetUserName(profile, environment);
                pswd = UserCredentials.PasswordGenerator.GetPassword(environment);
            }
        }


        [SetUp]
        public void BeforeEachTest()
        {

        }

        [OneTimeSetUp]
        public virtual void InitializeTestSuite()
        {

            var queueId = TestContext.Parameters["queueId"];

            if (queueId != null)
            {
                APIGatway aPIGatway = new APIGatway();
                bool status = aPIGatway.UpdateQueue(queueId, "InProgress").Result;
            }

            InitializeChromeAndLogin();
        }

        private void InitializeChromeAndLogin()
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--disable-notifications");
            chromeOptions.AddArguments("start-maximized");
            chromeOptions.AddArguments("--disable-extensions");
            chromeOptions.AddArguments("no-sandbox");
            chromeOptions.AddArguments("--ignore-certificate-errors");
            //chromeOptions.AddArguments("--incognito");
            // chromeOptions.AddArgument("--headless");
            if (Environment.GetEnvironmentVariable("AGENT_MACHINENAME") != null)
            {
                chromeOptions.AddArgument("--headless");
            }


            TestWebDriver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), chromeOptions, TimeSpan.FromMinutes(5));

            if (Username != null)
            {
                Login(Url, Username, pswd);//, WebOptions.LoginUrl
            }
        }

        private void InitializeEdgeAndLogin()
        {
            // Initialize EdgeOptions
            EdgeOptions edgeOptions = new EdgeOptions();
            edgeOptions.AddArgument("--disable-notifications");
            edgeOptions.AddArgument("start-maximized");
            edgeOptions.AddArgument("--disable-extensions");
            edgeOptions.AddArgument("no-sandbox");
            edgeOptions.AddArgument("--ignore-certificate-errors");
            //edgeOptions.AddArgument("--headless");

            // Conditional headless mode
            if (Environment.GetEnvironmentVariable("AGENT_MACHINENAME") != null)
            {
                edgeOptions.AddArgument("--headless");
            }

            // Initialize EdgeDriver
            TestWebDriver = new EdgeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), edgeOptions, TimeSpan.FromMinutes(5));

            if (Username != null)
            {
                Login(Url, Username, pswd);
            }
        }

      

        [OneTimeTearDown]
        public void TearDownTestSuite()
        {

            
            string className = TestContext.CurrentContext.Test.ClassName.Split('.').ToList().LastOrDefault();

            var onCIEnv = Environment.GetEnvironmentVariable(WebOptions.AGENT_MACHINENAME) != null;
            var fixturePassed = TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Passed;

            NUnit.Framework.Internal.TestResult result = NUnit.Framework.Internal.TestExecutionContext.CurrentContext.CurrentResult;

            IEnumerable<ITestResult> resultList = result.Children.ToList();

            List<TestResults> results = new List<TestResults>();

            //foreach (ITestResult testResult in resultList)
            //{
            //    TestResults testResults = new TestResults();
            //    testResults.Name = testResult.Name;
            //    testResults.ResultStatus = testResult.ResultState.Status.ToString();
            //    testResults.Message = testResult.Message;
            //    testResults.Duration = testResult.Duration.ToString();
            //    testResults.StartTime = testResult.StartTime;
            //    testResults.EndTime = testResult.EndTime;
            //    testResults.ClassName = className;
           
            //    results.Add(testResults);
            //}
 
            if (TestWebDriver != null)
            {
                if (onCIEnv || fixturePassed || Selenium.BaseComponents.Utilities.PreBuildConstants.PREBUILD_ENV != "PREBUILD_ENV_VALUE")
                {
                    TestWebDriver.Close();
                    TestWebDriver.Quit();
                    TestWebDriver.Dispose();
                    TestWebDriver = null;
                }
                else
                {
                    TestWebDriver.Close();
                    TestWebDriver.Quit();
                    TestWebDriver.Dispose();
                    TestWebDriver = null;
                }
            }

        }



        public void LoginByProfile(string profile)
        {
            var uname = UserCredentials.UserNameGenerator.GetUserName(profile, Users.CurrentEnvironment);
            Login(uname, UserCredentials.PasswordGenerator.GetPassword(Users.CurrentEnvironment));
        }
        public bool IsActive()
        {
            return this.TestWebDriver.Url.Contains("ChangePassword");
        }
        #region Cancel Change Password
        public void ClickCancelButton()
        {
            try
            {
                Button_Cancel.Click();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        private IWebElement button_Cancel;
        public IWebElement Button_Cancel
        {
            get
            {
                if (button_Cancel == null)
                    button_Cancel = TestWebDriver.FindElement(By.Id("cancel-button"), null);
                return button_Cancel;
            }
        }
        #endregion


        public void Login(string loginUrl, string userName, string password)
        {
            try
            {
                TestWebDriver.Navigate().GoToUrl(Url);
                TestWebDriver.WaitUntilDocumentIsReady(TimeSpan.FromSeconds(Convert.ToInt32(5)));
                UserName.Set(userName);
                NextButton.Click();
                Password.Set(password);
                LoginButton.Click();
                ChkLoginTerms.Click();

                if (TestWebDriver.Url.Contains("EmailVerification"))
                {
                    Assert.Fail("Login requires two-factor authentication. " +
                        "User Name: " + userName + "," +
                        "Password: " + password + "." +
                        "Please try running the test again.");
                }
                if (IsActive())
                {
                    ClickCancelButton();
                }
            }
            catch (Exception ex)
            {
                if (TestWebDriver != null)
                {
                    TestWebDriver.Close();
                    TestWebDriver.Quit();
                    TestWebDriver.Dispose();
                    TestWebDriver = null;
                }
                InitializeChromeAndLogin();
            }
        }

        public void Login(string userName, string password)
        {
            TestWebDriver.Navigate().GoToUrl(Url);

            TestWebDriver.WaitUntilDocumentIsReady(TimeSpan.FromSeconds(Convert.ToInt32(5)));
            UserName.Set(userName);
            NextButton.Click();

            WebDriverWait wait = new WebDriverWait(TestWebDriver, TimeoutConfiguration.Element);

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//input[@id='ctl00_MainContent_Login1_Password']")));

            Password.Set(password);
            LoginButton.Click();

            PageHelper.WaitUntilElementIsVisible(TestWebDriver, By.XPath("//input[@id='ctl00_MainContent_chkTerms']"), TimeoutConfiguration.Element);

            ChkLoginTerms.Click();

            if (TestWebDriver.Url.Contains("EmailVerification"))
            {
                Assert.Fail("Login requires two-factor authentication. " +
                    "User Name: " + userName + "," +
                    "Password: " + password + "." +
                    "Please try running the test again.");
            }
            if (IsActive())
            {
                ClickCancelButton();
            }
        }
        public void LoginEmc(string userName, string password)
        {
            //TestWebDriver.Navigate().GoToUrl(Url);

            UserName.Set(userName);
            Password.Set(password);
            LoginButton.Click();
        }

        public void LogOut()
        {
            LogOutButton.Click();
        }
    }
}
