using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using StazTesting.Methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StazTesting.Tests
{
    internal class Interactions
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
        public void TC_inter1()
        {
            var methods = new Method(driver);
            string demoqaWidgetsUrl = "https://demoqa.com/interaction";

            //variables

            //Xpaths
            string interactionsMenu = "//div[@class='element-list collapse show']";
            string sortableContainer = "//div[@id='sortableContainer']";
            string oneItem = "//div[@id='demo-tabpane-list']//div//div[contains(text(),'One')]";
            string twoItem = "//div[@id='demo-tabpane-list']//div//div[contains(text(),'Two')]";
            string threeItem = "//div[@id='demo-tabpane-list']//div//div[contains(text(),'Three')]";
            string fourItem = "//div[@id='demo-tabpane-list']//div//div[contains(text(),'Four')]";
            string fiveItem = "//div[@id='demo-tabpane-list']//div//div[contains(text(),'Five')]";
            string sixItem = "//div[@id='demo-tabpane-list']//div//div[contains(text(),'Six')]";
            string test = "//body/div[@id='app']/div/div/div/div/div[@id='sortableContainer']/div/div[@id='demo-tabpane-list']/div[1]";

            //Xpaths of buttons
            string moveToBtn = "//div[normalize-space()='Book Store Application']";
            string sortableBtn = "//span[normalize-space()='Sortable']";

            //Xpaths of results

            methods.GoToUrl(demoqaWidgetsUrl);
            methods.WaitUntilVisible(interactionsMenu);

            //User click “Sortable” button from the left menu side bar
            methods.MoveToElement(moveToBtn);
            methods.ClickElement(sortableBtn);

 
            methods.SleepInSeconds(1);
            methods.MoveToElement(sortableBtn);
            methods.SleepInSeconds(1);


            //Sortable items should appear on the main view
            methods.WaitUntilVisible(sortableContainer);



            IWebElement ele = driver.FindElement(By.XPath(sixItem));
            IWebElement ele2 = driver.FindElement(By.XPath(oneItem));
            Actions builder1 = new Actions(driver);
            methods.DragAndDropToElementPlusOffset(oneItem, sixItem, 5, 5);


        }

        [Test]
        public void TC_inter2()
        {
            var methods = new Method(driver);
            string demoqaWidgetsUrl = "https://demoqa.com/interaction";

            //variables

            //Xpaths
            string interactionsMenu = "//div[@class='element-list collapse show']";
            string selectableContainer = "//div[@id='listContainer']";
            string firstItem = "//li[normalize-space()='Cras justo odio']";
            string secondItem = "//li[normalize-space()='Dapibus ac facilisis in']";
            string thirdItem = "//li[normalize-space()='Morbi leo risus']";
            string fourthItem = "//li[normalize-space()='Porta ac consectetur ac']";

            //Xpaths of buttons
            string moveToBtn = "//div[normalize-space()='Book Store Application']";
            string selectableBtn = "//span[normalize-space()='Selectable']";






            methods.GoToUrl(demoqaWidgetsUrl);
            methods.WaitUntilVisible(interactionsMenu);

            //User click “Selectable” button from the left menu side bar
            methods.MoveToElement(moveToBtn);
            methods.ClickElement(selectableBtn);

            //Selectable items should appear on the main view
            methods.WaitUntilVisible(selectableContainer);



            //Xpaths of results
            IWebElement firstListItem = methods.FindElemnt(firstItem);
            IWebElement secondListItem = methods.FindElemnt(secondItem);
            IWebElement thirdListItem = methods.FindElemnt(thirdItem);
            IWebElement fourthListItem = methods.FindElemnt(fourthItem);


            //User choose first item from list
            methods.ClickElement(firstItem);
            methods.SleepInMiliseconds(300);
            //Selectable item should change color to blue
            Assert.That(firstListItem.GetCssValue("background-color"), Is.EqualTo("rgba(0, 123, 255, 1)"));


            //User choose third item from list
            methods.ClickElement(thirdItem);
            methods.SleepInMiliseconds(300);
            //Selectable item should change color to blue
            Assert.That(thirdListItem.GetCssValue("background-color"), Is.EqualTo("rgba(0, 123, 255, 1)"));


            //User choose fourth item from list
            methods.ClickElement(fourthItem);
            methods.SleepInMiliseconds(300);
            //Selectable item should change color to blue
            Assert.That(fourthListItem.GetCssValue("background-color"), Is.EqualTo("rgba(0, 123, 255, 1)"));


            //User choose third item from list
            methods.ClickElement(thirdItem);
            methods.SleepInMiliseconds(300);
            //methods.SleepInSeconds(1);
            //Selectable item should change its color from blue to default
            Assert.That(thirdListItem.GetCssValue("background-color"), Is.EqualTo("rgba(248, 249, 250, 1)"));


            //User choose first item from list
            methods.ClickElement(firstItem);
            methods.SleepInMiliseconds(300);
            //Selectable item should change its color from blue to default
            Assert.That(firstListItem.GetCssValue("background-color"), Is.EqualTo("rgba(248, 249, 250, 1)"));


            //User choose fourth item from list
            methods.ClickElement(fourthItem);
            methods.SleepInMiliseconds(300);
            //Selectable item should change its color from blue to default
            Assert.That(fourthListItem.GetCssValue("background-color"), Is.EqualTo("rgba(248, 249, 250, 1)"));


            //User choose second item from list
            methods.ClickElement(secondItem);
            methods.SleepInMiliseconds(300);
            //Selectable item should change color to blue
            Assert.That(secondListItem.GetCssValue("background-color"), Is.EqualTo("rgba(0, 123, 255, 1)"));


        }



        [Test]
        public void TC_inter4()
        {
            var methods = new Method(driver);
            string demoqaWidgetsUrl = "https://demoqa.com/interaction";

            //variables

            //Xpaths
            string interactionsMenu = "//div[@class='element-list collapse show']";
            string selectableContainer = "//div[@id='listContainer']";
            string selectableGridContainer = "//div[@id='gridContainer']";
            string oneItem = "//li[normalize-space()='One']";
            string twoItem = "//li[normalize-space()='Two']";
            string threeItem = "//li[normalize-space()='Three']";
            string fourItem = "//li[normalize-space()='Four']";
            string fiveItem = "//li[normalize-space()='Five']";
            string sixItem = "//li[normalize-space()='Six']";
            string sevenItem = "//li[normalize-space()='Seven']";
            string eightItem = "//li[normalize-space()='Eight']";
            string nineItem = "//li[normalize-space()='Nine']";


            //Xpaths of buttons
            string moveToBtn = "//div[normalize-space()='Book Store Application']";
            string selectableBtn = "//span[normalize-space()='Selectable']";
            string gridViewBtn = "//a[@id='demo-tab-grid']";





            methods.GoToUrl(demoqaWidgetsUrl);
            methods.WaitUntilVisible(interactionsMenu);

            //User click “Selectable” button from the left menu side bar
            methods.MoveToElement(moveToBtn);
            methods.ClickElement(selectableBtn);

            //Selectable items should appear on the main view
            methods.WaitUntilVisible(selectableContainer);

            //User click “grid” button on the top bar menu
            methods.ClickElement(gridViewBtn);

            //There should appear grid view of the identical items
            methods.WaitUntilVisible(selectableGridContainer);




            //Xpaths of results
            IWebElement oneListItem = methods.FindElemnt(oneItem);
            IWebElement twoListItem = methods.FindElemnt(twoItem);
            IWebElement threeListItem = methods.FindElemnt(threeItem);
            IWebElement fourListItem = methods.FindElemnt(fourItem);
            IWebElement fiveListItem = methods.FindElemnt(fiveItem);
            IWebElement sixListItem = methods.FindElemnt(sixItem);
            IWebElement sevenListItem = methods.FindElemnt(sevenItem);
            IWebElement eightListItem = methods.FindElemnt(eightItem);
            IWebElement nineListItem = methods.FindElemnt(nineItem);

            //User choose first item from list named “one”
            methods.ClickElement(oneItem);
            //Selectable item should change color to blue
            Assert.That(oneListItem.GetCssValue("background-color"), Is.EqualTo("rgba(0, 123, 255, 1)"));


            //User choose third item from list named “three”
            methods.ClickElement(threeItem);
            //Selectable item should change color to blue
            Assert.That(threeListItem.GetCssValue("background-color"), Is.EqualTo("rgba(0, 123, 255, 1)"));

            //User choose fifth item from list named “five”
            methods.ClickElement(fiveItem);
            //Selectable item should change color to blue
            Assert.That(fiveListItem.GetCssValue("background-color"), Is.EqualTo("rgba(0, 123, 255, 1)"));

            //User choose seventh item from list named “seven”
            methods.ClickElement(sevenItem);
            //Selectable item should change color to blue
            Assert.That(sevenListItem.GetCssValue("background-color"), Is.EqualTo("rgba(0, 123, 255, 1)"));

            //User choose nineth item from list named “nine”
            methods.ClickElement(nineItem);
            //Selectable item should change color to blue
            Assert.That(nineListItem.GetCssValue("background-color"), Is.EqualTo("rgba(0, 123, 255, 1)"));

            //User choose first item from list named “one”
            methods.ClickElement(oneItem);
            //Selectable item should change its color from blue to default
            Assert.That(oneListItem.GetCssValue("background-color"), Is.EqualTo("rgba(248, 249, 250, 1)"));

            //User choose third item from list named “three”
            methods.ClickElement(threeItem);
            //Selectable item should change its color from blue to default
            Assert.That(threeListItem.GetCssValue("background-color"), Is.EqualTo("rgba(248, 249, 250, 1)"));

            //User choose fifth item from list named “five”
            methods.ClickElement(fiveItem);
            //Selectable item should change its color from blue to default
            Assert.That(fiveListItem.GetCssValue("background-color"), Is.EqualTo("rgba(248, 249, 250, 1)"));

            //User choose seventh item from list named “seven”
            methods.ClickElement(sevenItem);
            //Selectable item should change its color from blue to default
            Assert.That(sevenListItem.GetCssValue("background-color"), Is.EqualTo("rgba(248, 249, 250, 1)"));

            //User choose nineth item from list named “nine”
            methods.ClickElement(nineItem);
            //Selectable item should change its color from blue to default
            Assert.That(nineListItem.GetCssValue("background-color"), Is.EqualTo("rgba(248, 249, 250, 1)"));


        }

        [Test]
        public void TC_inter5()
        {
            var methods = new Method(driver);
            string demoqaInteractionsUrl = "https://demoqa.com/interaction";

            //variables
            string defaultBox = "200x200";
            string finalBox = "500x300";

            //Xpaths
            string interactionsMenu = "//div[@class='element-list collapse show']";
            string resizableContainer = "//div[@class='resizable-container']";
            string firstResizableArrow = "//div[@id='resizableBoxWithRestriction']//span";
            string secondResizableArrow = "//div[@id='resizable']//span";
            string constraintArea = "//div[@class='constraint-area']";


            //Xpaths of buttons
            string moveToBtn = "//div[normalize-space()='Book Store Application']";
            string moveToBtn2 = "//div[normalize-space()='Interactions']//span";
            string resizableBtn = "//span[normalize-space()='Resizable']";

            //Xpaths results
            string sizeOfFirstBox = "//div[@id='resizableBoxWithRestriction']";
            string sizeOfSecondBox = "//div[@id='resizable']";
            




            methods.GoToUrl(demoqaInteractionsUrl);
            methods.WaitUntilVisible(interactionsMenu);

            //User click “Resizable” button from the left menu side bar
            methods.MoveToElement(moveToBtn);
            methods.ClickElement(resizableBtn);

            //Resizable items should appear on the main view
            methods.WaitUntilVisible(resizableContainer);
            methods.SleepInMiliseconds(500);

            methods.MoveToElement(moveToBtn2);
            methods.WaitUntilVisible(moveToBtn2);
            methods.SleepInMiliseconds(500);
            Assert.That(methods.GetSize(sizeOfFirstBox), Is.EqualTo(defaultBox));

            //User grab arrow on the right bottom corner of the first resizable box and resize it to its max
            methods.DragAndDropByOffset(firstResizableArrow, 550, 120);

            //Grey background should be covered and box should be bigger
            Assert.That(methods.GetSize(sizeOfFirstBox), Is.EqualTo(finalBox));
            Assert.That(methods.GetSize(sizeOfFirstBox), Is.EqualTo(methods.GetSize(constraintArea)));

            //User grab arrow on the right bottom corner of the first resizable box and resize it to its minimum
            methods.DragAndDropByOffset(firstResizableArrow, -590, -160);

            //Box should be small and text in it should almost fill the resizable box
            Assert.That(methods.GetSize(sizeOfFirstBox), Is.EqualTo("150x150"));

            //User grab arrow on the right bottom corner of the second resizable box and resize it to its minimum
            methods.MoveToElement(moveToBtn);
            methods.SleepInMiliseconds(500);
            methods.DragAndDropByOffset(secondResizableArrow, -180, -180);

            //Box should be very small and barely visible and almost covered by text
            Assert.That(methods.GetSize(sizeOfSecondBox), Is.EqualTo("20x20"));

            //User grab arrow on the right bottom corner of the second resizable box and resize it that it will be bigger
            methods.DragAndDropByOffset(secondResizableArrow, 800, 500);
            //Box should be big and even can go outside the normal page borders
            Assert.That(methods.GetSize(sizeOfSecondBox), Is.EqualTo("820x520"));


        }



        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

    }
}
