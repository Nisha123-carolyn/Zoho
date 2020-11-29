using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Linq;
using System.Threading;

namespace ZohoDemo
{
    [TestClass]
    public class UnitTest1
    {
        static IWebDriver driver;

        [AssemblyInitialize]
        public static void Setup(TestContext context)
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument(@"user-data-dir=C:\Users\nandu\AppData\Local\Google\Chrome\User Data\Default");
            driver = new ChromeDriver(options);
            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl("https://www.zoho.com/show");
            try
            {
                driver.FindElement(By.XPath("(//a[text()='LOGIN'])[1]")).Click();
                driver.FindElement(By.XPath("//input[@id='login_id']")).SendKeys("nandu9500100247@gmail.com");
                driver.FindElement(By.XPath("(//button[@id='nextbtn'])[1]")).Click();
                driver.FindElement(By.XPath("//input[@id='password']")).SendKeys("nisha123N");
                driver.FindElement(By.XPath("(//button[@id='nextbtn'])[1]")).Click();
                Thread.Sleep(10000);
            }
            catch (Exception)
            {
                driver.FindElement(By.XPath("(//a[text()='Access show'])[1]")).Click();
                Thread.Sleep(10000);
            }
        }
        [AssemblyCleanup]
        public static void Cleanup()
        {
            driver.Close();
            driver.Quit();
        }
        [TestMethod]
        public void Demo1()
        {
            Actions action = new Actions(driver);
            IWebElement we = driver.FindElement(By.XPath("(//div[@id='zs_imgCont'])[1]"));
            action.MoveToElement(we).Build().Perform();
            driver.FindElement(By.XPath("(//button[@id=\"zs_download\"])[1]")).Click();
            driver.FindElement(By.XPath("//z-menuitem[@data-label='MS Powerpoint Presentation']")).Click();

            Thread.Sleep(30000);

            driver.FindElement(By.XPath("//button[@data-title='List View']")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//button[@data-title='Grid View']")).Click();
        }

        [TestMethod]
        public void Demo2()
        {
            driver.FindElement(By.XPath("(//div[@id='zs_imgCont'])[1]")).Click();
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            Thread.Sleep(5000);

            driver.FindElement(By.XPath("//button[@popup='slideshowsetupmenu']")).Click();
            driver.FindElement(By.XPath("(//span[text()='Custom Slideshow']//parent::li)[2]")).Click();
            Assert.IsTrue(driver.FindElement(By.XPath("//h3[text()='Create Custom Slideshow']")).Displayed, "Create Custom Slideshow is not displayed");
            driver.FindElement(By.XPath("(//span[@class='ui-right ui-customshow-close'])[1]")).Click();
        }

        [TestMethod]
        public void Demo3()
        {
            driver.FindElement(By.XPath("(//div[@id='zs_imgCont'])[1]")).Click();
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            Thread.Sleep(5000);

            Actions action = new Actions(driver);
            action.ContextClick(driver.FindElement(By.XPath("//div[@class='ui-zthumbnail ui-zthumbnail-selected']"))).Perform();
            driver.FindElement(By.XPath("//span[text()='Hide/Show Slide']")).Click();
            Thread.Sleep(4000);
            Assert.IsTrue(driver.FindElement(By.XPath("//div[@class='ui-zthumbnail ui-zthumbnail-selected ui-zthumbnail-hidden']")).Displayed, "The slide is not hidden");
            action.ContextClick(driver.FindElement(By.XPath("//div[@class='ui-zthumbnail ui-zthumbnail-selected ui-zthumbnail-hidden']"))).Perform();
            Thread.Sleep(4000);
            action.SendKeys(Keys.Escape);
            action.ContextClick(driver.FindElement(By.XPath("//div[@class='ui-zthumbnail ui-zthumbnail-selected ui-zthumbnail-hidden']"))).Perform();
            Thread.Sleep(4000);
            driver.FindElement(By.XPath("//span[text()='Hide/Show Slide']")).Click();
            Thread.Sleep(4000);
            Assert.IsTrue(driver.FindElement(By.XPath("//div[@class='ui-zthumbnail ui-zthumbnail-selected']")).Displayed, "The slide is not shown");

            action.SendKeys(Keys.Escape);
            action.ContextClick(driver.FindElement(By.XPath("//div[@class='ui-zthumbnail ui-zthumbnail-selected']"))).Perform();
            Thread.Sleep(4000);
            action.ContextClick(driver.FindElement(By.XPath("//div[@class='ui-zthumbnail ui-zthumbnail-selected']"))).Perform();
            Thread.Sleep(4000);
            driver.FindElement(By.XPath("//span[text()='Add Comment']//parent::li")).Click();
            Thread.Sleep(4000);
            Assert.IsTrue(driver.FindElement(By.XPath("//div[@class='commentbox']")).Displayed, "The Comment box is not displayed");
        }

        [TestMethod]
        public void Demo4()
        {
            driver.FindElement(By.XPath("(//div[@id='zs_imgCont'])[1]")).Click();
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            Thread.Sleep(5000);

            driver.FindElement(By.XPath("//a[@id='fileMenu']")).Click();
            Thread.Sleep(4000);
            driver.FindElement(By.XPath("//span[text()='Make a Copy']")).Click();
            Thread.Sleep(4000);
            driver.FindElement(By.XPath("//span[@class='ui-button-text'][text()='Make a Copy']")).Click();
            Thread.Sleep(10000);
            Assert.IsTrue(driver.FindElement(By.XPath("//div[text()='Copy of Different types of mouse']")).Displayed, "The file is not copied");

            driver.FindElement(By.XPath("//a[@id='fileMenu']")).Click();
            driver.FindElement(By.XPath("//span[text()='Open...']")).Click();
            Assert.IsTrue(driver.FindElement(By.XPath("//span[text()='Open File']")).Displayed, "Open file popup is displayed");
        }

        [TestMethod]
        public void Demo5()
        {
            driver.FindElement(By.XPath("(//div[@id='zs_imgCont'])[1]")).Click();
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            Thread.Sleep(5000);
            Actions action = new Actions(driver);
            action.ContextClick(driver.FindElement(By.XPath("//div[@class='ui-zthumbnail ui-zthumbnail-selected']"))).Perform();
            driver.FindElement(By.XPath("//span[text()='Add Comment']")).Click();
            //driver.FindElement(By.XPath("//div[@id='comments_text']")).Click();
            action.SendKeys("H").Build().Perform();
            driver.FindElement(By.XPath("//div[@class='postcomment']")).Click();
            driver.FindElement(By.XPath("//span[text()='Resolve']//parent::button")).Click();
        }
    }
}