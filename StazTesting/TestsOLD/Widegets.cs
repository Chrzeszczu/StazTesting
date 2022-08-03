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

namespace StazTesting.Tests
{
    internal class Widegets
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
        public void TC_elements1()
        {
            var methods = new Method(driver);
            string demoqaWidgetsUrl = "https://demoqa.com/widgets";

            //variables
            string acc = "Accordion";

            //Xpaths
            string widgetsMenu = "//div[contains(@class,'element-list collapse show')]";
            string accContainer = "//div[contains(@class,'element-list collapse show')]//li[1]";

            //Xpaths of buttons
            string moveToBtn = "//body//div//div[1]//div[1]//div[4]//div[1]//ul[1]//li[2]";
            string accBtn = "//body//div//div[1]//div[1]//div[4]//div[1]//ul[1]//li[1]";

            //Xpaths of results

            methods.GoToUrl(demoqaWidgetsUrl);
            methods.WaitUntilVisible(widgetsMenu);

            //User click “Accordion” button from the left menu side bar
            methods.MoveToElement(moveToBtn);
            string accResult = methods.GetText(accBtn);

            //Accordion widget should appear on the main view = There is no button “Accordion”, there is a typo in the word – “Accordian”
            bool finalResult = methods.CheckIfTheSame(accResult, acc);
            Assert.IsFalse(finalResult);

        }

        [Test]
        public void TC_elements2()
        {
            var methods = new Method(driver);
            string demoqaWidgetsUrl = "https://demoqa.com/widgets";

            //variables

            //Xpaths
            string accContainer = "//div[contains(@class,'element-list collapse show')]//li[1]";
            string widgetsMenu = "//div[contains(@class,'element-list collapse show')]";
            string hidingTxt = "//div[@class='collapse show']";
            string firstAccTxt = "//p[contains(text(),'Lorem Ipsum is simply dummy text of the printing a')]";
            string secondAccTxt = "//p[contains(text(),'Contrary to popular belief, Lorem Ipsum is not sim')]";
            string thirdAccTxt = "//p[contains(text(),'It is a long established fact that a reader will b')]";

            //Xpaths of buttons
            string moveToBtn = "//span[normalize-space()='Auto Complete']";
            string moveToBtn2 = "//body[1]/div[2]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[4]/div[1]/ul[1]/li[5]";
            string accBtn = "//div[contains(@class,'element-list collapse show')]//li[1]";
            string whatIsLoreIpsumBtn = "//div[normalize-space()='What is Lorem Ipsum?']";
            string whereDoesItComeFromBtn = "//div[normalize-space()='Where does it come from?']";
            string whyDoWeUseItBtn = "//div[normalize-space()='Why do we use it?']";


            //Xpaths of results


            methods.GoToUrl(demoqaWidgetsUrl);
            methods.WaitUntilVisible(widgetsMenu);

            //User click “Accordion” button from the left menu side bar
            methods.MoveToElement(moveToBtn);
            methods.ClickElement(accBtn);
            methods.WaitUntilElementExists(accContainer);



            //User click on the first accordion button “what is lorem ipsum”
            methods.ClickElement(whatIsLoreIpsumBtn);
            methods.WaitUntilInvisible(firstAccTxt);

            //Text should wrap up to first button
            bool test = methods.CheckIfElementIsNOTVisible(firstAccTxt);
            Assert.IsTrue(test);

            //User click on the second accordion button “Where does it come from”
            methods.ClickElement(whereDoesItComeFromBtn);
            methods.WaitUntilVisible(secondAccTxt);

            //Text should wrap down to second button
            bool test2 = methods.CheckIfElementIsVisible(secondAccTxt);
            Assert.IsTrue(test2);

            //User click on the second accordion button “Where does it come from”
            methods.MoveToElement(moveToBtn2);
            methods.ClickElement(whyDoWeUseItBtn);
            methods.WaitUntilInvisible(secondAccTxt);

            //Text should wrap down to second button
            bool test3 = methods.CheckIfElementIsNOTVisible(secondAccTxt);
            bool test4 = methods.CheckIfElementIsVisible(thirdAccTxt);
            Assert.IsTrue(test3);
            Assert.IsTrue(test4);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
