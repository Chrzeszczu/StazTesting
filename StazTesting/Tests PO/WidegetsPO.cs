using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using StazTesting.Methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static StazTesting.Methods.Method;
using StazTesting.PageObjects;

namespace StazTesting.Tests
{
    internal class WidegetsPO
    {
        IWebDriver driver;


        [SetUp]
        public void Setup()
        {
            var methods = new Method(driver);
            driver = new ChromeDriver(methods.SetupOptions());

            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);

        }

        [Test]
        public void TC_widgets1()
        {
            var t = new POWidgetsAccordion(driver);
            var methods = new Method(driver);

            //variables
            string acc = "Accordion";


            t.goToPage();

            //User click “Accordion” button from the left menu side bar
            t.ClickAccBtn();

            //Accordion widget should appear on the main view = There is no button “Accordion”, there is a typo in the word – “Accordian”
            bool finalResult = methods.CheckIfTheSame(t.GetAccBtnTxt(), acc);
            Assert.IsFalse(finalResult);

        }

        [Test]
        public void TC_widgets2()
        {
            var t = new POWidgetsAccordion(driver);
            var methods = new Method(driver);


            t.goToPage();

            //User click “Accordion” button from the left menu side bar
            t.ClickAccBtn();

            //User click on the first accordion button “what is lorem ipsum”
            t.ClickFirstAccBtn();

            //Text should wrap up to first button
            Assert.IsFalse(t.ChekIfFirstAccIsDisplayed());

            //User click on the second accordion button “Where does it come from”
            t.ClickSecondAccBtn();

            //Text should wrap down to second button
            Assert.IsTrue(t.ChekIfSecondAccIsDisplayed());

            //User click on the second accordion button “Where does it come from”
            t.MoveToProgressBarBtn();
            t.ClickThirdAccBtn();
            methods.SleepInMiliseconds(300);

            //Text should wrap down to second button
            Assert.IsFalse(t.ChekIfSecondAccIsDisplayed());
            Assert.IsTrue(t.ChekIfThirdAccIsDisplayed());
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
