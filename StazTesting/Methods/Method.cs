using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace StazTesting.Methods
{
    public class Method
    {

        public readonly IWebDriver _driver;

        public string GetTitle() => _driver.Title;

        public string GetCurrentUrl() => _driver.Url;

        public void SleepInMiliseconds(int miliseconds) => Thread.Sleep(miliseconds);

        public void SleepInSeconds(int miliseconds) => Thread.Sleep(miliseconds * 1000);

        public void SwitchToAnotherTab(int WhichTab) => _driver.SwitchTo().Window(_driver.WindowHandles[WhichTab-1]);

        public void CloseTab() => _driver.Close();

        public Method(IWebDriver webDriver)
        {
            _driver = webDriver;
        }

        public void MaximizeWindow()
        {
            _driver.Manage().Window.Maximize();
        }

        public void WaitForPage()
        {
            _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
        }

        public void WaitForFunctions(int seconds)
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(seconds);
        }

        public void GoToUrl(string URL)
        {
            _driver.Navigate().GoToUrl(URL);
        }

        public void ClickElement(string Xpath)
        {
            _driver.FindElement(By.XPath(Xpath)).Click();
        }

        public void ClickElement(By by)
        {
            _driver.FindElement(by).Click();
        }

        public void SendKeysToElement(string Xpath, string Keys)
        {
            _driver.FindElement(By.XPath(Xpath)).SendKeys(Keys);
        }

        public void SendKeysToElement(By by, string Keys)
        {
            _driver.FindElement(by).SendKeys(Keys);
        }

        public void GoBack()
        {
            _driver.Navigate().Back();
        }

        public void GoForward()
        {
            _driver.Navigate().Forward();
        }

        public void Refresh()
        {
            _driver.Navigate().Refresh();
        }


        public string GetText(string Xpath) => _driver.FindElement(By.XPath(Xpath)).Text;

        public string GetText(By by) => _driver.FindElement(by).Text;



        public void WaitUntilVisible(string Xpath)
        {
            WebDriverWait w = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
            w.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(Xpath)));
        }

        public void WaitUntilVisible(By by)
        {
            WebDriverWait w = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
            w.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(by));
        }


        public void WaitUntilAlertIsPresent()
        {
            WebDriverWait w = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
            w.Until(ExpectedConditions.AlertIsPresent());
        }

        public bool CheckIfElementIsVisible(string Xpath)
        {
            bool displayed = _driver.FindElement(By.XPath(Xpath)).Displayed;
            return displayed;
        }

        public bool CheckIfElementIsVisible(By by)
        {
            bool displayed = _driver.FindElement(by).Displayed;
            return displayed;
        }

        public bool CheckIfElementIsNOTVisible(string Xpath)
        {
            bool displayed = _driver.FindElement(By.XPath(Xpath)).Displayed;
            return !displayed;
        }

        public bool CheckIfElementIsNOTVisible(By by)
        {
            bool displayed = _driver.FindElement(by).Displayed;
            return !displayed;
        }

        public void WaitUntilInvisible(By by)
        {
            WebDriverWait w = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
            w.Until(ExpectedConditions.InvisibilityOfElementLocated(by));
        }

        public void WaitUntilInvisible(string Xpath)
        {
            WebDriverWait w = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
            w.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(Xpath)));
        }


        public void WaitUntilElementExists(string Xpath)
        {
            WebDriverWait w = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
            w.Until(ExpectedConditions.ElementExists(By.XPath(Xpath)));
        }

        public void WaitUntilElementExists(By by)
        {
            WebDriverWait w = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
            w.Until(ExpectedConditions.ElementExists(by));
        }


        public void WaitUntiElementContains(string Xpath, string text)
        {
            WebDriverWait w = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
            w.Until(ExpectedConditions.TextToBePresentInElementLocated(By.XPath(Xpath), text));
        }

        public void WaitUntiElementContains(By by, string text)
        {
            WebDriverWait w = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
            w.Until(ExpectedConditions.TextToBePresentInElementLocated(by, text));
        }

        public void ClickWhenItBeClickable(string Xpath)
        {
            WebDriverWait w = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
            IWebElement element = w.Until(ExpectedConditions.ElementToBeClickable(By.XPath(Xpath)));
            Actions builder = new Actions(_driver);
            builder.MoveToElement(element).Click().Build().Perform();
        }
        public void ClickWhenItBeClickable(By by)
        {
            WebDriverWait w = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
            IWebElement element = w.Until(ExpectedConditions.ElementToBeClickable(by));
            Actions builder = new Actions(_driver);
            builder.MoveToElement(element).Click().Build().Perform();
        }

        public IWebElement WaitForElementToBeClickable(string xpath)
        {
            WebDriverWait w = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
            IWebElement moveToButton = _driver.FindElement(By.XPath(xpath));
            IWebElement element = w.Until(ExpectedConditions.ElementToBeClickable(moveToButton));
            return element;
        }

        public IWebElement WaitForElementToBeClickable(By by)
        {
            WebDriverWait w = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
            IWebElement moveToButton = _driver.FindElement(by);
            IWebElement element = w.Until(ExpectedConditions.ElementToBeClickable(moveToButton));
            return element;
        }

        public void MoveToElement(IWebElement element)
        {
            Actions action = new Actions(_driver);
            action.MoveToElement(element).Perform();
        }

        public void MoveToElement(string xpath)
        {
            Actions action = new Actions(_driver);
            IWebElement element = _driver.FindElement(By.XPath(xpath));
            action.MoveToElement(element).Perform();
        }

        public void MoveToElement(By by)
        {
            Actions action = new Actions(_driver);
            IWebElement element = _driver.FindElement(by);
            action.MoveToElement(element).Perform();
        }

        public void DoubleClickElement(string xpath)
        {
            Actions action = new Actions(_driver);
            IWebElement element = _driver.FindElement(By.XPath(xpath));
            action.DoubleClick(element).Perform();
        }

        public void DoubleClickElement(By by)
        {
            Actions action = new Actions(_driver);
            IWebElement element = _driver.FindElement(by);
            action.DoubleClick(element).Perform();
        }

        public void RightClickElement(string xpath)
        {
            Actions action = new Actions(_driver);
            IWebElement element = _driver.FindElement(By.XPath(xpath));
            action.ContextClick(element).Perform();
        }
        public void RightClickElement(By by)
        {
            Actions action = new Actions(_driver);
            IWebElement element = _driver.FindElement(by);
            action.ContextClick(element).Perform();
        }

        public bool CheckIfElementExist(string Xpath)
        {
            try
            {
                _driver.FindElement(By.XPath(Xpath));
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public bool CheckIfElementExist(By by)
        {
            try
            {
                _driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        public bool CheckIfElementExist(IWebElement element)
        {
            try
            {
                WaitForFunctions(1);
                return element.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public bool CkeckIfElementNOTExist(By by)
        {
            try
            {
                _driver.FindElement(by);
                return false;
            }
            catch (NoSuchElementException)
            {
                return true;
            }
        }

            public bool CkeckIfElementNOTExist(string Xpath)
        {
            try
            {
                _driver.FindElement(By.XPath(Xpath));
                return false;
            }
            catch (NoSuchElementException)
            {
                return true;
            }
        }



        public bool CheckFileDownloaded(string filename)
        {
            bool exist = true;
            string Path = Environment.GetEnvironmentVariable("USERPROFILE") + "\\Downloads";
            string[] filePaths = Directory.GetFiles(Path);
            foreach (string p in filePaths)
            {
                if (p.Contains(filename))
                {
                    FileInfo thisFile = new FileInfo(p);
                    //Check the file that are downloaded in the last 3 minutes
                    if (thisFile.LastWriteTime.ToShortTimeString() == DateTime.Now.ToShortTimeString() ||
                    thisFile.LastWriteTime.AddMinutes(1).ToShortTimeString() == DateTime.Now.ToShortTimeString() ||
                    thisFile.LastWriteTime.AddMinutes(2).ToShortTimeString() == DateTime.Now.ToShortTimeString() ||
                    thisFile.LastWriteTime.AddMinutes(3).ToShortTimeString() == DateTime.Now.ToShortTimeString())
                        exist = true;
                    File.Delete(p);
                    break;
                }
            }
            return exist;
        }

        public bool CheckIfTheSame(string first, string second)
        {
            if (first == second)
                return true;
            else
                return false;
        }

        public IWebElement FindElemnt(string Xpath)
        {
            IWebElement find = _driver.FindElement(By.XPath(Xpath));
            return find;
        }

        public IWebElement FindElemnt(By by)
        {
            IWebElement find = _driver.FindElement(by);
            return find;
        }


        public void DragAndDrop(string From, string To)
        {
            //Element(BANK) which need to drag.		
            IWebElement from = _driver.FindElement(By.XPath(From));
            IWebElement to = _driver.FindElement(By.XPath(To));


            //Using Action class for drag and drop.		
            Actions act = new Actions(_driver);

            //Drag and Drop by Offset.		
            act.DragAndDrop(from, to).Build().Perform();
        }

        public void DragAndDrop(By From, By To)
        {
            IWebElement from = _driver.FindElement(From);
            IWebElement to = _driver.FindElement(To);
	
            Actions act = new Actions(_driver);
	
            act.DragAndDrop(from, to).Build().Perform();
        }

        public void DragAndDropByOffset(string Xpath, int X, int Y)
        {
            IWebElement from = _driver.FindElement(By.XPath(Xpath));

            Actions act = new Actions(_driver);

            act.ClickAndHold(from).MoveByOffset(X, Y).Release().Build().Perform();
        }
        public void DragAndDropByOffset(IWebElement from, int X, int Y)
        {
            Actions act = new Actions(_driver);

            act.ClickAndHold(from).MoveByOffset(X, Y).Release().Build().Perform();
        }

        public void DragAndDropByOffset(By From, int X, int Y)
        {
            IWebElement from = _driver.FindElement(From);

            Actions act = new Actions(_driver);

            act.ClickAndHold(from).MoveByOffset(X, Y).Release().Build().Perform();
        }

        public void DragAndDrop(string From, string To, int X, int Y)
        {
            var from = _driver.FindElement(By.XPath(From));
            var to = _driver.FindElement(By.XPath(To));

            Actions builder1 = new Actions(_driver);
            IAction dragAndDrop1 = builder1.ClickAndHold(from).MoveToElement(to).Release(from).Build();
            dragAndDrop1.Perform();
        }

        public void DragAndDropToElementPlusOffset(string From, string To, int X, int Y)
        {
            var from = _driver.FindElement(By.XPath(From));
            var to = _driver.FindElement(By.XPath(To)).Location;
            int x = to.X;
            int y = to.Y;

            Actions builder1 = new Actions(_driver);
            IAction dragAndDrop1 = builder1.ClickAndHold(from).MoveByOffset(X+x,Y+y-183).Release().Build();
            dragAndDrop1.Perform();
        }
        public void DragAndDropToElementPlusOffset(IWebElement from, IWebElement elem2, int X, int Y)
        {
            var to = elem2.Location;
            int x = to.X;
            int y = to.Y;

            Actions builder1 = new Actions(_driver);
            IAction dragAndDrop1 = builder1.ClickAndHold(from).MoveByOffset(X + x, Y + y - 183).Release().Build();
            dragAndDrop1.Perform();
        }
        public string GetLocationOfElement(IWebElement elem)
        {
            var to = elem.Location;
            int x = to.X;
            int y = to.Y;

            string xtxt = x.ToString();
            string ytxt = y.ToString();

            return xtxt + "x" + ytxt;
        }

        public string GetSize(By by)
        {
            var size = _driver.FindElement(by).Size;
            string first = size.Width.ToString();
            string second = size.Height.ToString();
            string merge = first + " " + second;
            return merge;
        }

        public string GetSize(string Xpath)
        {
            var size = _driver.FindElement(By.XPath(Xpath)).Size;
            string first = size.Width.ToString();
            string second = size.Height.ToString();
            string merge = first + "x" + second;
            return merge;
        }
        public string GetSize(IWebElement elem)
        {
            var size = elem.Size;
            string first = size.Width.ToString();
            string second = size.Height.ToString();
            string merge = first + "x" + second;
            return merge;
        }

        public string UpFirstLetter(string str)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str.ToLower());
        }

        public ChromeOptions SetupOptions()
        {
            string pathToExtension = @"C:\Users\michal.chrzeszczyk\AppData\Local\Google\Chrome\User Data\Default\Extensions\cjpalhdlnbpafiamejdnhcphjbkeiagm\1.43.0_0";
            ChromeOptions options = new ChromeOptions();

            options.AddArgument("--no-experiments");
            options.AddArgument("--disable-translate");
            options.AddArgument("--disable-plugins");
            options.AddArgument("--no-default-browser-check");
            options.AddArgument("--clear-token-service");
            options.AddArgument("--disable-default-apps");
            options.AddArgument("--no-displaying-insecure-content");
            options.AddArgument("load-extension=" + pathToExtension);
            options.AddUserProfilePreference("profile.default_content_setting_values.cookies", 2);
            return options;
        }


    }
}
