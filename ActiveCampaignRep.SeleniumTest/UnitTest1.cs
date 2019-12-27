using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

namespace ActiveCampaignRep.SeleniumTest
{
    [TestClass]
    public class UnitTest1
    {
        private const string _webSiteUrl = "http://localhost:14669/";
        private RemoteWebDriver _browserDriver;
        public TestContext TestContext { get; set; }

        [TestMethod]
        [TestCategory("Selenium")]
        public void TestMethod1()
        {
            _browserDriver = new ChromeDriver();
            _browserDriver.Manage().Window.Maximize();
            _browserDriver.Navigate().GoToUrl(_webSiteUrl);
            _browserDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            //Assert.IsTrue(1==2);
        }
    }
}
