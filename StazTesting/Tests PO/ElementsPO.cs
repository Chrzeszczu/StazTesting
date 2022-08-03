using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StazTesting.Methods;
using NUnit.Framework;
using StazTesting.PageObjects;

namespace StazTesting.Tests
{
    public class ElementsPO
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
            var Text_Box = new POElementsTxtBox(driver);

            //variables
            string fullName = "Michal";
            string email = "mail@mail.com";
            string currentAddres = "addres";
            string permanentAddres = "addres";


            //driver.Navigate().GoToUrl(demoqaElementsUrl);
            Text_Box.goToPage();
            Text_Box.ClickTxtBox();
            Text_Box.SendKeysFullName(fullName);
            Text_Box.SendKeysEmail(email);
            Text_Box.SendKeysCurrentAddres(currentAddres);
            Text_Box.SendKeysPemanentAddres(permanentAddres);

            //check if box with results is invisible
            Assert.IsFalse(Text_Box.DisplayedOutputBox(), "Box is visible");


            Text_Box.ClickSubmitBtn();
            Text_Box.WaitUntilOutputVisible();
            //check if box with results is visible
            Assert.IsTrue(Text_Box.DisplayedOutputBox(), "Box is invisible");

            Assert.That("Name:" + fullName, Is.EqualTo(Text_Box.GetFullNameTxt()));
            Assert.That("Email:" + email, Is.EqualTo(Text_Box.GetEmailTxt()));
            Assert.That("Current Address :" + currentAddres, Is.EqualTo(Text_Box.GetCurrentAddresTxt()));
            Assert.That("Permananet Address :" + permanentAddres, Is.EqualTo(Text_Box.GetPermanentAddresTxt()));


        }

        [Test]
        public void TC_elements2()
        {
            var methods = new Method(driver);
            var Buttons = new POElementsButtons(driver);


            //variables
            string doubleClick = "You have done a double click";
            string rightClick = "You have done a right click";
            string dynamicClick = "You have done a dynamic click";


            Buttons.goToPage();

            //User click “Buttons” button from the left side menu bar
            Buttons.CLickButtonsBtn();

            //User left-click the "double click me" button
            Buttons.ClickDoubleClickBtn();

            //nothing should change
            Assert.IsFalse(Buttons.ChekIfDoubleClickMessageIsDisplayed());

            //User double click the "double click me" button
            Buttons.DoubleClickDoubleClickBtn();

            //text should appear under the buttons
            Assert.That(Buttons.GetDoubleClickMessage, Is.EqualTo(doubleClick));

            //User right-click the "right click me" button
            Buttons.RigthClickRightClickBtn();

            //text should appear under the buttons
            Assert.That(Buttons.GetRightClickMessage, Is.EqualTo(rightClick));

            //User left-click the "right click me" button
            Buttons.Refresh();

            Buttons.ClickRightClickBtn();
            //nothing should change
            Assert.IsFalse(Buttons.ChekIfRightClickMessageIsDisplayed());

            //User left-click the "right click me" button
            Buttons.ClickDynamicClickBtn();

            //data from boxes should appear under the button
            Assert.That(Buttons.GetDynamicClickMessage, Is.EqualTo(dynamicClick));

        }

        [Test]
        public void TC_elements3()
        {
            var methods = new Method(driver);
            var t = new POElementsRadioButtons(driver);

            string firstResult = "You have selected Yes";
            string secondResult = "You have selected Impressive";




            //driver.Navigate().GoToUrl(demoqaElementsUrl);
            t.goToPage();

            //User click “Radio button” button from the left side menu bar
            t.CLickRadioButtnonsBtn();
            //methods.SleepInMiliseconds(500);

            //User click “yes” button
            t.CLickYesBtn();

            //Text should appear under the buttons with the text – “You have selected Yes”
            Assert.That(t.GetResultTxt(), Is.EqualTo(firstResult));

            //User click “impressive” button
            t.CLickImpressiveBtn();

            //Text should appear under the buttons with the text – "You have selected Impressive"
            Assert.That(t.GetResultTxt(), Is.EqualTo(secondResult));

            // User click “no” button
            methods.Refresh();
            t.CLickNoBtn();

            //Button should be blocked and user cannot click it = no results
            Assert.IsFalse(t.ChekIfResultIsDisplayed());


        }

        [Test]
        public void TC_elements4()
        {
            var WebTables = new POElementsTabels(driver);

            //driver.Navigate().GoToUrl(demoqaElementsUrl);
            WebTables.goToPage();

            //User click “Web Tables” button from the left side menu bar
            WebTables.CLickWebTablesBtn();

            //user click “Add” button above form
            WebTables.ClickAddBtn();
            //Thread.Sleep(1000);

            //User tapes in “First name” box
            WebTables.SendKeysFirstName("michal");

            //User tapes in “Last name” box
            WebTables.SendKeysLastName(@"@%#&");

            //User tapes in “Email” box
            WebTables.SendKeysEmail(@"####@####.com ");

            //User tapes in “Age” box
            WebTables.SendKeysAge("99");

            //User tapes in “Salary” box
            WebTables.SendKeysSalary("-100");

            //User tapes in “Department” box
            WebTables.SendKeysDepartment("none");

            //User click “submit” button
            WebTables.ClickSubmitBtn();

            //Email and salary boxes should turn red on their border, wrong value from these boxes
            Assert.That(WebTables.BorderColorOfEmailBox(), Is.EqualTo("rgb(220, 53, 69)"));
            Assert.That(WebTables.BorderColorOfSalaryBox(), Is.EqualTo("rgb(220, 53, 69)"));

        }

        [Test]
        public void TC_elements5()
        {
            var WebTables = new POElementsTabels(driver);

            //variables
            string firstNameData = "@%#&";
            string lastNameData = @"michal";
            string emailData = @"mail@mail.com";
            string ageData = "50";
            string salaryData = "100";
            string departmentData = "none";


            //driver.Navigate().GoToUrl(demoqaElementsUrl);
            WebTables.goToPage();

            //User click “Web Tables” button from the left side menu bar
            WebTables.CLickWebTablesBtn();

            //user click “Add” button above form
            WebTables.ClickAddBtn();

            //User tapes in “First name” box
            WebTables.SendKeysFirstName(firstNameData);

            //User tapes in “Last name” box
            WebTables.SendKeysLastName(lastNameData);

            //User tapes in “Email” box
            WebTables.SendKeysEmail(emailData);

            //User tapes in “Age” box
            WebTables.SendKeysAge(ageData);

            //User tapes in “Salary” box
            WebTables.SendKeysSalary(salaryData);

            //User tapes in “Department” box
            WebTables.SendKeysDepartment(departmentData);

            //User click “submit” button
            WebTables.ClickSubmitBtn();

            //methods.SleepInSeconds(10);
            Assert.That(WebTables.GetTextFirstNameFromTable(), Is.EqualTo(firstNameData));
            Assert.That(WebTables.GetTextLastNameFromTable(), Is.EqualTo(lastNameData));
            Assert.That(WebTables.GetTextEmailFromTable(), Is.EqualTo(emailData));
            Assert.That(WebTables.GetTextAgeFromTable(), Is.EqualTo(ageData));
            Assert.That(WebTables.GetTextSalaryFromTable(), Is.EqualTo(salaryData));
            Assert.That(WebTables.GetTextDepartmentFromTable(), Is.EqualTo(departmentData));
        }

        [Test]
        public void TC_elements6()
        {
            var WebTables = new POElementsTabels(driver);

            //Variables
            string empty = " ";
            string firstSearch = "Cier";
            string secondSearch = "2000";
            string thirdSearch = "@$#%";


            //driver.Navigate().GoToUrl(demoqaElementsUrl);
            WebTables.goToPage();

            //User click “Web Tables” button from the left side menu bar
            WebTables.CLickWebTablesBtn();

            //User tapes in search bar right to the “add” button
            WebTables.SendKeysSearchBar(firstSearch);

            //Only one row with someone named “Cierra” should be visible
            Assert.That(WebTables.GetTextFirstRow(), Is.Not.EqualTo(empty).And.Contains(firstSearch));
            Assert.That(WebTables.GetTextSecondRow(), Is.EqualTo(empty));

            //User tapes in search bar right to the “add” button
            WebTables.SendKeysSearchBar(secondSearch);

            //Two rows with salaries should appear – 12000 and 2000
            Assert.That(WebTables.GetTextFirstRowSalary(), Is.Not.EqualTo(empty).And.Contains(secondSearch));
            Assert.That(WebTables.GetTextSecondRowSalary, Is.Not.EqualTo(empty).And.Contains(secondSearch));
            Assert.That(WebTables.GetTextThirdRowSalary, Is.EqualTo(empty));

            //User tapes in search bar right to the “add” button
            WebTables.SendKeysSearchBar(thirdSearch);

            //Now rows should be visible (contains data)
            Assert.That(WebTables.GetTextFirstRow(), Is.EqualTo(empty));
            Assert.That(WebTables.GetTextSecondRow, Is.EqualTo(empty));
        }

        [Test]
        public void TC_elements7()
        {
            var WebTables = new POElementsTabels(driver);

            //Variables
            string previousLastName = "Vega";
            string lastName = "@#$%";
            string previousSalary = "10000";
            string salary = "999";
            string empty = " ";


            //driver.Navigate().GoToUrl(demoqaElementsUrl);
            WebTables.goToPage();

            //User click “Web Tables” button from the left side menu bar
            WebTables.CLickWebTablesBtn();

            //User click pen like button on “Action” column and edit “Salary” text box than press “submit” button
            WebTables.ClickEditdBtn();
            WebTables.SendKeysSalary(salary);
            WebTables.ClickSubmitBtn();

            //Salary from the changed row should changed to value that user chose
            Assert.That(WebTables.GetTextFirstRowSalary, Is.Not.EqualTo(empty).And.Not.EqualTo(previousSalary).And.Contains(salary));

            //User click pen like button on “Action” column and edit “Last Name” text box than press “submit” button
            WebTables.ClickEditdBtn();
            WebTables.SendKeysLastName(lastName);
            WebTables.ClickSubmitBtn();

            //Last Name from the changed row should changed to value that user chose
            Assert.That(WebTables.GetTextFirstRowLastName(), Is.Not.EqualTo(empty).And.Not.EqualTo(previousLastName).And.Contains(lastName));

            //User click on trash like button on “Action” column on the one of the rows
            WebTables.ClickDeleteBtn();

            //Row should disappear from table
            Assert.IsFalse(WebTables.ChekIfFirstRowIsDisplayed());

        }

        [Test]
        public void TC_elements8()
        {
            var methods = new Method(driver);
            var Links = new POElementsLinks(driver);

            //Variables
            string demoqaURL = "https://demoqa.com/";
            string demoqaLinksURL = "https://demoqa.com/links";


            //driver.Navigate().GoToUrl(demoqaElementsUrl);
            Links.goToPage();

            //User click “Links” button from the left side menu bar
            Links.CLickLinksBtn();

            //User click on the first link named “home”
            Links.ClickHomeLink();

            //New browser tab with home page of ToolsQA should open
            Assert.That(methods.GetCurrentUrl, Is.EqualTo(demoqaURL));

            Links.GetBackFromTab();

            Assert.That(methods.GetCurrentUrl, Is.EqualTo(demoqaLinksURL));

            //User click on the second link named “Homeoim”
            Links.ClickDynamicHomeLink();

            //New browser tab with home page of ToolsQA should open
            Assert.That(methods.GetCurrentUrl, Is.EqualTo(demoqaURL));

            Links.GetBackFromTab();

            Assert.That(methods.GetCurrentUrl, Is.EqualTo(demoqaLinksURL));

        }

        [Test]
        public void TC_elements9()
        {
            var Links = new POElementsLinks(driver);


            //Variables
            string createdLinkCode = "201";
            string createdLinkName = "Created";
            string noContentLinkCode = "204";
            string noContentLinkName = "No Content";
            string movedLinkCode = "301";
            string movedLinkName = "Moved Permanently";
            string badRequestLinkCode = "400";
            string badRequestLinkName = "Bad Request";
            string unauthorizedLinkCode = "401";
            string unauthorizedLinkName = "Unauthorized";
            string forbiddenLinkCode = "403";
            string forbiddenLinkName = "Forbidden";
            string notFoundLinkCode = "404";
            string notFoundLinkName = "Not Found";



            //driver.Navigate().GoToUrl(demoqaElementsUrl);
            Links.goToPage();

            //User click “Links” button from the left side menu bar
            Links.CLickLinksBtn();

            //User click on the first link named “Created” under the “Following links will send an api call” section
            Links.ClickCreatedLink();
            //t.WaitUntilLinkResponseContains(createdLinkName);
            //Text should appear under the links with status number and method that was in link name
            Assert.That(Links.GetLinkResponseTxt(), Is.Not.Empty.And.Contains(createdLinkCode).And.Contains(createdLinkName));

            //User click on the second link named “No Content” under the “Following links will send an api call” section
            Links.ClickNoContentLink();
            Links.WaitUntilLinkResponseContains(noContentLinkName);
            //Text should appear under the links with status number and method that was in link name
            Assert.That(Links.GetLinkResponseTxt(), Is.Not.Empty.And.Contains(noContentLinkCode).And.Contains(noContentLinkName));

            //User click on the fourth link named “Moved” under the “Following links will send an api call” section
            Links.ClickMovedLink();
            Links.WaitUntilLinkResponseContains(movedLinkName);
            //Text should appear under the links with status number and method that was in link name
            Assert.That(Links.GetLinkResponseTxt(), Is.Not.Empty.And.Contains(movedLinkCode).And.Contains(movedLinkName));

            //User click on the second link named “Bad Request” under the “Following links will send an api call” section
            Links.ClickBadRequestLink();
            Links.WaitUntilLinkResponseContains(badRequestLinkName);
            //Text should appear under the links with status number and method that was in link name
            Assert.That(Links.GetLinkResponseTxt(), Is.Not.Empty.And.Contains(badRequestLinkCode).And.Contains(badRequestLinkName));

            //User click on the second link named “Unauthorized” under the “Following links will send an api call” section
            Links.ClickUnauthorizedLink();
            Links.WaitUntilLinkResponseContains(unauthorizedLinkName);
            //Text should appear under the links with status number and method that was in link name
            Assert.That(Links.GetLinkResponseTxt(), Is.Not.Empty.And.Contains(unauthorizedLinkCode).And.Contains(unauthorizedLinkName));

            //User click on the second link named “Forbidden” under the “Following links will send an api call” section
            Links.ClickForbiddenLink();
            Links.WaitUntilLinkResponseContains(forbiddenLinkName);
            //Text should appear under the links with status number and method that was in link name
            Assert.That(Links.GetLinkResponseTxt(), Is.Not.Empty.And.Contains(forbiddenLinkCode).And.Contains(forbiddenLinkName));

            //User click on the second link named “Not Found” under the “Following links will send an api call” section
            Links.ClickNotFoundLink();
            Links.WaitUntilLinkResponseContains(notFoundLinkName);
            //Text should appear under the links with status number and method that was in link name
            Assert.That(Links.GetLinkResponseTxt(), Is.Not.Empty.And.Contains(notFoundLinkCode).And.Contains(notFoundLinkName));

        }


        [Test]
        public void TC_elements10()
        {
            var Up_And_Downloads = new POElementsUpAndDownload(driver);

            //Variables
            string file = @"C:\Users\michal.chrzeszczyk\Downloads\sampleFile (3).jpeg";
            string fileName = "sampleFile";
            string lastPath = "fakepath";


            //driver.Navigate().GoToUrl(demoqaElementsUrl);
            Up_And_Downloads.goToPage();

            //User click “Links” button from the left side menu bar
            Up_And_Downloads.CLickUpDownLoadBtn();

            //User click “Download” button
            Up_And_Downloads.CLickDownloadBtn();

            //Samplefile.jpeg should download itself
            Assert.IsTrue(Up_And_Downloads.CheckIfDownloaded(fileName));

            //choose the samplefile.jpeg than press open
            Up_And_Downloads.SendKeysUpload(file);

            //Path to the file should appear under the “choose file” button
            Assert.That(Up_And_Downloads.GetFilePathTxt(), Is.Not.Empty.And.Contains(lastPath));
        }

            [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
        
    }
}
