using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using StazTesting.Methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StazTesting.PageObjects;

namespace StazTesting.Tests
{
    internal class AlertsFramesWindowsPO
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
        public void TC_afw1()
        {
            var Browser_Windows = new POAlertsFramesWindowsBrowserWindows(driver);
            var methods = new Method(driver);
            string demoqaAFWUrl = "https://demoqa.com/alertsWindows";

            //variables
            string newWindowURL = "https://demoqa.com/sample";
            string browserWindowURL = "https://demoqa.com/browser-windows";




            //Xpaths of results

            Browser_Windows.goToPage();

            //User click “Browser Windows” button from the left menu side bar
            Browser_Windows.ClickBrowseWindowsBtn();

            //User click “new tab” button 
            Browser_Windows.ClickNewTabBtn();

            //New tab should open with site - https://demoqa.com/sample 
            Assert.That(methods.GetCurrentUrl, Is.EqualTo(newWindowURL));

            //User close new opened tab 
            Browser_Windows.GetBackFromTab();


            //User click “new window” button 
            Browser_Windows.ClickNewWindowBtn();
            //New window should open with site - https://demoqa.com/sample 
            Assert.That(methods.GetCurrentUrl, Is.EqualTo(newWindowURL));

            //User close new opened tab 
            Browser_Windows.GetBackFromTab();

            //User click “new window message” button 
            Browser_Windows.ClickNewWindowWithMessageBtn();

            //New window with message should open (closing window and checking if u are on the main site)
            Browser_Windows.GetBackFromTab();
            Assert.That(methods.GetCurrentUrl, Is.EqualTo(browserWindowURL));

        }

        [Test]
        public void TC_afw2()
        {
            var methods = new Method(driver);
            var Alerts = new POAlertsFramesWindowsAlerts(driver);
            string demoqaAFWUrl = "https://demoqa.com/alertsWindows";
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);

            //variables
            string keyToBox = "#$&";
            string alertsURL = "https://demoqa.com/alerts";

            Alerts.goToPage();

            //User click “Alerts” button from the left menu side bar
            Alerts.ClickAlertsBtn();

            //User click first “click me” button
            Alerts.ClickFirstAlert();

            //An alert with message should appear
            Assert.That(Alerts.SwitchToAlert().Text, Is.EqualTo("You clicked a button"));

            //User click “OK” button on the alert
            Alerts.AcceptAlert();

            //An alert should disappear (u cant get URL if you are on alert frame/window)
            Assert.That(methods.GetCurrentUrl,Is.EqualTo(alertsURL));

            //User click second “click me” button
            Alerts.ClickSecondAlert();

            //An alert with message should appear
            Assert.That(Alerts.SwitchToAlert().Text, Is.EqualTo("This alert appeared after 5 seconds"));

            //User click “OK” button on the alert
            Alerts.AcceptAlert();

            //An alert should disappear (u cant get URL if you are on alert frame/window)
            Assert.That(methods.GetCurrentUrl, Is.EqualTo(alertsURL));

            //User click third “click me” button
            Alerts.ClickThirdAlert();

            //An alert with message should appear
            Assert.That(Alerts.SwitchToAlert().Text, Is.EqualTo("Do you confirm action?"));

            //User click “OK” button on the alert
            Alerts.AcceptAlert();

            //An alert should disappear and there should be a green text with short message and what user selected (OK) (u cant get URL if you are on alert frame/window)
            Assert.That(methods.GetCurrentUrl, Is.EqualTo(alertsURL));
            Assert.IsTrue(Alerts.ChekIfConfirmMessageIsDisplayed());
            Assert.That(Alerts.GetConfirmTxt(), Is.EqualTo("You selected Ok"));

            //User click third “click me” button
            Alerts.ClickThirdAlert();

            //An alert with message should appear
            Assert.That(Alerts.SwitchToAlert().Text, Is.EqualTo("Do you confirm action?"));

            //User click “OK” button on the alert
            Alerts.DismissAlert();

