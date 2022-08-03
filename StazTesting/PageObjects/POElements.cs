using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StazTesting.Methods;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace StazTesting.PageObjects
{
    internal class POElementsTxtBox
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        //Urls
        string demoqaElementsUrl = "https://demoqa.com/elements";

        public POElementsTxtBox(IWebDriver driver)
        {
            this._driver = driver;
            PageFactory.InitElements(driver, this);
        }


        //BUTONS
        [FindsBy(How = How.XPath, Using = "//div[@class='element-list collapse show']//li[@id='item-0']")]
        [CacheLookup]
        private IWebElement elem_btn_txt_box;

        [FindsBy(How = How.XPath, Using = "//button[@id='submit']")]
        [CacheLookup]
        private IWebElement elem_btn_submit;

        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'element-list collapse show')]//li[9]")]
        [CacheLookup]
        private IWebElement elem_btn_last_menu;


        //TXT BOXES
        [FindsBy(How = How.XPath, Using = "//input[@id='userName']")]
        [CacheLookup]
        private IWebElement elem_txt_box_fullname;

        [FindsBy(How = How.XPath, Using = "//input[@id='userEmail']")]
        [CacheLookup]
        private IWebElement elem_txt_box_email;

        [FindsBy(How = How.XPath, Using = "//textarea[@id='currentAddress']")]
        [CacheLookup]
        private IWebElement elem_txt_box_current_addres;

        [FindsBy(How = How.XPath, Using = "//textarea[@id='permanentAddress']")]
        [CacheLookup]
        private IWebElement elem_txt_box_permanent_addres;


        //FOR WAIT
        [FindsBy(How = How.XPath, Using = "//div[@id='output']")]
        [CacheLookup]
        private IWebElement elem_box_output;


        //RESULTS
        [FindsBy(How = How.XPath, Using = "//p[@id='name']")]
        [CacheLookup]
        private IWebElement elem_result_fullname;

        [FindsBy(How = How.XPath, Using = "//p[@id='email']")]
        [CacheLookup]
        private IWebElement elem_result_email;

        [FindsBy(How = How.XPath, Using = "//p[@id='currentAddress']")]
        [CacheLookup]
        private IWebElement elem_result_current_addres;

        [FindsBy(How = How.XPath, Using = "//p[@id='permanentAddress']")]
        [CacheLookup]
        private IWebElement elem_result_permanent_addres;

        //[FindsBy(How = How.XPath, Using = "")]
        //[CacheLookup]
        //private IWebElement elem_;

        public void goToPage()
        {
            _driver.Navigate().GoToUrl(demoqaElementsUrl);
        }
        public void ClickTxtBox()
        {
            elem_btn_txt_box.Click();
        }
        public void ClickSubmitBtn()
        {
            MoveToLastBtn();
            WaitForSubmitBtn();
            elem_btn_submit.Click();
        }
        public void ClickLastMenuBtn()
        {
            elem_btn_last_menu.Click();
        }
        public void SendKeysFullName(string input)
        {
            elem_txt_box_fullname.Clear();
            elem_txt_box_fullname.SendKeys(input);
        }
        public void SendKeysEmail(string input)
        {
            elem_txt_box_email.Clear();
            elem_txt_box_email.SendKeys(input);
        }
        public void SendKeysCurrentAddres(string input)
        {
            elem_txt_box_current_addres.Clear();
            elem_txt_box_current_addres.SendKeys(input);
        }
        public void SendKeysPemanentAddres(string input)
        {
            elem_txt_box_permanent_addres.Clear();
            elem_txt_box_permanent_addres.SendKeys(input);
        }


        //public void SendKeys(string input)
        //{
        //    sample.SendKeys(input);
        //}
        public bool DisplayedOutputBox()
        {
            return elem_box_output.Displayed;
        }

        public void MoveToLastBtn()
        {
            Actions actions = new Actions(_driver);
            actions.MoveToElement(elem_btn_last_menu).Perform() ;
        }
        public void WaitForSubmitBtn()
        {
            var methods = new Method(_driver);
            methods.WaitForElementToBeClickable("//button[@id='submit']");
        }

        public void WaitUntilOutputVisible()
        {
            var methods = new Method(_driver);
            methods.WaitUntilVisible("//div[@id='output']");

        }

        public string GetFullNameTxt()
        {
            return elem_result_fullname.Text;
        }
        public string GetEmailTxt()
        {
            return elem_result_email.Text;
        }
        public string GetCurrentAddresTxt()
        {
            return elem_result_current_addres.Text;
        }
        public string GetPermanentAddresTxt()
        {
            return elem_result_permanent_addres.Text;
        }
    }
    internal class POElementsButtons
    {
        private IWebDriver _driver;

        //Urls
        string demoqaElementsUrl = "https://demoqa.com/elements";


        //BUTTONS
        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'element-list collapse show')]//li[9]")]
        private IWebElement elem_btn_last_menu;

        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'element-list collapse show')]//li[5]")]
        private IWebElement elem_btn_buttons;

        [FindsBy(How = How.XPath, Using = "//button[@id='doubleClickBtn']")]
        private IWebElement elem_btn_double_click;

        [FindsBy(How = How.XPath, Using = "//button[@id='rightClickBtn']")]
        private IWebElement elem_btn_right_click;

        [FindsBy(How = How.XPath, Using = "//button[normalize-space()='Click Me']")]
        private IWebElement elem_btn_dynamic_click;


        //RESULTS
        [FindsBy(How = How.XPath, Using = "//p[@id='doubleClickMessage']")]
        private IWebElement elem_message_double_click;

        [FindsBy(How = How.XPath, Using = "//p[@id='rightClickMessage']")]
        private IWebElement elem_message_right_click;

        [FindsBy(How = How.XPath, Using = "//p[@id='dynamicClickMessage']")]
        private IWebElement elem_message_dynamic_click;


        public POElementsButtons(IWebDriver driver)
        {
                this._driver = driver;
                PageFactory.InitElements(driver, this);
        }


        public void goToPage()
        {
            _driver.Navigate().GoToUrl(demoqaElementsUrl);
        }


        public void CLickButtonsBtn()
        {
            MoveToLastBtn();
            elem_btn_buttons.Click();
        }
        public string GetDoubleClickMessage()
        {
            return elem_message_double_click.Text;
        }
        public string GetRightClickMessage()
        {
            return elem_message_right_click.Text;
        }
        public string GetDynamicClickMessage()
        {
            return elem_message_dynamic_click.Text;
        }
        //public void SendKeys(string input)
        //{
        //    sample.SendKeys(input);
        //}

        public void MoveToLastBtn()
        {
            Actions actions = new Actions(_driver);
            actions.MoveToElement(elem_btn_last_menu).Perform();
        }

        public void ClickDoubleClickBtn()
        {
            WaitForDoubleClickBtn();
            elem_btn_double_click.Click();
        }
        public void DoubleClickDoubleClickBtn()
        {
            WaitForDoubleClickBtn();
            Actions action = new Actions(_driver);
            action.DoubleClick(elem_btn_double_click).Perform();
        }
        public void ClickRightClickBtn()
        {
            WaitForRightClickBtn();
            elem_btn_right_click.Click();
        }
        public void RigthClickRightClickBtn()
        {
            WaitForRightClickBtn();
            Actions action = new Actions(_driver);
            action.ContextClick(elem_btn_right_click).Perform();
        }
        public void ClickDynamicClickBtn()
        {
            WaitForDynamicClickBtn();
            elem_btn_dynamic_click.Click();
        }

        public bool ChekIfDoubleClickMessageIsDisplayed()
        {
            var methods = new Method(_driver);
            return methods.CheckIfElementExist(elem_message_double_click);
        }
        public bool ChekIfRightClickMessageIsDisplayed()
        {
            var methods = new Method(_driver);
            return methods.CheckIfElementExist(elem_message_right_click);
        }
        //WAITS
        private void WaitForDoubleClickBtn()
        {
            var methods = new Method(_driver);
            methods.WaitUntilVisible("//button[@id='doubleClickBtn']");
        }
        private void WaitForRightClickBtn()
        {
            var methods = new Method(_driver);
            methods.WaitUntilVisible("//button[@id='rightClickBtn']");
        }
        private void WaitForDynamicClickBtn()
        {
            var methods = new Method(_driver);
            methods.WaitUntilVisible("//button[normalize-space()='Click Me']");
        }
        public void Refresh()
        {
            _driver.Navigate().Refresh();
        }
        
    }

    internal class POElementsRadioButtons
    {
        private IWebDriver _driver;

        //Urls
        string demoqaElementsUrl = "https://demoqa.com/elements";


        //BUTTONS
        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'element-list collapse show')]//li[9]")]
        private IWebElement elem_btn_last_menu;

        [FindsBy(How = How.XPath, Using = "//body[1]/div[2]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/ul[1]/li[3]")]
        private IWebElement elem_btn_radio_buttons;

        [FindsBy(How = How.XPath, Using = "//label[normalize-space()='Yes']")]
        private IWebElement elem_btn_yes;

        [FindsBy(How = How.XPath, Using = "//label[normalize-space()='Impressive']")]
        private IWebElement elem_btn_impressive;

        [FindsBy(How = How.XPath, Using = "//label[normalize-space()='No']")]
        private IWebElement elem_btn_no;


        //RESULTS
        [FindsBy(How = How.XPath, Using = "//p[1]")]
        private IWebElement elem_result_txt;


        //WAITS
        [FindsBy(How = How.XPath, Using = "//body/div[@id='app']/div/div/div/div/div[2]")]
        private IWebElement elem_wait_radio_buttons_container;


        public POElementsRadioButtons(IWebDriver driver)
        {
            this._driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void goToPage()
        {
            _driver.Navigate().GoToUrl(demoqaElementsUrl);
        }


        public void CLickRadioButtnonsBtn()
        {
            var methods = new Method(_driver);
            MoveToLastBtn();
            elem_btn_radio_buttons.Click();
            methods.SleepInMiliseconds(500);
        }
        public void CLickYesBtn()
        {
            WaitForYesBtn();
            elem_btn_yes.Click();
        }
        public void CLickImpressiveBtn()
        {
            WaitForImpressiveBtn();
            elem_btn_impressive.Click();
        }
        public void CLickNoBtn()
        {
            WaitForNoBtn();
            elem_btn_no.Click();
        }

        public string GetResultTxt() => elem_result_txt.Text;

        public bool ChekIfResultIsDisplayed()
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            var methods = new Method(_driver);
            bool output = methods.CheckIfElementExist(elem_result_txt);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            return output;
        }

        public void MoveToLastBtn()
        {
            Actions actions = new Actions(_driver);
            actions.MoveToElement(elem_btn_last_menu).Perform();
        }

        //WAITS
        private void WaitForYesBtn()
        {
            var methods = new Method(_driver);
            string yesBtnXpath = "//label[normalize-space()='Yes']";
            methods.WaitUntilVisible(yesBtnXpath);
            methods.WaitForElementToBeClickable(yesBtnXpath);
        }
        private void WaitForImpressiveBtn()
        {
            var methods = new Method(_driver);
            string impressiveBtnXpath = "//label[normalize-space()='Impressive']";
            methods.WaitUntilVisible(impressiveBtnXpath);
            methods.WaitForElementToBeClickable(impressiveBtnXpath);
        }
        private void WaitForNoBtn()
        {
            var methods = new Method(_driver);
            string noBtnXpath = "//label[normalize-space()='No']";
            methods.WaitUntilVisible(noBtnXpath);
            methods.WaitForElementToBeClickable(noBtnXpath);
        }


    }

    internal class POElementsTabels
    {
        private IWebDriver _driver;

        //Urls
        string demoqaElementsUrl = "https://demoqa.com/elements";




        //BUTTONS
        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'element-list collapse show')]//li[9]")]
        private IWebElement elem_btn_last_menu;

        [FindsBy(How = How.XPath, Using = "//body[1]/div[2]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/ul[1]/li[4]")]
        private IWebElement elem_btn_web_tables;

        [FindsBy(How = How.XPath, Using = "//button[@id='addNewRecordButton']")]
        private IWebElement elem_btn_add;

        [FindsBy(How = How.XPath, Using = "//button[@id='submit']")]
        private IWebElement elem_btn_submit;

        [FindsBy(How = How.XPath, Using = "(//span[@title='Edit'])[1]")]
        private IWebElement elem_btn_edit;

        [FindsBy(How = How.XPath, Using = "(//span[@title='Delete'])[1]")]
        private IWebElement elem_btn_delete;



        //WAITS
        [FindsBy(How = How.XPath, Using = "//div[@class='modal-content']")]
        private IWebElement elem_wait_registration_form;


        //SEARCHBARS
        [FindsBy(How = How.XPath, Using = "//input[@id='searchBox']")]
        private IWebElement elem_searchbar;


        //SEND KEYS
        [FindsBy(How = How.XPath, Using = "//input[@id='firstName']")]
        private IWebElement elem_sendkeys_first_name;

        [FindsBy(How = How.XPath, Using = "//input[@id='lastName']")]
        private IWebElement elem_sendkeys_last_name;

        [FindsBy(How = How.XPath, Using = "//input[@id='userEmail']")]
        private IWebElement elem_sendkeys_email;

        [FindsBy(How = How.XPath, Using = "//input[@id='age']")]
        private IWebElement elem_sendkeys_age;

        [FindsBy(How = How.XPath, Using = "//input[@id='salary']")]
        private IWebElement elem_sendkeys_salary;

        [FindsBy(How = How.XPath, Using = "//input[@id='department']")]
        private IWebElement elem_sendkeys_department;

        //RESULTS
        [FindsBy(How = How.XPath, Using = "(//div[@role='gridcell'])[22]")]
        private IWebElement elem_result_fourth_row_first_name_column;

        [FindsBy(How = How.XPath, Using = "(//div[@role='gridcell'])[23]")]
        private IWebElement elem_result_fourth_row_last_name_column;

        [FindsBy(How = How.XPath, Using = "(//div[@role='gridcell'])[24]")]
        private IWebElement elem_result_fourth_row_age_column;

        [FindsBy(How = How.XPath, Using = "(//div[@role='gridcell'])[25]")]
        private IWebElement elem_result_fourth_row_email_column;

        [FindsBy(How = How.XPath, Using = "(//div[@role='gridcell'])[26]")]
        private IWebElement elem_result_fourth_row_salary_column;

        [FindsBy(How = How.XPath, Using = "(//div[@role='gridcell'])[27]")]
        private IWebElement elem_result_fourth_row_department_column;

        [FindsBy(How = How.XPath, Using = "(//div[@role='gridcell'])[1]")]
        private IWebElement elem_result_first_row;

        [FindsBy(How = How.XPath, Using = "(//div[@role='gridcell'])[5]")]
        private IWebElement elem_result_first_row_salary;

        [FindsBy(How = How.XPath, Using = "(//div[@role='gridcell'])[8]")]
        private IWebElement elem_result_second_row;

        [FindsBy(How = How.XPath, Using = "(//div[@role='gridcell'])[12]")]
        private IWebElement elem_result_second_row_salary;

        [FindsBy(How = How.XPath, Using = "(//div[@role='gridcell'])[15]")]
        private IWebElement elem_result_third_row;

        [FindsBy(How = How.XPath, Using = "(//div[@role='gridcell'])[19]")]
        private IWebElement elem_result_third_row_salary;

        [FindsBy(How = How.XPath, Using = "(//div[@role='gridcell'])[2]")]
        private IWebElement elem_result_first_row_last_name;

        [FindsBy(How = How.XPath, Using = "//div[normalize-space()='Cierra']")]
        private IWebElement elem_result_first_row_conatians;



        public POElementsTabels(IWebDriver driver)
        {
            this._driver = driver;
            PageFactory.InitElements(driver, this);
        }


        public void goToPage()
        {
            _driver.Navigate().GoToUrl(demoqaElementsUrl);
        }


        public void CLickWebTablesBtn()
        {
            MoveToLastBtn();
            elem_btn_web_tables.Click();
        }

        public void ClickAddBtn()
        {
            elem_btn_add.Click();
            WaitForRegistrationForm();
        }

        public void ClickSubmitBtn()
        {
            var methods = new Method(_driver);
            WaitForSubmitBtn();
            elem_btn_submit.Click();
            methods.SleepInMiliseconds(500);
        }
        public void ClickEditdBtn()
        {
            elem_btn_edit.Click();
            WaitForRegistrationForm();
        }
        public void ClickDeleteBtn()
        {
            elem_btn_delete.Click();
        }



        public string BorderColorOfEmailBox() => elem_sendkeys_email.GetCssValue("border-color");

        public string BorderColorOfSalaryBox() => elem_sendkeys_salary.GetCssValue("border-color");

        public string GetTextFirstNameFromTable() => elem_result_fourth_row_first_name_column.Text;
        public string GetTextLastNameFromTable() => elem_result_fourth_row_last_name_column.Text;
        public string GetTextAgeFromTable() => elem_result_fourth_row_age_column.Text;
        public string GetTextEmailFromTable() => elem_result_fourth_row_email_column.Text;
        public string GetTextSalaryFromTable() => elem_result_fourth_row_salary_column.Text;
        public string GetTextDepartmentFromTable() => elem_result_fourth_row_department_column.Text;
        public string GetTextFirstRow() => elem_result_first_row.Text;
        public string GetTextFirstRowSalary() => elem_result_first_row_salary.Text;
        public string GetTextSecondRow() => elem_result_second_row.Text;
        public string GetTextSecondRowSalary() => elem_result_second_row_salary.Text;
        public string GetTextThirdRow() => elem_result_third_row.Text;
        public string GetTextThirdRowSalary() => elem_result_third_row_salary.Text;
        public string GetTextFirstRowLastName() => elem_result_first_row_last_name.Text;




        public void SendKeysSearchBar(string input)
        {
            elem_searchbar.Clear();
            elem_searchbar.SendKeys(input);
        }

        public void SendKeysFirstName(string input)
        {
            elem_sendkeys_first_name.Clear();
            elem_sendkeys_first_name.SendKeys(input);
        }

        public void SendKeysLastName(string input)
        {
            elem_sendkeys_last_name.Clear();
            elem_sendkeys_last_name.SendKeys(input);
        }

        public void SendKeysEmail(string input)
        {
            elem_sendkeys_email.Clear();
            elem_sendkeys_email.SendKeys(input);
        }

        public void SendKeysAge(string input)
        {
            elem_sendkeys_age.Clear();
            elem_sendkeys_age.SendKeys(input);
        }

        public void SendKeysSalary(string input)
        {
            elem_sendkeys_salary.Clear();
            elem_sendkeys_salary.SendKeys(input);
        }

        public void SendKeysDepartment(string input)
        {
            elem_sendkeys_department.Clear();
            elem_sendkeys_department.SendKeys(input);
        }

        //public void SendKeys(string input)
        //{
        //    sample.SendKeys(input);
        //}

        public void MoveToLastBtn()
        {
            Actions actions = new Actions(_driver);
            actions.MoveToElement(elem_btn_last_menu).Perform();
        }

        public bool ChekIfFirstRowIsDisplayed()
        {
            var methods = new Method(_driver);
            return methods.CheckIfElementExist(elem_result_first_row_conatians);
        }

        //WAITS
        public void WaitForRegistrationForm()
        {
            var methods = new Method(_driver);
            methods.WaitUntilVisible("//div[@class='modal-content']");
        }

        public void WaitForSubmitBtn()
        {
            var methods = new Method(_driver);
            methods.WaitUntilVisible("//button[@id='submit']");
        }
    }

    internal class POElementsLinks
    {
        private IWebDriver _driver;

        //Urls
        string demoqaElementsUrl = "https://demoqa.com/elements";


        //BUTTONS
        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'element-list collapse show')]//li[9]")]
        private IWebElement elem_btn_last_menu;

        [FindsBy(How = How.XPath, Using = "//body[1]/div[2]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/ul[1]/li[6]")]
        private IWebElement elem_btn_links;



        //LINKS
        [FindsBy(How = How.XPath, Using = "//a[@id='simpleLink']")]
        private IWebElement elem_links_home;

        [FindsBy(How = How.XPath, Using = "//a[@id='dynamicLink']")]
        private IWebElement elem_links_dynamic_home;

        [FindsBy(How = How.XPath, Using = "//a[@id='created']")]
        private IWebElement elem_links_created;

        [FindsBy(How = How.XPath, Using = "//a[@id='no-content']")]
        private IWebElement elem_links_no_content;

        [FindsBy(How = How.XPath, Using = "//a[@id='moved']")]
        private IWebElement elem_links_moved;

        [FindsBy(How = How.XPath, Using = "//a[@id='bad-request']")]
        private IWebElement elem_links_bad_request;

        [FindsBy(How = How.XPath, Using = "//a[@id='unauthorized']")]
        private IWebElement elem_links_unauthorized;

        [FindsBy(How = How.XPath, Using = "//a[@id='forbidden']")]
        private IWebElement elem_links_forbidden;

        [FindsBy(How = How.XPath, Using = "//a[@id='invalid-url']")]
        private IWebElement elem_links_not_found;


        //CONTAINERS
        [FindsBy(How = How.XPath, Using = "//body[1]/div[2]/div[1]/div[1]/div[2]/div[2]/div[2]")]
        private IWebElement elem_container_links;


        //WAITS
        [FindsBy(How = How.XPath, Using = "//div[@class='modal-content']")]
        private IWebElement elem_wait_registration_form;


        //RESULTS 
        [FindsBy(How = How.XPath, Using = "//p[@id='linkResponse']")]
        private IWebElement elem_result_link_response;




        public POElementsLinks(IWebDriver driver)
        {
            this._driver = driver;
            PageFactory.InitElements(driver, this);
        }


        public void goToPage()
        {
            _driver.Navigate().GoToUrl(demoqaElementsUrl);
        }


        public void CLickLinksBtn()
        {
            MoveToLastBtn();
            elem_btn_links.Click();
            WaitForLinksContainer();
        }

        public void ClickHomeLink()
        {
            var methods = new Method(_driver);
            elem_links_home.Click();
            methods.SleepInMiliseconds(300);
            methods.SwitchToAnotherTab(2);
            methods.WaitUntilVisible("//body");
        }

        public void ClickDynamicHomeLink()
        {
            var methods = new Method(_driver);
            elem_links_dynamic_home.Click();
            methods.SleepInMiliseconds(300);
            methods.SwitchToAnotherTab(2);
            methods.WaitUntilVisible("//body");
        }

        public void GetBackFromTab()
        {
            var methods = new Method(_driver);
            methods.CloseTab();
            methods.SleepInMiliseconds(500);
            methods.SwitchToAnotherTab(1);
            methods.WaitUntilVisible("//body");
        }

        public void ClickCreatedLink()
        {
            var methods = new Method(_driver);
            methods.SleepInMiliseconds(300);
            MoveToLastBtn();
            elem_links_created.Click();
        }
        public void ClickBadRequestLink()
        {
            elem_links_bad_request.Click();
        }
        public void ClickForbiddenLink()
        {
            elem_links_forbidden.Click();
        }
        public void ClickMovedLink()
        {
            elem_links_moved.Click();
        }
        public void ClickNotFoundLink()
        {
            elem_links_not_found.Click();
        }
        public void ClickNoContentLink()
        {
            elem_links_no_content.Click();
        }
        public void ClickUnauthorizedLink()
        {
            elem_links_unauthorized.Click();
        }


        public string GetLinkResponseTxt() => elem_result_link_response.Text;


        public void MoveToLastBtn()
        {
            Actions actions = new Actions(_driver);
            actions.MoveToElement(elem_btn_last_menu).Perform();
        }

        //WAITS
        public void WaitForLinksContainer()
        {
            var methods = new Method(_driver);
            methods.WaitUntilVisible("//body[1]/div[2]/div[1]/div[1]/div[2]/div[2]/div[2]");
        }
        public void WaitUntilLinkResponseContains(string input)
        {
            var methods = new Method(_driver);
            methods.WaitUntiElementContains("//p[@id='linkResponse']", input);
        }
        public void WaitUntilCreatedContains(string input)
        {
            var methods = new Method(_driver);
            methods.WaitUntiElementContains("//a[@id='created']", input);
        }
        public void WaitUntilNoContentContains(string input)
        {
            var methods = new Method(_driver);
            methods.WaitUntiElementContains("//a[@id='no-content']", input);
        }
        public void WaitUntilMovedContains(string input)
        {
            var methods = new Method(_driver);
            methods.WaitUntiElementContains("//a[@id='moved']", input);
        }
        public void WaitUntilBadRequestContains(string input)
        {
            var methods = new Method(_driver);
            methods.WaitUntiElementContains("//a[@id='bad-request']", input);
        }
        public void WaitUntilUnauthorizedContains(string input)
        {
            var methods = new Method(_driver);
            methods.WaitUntiElementContains("//a[@id='unauthorized']", input);
        }
        public void WaitUntilForbiddenContains(string input)
        {
            var methods = new Method(_driver);
            methods.WaitUntiElementContains("//a[@id='forbidden']", input);
        }
        public void WaitUntilNotFoundContains(string input)
        {
            var methods = new Method(_driver);
            methods.WaitUntiElementContains("//a[@id='invalid-url']", input);
        }

    }

    internal class POElementsUpAndDownload
    {
        private IWebDriver _driver;

        //Urls
        string demoqaElementsUrl = "https://demoqa.com/elements";


        //BUTTONS
        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'element-list collapse show')]//li[9]")]
        private IWebElement elem_btn_last_menu;

        [FindsBy(How = How.XPath, Using = "//body[1]/div[2]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/ul[1]/li[8]")]
        private IWebElement elem_btn_up_down_load;

        [FindsBy(How = How.XPath, Using = "//input[@id='uploadFile']")]
        private IWebElement elem_btn_upload;

        [FindsBy(How = How.XPath, Using = "//a[@id='downloadButton']")]
        private IWebElement elem_btn_download;


        //CONTAINERS
        [FindsBy(How = How.XPath, Using = "//body[1]/div[2]/div[1]/div[1]/div[2]/div[2]/div[2]")]
        private IWebElement elem_container_up_down_load;


        //WAITS
        [FindsBy(How = How.XPath, Using = "//div[@class='modal-content']")]
        private IWebElement elem_wait_registration_form;


        //RESULTS 
        [FindsBy(How = How.XPath, Using = "//p[@id='uploadedFilePath']")]
        private IWebElement elem_result_uploaded_file_path;




        public POElementsUpAndDownload(IWebDriver driver)
        {
            this._driver = driver;
            PageFactory.InitElements(driver, this);
        }


        public void goToPage()
        {
            _driver.Navigate().GoToUrl(demoqaElementsUrl);
        }


        public void CLickUpDownLoadBtn()
        {
            MoveToLastBtn();
            elem_btn_up_down_load.Click();
            WaitForUpDownLoadContainer();
        }
        public void CLickDownloadBtn()
        {
            elem_btn_download.Click();
        }
        public void CLickUploadBtn()
        {
            elem_btn_upload.Click();
        }

        public void SendKeysUpload(string input)
        {
            elem_btn_upload.Clear();
            elem_btn_upload.SendKeys(input);
            WaitForFilePath();
        }


        public string GetFilePathTxt() => elem_result_uploaded_file_path.Text;


        public void MoveToLastBtn()
        {
            Actions actions = new Actions(_driver);
            actions.MoveToElement(elem_btn_last_menu).Perform();
        }
        public bool CheckIfDownloaded(string FileName)
        {
            var methods = new Method(_driver);
            return methods.CheckFileDownloaded(FileName);
        }

        //WAITS
        public void WaitForUpDownLoadContainer()
        {
            var methods = new Method(_driver);
            methods.WaitUntilVisible("//body[1]/div[2]/div[1]/div[1]/div[2]/div[2]/div[2]");
        }
        public void WaitForFilePath()
        {
            var methods = new Method(_driver);
            methods.WaitUntilElementExists("//p[@id='uploadedFilePath']");
        }
    }
}
