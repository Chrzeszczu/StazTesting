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
    internal class POWidgetsAccordion
    {
        private IWebDriver _driver;

        //Urls
        string demoqaAFWUrl = "https://demoqa.com/widgets";

        //BUTTONS
        [FindsBy(How = How.XPath, Using = "//body/div[@id='app']/div/div/div/div/div/div/div[5]/span[1]/div[1]/div[1]")]
        [CacheLookup]
        private IWebElement elem_btn_move_to;

        [FindsBy(How = How.XPath, Using = "//body//div//div[1]//div[1]//div[4]//div[1]//ul[1]//li[1]")]
        [CacheLookup]
        private IWebElement elem_btn_acc;

        [FindsBy(How = How.XPath, Using = "//body[1]/div[2]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[4]/div[1]/ul[1]/li[5]")]
        private IWebElement elem_btn_move_to_progress_bar;

        [FindsBy(How = How.XPath, Using = "//div[normalize-space()='What is Lorem Ipsum?']")]
        private IWebElement elem_btn_what_is_lorem_ipsum;

        [FindsBy(How = How.XPath, Using = "//div[normalize-space()='Where does it come from?']")]
        private IWebElement elem_btn_where_does_it_come_from;

        [FindsBy(How = How.XPath, Using = "//div[normalize-space()='Why do we use it?']")]
        private IWebElement elem_btn_why_do_we_use_it;



        //CONTAINERS
        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'element-list collapse show')]")]
        private IWebElement elem_container_widegts_menu;

        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'element-list collapse show')]//li[1]")]
        private IWebElement elem_container_acc;


        //WAITS
        [FindsBy(How = How.XPath, Using = "//p[contains(text(),'Lorem Ipsum is simply dummy text of the printing a')]")]
        private IWebElement elem_wait_first_acc_txt;

        [FindsBy(How = How.XPath, Using = "//p[contains(text(),'Contrary to popular belief, Lorem Ipsum is not sim')]")]
        private IWebElement elem_wait_second_acc_txt;

        [FindsBy(How = How.XPath, Using = "//p[contains(text(),'It is a long established fact that a reader will b')]")]
        private IWebElement elem_wait_third_acc_txt;


        //Xpaths for WAITS
        string hidingTxt = "//div[@class='collapse show']";
        string firstAccTxt = "//p[contains(text(),'Lorem Ipsum is simply dummy text of the printing a')]";
        string secondAccTxt = "//p[contains(text(),'Contrary to popular belief, Lorem Ipsum is not sim')]";
        string thirdAccTxt = "//p[contains(text(),'It is a long established fact that a reader will b')]";

        //[FindsBy(How = How.XPath, Using = "")]
        //private IWebElement elem_btn_;

        public POWidgetsAccordion(IWebDriver driver)
        {
            this._driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void goToPage()
        {
            _driver.Navigate().GoToUrl(demoqaAFWUrl);
            WaitForWidgetsMenu();
        }
        public void ClickAccBtn()
        {
            MoveToLastBtn();
            elem_btn_acc.Click();
            WaitForAccContainer();
        }
        public void ClickFirstAccBtn()
        {
            var methods = new Method(_driver);
            bool check = methods.CheckIfElementIsVisible(firstAccTxt);
            if(check == true)
            {
                elem_btn_what_is_lorem_ipsum.Click();
                WaitForFirstAccDisappear();
            }
            else
            {
                elem_btn_what_is_lorem_ipsum.Click();
                WaitForFirstAcc();
            }
        }
        public void ClickSecondAccBtn()
        {
            var methods = new Method(_driver);
            bool check = methods.CheckIfElementIsVisible(firstAccTxt);
            if (check == true)
            {
                elem_btn_where_does_it_come_from.Click();
                WaitForSecondtAccDisappear();
            }
            else
            {
                elem_btn_where_does_it_come_from.Click();
                WaitForSecondtAcc();
            }
        }
        public void ClickThirdAccBtn()
        {
            var methods = new Method(_driver);
            bool check = methods.CheckIfElementIsVisible(firstAccTxt);
            if (check == true)
            {
                elem_btn_why_do_we_use_it.Click();
                WaitForThirdAccDisappear();
            }
            else
            {
                elem_btn_why_do_we_use_it.Click();
                WaitForThirdAcc();
            }
        }

        public string GetAccBtnTxt() => elem_btn_acc.Text;


        public void MoveToLastBtn()
        {
            Actions actions = new Actions(_driver);
            actions.MoveToElement(elem_btn_move_to).Perform();
        }
        public void MoveToProgressBarBtn()
        {
            Actions actions = new Actions(_driver);
            actions.MoveToElement(elem_btn_move_to_progress_bar).Perform();
        }
        public bool ChekIfFirstAccIsDisplayed()
        {
            var methods = new Method(_driver);
            return methods.CheckIfElementExist(elem_wait_first_acc_txt);
        }
        public bool ChekIfSecondAccIsDisplayed()
        {
            var methods = new Method(_driver);
            return methods.CheckIfElementExist(elem_wait_second_acc_txt);
        }
        public bool ChekIfThirdAccIsDisplayed()
        {
            var methods = new Method(_driver);
            return methods.CheckIfElementExist(elem_wait_third_acc_txt);
        }

        //WAITS 
        private void WaitForWidgetsMenu()
        {
            var methods = new Method(_driver);
            methods.WaitUntilVisible("//div[contains(@class,'element-list collapse show')]");
        }
        private void WaitForAccContainer()
        {
            var methods = new Method(_driver);
            methods.WaitUntilVisible("//div[contains(@class,'element-list collapse show')]//li[1]");
        }
        private void WaitForFirstAccDisappear()
        {
            var methods = new Method(_driver);
            methods.WaitUntilInvisible(firstAccTxt);
        }
        private void WaitForSecondtAccDisappear()
        {
            var methods = new Method(_driver);
            methods.WaitUntilInvisible(secondAccTxt);
        }
        private void WaitForThirdAccDisappear()
        {
            var methods = new Method(_driver);
            methods.WaitUntilInvisible(thirdAccTxt);
        }
        private void WaitForFirstAcc()
        {
            var methods = new Method(_driver);
            methods.WaitUntilVisible(firstAccTxt);
        }
        private void WaitForSecondtAcc()
        {
            var methods = new Method(_driver);
            methods.WaitUntilVisible(secondAccTxt);
        }
        private void WaitForThirdAcc()
        {
            var methods = new Method(_driver);
            methods.WaitUntilVisible(thirdAccTxt);
        }
    }
}