            //An alert should disappear and there should be a green text with short message and what user selected (CANCEL) (u cant get URL if you are on alert frame/window)
            Assert.That(methods.GetCurrentUrl, Is.EqualTo(alertsURL));
            Assert.IsTrue(Alerts.ChekIfConfirmMessageIsDisplayed());
            Assert.That(Alerts.GetConfirmTxt(), Is.EqualTo("You selected Cancel"));

            //User click fourth “click me” button
            Alerts.ClickFourthAlert();

            //An alert with text box should appear
            Assert.That(Alerts.SwitchToAlert().Text, Is.EqualTo("Please enter your name"));

            //User tapes in text box
            Alerts.SwitchToAlert().SendKeys(keyToBox);

            //User click “OK” button on the alert
            Alerts.AcceptAlert();

            //An alert should disappear and there should be a green text with short message and what user taped (u cant get URL if you are on alert frame/window)
            Assert.That(methods.GetCurrentUrl, Is.EqualTo(alertsURL));
            Assert.IsTrue(Alerts.ChekIfPromptMessageIsDisplayed());
            Assert.That(Alerts.GetPromptTxt(), Is.EqualTo("You entered " + keyToBox));

            //User click fourth “click me” button
            Alerts.ClickFourthAlert();

            //An alert with text box should appear
            Assert.That(Alerts.SwitchToAlert().Text, Is.EqualTo("Please enter your name"));

            //User click “Cancel” button on the alert
            Alerts.DismissAlert();

            //An alert and green text should disappear (u cant get URL if you are on alert frame/window)
            Assert.That(methods.GetCurrentUrl, Is.EqualTo(alertsURL));
            Assert.IsFalse(Alerts.ChekIfPromptMessageIsDisplayed());

        }

        [Test]
        public void TC_afw3()
        {
            var t = new POAlertsFramesWindowsModals(driver);
            var methods = new Method(driver);
            string demoqaAFWUrl = "https://demoqa.com/alertsWindows";
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);

            //variables
            string smallModal = "Small Modal";
            string largeModal = "Large Modal";


            t.goToPage();

            //User click “Modal dialogs” button from the left menu side bar
            t.ClickModalDialogsBtn();

            //User click first button “small modal”
            t.ClickSmallModalBtn();

            //Small modal message should appear on the screen
            Assert.IsTrue(t.ChekIfModalIsDisplayed());
            Assert.That(t.GetSmallModalHeaderTxt(), Is.Not.Empty.And.Contains(smallModal));

            //User click “Close” button
            t.ClickSmallModalCloseBtn();

            //Modal should disappear
            Assert.IsFalse(t.ChekIfModalIsDisplayed());

            //User click first button “small modal”
            t.ClickSmallModalBtn();

            //Small modal message should appear on the screen
            Assert.IsTrue(t.ChekIfModalIsDisplayed());
            Assert.That(t.GetSmallModalHeaderTxt(), Is.Not.Empty.And.Contains(smallModal));

            //User click small “x” button on the top right corner of the modal
            t.Click_X_CloseBtn();

            //Modal should disappear
            Assert.IsFalse(t.ChekIfModalIsDisplayed());

            //User click second button “large modal”
            t.ClickLargeModalBtn();

            //Large modal message should appear on the screen
            Assert.IsTrue(t.ChekIfModalIsDisplayed());
            Assert.That(t.GetLargeModalHeaderTxt(), Is.Not.Empty.And.Contains(largeModal));

            //User click “Close” button
            t.ClickLargeModalCloseBtn();

            //Modal should disappear
            Assert.IsFalse(t.ChekIfModalIsDisplayed());

            //User click second button “large modal”
            t.ClickLargeModalBtn();

            //Large modal message should appear on the screen
            Assert.IsTrue(t.ChekIfModalIsDisplayed());
            Assert.That(t.GetLargeModalHeaderTxt(), Is.Not.Empty.And.Contains(largeModal));

            //User click “Close” button
            t.Click_X_CloseBtn();

            //Modal should disappear
            Assert.IsFalse(t.ChekIfModalIsDisplayed());

        }


        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
