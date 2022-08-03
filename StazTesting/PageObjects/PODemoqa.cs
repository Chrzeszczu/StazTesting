using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StazTesting.Methods;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace StazTesting.PageObjects
{
    internal class PODemoqa
    {
        private IWebDriver _driver;

        //Urls
        string demoqaUrl = "https://demoqa.com/";

        public PODemoqa(IWebDriver driver)
        {
            this. _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "(//a[@href='https://demoqa.com'])[1]")]
        [CacheLookup]
        private IWebElement elem_logo;

        [FindsBy(How = How.XPath, Using = "(//div[@class='home-banner'])[1]")]
        [CacheLookup]
        private IWebElement elem_banner;

        [FindsBy(How = How.XPath, Using = "(//div[@class='card mt-4 top-card'])[1]")]
        [CacheLookup]
        private IWebElement elem_elements_btn;

        [FindsBy(How = How.XPath, Using = "(//div[@class='card mt-4 top-card'])[2]")]
        [CacheLookup]
        private IWebElement elem_forms_btn;

        [FindsBy(How = How.XPath, Using = "(//div[@class='card mt-4 top-card'])[3]")]
        [CacheLookup]
        private IWebElement elem_alerts_frame_window_btn;

        [FindsBy(How = How.XPath, Using = "(//div[@class='card mt-4 top-card'])[4]")]
        [CacheLookup]
        private IWebElement elem_widgets_btn;

        [FindsBy(How = How.XPath, Using = "(//div[@class='card mt-4 top-card'])[5]")]
        [CacheLookup]
        private IWebElement elem_interactions_btn;

        [FindsBy(How = How.XPath, Using = "(//div[@class='card mt-4 top-card'])[6]")]
        [CacheLookup]
        private IWebElement elem_bookstore_app_btn;

        [FindsBy(How = How.XPath, Using = "//div[@id='no-cookie-warning']")]
        [CacheLookup]
        private IWebElement elem_no_cookie_warning_wait;

        [FindsBy(How = How.XPath, Using = "//div[@class='category-cards']")]
        [CacheLookup]
        private IWebElement elem_cards_wait;

        [FindsBy(How = How.XPath, Using = "//img[@src='/images/Toolsqa.jpg']")]
        [CacheLookup]
        private IWebElement elem_logo_wait;

        //[FindsBy(How = How.XPath, Using = )]
        //[CacheLookup]
        //private IWebElement elem_;

        public void goToPage()
        {
            _driver.Navigate().GoToUrl(demoqaUrl);
        }
        public void ClickLogo()
        {
            elem_logo.Click();
        }
        public void ClickBanner()
        {
            var methods = new Method(_driver);
            elem_banner.Click();
            methods.SwitchToAnotherTab(2);
            WaitForDisableCookies();
        }
        public void GetBackFromBanner()
        {
            var methods = new Method(_driver);
            methods.CloseTab();
            methods.SwitchToAnotherTab(1);
        }
        public void ClickElements()
        {
            MoveToBottomOfPage();
            elem_elements_btn.Click();
            WaitForLogo();
        }
        public void MoveToBottomOfPage()
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight - 150)");
        }
        public void MoveByOff()
        {
            Actions actions = new Actions(_driver);
            actions.MoveByOffset(0,700).Perform();
        }
        public void ClickForsm()
        {
            MoveToBottomOfPage();
            elem_forms_btn.Click();
            WaitForLogo();
        }
        public void ClickAFW()
        {
            MoveToBottomOfPage();
            elem_alerts_frame_window_btn.Click();
            WaitForLogo();
        }
        public void ClickWidegts()
        {
            MoveToBottomOfPage();
            elem_widgets_btn.Click();
            WaitForLogo();
        }
        public void ClickInteractions()
        {
            MoveToBottomOfPage();
            elem_interactions_btn.Click();
            WaitForLogo();
            
        }
        public void ClickBookstoreApp()
        {
            MoveToBottomOfPage();
            elem_bookstore_app_btn.Click();
            WaitForLogo();
            
        }
        public void WaitForDisableCookies()
        {
            var methods = new Method(_driver);
            methods.WaitUntilVisible("//div[@id='no-cookie-warning']");
            //elem_no_cookie_warning_wait.Displayed;
        }
        public void GoBackAndWaitForCards()
        {
            var methods = new Method(_driver);
            methods.GoBack();
            methods.WaitUntilVisible("//div[@class='category-cards']");
            //elem_cards_wait.Click();
        }
        public void WaitForLogo()
        {
            var methods = new Method(_driver);
            methods.WaitUntilVisible("//img[@src='/images/Toolsqa.jpg']");
            //elem_no_cookie_warning_wait.Click();
        }

    }
}
