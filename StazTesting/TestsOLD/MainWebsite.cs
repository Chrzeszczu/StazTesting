using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.Events;
using OpenQA.Selenium.Support.Extensions;
using SeleniumExtras.WaitHelpers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StazTesting.Methods;
using StazTesting.PageObjects;


namespace StazTesting.Tests
{
    internal class MainWebsite
    {
        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            var methods = new Method(driver);
            driver = new ChromeDriver(methods.SetupOptions());
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
        }

        [Test]
        public void MainWebsiteTest()
        {
            var methods = new Method(driver);
            WebDriverWait w = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

            //Urls
            string demoqaUrl = "https://demoqa.com/";
            string bannerUrl = "https://www.toolsqa.com/selenium-training/";
            string elementsUrl = "https://demoqa.com/elements";
            string formsUrl = "https://demoqa.com/forms";
            string alertsFrameWindowsUrl = "https://demoqa.com/alertsWindows";
            string widgetsUrl = "https://demoqa.com/widgets";
            string interactionsUrl = "https://demoqa.com/interaction";
            string bookStoreApplicationUrl = "https://demoqa.com/books";

            //elements xpaths
            string noCookieWarning = "//div[@id='no-cookie-warning']";
            string waitForCards = "//div[@class='category-cards']";
            string waitForLogo = "//img[@src='/images/Toolsqa.jpg']";

            //Btn Xpaths
            string logoXpath = "(//a[@href='https://demoqa.com'])[1]";
            string bannerXpath = "(//div[@class='home-banner'])[1]";
            string elementsBtnXpath = "(//div[@class='card mt-4 top-card'])[1]";
            string formsXpath = "(//div[@class='card mt-4 top-card'])[2]";
            string alertsFrameWindowsXpath = "(//div[@class='card mt-4 top-card'])[3]";
            string widgetsXpath = "(//div[@class='card mt-4 top-card'])[4]";
            string interactionsXpath = "(//div[@class='card mt-4 top-card'])[5]";
            string bookStoreApplicationBtnXpath = "(//div[@class='card mt-4 top-card'])[6]";

            methods.GoToUrl(demoqaUrl);
            methods.ClickElement(logoXpath);
            Assert.That(methods.GetCurrentUrl, Is.EqualTo(demoqaUrl));

            methods.ClickElement(bannerXpath);
            methods.SwitchToAnotherTab(2);
            methods.WaitUntilVisible(noCookieWarning);
            Assert.That(methods.GetCurrentUrl, Is.EqualTo(bannerUrl));

            methods.WaitForPage();
            methods.CloseTab();
            methods.SwitchToAnotherTab(1);
            Assert.That(methods.GetCurrentUrl, Is.EqualTo(demoqaUrl));

            methods.MoveToElement(bookStoreApplicationBtnXpath);
            methods.ClickWhenItBeClickable(elementsBtnXpath);
            methods.WaitUntilVisible(waitForLogo);
            Assert.That(methods.GetCurrentUrl, Is.EqualTo(elementsUrl));

            methods.GoBack();
            methods.WaitUntilVisible(waitForCards);
            Assert.That(methods.GetCurrentUrl, Is.EqualTo(demoqaUrl));

            methods.MoveToElement(bookStoreApplicationBtnXpath);
            methods.ClickWhenItBeClickable(formsXpath);
            methods.WaitUntilVisible(waitForLogo);
            Assert.That(methods.GetCurrentUrl, Is.EqualTo(formsUrl));

            methods.GoBack();
            methods.WaitUntilVisible(waitForCards);
            Assert.That(methods.GetCurrentUrl, Is.EqualTo(demoqaUrl));

            methods.MoveToElement(bookStoreApplicationBtnXpath);
            methods.ClickWhenItBeClickable(alertsFrameWindowsXpath);
            methods.WaitUntilVisible(waitForLogo);
            Assert.That(methods.GetCurrentUrl, Is.EqualTo(alertsFrameWindowsUrl));

            methods.GoBack();
            methods.WaitUntilVisible(waitForCards);
            Assert.That(methods.GetCurrentUrl, Is.EqualTo(demoqaUrl));

            methods.MoveToElement(bookStoreApplicationBtnXpath);
            methods.ClickWhenItBeClickable(widgetsXpath);
            methods.WaitUntilVisible(waitForLogo);
            Assert.That(methods.GetCurrentUrl, Is.EqualTo(widgetsUrl));

            methods.GoBack();
            methods.WaitUntilVisible(waitForCards);
            Assert.That(methods.GetCurrentUrl, Is.EqualTo(demoqaUrl));

            methods.MoveToElement(bookStoreApplicationBtnXpath);
            methods.ClickWhenItBeClickable(interactionsXpath);
            methods.WaitUntilVisible(waitForLogo);
            methods.SleepInMiliseconds(300);
            Assert.That(methods.GetCurrentUrl, Is.EqualTo(interactionsUrl));

            methods.GoBack();
            methods.WaitUntilVisible(waitForCards);
            Assert.That(methods.GetCurrentUrl, Is.EqualTo(demoqaUrl));

            methods.MoveToElement(bookStoreApplicationBtnXpath);
            methods.ClickWhenItBeClickable(bookStoreApplicationBtnXpath);
            methods.WaitUntilVisible(waitForLogo);
            Assert.That(methods.GetCurrentUrl, Is.EqualTo(bookStoreApplicationUrl));

            methods.GoBack();
            methods.WaitUntilVisible(waitForCards);
            Assert.That(methods.GetCurrentUrl, Is.EqualTo(demoqaUrl));


        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }


    }
}
