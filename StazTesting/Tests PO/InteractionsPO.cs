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
using StazTesting.PageObjects;

namespace StazTesting.Tests
{
    internal class InteractionsPO
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
            var Sortable = new POInteractionsSortable(driver);


            Sortable.goToPage();

            //User click “Sortable” button from the left menu side bar
            Sortable.ClickSortableBtn();

            Sortable.MoveToSortableBtn();


            //Item one goes under six
            string sixLocation = Sortable.GetLocationOfSixItem();
            Sortable.DragOneItemUnderSixItem();
            Assert.That(Sortable.GetLocationOfOneItem(), Is.EqualTo(sixLocation));

            //Item five goes above two
            string twoLocation = Sortable.GetLocationOfTwoItem();
            Sortable.DragFiveItemAboveTwoItem();
            Assert.That(Sortable.GetLocationOfFiveItem(), Is.EqualTo(twoLocation));

        }

        [Test]
        public void TC_inter2()
        {
            var Sortable = new POInteractionsSortable(driver);

            Sortable.goToPage();

            //User click “Sortable” button from the left menu side bar
            Sortable.ClickSortableBtn();

            Sortable.ClickGridViewBtn();

            Sortable.MoveToSortableBtn();


            //Sortable items should appear on the main view

            string lastLocation = Sortable.GetGridLocationOfNineItem();
            Sortable.DragGridOneToLast();
            Assert.That(Sortable.GetGridLocationOfOneItem(), Is.EqualTo(lastLocation));

            string middleLocation = Sortable.GetGridLocationOfSixItem();
            Sortable.DragGridNineToMiddle();
            Assert.That(Sortable.GetGridLocationOfNineItem(), Is.EqualTo(middleLocation));

            string firstOfSecondRowLocation = Sortable.GetGridLocationOfFiveItem();
            Sortable.DragGridFourToFirstItemOfSecondRow();
            Assert.That(Sortable.GetGridLocationOfFourItem(), Is.EqualTo(firstOfSecondRowLocation));

            string beginningLocation = Sortable.GetGridLocationOfTwoItem();
            Sortable.DragEightToBeginning();
            Assert.That(Sortable.GetGridLocationOfEightItem(), Is.EqualTo(beginningLocation));

        }
        [Test]
        public void TC_inter3()
        {
            var t = new POInteractionsSelectable(driver);

            //variables
            string defaultBackground = "rgba(248, 249, 250, 1)";
            string blueBackground = "rgba(0, 123, 255, 1)";



            t.goToPage();

            //User click “Selectable” button from the left menu side bar
            t.ClickSelectableBtn();


            //User choose first item from list
            t.ClickFirstItem();
            //Selectable item should change color to blue
            Assert.That(t.GetFirstItemBackgroundColor(), Is.EqualTo(blueBackground));


            //User choose third item from list
            t.ClickThirdItem();
            //Selectable item should change color to blue
            Assert.That(t.GetThirdItemBackgroundColor(), Is.EqualTo(blueBackground));


            //User choose fourth item from list
            t.ClickFourthItem();
            //Selectable item should change color to blue
            Assert.That(t.GetFourthItemBackgroundColor(), Is.EqualTo(blueBackground));


            //User choose third item from list
            t.ClickThirdItem();
            //methods.SleepInSeconds(1);
            //Selectable item should change its color from blue to default
            Assert.That(t.GetThirdItemBackgroundColor(), Is.EqualTo(defaultBackground));


            //User choose first item from list
            t.ClickFirstItem();
            //Selectable item should change its color from blue to default
            Assert.That(t.GetFirstItemBackgroundColor(), Is.EqualTo(defaultBackground));


            //User choose fourth item from list
            t.ClickFourthItem();
            //Selectable item should change its color from blue to default
            Assert.That(t.GetFourthItemBackgroundColor(), Is.EqualTo(defaultBackground));


            //User choose second item from list
            t.ClickSecondItem();
            //Selectable item should change color to blue
            Assert.That(t.GetSecondItemBackgroundColor(), Is.EqualTo(blueBackground));


        }



        [Test]
        public void TC_inter4()
        {
            var t = new POInteractionsSelectable(driver);

            //variables
            string defaultBackground = "rgba(248, 249, 250, 1)";
            string blueBackground = "rgba(0, 123, 255, 1)";

            t.goToPage();

            //User click “Selectable” button from the left menu side bar
            t.ClickSelectableBtn();

            //User click “grid” button on the top bar menu
            t.ClickGridVeiwBtn();

            //User choose first item from list named “one”
            t.ClickGridViewOneItem();
            //Selectable item should change color to blue
            Assert.That(t.GetOneItemBackgroundColor(), Is.EqualTo(blueBackground));


            //User choose third item from list named “three”
            t.ClickGridViewThreeItem();
            //Selectable item should change color to blue
            Assert.That(t.GetThreeItemBackgroundColor(), Is.EqualTo(blueBackground));

            //User choose fifth item from list named “five”
            t.ClickGridViewFiveItem();
            //Selectable item should change color to blue
            Assert.That(t.GetFiveItemBackgroundColor(), Is.EqualTo(blueBackground));

            //User choose seventh item from list named “seven”
            t.ClickGridViewSevenItem();
            //Selectable item should change color to blue
            Assert.That(t.GetSevenItemBackgroundColor(), Is.EqualTo(blueBackground));

            //User choose nineth item from list named “nine”
            t.ClickGridViewNineItem();
            //Selectable item should change color to blue
            Assert.That(t.GetNineItemBackgroundColor(), Is.EqualTo(blueBackground));

            //User choose first item from list named “one”
            t.ClickGridViewOneItem();
            //Selectable item should change its color from blue to default
            Assert.That(t.GetOneItemBackgroundColor(), Is.EqualTo(defaultBackground));

            //User choose third item from list named “three”
            t.ClickGridViewThreeItem();
            //Selectable item should change its color from blue to default
            Assert.That(t.GetThreeItemBackgroundColor(), Is.EqualTo(defaultBackground));

            //User choose fifth item from list named “five”
            t.ClickGridViewFiveItem();
            //Selectable item should change its color from blue to default
            Assert.That(t.GetFiveItemBackgroundColor(), Is.EqualTo(defaultBackground));

            //User choose seventh item from list named “seven”
            t.ClickGridViewSevenItem();
            //Selectable item should change its color from blue to default
            Assert.That(t.GetSevenItemBackgroundColor(), Is.EqualTo(defaultBackground));

            //User choose nineth item from list named “nine”
            t.ClickGridViewNineItem();
            //Selectable item should change its color from blue to default
            Assert.That(t.GetNineItemBackgroundColor(), Is.EqualTo(defaultBackground));


        }

        [Test]
        public void TC_inter5()
        {
            var t = new POInteractionsResizable(driver);

            //variables
            string defaultBox = "200x200";
            string finalBox = "500x300";
            string firstBoxMinimumSize = "150x150";
            string SecondBoxMinimumSize = "20x20";
            string SecondBoxFinalSize = "820x520";


            t.goToPage();

            //User click “Resizable” button from the left menu side bar
            t.ClickResizableBtn();

            //Resizable items should appear on the main view
            Assert.That(t.GetSizeOfFirstBox(), Is.EqualTo(defaultBox));

            //User grab arrow on the right bottom corner of the first resizable box and resize it to its max
            t.ResizeFirstBoxToMax();

            //Grey background should be covered and box should be bigger
            Assert.That(t.GetSizeOfFirstBox(), Is.EqualTo(finalBox));
            Assert.That(t.GetSizeOfFirstBox(), Is.EqualTo(t.GetSizeOfConstraintArea()));

            //User grab arrow on the right bottom corner of the first resizable box and resize it to its minimum
            t.ResizeFirstBoxToMinimum();

            //Box should be small and text in it should almost fill the resizable box
            Assert.That(t.GetSizeOfFirstBox(), Is.EqualTo(firstBoxMinimumSize));

            //User grab arrow on the right bottom corner of the second resizable box and resize it to its minimum
            t.MoveToLastBtnWithDelay();
            t.ResizeSecondBoxToMinimum();

            //Box should be very small and barely visible and almost covered by text
            Assert.That(t.GetSizeOfSecondBox(), Is.EqualTo(SecondBoxMinimumSize));

            //User grab arrow on the right bottom corner of the second resizable box and resize it that it will be bigger
            t.ResizeSecondBoxToPoint();
            //Box should be big and even can go outside the normal page borders
            Assert.That(t.GetSizeOfSecondBox(), Is.EqualTo(SecondBoxFinalSize));


        }



        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

    }
}
