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

namespace StazTesting.Tests
{
    public class Elements
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
            string demoqaElementsUrl = "https://demoqa.com/elements";

            //variables
            string fullName = "Michal";
            string email = "mail@mail.com";
            string currentAddres = "addres";
            string permanentAddres = "addres";

            //Xpaths of buttons
            string txtBoxBtn = "//div[@class='element-list collapse show']//li[@id='item-0']";
            string submitBtn = "//button[@id='submit']";
            string lastMenuBtn = "//div[contains(@class,'element-list collapse show')]//li[9]";


            //Xpaths of TextBoxes
            string fullNameTxtBox = "//input[@id='userName']";
            string emailTxtBox = "//input[@id='userEmail']";
            string currentAddresTxtBox = "//textarea[@id='currentAddress']";
            string permanentAddresTxtBox = "//textarea[@id='permanentAddress']";

            //Xpaths for wait
            string outputBox = "//div[@id='output']";

            //Xpaths of results
            string fullNameResult = "//p[@id='name']";
            string emailResult = "//p[@id='email']";
            string currentAddresslNameResult = "//p[@id='currentAddress']";
            string permanentAddressResult = "//p[@id='permanentAddress']";

            //driver.Navigate().GoToUrl(demoqaElementsUrl);
            methods.GoToUrl(demoqaElementsUrl);
            methods.ClickElement(txtBoxBtn);
            methods.SendKeysToElement(fullNameTxtBox, fullName);
            methods.SendKeysToElement(emailTxtBox, email);
            methods.SendKeysToElement(currentAddresTxtBox, currentAddres);
            methods.SendKeysToElement(permanentAddresTxtBox, permanentAddres);

            //check if box with results is invisible
            Assert.IsFalse(driver.FindElement(By.XPath(outputBox)).Displayed, "Box is visible");

            methods.MoveToElement(lastMenuBtn);
            methods.WaitForElementToBeClickable(submitBtn);
            methods.ClickElement(submitBtn);
            methods.WaitUntilVisible(outputBox);

            //check if box with results is visible
            Assert.IsTrue(driver.FindElement(By.XPath(outputBox)).Displayed, "Box is invisible");

            var firstResult = driver.FindElement(By.XPath(fullNameResult)).Text;
            var secondResult = driver.FindElement(By.XPath(emailResult)).Text;
            var thirdResult = driver.FindElement(By.XPath(currentAddresslNameResult)).Text;
            var fourthResult = driver.FindElement(By.XPath(permanentAddressResult)).Text;

