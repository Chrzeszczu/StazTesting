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
    internal class MainWebsitePO
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
            var Main_Website = new PODemoqa(driver);
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


            Main_Website.goToPage();
            Main_Website.ClickLogo();
            Assert.That(methods.GetCurrentUrl, Is.EqualTo(demoqaUrl));

            Main_Website.ClickBanner();
            Assert.That(methods.GetCurrentUrl, Is.EqualTo(bannerUrl));

            Main_Website.GetBackFromBanner();
            Assert.That(methods.GetCurrentUrl, Is.EqualTo(demoqaUrl));

            Main_Website.ClickElements();
            Assert.That(methods.GetCurrentUrl, Is.EqualTo(elementsUrl));

            Main_Website.GoBackAndWaitForCards();
            Assert.That(methods.GetCurrentUrl, Is.EqualTo(demoqaUrl));

            Main_Website.ClickForsm();
            Assert.That(methods.GetCurrentUrl, Is.EqualTo(formsUrl));

            Main_Website.GoBackAndWaitForCards();
            Assert.That(methods.GetCurrentUrl, Is.EqualTo(demoqaUrl));

            Main_Website.ClickAFW();
            Assert.That(methods.GetCurrentUrl, Is.EqualTo(alertsFrameWindowsUrl));

            Main_Website.GoBackAndWaitForCards();
            Assert.That(methods.GetCurrentUrl, Is.EqualTo(demoqaUrl));

            Main_Website.ClickWidegts();
            Assert.That(methods.GetCurrentUrl, Is.EqualTo(widgetsUrl));

            Main_Website.GoBackAndWaitForCards();
            Assert.That(methods.GetCurrentUrl, Is.EqualTo(demoqaUrl));

            Main_Website.ClickInteractions();
            Assert.That(methods.GetCurrentUrl, Is.EqualTo(interactionsUrl));

            Main_Website.GoBackAndWaitForCards();
            Assert.That(methods.GetCurrentUrl, Is.EqualTo(demoqaUrl));

            Main_Website.ClickBookstoreApp();
            Assert.That(methods.GetCurrentUrl, Is.EqualTo(bookStoreApplicationUrl));

            Main_Website.GoBackAndWaitForCards();
            Assert.That(methods.GetCurrentUrl, Is.EqualTo(demoqaUrl));

        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }


    }
}
