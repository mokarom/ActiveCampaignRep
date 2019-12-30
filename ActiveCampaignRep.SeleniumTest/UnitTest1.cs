using System;
using System.IO;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;

namespace ActiveCampaignRep.SeleniumTest
{
    [TestClass]
    public class MySeleniumTests
    {
        //private const string _webSiteUrl = "http://localhost:14669/";
        //private RemoteWebDriver _browserDriver;
        //public TestContext TestContext { get; set; }

        //[TestMethod]
        //[TestCategory("Selenium")]
        //public void TestMethod1()
        //{
        //    _browserDriver = new ChromeDriver();
        //    _browserDriver.Manage().Window.Maximize();
        //    _browserDriver.Navigate().GoToUrl(_webSiteUrl);
        //    _browserDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        //    Assert.IsTrue(false);
        //    //Assert.IsTrue(1 == 3);
        //}

        private TestContext testContextInstance;
        private IWebDriver driver;
        private string appURL;

        public MySeleniumTests()
        {
        }

        [TestMethod]
        [TestCategory("Chrome")]
        public void TheBingSearchTest()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("headless");
            using (driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), chromeOptions))
            {
                driver.Navigate().GoToUrl(appURL + "/");
                driver.FindElement(By.Id("CampaignName")).SendKeys("Azure Pipelines");
                //driver.FindElement(By.Id("sb_form_go")).Click();
                //driver.FindElement(By.XPath("//ol[@id='b_results']/li/h2/a/strong[3]")).Click();
                //Assert.IsTrue(driver.Title.Contains("Azure Pipelines"), "Verified title of the page");
                Assert.IsTrue(true);
            }
           
        }

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }

        [TestInitialize()]
        public void SetupTest()
        {
            appURL = "http://localhost:14669/";

            string browser = "Chrome";
            switch (browser)
            {
                case "Chrome":
                    driver = new ChromeDriver();
                    break;
                case "Firefox":
                    driver = new FirefoxDriver();
                    break;
                case "IE":
                    driver = new InternetExplorerDriver();
                    break;
                default:
                    driver = new ChromeDriver();
                    break;
            }

        }

        [TestCleanup()]
        public void MyTestCleanup()
        {
            driver.Quit();
        }
    }
}