            Assert.That("Name:" + fullName, Is.EqualTo(firstResult));
            Assert.That("Email:" + email, Is.EqualTo(secondResult));
            Assert.That("Current Address :" + currentAddres, Is.EqualTo(thirdResult));
            Assert.That("Permananet Address :" + permanentAddres, Is.EqualTo(fourthResult));


        }

        [Test]
        public void TC_elements2()
        {
            var methods = new Method(driver);
            WebDriverWait w = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            string demoqaElementsUrl = "https://demoqa.com/elements";

            //variables


            //Xpaths of buttons
            string lastMenuBtn = "//div[contains(@class,'element-list collapse show')]//li[9]";
            string buttonsBtn = "//div[contains(@class,'element-list collapse show')]//li[5]";
            string doubleClickBtn = "//button[@id='doubleClickBtn']";
            string rightClickBtn = "//button[@id='rightClickBtn']";
            string dynamicClickBtn = "//button[normalize-space()='Click Me']";

            //Actions
            Actions action = new Actions(driver);

            //Xpaths of results
            string doubleClickMessageXpath = "//p[@id='doubleClickMessage']";
            string rightClickMessageXpath = "//p[@id='rightClickMessage']";
            string dynamicClickMessageXpath = "//p[@id='dynamicClickMessage']";


            methods.GoToUrl(demoqaElementsUrl);

            //User click “Buttons” button from the left side menu bar
            methods.MoveToElement(lastMenuBtn);
            methods.ClickWhenItBeClickable(buttonsBtn);

            //User left-click the "double click me" button
            methods.WaitUntilVisible(doubleClickBtn);
            methods.ClickElement(doubleClickBtn);
            //nothing should change
            methods.WaitForFunctions(1);
            bool elementExist1 = methods.CheckIfElementExist(By.XPath(doubleClickMessageXpath));
            Assert.IsFalse(elementExist1);

            //User double click the "double click me" button
            methods.DoubleClickElement(doubleClickBtn);
            string result1 = methods.GetText(doubleClickMessageXpath);
            //text should appear under the buttons
            Assert.That(result1, Is.EqualTo("You have done a double click"));

            //User right-click the "right click me" button
            methods.WaitUntilVisible(rightClickBtn);
            methods.RightClickElement(rightClickBtn);
            string result2 = methods.GetText(rightClickMessageXpath);
            //text should appear under the buttons
            Assert.That(result2, Is.EqualTo("You have done a right click"));

            //User left-click the "right click me" button
            methods.Refresh();
            methods.ClickWhenItBeClickable(rightClickBtn);
            //nothing should change
            bool elementExist2 = methods.CheckIfElementExist(By.XPath(rightClickMessageXpath));
            Assert.IsFalse(elementExist2);

            //User left-click the "right click me" button
            methods.ClickWhenItBeClickable(dynamicClickBtn);
            string result3 = methods.GetText(dynamicClickMessageXpath);
            //data from boxes should appear under the button
            Assert.That(result3, Is.EqualTo("You have done a dynamic click"));

            methods.WaitForFunctions(10);
        }

        [Test]
        public void TC_elements3()
        {
            var methods = new Method(driver);
            string demoqaElementsUrl = "https://demoqa.com/elements";

            //variables

            //Xpaths of buttons
            string radioButtonBtn = "//body[1]/div[2]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/ul[1]/li[3]";
            string yesBtn = "//label[normalize-space()='Yes']";
            string impressiveBtn = "//label[normalize-space()='Impressive']";
            string noBtn = "//label[normalize-space()='No']";
            string moveToBtn = "//body[1]/div[2]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/ul[1]/li[4]";


            //Xpaths of TextBoxes

            //Xpaths of results
            string resultTxt = "//p[1]";
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);


            //driver.Navigate().GoToUrl(demoqaElementsUrl);
            methods.GoToUrl(demoqaElementsUrl);

            //User click “Radio button” button from the left side menu bar
            methods.MoveToElement(moveToBtn);
            methods.ClickElement(radioButtonBtn);

            //User click “yes” button
            methods.WaitUntilVisible(yesBtn);
            methods.ClickWhenItBeClickable(yesBtn);
            //Text should appear under the buttons with the text – “You have selected Yes”
            string result1 = methods.GetText(resultTxt);
            Assert.That(result1, Is.EqualTo("You have selected Yes"));

            //User click “impressive” button
            methods.ClickWhenItBeClickable(impressiveBtn);
            string result2 = methods.GetText(resultTxt);
            Assert.That(result2, Is.EqualTo("You have selected Impressive"));

            // User click “no” button
            methods.Refresh();
            methods.ClickWhenItBeClickable(noBtn);
            bool resultExists = methods.CheckIfElementExist(By.XPath(resultTxt));
            //Button should be blocked and user cannot click it = no results
            Assert.IsFalse(resultExists);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);


        }

        [Test]
        public void TC_elements4()
        {
            var methods = new Method(driver);
            string demoqaElementsUrl = "https://demoqa.com/elements";

            //variables
            string firstNameBoxXpath = "//input[@id='firstName']";
            string lastNameBoxXpath = "//input[@id='lastName']";
            string emailBoxXpath = "//input[@id='userEmail']";
            string ageBoxXpath = "//input[@id='age']";
            string salaryBoxXpath = "//input[@id='salary']";
            string departmentBoxXpath = "//input[@id='department']";
            string registrationFormWindow = "//div[@class='modal-content']";

            //Xpaths of buttons
            string webTablesBtn = "//body[1]/div[2]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/ul[1]/li[4]";
            string addBtn = "//button[@id='addNewRecordButton']";
            string submitFormBtn = "//button[@id='submit']";
            string moveToBtn = "//body[1]/div[2]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/ul[1]/li[5]";

            //Xpaths of TextBoxes

            //Xpaths of results

            //driver.Navigate().GoToUrl(demoqaElementsUrl);
            methods.GoToUrl(demoqaElementsUrl);

            //User click “Web Tables” button from the left side menu bar
            methods.MoveToElement(moveToBtn);
            methods.ClickElement(webTablesBtn);

            //user click “Add” button above form
            methods.ClickElement(addBtn);
            methods.WaitUntilElementExists(registrationFormWindow);
            //Thread.Sleep(1000);

            //User tapes in “First name” box
            methods.SendKeysToElement(firstNameBoxXpath, "michal");

            //User tapes in “Last name” box
            methods.SendKeysToElement(lastNameBoxXpath, @"@%#&");

            //User tapes in “Email” box
            methods.SendKeysToElement(emailBoxXpath, @"####@####.com ");

            //User tapes in “Age” box
            methods.SendKeysToElement(ageBoxXpath, "99");

            //User tapes in “Salary” box
            methods.SendKeysToElement(salaryBoxXpath, "-100");

            //User tapes in “Department” box
            methods.SendKeysToElement(departmentBoxXpath, "none");

            //User click “submit” button
            methods.ClickWhenItBeClickable(submitFormBtn);

            //Email and salary boxes should turn red on their border, wrong value from these boxes
            IWebElement borderOfEmailBox = driver.FindElement(By.XPath(emailBoxXpath));
            IWebElement borderOfSalaryBox = driver.FindElement(By.XPath(salaryBoxXpath));
            Thread.Sleep(500);

            string borderColorOfEmailBox = borderOfEmailBox.GetCssValue("border-color");
            string borderColorOfSalaryBox = borderOfSalaryBox.GetCssValue("border-color");
            Assert.That(borderColorOfEmailBox, Is.EqualTo("rgb(220, 53, 69)"));
            Assert.That(borderColorOfSalaryBox, Is.EqualTo("rgb(220, 53, 69)"));

        }

        [Test]
        public void TC_elements5()
        {
            var methods = new Method(driver);
            string demoqaElementsUrl = "https://demoqa.com/elements";


            //variables
            string firstNameBoxXpath = "//input[@id='firstName']";
            string lastNameBoxXpath = "//input[@id='lastName']";
            string emailBoxXpath = "//input[@id='userEmail']";
            string ageBoxXpath = "//input[@id='age']";
            string salaryBoxXpath = "//input[@id='salary']";
            string departmentBoxXpath = "//input[@id='department']";
            string registrationFormWindow = "//div[@class='modal-content']";

            string firstNameData = "@%#&";
            string lastNameData = @"michal";
            string emailData = @"mail@mail.com";
            string ageData = "50";
            string salaryData = "100";
            string departmentData = "none";

            //Xpaths of buttons
            string webTablesBtn = "//body[1]/div[2]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/ul[1]/li[4]";
            string addBtn = "//button[@id='addNewRecordButton']";
            string submitFormBtn = "//button[@id='submit']";
            string moveToBtn = "//body[1]/div[2]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/ul[1]/li[5]";

            //Xpaths of rows from table
            string fourthRowFirstNameColumn = "(//div[@role='gridcell'])[22]";
            string fourthRowLastNameColumn = "(//div[@role='gridcell'])[23]";
            string fourthRowAgeColumn = "(//div[@role='gridcell'])[24]";
            string fourthRowEmaileColumn = "(//div[@role='gridcell'])[25]";
            string fourthRowSalaryColumn = "(//div[@role='gridcell'])[26]";
            string fourthRowDepartmenteColumn = "(//div[@role='gridcell'])[27]";

            //Xpaths of results

            //driver.Navigate().GoToUrl(demoqaElementsUrl);
            methods.GoToUrl(demoqaElementsUrl);

            //User click “Web Tables” button from the left side menu bar
            methods.MoveToElement(moveToBtn);
            methods.ClickElement(webTablesBtn);

            //user click “Add” button above form
            methods.ClickElement(addBtn);
            methods.WaitUntilElementExists(registrationFormWindow);
            //Thread.Sleep(1000);

            //User tapes in “First name” box
            methods.SendKeysToElement(firstNameBoxXpath, firstNameData);

            //User tapes in “Last name” box
            methods.SendKeysToElement(lastNameBoxXpath, lastNameData);

            //User tapes in “Email” box
            methods.SendKeysToElement(emailBoxXpath, emailData);

            //User tapes in “Age” box
            methods.SendKeysToElement(ageBoxXpath, ageData);

            //User tapes in “Salary” box
            methods.SendKeysToElement(salaryBoxXpath, salaryData);

            //User tapes in “Department” box
            methods.SendKeysToElement(departmentBoxXpath, departmentData);

            //User click “submit” button
            methods.ClickWhenItBeClickable(submitFormBtn);

            //Window should close and new row with data from previous steps should appear under the other rows
            string testText1 = methods.GetText(fourthRowFirstNameColumn);
            string testText2 = methods.GetText(fourthRowLastNameColumn);
            string testText3 = methods.GetText(fourthRowEmaileColumn);
            string testText4 = methods.GetText(fourthRowAgeColumn);
            string testText5 = methods.GetText(fourthRowSalaryColumn);
            string testText6 = methods.GetText(fourthRowDepartmenteColumn);
            //methods.SleepInSeconds(10);
            Assert.That(testText1, Is.EqualTo(firstNameData));
            Assert.That(testText2, Is.EqualTo(lastNameData));
            Assert.That(testText3, Is.EqualTo(emailData));
            Assert.That(testText4, Is.EqualTo(ageData));
            Assert.That(testText5, Is.EqualTo(salaryData));
            Assert.That(testText6, Is.EqualTo(departmentData));
        }

        [Test]
        public void TC_elements6()
        {
            var methods = new Method(driver);
            string demoqaElementsUrl = "https://demoqa.com/elements";

            //Variables
            string empty = " ";
            string firstSearch = "cier";
            string secondSearch = "2000";
            string thirdSearch = "@$#%";
            //Xpaths
            string searchBar = "//input[@id='searchBox']";
            string firstRow = "(//div[@role='gridcell'])[1]";
            string firstRowSalary = "(//div[@role='gridcell'])[5]";
            string secondRow = "(//div[@role='gridcell'])[8]";
            string secondRowSalary = "(//div[@role='gridcell'])[12]";
            string thirdRow = "(//div[@role='gridcell'])[15]";
            string thirdRowSalary = "(//div[@role='gridcell'])[19]";

            //Xpaths of buttons
            string webTablesBtn = "//body[1]/div[2]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/ul[1]/li[4]";
            string moveToBtn = "//body[1]/div[2]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/ul[1]/li[5]";

            //driver.Navigate().GoToUrl(demoqaElementsUrl);
            methods.GoToUrl(demoqaElementsUrl);

            //User click “Web Tables” button from the left side menu bar
            methods.MoveToElement(moveToBtn);
            methods.ClickElement(webTablesBtn);

            //User tapes in search bar right to the “add” button
            methods.SendKeysToElement(searchBar, firstSearch);
            methods.WaitUntilVisible("//div[normalize-space()='Cierra']");

            //Only one row with someone named “Cierra” should be visible
            string searchResultForCier = methods.GetText(firstRow);
            Assert.That(searchResultForCier, Is.Not.EqualTo(empty).And.Contains(methods.UpFirstLetter(firstSearch)));
            Assert.That(methods.GetText(secondRow), Is.EqualTo(empty));

            //User tapes in search bar right to the “add” button
            methods.FindElemnt(searchBar).Clear();
            methods.SendKeysToElement(searchBar, secondSearch);
            methods.WaitUntilVisible("//div[normalize-space()='Alden']");

            //Two rows with salaries should appear – 12000 and 2000
            string searchResultFor2000_01 = methods.GetText(firstRowSalary);
            string searchResultFor2000_02 = methods.GetText(secondRowSalary);
            Assert.That(searchResultFor2000_01, Is.Not.EqualTo(empty).And.Contains(secondSearch));
            Assert.That(searchResultFor2000_02, Is.Not.EqualTo(empty).And.Contains(secondSearch));
            Assert.That(methods.GetText(thirdRowSalary), Is.EqualTo(empty));

            //User tapes in search bar right to the “add” button
            methods.FindElemnt(searchBar).Clear();
            methods.SendKeysToElement(searchBar, thirdSearch);
            methods.WaitUntilVisible("//div[@role='grid']//div[4]//div[1]//div[1]");

            //Now rows should be visible (contains data)
            string searchResultForEmpty_01 = methods.GetText(firstRow);
            string searchResultForEmpty_02 = methods.GetText(secondRow);
            Assert.That(searchResultForEmpty_01, Is.EqualTo(empty));
            Assert.That(searchResultForEmpty_02, Is.EqualTo(empty));
        }

        [Test]
        public void TC_elements7()
        {
            var methods = new Method(driver);
            string demoqaElementsUrl = "https://demoqa.com/elements";

            //Variables
            string previousLastName = "Vega";
            string lastName = "@#$%";
            string previousSalary = "10000";
            string salary = "999";
            string empty = " ";
            //Xpaths
            string lastNameBox = "//input[@id='lastName']";
            string salaryBox = "//input[@id='salary']";
            string registrationFormWindow = "//div[@class='modal-content']";
            string firstRowSallary = "(//div[@role='gridcell'])[5]";
            string firstRowLastName = "(//div[@role='gridcell'])[2]";
            string firstRow = "//div[normalize-space()='Cierra']";

            //Xpaths of buttons
            string webTablesBtn = "//body[1]/div[2]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/ul[1]/li[4]";
            string moveToBtn = "//body[1]/div[2]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/ul[1]/li[5]";
            string editBtn = "(//span[@title='Edit'])[1]";
            string deleteBtn = "(//span[@title='Delete'])[1]";
            string submitFormBtn = "//button[@id='submit']";

            //driver.Navigate().GoToUrl(demoqaElementsUrl);
            methods.GoToUrl(demoqaElementsUrl);

            //User click “Web Tables” button from the left side menu bar
            methods.MoveToElement(moveToBtn);
            methods.ClickElement(webTablesBtn);

            //User click pen like button on “Action” column and edit “Salary” text box than press “submit” button
            methods.ClickElement(editBtn);
            methods.WaitUntilElementExists(registrationFormWindow);
            methods.FindElemnt(salaryBox).Clear();
            methods.SendKeysToElement(salaryBox,salary);
            methods.ClickWhenItBeClickable(submitFormBtn);

            //Salary from the changed row should changed to value that user chose
            string firstEdit = methods.GetText(firstRowSallary);
            Assert.That(firstEdit, Is.Not.EqualTo(empty).And.Not.EqualTo(previousSalary).And.Contains(methods.UpFirstLetter(salary)));

            //User click pen like button on “Action” column and edit “Last Name” text box than press “submit” button
            methods.ClickElement(editBtn);
            methods.WaitUntilElementExists(registrationFormWindow);
            methods.FindElemnt(lastNameBox).Clear();
            methods.SendKeysToElement(lastNameBox, lastName);
            methods.ClickWhenItBeClickable(submitFormBtn);

            //Last Name from the changed row should changed to value that user chose
            string secondEdit = methods.GetText(firstRowLastName);
            Assert.That(secondEdit, Is.Not.EqualTo(empty).And.Not.EqualTo(previousLastName).And.Contains(methods.UpFirstLetter(lastName)));

            //User click on trash like button on “Action” column on the one of the rows
            methods.ClickElement(deleteBtn);

            //Row should disappear from table
            bool rowDelete = methods.CkeckIfElementNOTExist(firstRow);
            Assert.IsTrue(rowDelete);

        }

        [Test]
        public void TC_elements8()
        {
            var methods = new Method(driver);
            string demoqaElementsUrl = "https://demoqa.com/elements";

            //Variables

            //Xpaths
            string linkWrapper = "//body[1]/div[2]/div[1]/div[1]/div[2]/div[2]/div[2]";
            string homeLink = "//a[@id='simpleLink']";
            string dynamicLink = "//a[@id='dynamicLink']";

            //Xpaths of buttons
            string linksBtn = "//body[1]/div[2]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/ul[1]/li[6]";
            string moveToBtn = "//body[1]/div[2]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/ul[1]/li[7]";


            //driver.Navigate().GoToUrl(demoqaElementsUrl);
            methods.GoToUrl(demoqaElementsUrl);

            //User click “Links” button from the left side menu bar
            methods.MoveToElement(moveToBtn);
            methods.ClickElement(linksBtn);
            methods.WaitUntilVisible(linkWrapper);

            //User click on the first link named “home”
            methods.ClickElement(homeLink);
            methods.SwitchToAnotherTab(2);
            methods.WaitUntilVisible("//body");

            //New browser tab with home page of ToolsQA should open
            Assert.That(methods.GetCurrentUrl, Is.EqualTo("https://demoqa.com/"));
            methods.CloseTab();
            methods.SleepInMiliseconds(500);
            methods.SwitchToAnotherTab(1);
            methods.WaitUntilVisible("//body");
            Assert.That(methods.GetCurrentUrl, Is.EqualTo("https://demoqa.com/links"));

            //User click on the second link named “Homeoim”
            methods.ClickElement(dynamicLink);
            methods.SwitchToAnotherTab(2);
            methods.WaitUntilVisible("//body");
            //New browser tab with home page of ToolsQA should open
            Assert.That(methods.GetCurrentUrl, Is.EqualTo("https://demoqa.com/"));
            methods.CloseTab();
            methods.SleepInMiliseconds(500);
            methods.SwitchToAnotherTab(1);
            methods.WaitUntilVisible("//body");
            Assert.That(methods.GetCurrentUrl, Is.EqualTo("https://demoqa.com/links"));

        }

        [Test]
        public void TC_elements9()
        {
            var methods = new Method(driver);
            string demoqaElementsUrl = "https://demoqa.com/elements";

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




            //Xpaths
            string linkWrapper = "//body[1]/div[2]/div[1]/div[1]/div[2]/div[2]/div[2]";
            string linkResponse = "//p[@id='linkResponse']";

            //Xpaths of buttons
            string linksBtn = "//body[1]/div[2]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/ul[1]/li[6]";
            string moveToBtn = "//body[1]/div[2]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/ul[1]/li[7]";
            string createdLinkBtn = "//a[@id='created']";
            string noContentLinkBtn = "//a[@id='no-content']";
            string movedLinkBtn = "//a[@id='moved']";
            string badRequestLinkBtn = "//a[@id='bad-request']";
            string unauthorizedLinkBtn = "//a[@id='unauthorized']";
            string forbiddenLinkBtn = "//a[@id='forbidden']";
            string notFoundLinkBtn = "//a[@id='invalid-url']";

            //driver.Navigate().GoToUrl(demoqaElementsUrl);
            methods.GoToUrl(demoqaElementsUrl);

            //User click “Links” button from the left side menu bar
            methods.MoveToElement(moveToBtn);
            methods.ClickElement(linksBtn);
            methods.WaitUntilVisible(linkWrapper);

            //User click on the first link named “Created” under the “Following links will send an api call” section
            methods.ClickElement(createdLinkBtn);
            //Text should appear under the links with status number and method that was in link name
            string createdLinkResponse = methods.GetText(linkResponse);
            Assert.That(createdLinkResponse, Is.Not.Empty.And.Contains(createdLinkCode).And.Contains(createdLinkName));

            //User click on the second link named “No Content” under the “Following links will send an api call” section
            methods.ClickElement(noContentLinkBtn);
            methods.WaitUntiElementContains(linkResponse, noContentLinkName);
            //Text should appear under the links with status number and method that was in link name
            string noContentlinkResponse = methods.GetText(linkResponse);
            Assert.That(noContentlinkResponse, Is.Not.Empty.And.Contains(noContentLinkCode).And.Contains(noContentLinkName));

            //User click on the fourth link named “Moved” under the “Following links will send an api call” section
            methods.ClickElement(movedLinkBtn);
            methods.WaitUntiElementContains(linkResponse, movedLinkName);
            //Text should appear under the links with status number and method that was in link name
            string movedLinkResponse = methods.GetText(linkResponse);
            Assert.That(movedLinkResponse, Is.Not.Empty.And.Contains(movedLinkCode).And.Contains(movedLinkName));

            //User click on the second link named “Bad Request” under the “Following links will send an api call” section
            methods.ClickElement(badRequestLinkBtn);
            methods.WaitUntiElementContains(linkResponse, badRequestLinkName);
            //Text should appear under the links with status number and method that was in link name
            string badRequestLinkResponse = methods.GetText(linkResponse);
            Assert.That(badRequestLinkResponse, Is.Not.Empty.And.Contains(badRequestLinkCode).And.Contains(badRequestLinkName));

            //User click on the second link named “Unauthorized” under the “Following links will send an api call” section
            methods.ClickElement(unauthorizedLinkBtn);
            methods.WaitUntiElementContains(linkResponse, unauthorizedLinkName);
            //Text should appear under the links with status number and method that was in link name
            string unauthorizedLinkResponse = methods.GetText(linkResponse);
            Assert.That(unauthorizedLinkResponse, Is.Not.Empty.And.Contains(unauthorizedLinkCode).And.Contains(unauthorizedLinkName));

            //User click on the second link named “Forbidden” under the “Following links will send an api call” section
            methods.ClickElement(forbiddenLinkBtn);
            methods.WaitUntiElementContains(linkResponse, forbiddenLinkName);
            //Text should appear under the links with status number and method that was in link name
            string forbiddenLinkResponse = methods.GetText(linkResponse);
            Assert.That(forbiddenLinkResponse, Is.Not.Empty.And.Contains(forbiddenLinkCode).And.Contains(forbiddenLinkName));

            //User click on the second link named “Not Found” under the “Following links will send an api call” section
            methods.ClickElement(notFoundLinkBtn);
            methods.WaitUntiElementContains(linkResponse, notFoundLinkName);
            //Text should appear under the links with status number and method that was in link name
            string notFoundLinkResponse = methods.GetText(linkResponse);
            Assert.That(notFoundLinkResponse, Is.Not.Empty.And.Contains(notFoundLinkCode).And.Contains(notFoundLinkName));



        }


        [Test]
        public void TC_elements10()
        {
            var methods = new Method(driver);
            string demoqaElementsUrl = "https://demoqa.com/elements";

            //Variables
            string file = @"C:\Users\michal.chrzeszczyk\Downloads\sampleFile (3).jpeg";

            //Xpaths
            string uploadedFilePath = "//p[@id='uploadedFilePath']";

            //Xpaths of buttons
            string uploadAndDownloadBtn = "//body[1]/div[2]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/ul[1]/li[8]";
            string moveToBtn = "//body[1]/div[2]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/ul[1]/li[9]";
            string btnWrapper = "//body[1]/div[2]/div[1]/div[1]/div[2]/div[2]/div[2]";
            string uploadFileBtn = "//input[@id='uploadFile']";
            string downloadBtn = "//a[@id='downloadButton']";


            //driver.Navigate().GoToUrl(demoqaElementsUrl);
            methods.GoToUrl(demoqaElementsUrl);

            //User click “Links” button from the left side menu bar
            methods.MoveToElement(moveToBtn);
            methods.ClickElement(uploadAndDownloadBtn);

            //User click “Download” button
            methods.ClickElement(downloadBtn);

            //Samplefile.jpeg should download itself
            bool checkIfDownloaded = methods.CheckFileDownloaded("sampleFile");
            Assert.IsTrue(checkIfDownloaded);

            //choose the samplefile.jpeg than press open
            methods.WaitUntilVisible(btnWrapper);
            methods.SendKeysToElement(uploadFileBtn, file);

            //Path to the file should appear under the “choose file” button
            methods.WaitUntilElementExists(uploadedFilePath);
            string upFilePathTXT = methods.GetText(uploadedFilePath);
            Assert.That(upFilePathTXT, Is.Not.Empty.And.Contains("fakepath"));
        }

            [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
        
    }
}
