using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using StazTesting.Methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StazTesting.Tests
{
    internal class AlertsFramesWindows
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
            var methods = new Method(driver);
            string demoqaAFWUrl = "https://demoqa.com/alertsWindows";

            //variables

            //Xpaths
            string AFWMenu = "//div[contains(@class,'element-list collapse show')]";
            string browserContainer = "//div[@id='browserWindows']";
            string newTabTxt = "//h1[@id='sampleHeading']";
            //string newWindowWithMessageTxt = "//body";
            string newWindowURL = "https://demoqa.com/sample";
            string browserWindowURL = "https://demoqa.com/browser-windows";

            //Xpaths of buttons
            string moveToBtn = "//body/div[@id='app']/div/div/div/div/div/div/div[4]/span[1]/div[1]";
            string browserWindowsBtn = "//span[normalize-space()='Browser Windows']";
            string newTabBtn = "//button[@id='tabButton']";
            string newWindowBtn = "//button[@id='windowButton']";
            string newWindowWithMessageBtn = "//button[@id='messageWindowButton']";

            //Xpaths of results

            methods.GoToUrl(demoqaAFWUrl);
            methods.WaitUntilVisible(AFWMenu);

            //User click “Browser Windows” button from the left menu side bar
            methods.MoveToElement(moveToBtn);
            methods.ClickElement(browserWindowsBtn);
            methods.WaitUntilVisible(browserContainer);

            //User click “new tab” button 
            methods.ClickElement(newTabBtn);
            methods.SwitchToAnotherTab(2);
            methods.WaitUntilVisible(newTabTxt);

            //New tab should open with site - https://demoqa.com/sample 
            Assert.That(methods.GetCurrentUrl, Is.EqualTo(newWindowURL));

            //User close new opened tab 
            methods.CloseTab();
            methods.SwitchToAnotherTab(1);
            methods.Refresh();
            methods.WaitUntilVisible(browserContainer);


            //User click “new window” button 
            methods.ClickElement(newWindowBtn);
            methods.SwitchToAnotherTab(2);
            methods.WaitUntilVisible(newTabTxt);
            //New window should open with site - https://demoqa.com/sample 
            Assert.That(methods.GetCurrentUrl, Is.EqualTo(newWindowURL));

            //User close new opened tab 
            methods.CloseTab();
            methods.SwitchToAnotherTab(1);
            methods.Refresh();
            methods.WaitUntilVisible(browserContainer);

            //User click “new window message” button 
            methods.ClickElement(newWindowWithMessageBtn);
            methods.SwitchToAnotherTab(2);

            //New window with message should open (closing window and checking if u are on the main site)
            methods.CloseTab();
            methods.SwitchToAnotherTab(1);
            //string test = methods.GetTitle();
            //Assert.That(test, Is.EqualTo("title"));
            methods.Refresh();
            methods.WaitUntilVisible(browserContainer);
            Assert.That(methods.GetCurrentUrl, Is.EqualTo(browserWindowURL));

        }

        [Test]
        public void TC_afw2()
        {
            var methods = new Method(driver);
            string demoqaAFWUrl = "https://demoqa.com/alertsWindows";
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);


            //variables
            string keyToBox = "#$&";

            //Xpaths
            string AFWMenu = "//div[contains(@class,'element-list collapse show')]";
            string alertsContainer = "//div[@id='javascriptAlertsWrapper']";
            string alertsURL = "https://demoqa.com/alerts";

            //Xpaths of buttons
            string moveToBtn = "//body/div[@id='app']/div/div/div/div/div/div/div[4]/span[1]/div[1]";
            string alertsBtn = "//span[normalize-space()='Alerts']";
            string firstAlertBtn = "//button[@id='alertButton']";
            string secondAlertBtn = "//button[@id='timerAlertButton']";
            string thirdAlertBtn = "//button[@id='confirmButton']";
            string FourthAlertBtn = "//button[@id='promtButton']";

            //Xpaths of results
            string confirmResult = "//span[@id='confirmResult']";
            string promptResult = "//span[@id='promptResult']";

            methods.GoToUrl(demoqaAFWUrl);
            methods.WaitUntilVisible(AFWMenu);

            //User click “Alerts” button from the left menu side bar
            methods.MoveToElement(moveToBtn);
            methods.ClickElement(alertsBtn);
            methods.WaitUntilVisible(alertsContainer);

            //User click first “click me” button
            methods.ClickElement(firstAlertBtn);
            methods.WaitUntilAlertIsPresent();
            var firstAlert = driver.SwitchTo().Alert();

            //An alert with message should appear
            Assert.That(firstAlert.Text, Is.EqualTo("You clicked a button"));

            //User click “OK” button on the alert
            firstAlert.Accept();

            //An alert should disappear (u cant get URL if you are on alert frame/window)
            Assert.That(methods.GetCurrentUrl,Is.EqualTo(alertsURL));

            //User click second “click me” button
            methods.ClickElement(secondAlertBtn);
            methods.WaitUntilAlertIsPresent();
            var secondAlert = driver.SwitchTo().Alert();

            //An alert with message should appear
            Assert.That(secondAlert.Text, Is.EqualTo("This alert appeared after 5 seconds"));

            //User click “OK” button on the alert
            secondAlert.Accept();

            //An alert should disappear (u cant get URL if you are on alert frame/window)
            Assert.That(methods.GetCurrentUrl, Is.EqualTo(alertsURL));

            //User click third “click me” button
            methods.ClickElement(thirdAlertBtn);
            methods.WaitUntilAlertIsPresent();
            var thirdAlert = driver.SwitchTo().Alert();

            //An alert with message should appear
            Assert.That(thirdAlert.Text, Is.EqualTo("Do you confirm action?"));

            //User click “OK” button on the alert
            thirdAlert.Accept();

            //An alert should disappear and there should be a green text with short message and what user selected (OK) (u cant get URL if you are on alert frame/window)
            Assert.That(methods.GetCurrentUrl, Is.EqualTo(alertsURL));
            Assert.IsTrue(methods.CheckIfElementExist(confirmResult));
            string finalconfrimResult = methods.GetText(confirmResult);
            Assert.That(finalconfrimResult, Is.EqualTo("You selected Ok"));

            //User click third “click me” button
            methods.ClickElement(thirdAlertBtn);
            methods.WaitUntilAlertIsPresent();
            var thirdAlert2 = driver.SwitchTo().Alert();

            //An alert with message should appear
            Assert.That(thirdAlert2.Text, Is.EqualTo("Do you confirm action?"));

            //User click “OK” button on the alert
            thirdAlert2.Dismiss();

            //An alert should disappear and there should be a green text with short message and what user selected (CANCEL) (u cant get URL if you are on alert frame/window)
            Assert.That(methods.GetCurrentUrl, Is.EqualTo(alertsURL));
            Assert.IsTrue(methods.CheckIfElementExist(confirmResult));
            string finalconfrimResult2 = methods.GetText(confirmResult);
            Assert.That(finalconfrimResult2, Is.EqualTo("You selected Cancel"));

            //User click fourth “click me” button
            methods.ClickElement(FourthAlertBtn);
            methods.WaitUntilAlertIsPresent();
            var fourthAlert = driver.SwitchTo().Alert();

            //An alert with text box should appear
            Assert.That(fourthAlert.Text, Is.EqualTo("Please enter your name"));

            //User tapes in text box
            fourthAlert.SendKeys(keyToBox);

            //User click “OK” button on the alert
            fourthAlert.Accept();

            //An alert should disappear and there should be a green text with short message and what user taped (u cant get URL if you are on alert frame/window)
            Assert.That(methods.GetCurrentUrl, Is.EqualTo(alertsURL));
            Assert.IsTrue(methods.CheckIfElementExist(promptResult));
            string finalPromptResult = methods.GetText(promptResult);
            Assert.That(finalPromptResult, Is.EqualTo("You entered " + keyToBox));

            //User click fourth “click me” button
            methods.ClickElement(FourthAlertBtn);
            methods.WaitUntilAlertIsPresent();
            var fourthAlert2 = driver.SwitchTo().Alert();

            //An alert with text box should appear
            Assert.That(fourthAlert2.Text, Is.EqualTo("Please enter your name"));

            //User click “Cancel” button on the alert
            fourthAlert2.Dismiss();

            //An alert and green text should disappear (u cant get URL if you are on alert frame/window)
            Assert.That(methods.GetCurrentUrl, Is.EqualTo(alertsURL));
            bool wkurw = methods.CkeckIfElementNOTExist(promptResult);
            Assert.IsTrue(wkurw);

        }

        [Test]
        public void TC_afw3()
        {
            var methods = new Method(driver);
            string demoqaAFWUrl = "https://demoqa.com/alertsWindows";
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);

            //variables
            string smallModal = "Small Modal";
            string largeModal = "Large Modal";

            //Xpaths
            string AFWMenu = "//div[contains(@class,'element-list collapse show')]";
            string modalDialogsContainer = "//div[@id='modalWrapper']";
            string smallModalWaiter = "//div[@class='modal-footer']";
            string smallModalHeader = "//div[@class='modal-header']";
            string largeModalWaiter = "//div[@class='modal-footer']";
            string largeModalHeader = "//div[@id='example-modal-sizes-title-lg']";
            string modalContent = "//div[@class='modal-content']";


            //Xpaths of buttons
            string moveToBtn = "//body/div[@id='app']/div/div/div/div/div/div/div[4]/span[1]/div[1]";
            string modalDialogsBtn = "//span[normalize-space()='Modal Dialogs']";
            string smallModalBtn = "//button[@id='showSmallModal']";
            string smallModalCloseBtn = "//button[@id='closeSmallModal']";
            string largeModalBtn = "//button[@id='showLargeModal']";
            string largeModalCloseBtn = "//button[@id='closeLargeModal']";
            string xCloseBtn = "//span[@aria-hidden='true']";


            //Xpaths of results



            methods.GoToUrl(demoqaAFWUrl);
            methods.WaitUntilVisible(AFWMenu);

            //User click “Modal dialogs” button from the left menu side bar
            methods.MoveToElement(moveToBtn);
            methods.ClickElement(modalDialogsBtn);
            methods.WaitUntilVisible(modalDialogsContainer);

            //User click first button “small modal”
            methods.ClickElement(smallModalBtn);

            //Small modal message should appear on the screen
            methods.WaitUntilElementExists(smallModalWaiter);
            Assert.IsTrue(methods.CheckIfElementExist(modalContent));
            Assert.That(methods.GetText(smallModalHeader), Is.Not.Empty.And.Contains(smallModal));

            //User click “Close” button
            methods.ClickElement(smallModalCloseBtn);

            //Modal should disappear
            methods.WaitUntilInvisible(modalContent);
            Assert.IsTrue(methods.CkeckIfElementNOTExist(modalContent));

            //User click first button “small modal”
            methods.ClickElement(smallModalBtn);

            //Small modal message should appear on the screen
            methods.WaitUntilElementExists(smallModalWaiter);
            Assert.IsTrue(methods.CheckIfElementExist(modalContent));
            Assert.That(methods.GetText(smallModalHeader), Is.Not.Empty.And.Contains(smallModal));

            //User click small “x” button on the top right corner of the modal
            methods.ClickElement(xCloseBtn);

            //Modal should disappear
            methods.WaitUntilInvisible(modalContent);
            Assert.IsTrue(methods.CkeckIfElementNOTExist(modalContent));

            //User click second button “large modal”
            methods.ClickElement(largeModalBtn);

            //Large modal message should appear on the screen
            methods.WaitUntilElementExists(largeModalWaiter);
            Assert.IsTrue(methods.CheckIfElementExist(modalContent));
            Assert.That(methods.GetText(largeModalHeader), Is.Not.Empty.And.Contains(largeModal));

            //User click “Close” button
            methods.ClickElement(largeModalCloseBtn);

            //Modal should disappear
            methods.WaitUntilInvisible(modalContent);
            Assert.IsTrue(methods.CkeckIfElementNOTExist(modalContent));

            //User click second button “large modal”
            methods.ClickElement(largeModalBtn);

            //Large modal message should appear on the screen
            methods.WaitUntilElementExists(largeModalWaiter);
            Assert.IsTrue(methods.CheckIfElementExist(modalContent));
            Assert.That(methods.GetText(largeModalHeader), Is.Not.Empty.And.Contains(largeModal));

            //User click “Close” button
            methods.ClickElement(xCloseBtn);

            //Modal should disappear
            methods.WaitUntilInvisible(modalContent);
            Assert.IsTrue(methods.CkeckIfElementNOTExist(modalContent));

        }


        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
