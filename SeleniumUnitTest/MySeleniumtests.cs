using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;			
using OpenQA.Selenium.Firefox;	
using OpenQA.Selenium.Chrome;	
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;


namespace SeleniumUnitTest
{
  /// <summary>
  /// Summary description for MySeleniumTests
  /// </summary>
  [TestClass]
  public class MySeleniumTests
  {
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
        driver.Navigate().GoToUrl(appURL + "/");
        driver.FindElement(By.Id("sb_form_q")).SendKeys("Azure Pipelines");
        driver.FindElement(By.Id("sb_form_go")).Click();
        driver.FindElement(By.XPath("//ol[@id='b_results']/li/h2/a/strong[3]")).Click();
        Assert.IsTrue(driver.Title.Contains("Azure Pipelines"), "Verified title of the page");

        //using (IWebDriver driver = new FirefoxDriver())
        //{
        //    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        //    driver.Navigate().GoToUrl("https://www.google.com/ncr");
        //    driver.FindElement(By.Name("q")).SendKeys("cheese" + Keys.Enter);
        //    IWebElement firstResult = wait.Until(ExpectedConditions.ElementExists(By.CssSelector("h3>div")));
        //    Console.WriteLine(firstResult.GetAttribute("textContent"));
        //}
    }

    /// <summary>
    ///Gets or sets the test context which provides
    ///information about and functionality for the current test run.
    ///</summary>
    public TestContext TestContext
    {
      get
      {
        return testContextInstance;
      }
      set
      {
        testContextInstance = value;
      }
    }

    [TestInitialize()]
    public void SetupTest()
    {
      appURL = "http://www.bing.com/";

      string browser = "Chrome";
      switch(browser)
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
