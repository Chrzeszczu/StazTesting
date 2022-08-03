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
using SeleniumExtras.WaitHelpers;

namespace StazTesting.PageObjects
{
    internal class POAlertsFramesWindowsBrowserWindows
    {
        private IWebDriver _driver;

        //Urls
        string demoqaAFWUrl = "https://demoqa.com/alertsWindows";

        //BUTTONS
        [FindsBy(How = How.XPath, Using = "//body/div[@id='app']/div/div/div/div/div/div/div[4]/span[1]/div[1]")]
        [CacheLookup]
        private IWebElement elem_btn_move_to;

        [FindsBy(How = How.XPath, Using = "//span[normalize-space()='Browser Windows']")]
        [CacheLookup]
        private IWebElement elem_btn_browse_windows;

        [FindsBy(How = How.XPath, Using = "//button[@id='tabButton']")]
        private IWebElement elem_btn_new_tab;

        [FindsBy(How = How.XPath, Using = "//button[@id='windowButton']")]
        private IWebElement elem_btn_new_window;

        [FindsBy(How = How.XPath, Using = "//button[@id='messageWindowButton']")]
        private IWebElement elem_btn_new_window_with_message;


        //CONTAINERS
        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'element-list collapse show')]")]
        private IWebElement elem_container_AFW_menu;

        [FindsBy(How = How.XPath, Using = "//div[@id='browserWindows']")]
        private IWebElement elem_container_browser;

        [FindsBy(How = How.XPath, Using = "//h1[@id='sampleHeading']")]
        private IWebElement elem_container_new_tab;

        

        //[FindsBy(How = How.XPath, Using = "")]
        //private IWebElement elem_btn_;

        public POAlertsFramesWindowsBrowserWindows(IWebDriver driver)
        {
            this._driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void goToPage()
        {
            _driver.Navigate().GoToUrl(demoqaAFWUrl);
            WaitForAFWMenu();
        }
        public void ClickBrowseWindowsBtn()
        {
            MoveToLastBtn();
            elem_btn_browse_windows.Click();
            WaitForBrowserContainer();
        }
        public void ClickNewTabBtn()
        {
            var methods = new Method(_driver);
            elem_btn_new_tab.Click();
            methods.SwitchToAnotherTab(2);
            WaitUntilNewTabVisible();
        }
        public void GetBackFromTab()
        {
            var methods = new Method(_driver);
            methods.CloseTab();
            methods.SwitchToAnotherTab(1);
            methods.Refresh();
            WaitForBrowserContainer();
        }
        public void ClickNewWindowBtn()
        {
            var methods = new Method(_driver);
            elem_btn_new_window.Click();
            methods.SwitchToAnotherTab(2);
            WaitUntilNewTabVisible();
        }
        public void ClickNewWindowWithMessageBtn()
        {
            var methods = new Method(_driver);
            elem_btn_new_window_with_message.Click();
            methods.SwitchToAnotherTab(2);
        }

        public void MoveToLastBtn()
        {
            Actions actions = new Actions(_driver);
            actions.MoveToElement(elem_btn_move_to).Perform();
        }

        //WAITS 
        private void WaitForAFWMenu()
        {
            var methods = new Method(_driver);
            methods.WaitUntilVisible("//div[contains(@class,'element-list collapse show')]");
        }
        private void WaitForBrowserContainer()
        {
            var methods = new Method(_driver);
            methods.WaitUntilVisible("//div[@id='browserWindows']");
        }
        private void WaitUntilNewTabVisible()
        {
            var methods = new Method(_driver);
            methods.WaitUntilVisible("//h1[@id='sampleHeading']");
        }
    }
    internal class POAlertsFramesWindowsAlerts
    {
        private IWebDriver _driver;

        //Urls
        string demoqaAFWUrl = "https://demoqa.com/alertsWindows";

        //BUTTONS
        [FindsBy(How = How.XPath, Using = "//body/div[@id='app']/div/div/div/div/div/div/div[4]/span[1]/div[1]")]
        [CacheLookup]
        private IWebElement elem_btn_move_to;

        [FindsBy(How = How.XPath, Using = "//span[normalize-space()='Alerts']")]
        [CacheLookup]
        private IWebElement elem_btn_alerts;

        [FindsBy(How = How.XPath, Using = "//button[@id='alertButton']")]
        private IWebElement elem_btn_first_alert;

        [FindsBy(How = How.XPath, Using = "//button[@id='timerAlertButton']")]
        private IWebElement elem_btn_second_alert;

        [FindsBy(How = How.XPath, Using = "//button[@id='confirmButton']")]
        private IWebElement elem_btn_third_alert;

        [FindsBy(How = How.XPath, Using = "//button[@id='promtButton']")]
        private IWebElement elem_btn_fourth_alert;


        //CONTAINERS
        [FindsBy(How = How.XPath, Using = "//div[@id='javascriptAlertsWrapper']")]
        private IWebElement elem_container_alerts;

        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'element-list collapse show')]")]
        private IWebElement elem_container_AFW_menu;



        //RESULTS
        [FindsBy(How = How.XPath, Using = "//span[@id='confirmResult']")]
        private IWebElement elem_result_confirm;

        [FindsBy(How = How.XPath, Using = "//span[@id='promptResult']")]
        private IWebElement elem_result_prompt;







        //[FindsBy(How = How.XPath, Using = "")]
        //private IWebElement elem_btn_;

        public POAlertsFramesWindowsAlerts(IWebDriver driver)
        {
            this._driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void goToPage()
        {
            _driver.Navigate().GoToUrl(demoqaAFWUrl);
            WaitForAFWMenu();
        }
        public void ClickAlertsBtn()
        {
            MoveToLastBtn();
            elem_btn_alerts.Click();
            WaitForAlertsContainer();
        }
        public void ClickFirstAlert()
        {
            elem_btn_first_alert.Click();
            WaitForAlert();
        }
        public void ClickSecondAlert()
        {
            elem_btn_second_alert.Click();
            WaitForAlert();
        }
        public void ClickThirdAlert()
        {
            elem_btn_third_alert.Click();
            WaitForAlert();
        }
        public void ClickFourthAlert()
        {
            elem_btn_fourth_alert.Click();
            WaitForAlert();
        }

        public IAlert SwitchToAlert() => _driver.SwitchTo().Alert();

        public void AcceptAlert()
        {
            _driver.SwitchTo().Alert().Accept();
        }
        public void DismissAlert()
        {
            _driver.SwitchTo().Alert().Dismiss();
        }

        public string GetConfirmTxt() => elem_result_confirm.Text;
        public string GetPromptTxt() => elem_result_prompt.Text;



        public bool ChekIfConfirmMessageIsDisplayed()
        {
            var methods = new Method(_driver);
            return methods.CheckIfElementExist(elem_result_confirm);
        }
        public bool ChekIfPromptMessageIsDisplayed()
        {
            var methods = new Method(_driver);
            return methods.CheckIfElementExist(elem_result_prompt);
        }
        public void MoveToLastBtn()
        {
            Actions actions = new Actions(_driver);
            actions.MoveToElement(elem_btn_move_to).Perform();
        }

        //WAITS 
        private void WaitForAFWMenu()
        {
            var methods = new Method(_driver);
            methods.WaitUntilVisible("//div[contains(@class,'element-list collapse show')]");
        }
        private void WaitForAlertsContainer()
        {
            var methods = new Method(_driver);
            methods.WaitUntilVisible("//div[@id='javascriptAlertsWrapper']");
        }
        private void WaitUntilNewTabVisible()
        {
            var methods = new Method(_driver);
            methods.WaitUntilVisible("//h1[@id='sampleHeading']");
        }
        private void WaitForAlert()
        {
            var methods = new Method(_driver);
            methods.WaitUntilAlertIsPresent();
        }
    }

    internal class POAlertsFramesWindowsModals
    {
        private IWebDriver _driver;

        //Urls
        string demoqaAFWUrl = "https://demoqa.com/alertsWindows";

        //BUTTONS
        [FindsBy(How = How.XPath, Using = "//body/div[@id='app']/div/div/div/div/div/div/div[4]/span[1]/div[1]")]
        [CacheLookup]
        private IWebElement elem_btn_move_to;

        [FindsBy(How = How.XPath, Using = "//span[normalize-space()='Modal Dialogs']")]
        [CacheLookup]
        private IWebElement elem_btn_modal_dialogs;



        //CONTAINERS
        [FindsBy(How = How.XPath, Using = "//div[@id='modalWrapper']")]
        private IWebElement elem_container_modal_dialog;

        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'element-list collapse show')]")]
        private IWebElement elem_container_AFW_menu;

        [FindsBy(How = How.XPath, Using = "//button[@id='showSmallModal']")]
        private IWebElement elem_btn_small_modal;

        [FindsBy(How = How.XPath, Using = "//button[@id='closeSmallModal']")]
        private IWebElement elem_btn_small_modal_close;

        [FindsBy(How = How.XPath, Using = "//button[@id='showLargeModal']")]
        private IWebElement elem_btn_large_modal;

        [FindsBy(How = How.XPath, Using = "//button[@id='closeLargeModal']")]
        private IWebElement elem_btn_large_modal_close;

        [FindsBy(How = How.XPath, Using = "//span[@aria-hidden='true']")]
        private IWebElement elem_btn_x_close;


        //ELEMS
        [FindsBy(How = How.XPath, Using = "//div[@class='modal-footer']")]
        private IWebElement elem_modal_footer;

        [FindsBy(How = How.XPath, Using = "//div[@class='modal-header']")]
        private IWebElement elem_small_modal_header;

        [FindsBy(How = How.XPath, Using = "//div[@id='example-modal-sizes-title-lg']")]
        private IWebElement elem_large_modal_header;

        //CHECK
        [FindsBy(How = How.XPath, Using = "//div[@class='modal-content']")]
        private IWebElement elem_check_modal_content;


        //[FindsBy(How = How.XPath, Using = "")]
        //private IWebElement elem_btn_;

        public POAlertsFramesWindowsModals(IWebDriver driver)
        {
            this._driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void goToPage()
        {
            _driver.Navigate().GoToUrl(demoqaAFWUrl);
            WaitForAFWMenu();
        }
        public void ClickModalDialogsBtn()
        {
            MoveToLastBtn();
            elem_btn_modal_dialogs.Click();
            WaitForModalDialogsContainer();
        }
        public void ClickSmallModalBtn()
        {
            elem_btn_small_modal.Click();
            WaitForModal();
        }
        public void ClickSmallModalCloseBtn()
        {
            elem_btn_small_modal_close.Click();
            WaitForModalContentToDisappear();
        }
        public void ClickLargeModalBtn()
        {
            elem_btn_large_modal.Click();
            WaitForModal();
        }
        public void ClickLargeModalCloseBtn()
        {
            elem_btn_large_modal_close.Click();
            WaitForModalContentToDisappear();
        }
        public void Click_X_CloseBtn()
        {
            elem_btn_x_close.Click();
            WaitForModalContentToDisappear();
        }

        public string GetSmallModalHeaderTxt() => elem_small_modal_header.Text;
        public string GetLargeModalHeaderTxt() => elem_large_modal_header.Text;



        public void MoveToLastBtn()
        {
            Actions actions = new Actions(_driver);
            actions.MoveToElement(elem_btn_move_to).Perform();
        }

        public bool ChekIfModalIsDisplayed()
        {
            var methods = new Method(_driver);
            return methods.CheckIfElementExist(elem_check_modal_content);
        }

        //WAITS 
        private void WaitForAFWMenu()
        {
            var methods = new Method(_driver);
            methods.WaitUntilVisible("//div[contains(@class,'element-list collapse show')]");
        }
        private void WaitForModalDialogsContainer()
        {
            var methods = new Method(_driver);
            methods.WaitUntilVisible("//div[@id='modalWrapper']");
        }
        private void WaitForModalContentToDisappear()
        {
            var methods = new Method(_driver);
            methods.WaitUntilInvisible("//div[@class='modal-content']");
        }
        private void WaitUntilNewTabVisible()
        {
            var methods = new Method(_driver);
            methods.WaitUntilVisible("//h1[@id='sampleHeading']");
        }

        public void WaitForModal()
        {
            var methods = new Method(_driver);
            methods.WaitUntilElementExists("//div[@class='modal-footer']");
        }

    }
}
