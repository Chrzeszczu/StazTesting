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
    internal class POInteractionsSortable
    {
        private IWebDriver _driver;

        //Urls
        string demoqaInteractionsURL = "https://demoqa.com/interaction";

        //BUTTONS
        [FindsBy(How = How.XPath, Using = "//div[normalize-space()='Book Store Application']")]
        [CacheLookup]
        private IWebElement elem_btn_move_to;

        [FindsBy(How = How.XPath, Using = "//span[normalize-space()='Sortable']")]
        [CacheLookup]
        private IWebElement elem_btn_sortable;

        [FindsBy(How = How.XPath, Using = "//a[@id='demo-tab-grid']")]
        [CacheLookup]
        private IWebElement elem_btn_sortable_grid_view;
        


        //CONTAINERS
        [FindsBy(How = How.XPath, Using = "//div[@id='sortableContainer']")]
        private IWebElement elem_container_sortable;



        //LIST ITEMS
        [FindsBy(How = How.XPath, Using = "//div[@id='demo-tabpane-list']//div//div[contains(text(),'One')]")]
        private IWebElement elem_item_one;

        [FindsBy(How = How.XPath, Using = "//div[@id='demo-tabpane-list']//div//div[contains(text(),'Two')]")]
        private IWebElement elem_item_two;

        [FindsBy(How = How.XPath, Using = "//div[@id='demo-tabpane-list']//div//div[contains(text(),'Three')]")]
        private IWebElement elem_item_three;

        [FindsBy(How = How.XPath, Using = "//div[@id='demo-tabpane-list']//div//div[contains(text(),'Four')]")]
        private IWebElement elem_item_four;

        [FindsBy(How = How.XPath, Using = "//div[@id='demo-tabpane-list']//div//div[contains(text(),'Five')]")]
        private IWebElement elem_item_five;

        [FindsBy(How = How.XPath, Using = "//div[@id='demo-tabpane-list']//div//div[contains(text(),'Six')]")]
        private IWebElement elem_item_six;

        //GRID ITEM 
        [FindsBy(How = How.XPath, Using = "//div[@id='demo-tabpane-grid']//div//div//div[contains(text(),'One')]")]
        private IWebElement elem_item_grid_one;

        [FindsBy(How = How.XPath, Using = "//div[@id='demo-tabpane-grid']//div//div//div[contains(text(),'Two')]")]
        private IWebElement elem_item_grid_two;

        [FindsBy(How = How.XPath, Using = "//div[@id='demo-tabpane-grid']//div//div//div[contains(text(),'Three')]")]
        private IWebElement elem_item_grid_three;

        [FindsBy(How = How.XPath, Using = "//div[@id='demo-tabpane-grid']//div//div//div[contains(text(),'Four')]")]
        private IWebElement elem_item_grid_four;

        [FindsBy(How = How.XPath, Using = "//div[@id='demo-tabpane-grid']//div//div//div[contains(text(),'Five')]")]
        private IWebElement elem_item_grid_five;

        [FindsBy(How = How.XPath, Using = "//div[@id='demo-tabpane-grid']//div//div//div[contains(text(),'Six')]")]
        private IWebElement elem_item_grid_six;

        [FindsBy(How = How.XPath, Using = "//div[@id='demo-tabpane-grid']//div//div//div[contains(text(),'Seven')]")]
        private IWebElement elem_item_grid_seven;

        [FindsBy(How = How.XPath, Using = "//div[@id='demo-tabpane-grid']//div//div//div[contains(text(),'Eight')]")]
        private IWebElement elem_item_grid_eight;

        [FindsBy(How = How.XPath, Using = "//div[@id='demo-tabpane-grid']//div//div//div[contains(text(),'Nine')]")]
        private IWebElement elem_item_grid_nine;



        //WAITS
        [FindsBy(How = How.XPath, Using = "//div[@class='element-list collapse show']")]
        private IWebElement elem_wait_interactions_menu;

        [FindsBy(How = How.XPath, Using = "//div[@class='create-grid']")]
        private IWebElement elem_wait_grid_view;



        //Xpaths of WAITS
        string interactionsMenu = "//div[@class='element-list collapse show']";
        string sortableContainer = "//div[@id='sortableContainer']";
        string sortableGridContainer = "//div[@class='create-grid']";



        //[FindsBy(How = How.XPath, Using = "")]
        //private IWebElement elem_btn_;

        public POInteractionsSortable(IWebDriver driver)
        {
            this._driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void goToPage()
        {
            _driver.Navigate().GoToUrl(demoqaInteractionsURL);
            WaitForInteractionsMenu();
        }
        public void ClickSortableBtn()
        {
            MoveToLastBtn();
            elem_btn_sortable.Click();
            WaitForSortableContainer();
        }  


        public void DragOneItemUnderSixItem()
        {
            var methods = new Method(_driver);
            methods.DragAndDropToElementPlusOffset(elem_item_one, elem_item_six, 5, 5);
        }
        public void DragFiveItemAboveTwoItem()
        {
            var methods = new Method(_driver);
            methods.DragAndDropByOffset(elem_item_five, 0, -170);
        }

        public string GetLocationOfOneItem()
        {
            var methods = new Method(_driver);
            return methods.GetLocationOfElement(elem_item_one);
        }
        public string GetLocationOfTwoItem()
        {
            var methods = new Method(_driver);
            return methods.GetLocationOfElement(elem_item_two);
        }
        public string GetLocationOfThreeItem()
        {
            var methods = new Method(_driver);
            return methods.GetLocationOfElement(elem_item_three);
        }
        public string GetLocationOfFourItem()
        {
            var methods = new Method(_driver);
            return methods.GetLocationOfElement(elem_item_four);
        }
        public string GetLocationOfFiveItem()
        {
            var methods = new Method(_driver);
            return methods.GetLocationOfElement(elem_item_five);
        }
        public string GetLocationOfSixItem()
        {
            var methods = new Method(_driver);
            return methods.GetLocationOfElement(elem_item_six);
        }

        //GRID VIEW
        public void ClickGridViewBtn()
        {
            elem_btn_sortable_grid_view.Click();
            WaitForSortableGridViewContainer();
        }
        public void DragGridOneToLast()
        {
            var methods = new Method(_driver);
            methods.DragAndDropByOffset(elem_item_grid_one, 230, 200);
        }
        public void DragGridNineToMiddle()
        {
            var methods = new Method(_driver);
            methods.DragAndDropByOffset(elem_item_grid_nine, 0, -90);
        }
        public void DragGridFourToFirstItemOfSecondRow()
        {
            var methods = new Method(_driver);
            methods.DragAndDropByOffset(elem_item_grid_four, -210, 100);
        }
        public void DragEightToBeginning()
        {
            var methods = new Method(_driver);
            methods.DragAndDropByOffset(elem_item_grid_eight, -110, -190);
        }

        public string GetGridLocationOfOneItem()
        {
            var methods = new Method(_driver);
            return methods.GetLocationOfElement(elem_item_grid_one);
        }
        public string GetGridLocationOfTwoItem()
        {
            var methods = new Method(_driver);
            return methods.GetLocationOfElement(elem_item_grid_two);
        }
        public string GetGridLocationOfThreeItem()
        {
            var methods = new Method(_driver);
            return methods.GetLocationOfElement(elem_item_grid_three);
        }
        public string GetGridLocationOfFourItem()
        {
            var methods = new Method(_driver);
            return methods.GetLocationOfElement(elem_item_grid_four);
        }
        public string GetGridLocationOfFiveItem()
        {
            var methods = new Method(_driver);
            return methods.GetLocationOfElement(elem_item_grid_five);
        }
        public string GetGridLocationOfSixItem()
        {
            var methods = new Method(_driver);
            return methods.GetLocationOfElement(elem_item_grid_six);
        }
        public string GetGridLocationOfSevenItem()
        {
            var methods = new Method(_driver);
            return methods.GetLocationOfElement(elem_item_grid_seven);
        }
        public string GetGridLocationOfEightItem()
        {
            var methods = new Method(_driver);
            return methods.GetLocationOfElement(elem_item_grid_eight);
        }
        public string GetGridLocationOfNineItem()
        {
            var methods = new Method(_driver);
            return methods.GetLocationOfElement(elem_item_grid_nine);
        }



        public void MoveToLastBtn()
        {
            Actions actions = new Actions(_driver);
            actions.MoveToElement(elem_btn_move_to).Perform();
        }

        public void MoveToSortableBtn()
        {
            var methods = new Method(_driver);
            methods.SleepInMiliseconds(500);
            Actions actions = new Actions(_driver);
            actions.MoveToElement(elem_btn_sortable).Perform();
            methods.SleepInMiliseconds(500);
        }
        //WAITS 
        private void WaitForInteractionsMenu()
        {
            var methods = new Method(_driver);
            methods.WaitUntilVisible(interactionsMenu);
        }
        private void WaitForSortableContainer()
        {
            var methods = new Method(_driver);
            methods.WaitUntilVisible(sortableContainer);
        }
        private void WaitForSortableGridViewContainer()
        {
            var methods = new Method(_driver);
            methods.WaitUntilVisible(sortableGridContainer);
        }


    }
    internal class POInteractionsSelectable
    {
        private IWebDriver _driver;

        //Urls
        string demoqaInteractionsURL = "https://demoqa.com/interaction";

        //BUTTONS
        [FindsBy(How = How.XPath, Using = "//div[normalize-space()='Book Store Application']")]
        [CacheLookup]
        private IWebElement elem_btn_move_to;

        [FindsBy(How = How.XPath, Using = "//span[normalize-space()='Selectable']")]
        [CacheLookup]
        private IWebElement elem_btn_selectable;

        [FindsBy(How = How.XPath, Using = "//a[@id='demo-tab-grid']")]
        [CacheLookup]
        private IWebElement elem_btn_grid_view;


        //CONTAINERS
        [FindsBy(How = How.XPath, Using = "//div[@id='listContainer']")]
        private IWebElement elem_container_selectable;

        [FindsBy(How = How.XPath, Using = "//div[@id='gridContainer']")]
        private IWebElement elem_container_grid_selectable;

        
        //ITEMS LIST
        [FindsBy(How = How.XPath, Using = "//li[normalize-space()='Cras justo odio']")]
        private IWebElement elem_item_first;

        [FindsBy(How = How.XPath, Using = "//li[normalize-space()='Dapibus ac facilisis in']")]
        private IWebElement elem_item_second;

        [FindsBy(How = How.XPath, Using = "//li[normalize-space()='Morbi leo risus']")]
        private IWebElement elem_item_third;

        [FindsBy(How = How.XPath, Using = "//li[normalize-space()='Porta ac consectetur ac']")]
        private IWebElement elem_item_fourth;



        //ITEMS GRID
        [FindsBy(How = How.XPath, Using = "//li[normalize-space()='One']")]
        private IWebElement elem_item_grid_one;

        [FindsBy(How = How.XPath, Using = "//li[normalize-space()='Two']")]
        private IWebElement elem_item_grid_two;

        [FindsBy(How = How.XPath, Using = "//li[normalize-space()='Three']")]
        private IWebElement elem_item_grid_three;

        [FindsBy(How = How.XPath, Using = "//li[normalize-space()='Four']")]
        private IWebElement elem_item_grid_four;

        [FindsBy(How = How.XPath, Using = "//li[normalize-space()='Five']")]
        private IWebElement elem_item_grid_five;

        [FindsBy(How = How.XPath, Using = "//li[normalize-space()='Six']")]
        private IWebElement elem_item_grid_six;

        [FindsBy(How = How.XPath, Using = "//li[normalize-space()='Seven']")]
        private IWebElement elem_item_grid_seven;

        [FindsBy(How = How.XPath, Using = "//li[normalize-space()='Eight']")]
        private IWebElement elem_item_grid_eight;

        [FindsBy(How = How.XPath, Using = "//li[normalize-space()='Nine']")]
        private IWebElement elem_item_grid_nine;



        //WAITS
        [FindsBy(How = How.XPath, Using = "//div[@class='element-list collapse show']")]
        private IWebElement elem_wait_interactions_menu;

        [FindsBy(How = How.XPath, Using = "")]
        private IWebElement elem_wait_;



        //Xpaths of WAITS
        string interactionsMenu = "//div[@class='element-list collapse show']";
        string selectableContainer = "//div[@id='listContainer']";
        string selectableGridContainer = "//div[@id='gridContainer']";


        //[FindsBy(How = How.XPath, Using = "")]
        //private IWebElement elem_btn_;

        public POInteractionsSelectable(IWebDriver driver)
        {
            this._driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void goToPage()
        {
            _driver.Navigate().GoToUrl(demoqaInteractionsURL);
            WaitForInteractionsMenu();
        }
        public void ClickSelectableBtn()
        {
            MoveToLastBtn();
            elem_btn_selectable.Click();
            WaitForSelectableContainer();
        }
        public void ClickFirstItem()
        {
            var methods = new Method(_driver);
            elem_item_first.Click();
            methods.SleepInMiliseconds(300);
        }
        public void ClickSecondItem()
        {
            var methods = new Method(_driver);
            elem_item_second.Click();
            methods.SleepInMiliseconds(300);
        }
        public void ClickThirdItem()
        {
            var methods = new Method(_driver);
            elem_item_third.Click();
            methods.SleepInMiliseconds(300);
        }
        public void ClickFourthItem()
        {
            var methods = new Method(_driver);
            elem_item_fourth.Click();
            methods.SleepInMiliseconds(300);
        }

        //GRID VIEW
        public void ClickGridVeiwBtn()
        {
            elem_btn_grid_view.Click();
            WaitForSelectableGridContainer();
        }
        public void ClickGridViewOneItem()
        {
            elem_item_grid_one.Click();
        }
        public void ClickGridViewTwoItem()
        {
            elem_item_grid_two.Click();
        }
        public void ClickGridViewThreeItem()
        {
            elem_item_grid_three.Click();
        }
        public void ClickGridViewFourItem()
        {
            elem_item_grid_four.Click();
        }
        public void ClickGridViewFiveItem()
        {
            elem_item_grid_five.Click();
        }
        public void ClickGridViewSixItem()
        {
            elem_item_grid_six.Click();
        }
        public void ClickGridViewSevenItem()
        {
            elem_item_grid_seven.Click();
        }
        public void ClickGridViewEightItem()
        {
            elem_item_grid_eight.Click();
        }
        public void ClickGridViewNineItem()
        {
            elem_item_grid_nine.Click();
        }


        //LIST VIEW
        public string GetFirstItemBackgroundColor() => elem_item_first.GetCssValue("background-color");
        public string GetSecondItemBackgroundColor() => elem_item_second.GetCssValue("background-color");
        public string GetThirdItemBackgroundColor() => elem_item_third.GetCssValue("background-color");
        public string GetFourthItemBackgroundColor() => elem_item_fourth.GetCssValue("background-color");


        //GRID VIEW
        public string GetOneItemBackgroundColor() => elem_item_grid_one.GetCssValue("background-color");
        public string GetTwoItemBackgroundColor() => elem_item_grid_two.GetCssValue("background-color");
        public string GetThreeItemBackgroundColor() => elem_item_grid_three.GetCssValue("background-color");
        public string GetFourItemBackgroundColor() => elem_item_grid_four.GetCssValue("background-color");
        public string GetFiveItemBackgroundColor() => elem_item_grid_five.GetCssValue("background-color");
        public string GetSixItemBackgroundColor() => elem_item_grid_six.GetCssValue("background-color");
        public string GetSevenItemBackgroundColor() => elem_item_grid_seven.GetCssValue("background-color");
        public string GetEightItemBackgroundColor() => elem_item_grid_eight.GetCssValue("background-color");
        public string GetNineItemBackgroundColor() => elem_item_grid_nine.GetCssValue("background-color");


        public void MoveToLastBtn()
        {
            Actions actions = new Actions(_driver);
            actions.MoveToElement(elem_btn_move_to).Perform();
        }

        //WAITS 
        private void WaitForInteractionsMenu()
        {
            var methods = new Method(_driver);
            methods.WaitUntilVisible(interactionsMenu);
        }
        private void WaitForSelectableContainer()
        {
            var methods = new Method(_driver);
            methods.WaitUntilVisible(selectableContainer);
        }
        private void WaitForSelectableGridContainer()
        {
            var methods = new Method(_driver);
            methods.WaitUntilVisible(selectableGridContainer);
        }
    }
    internal class POInteractionsResizable
    {
        private IWebDriver _driver;

        //Urls
        string demoqaInteractionsURL = "https://demoqa.com/interaction";

        //BUTTONS
        [FindsBy(How = How.XPath, Using = "//div[normalize-space()='Book Store Application']")]
        [CacheLookup]
        private IWebElement elem_btn_move_to;

        [FindsBy(How = How.XPath, Using = "//div[normalize-space()='Interactions']//span")]
        [CacheLookup]
        private IWebElement elem_btn_move_to_second;

        [FindsBy(How = How.XPath, Using = "//span[normalize-space()='Resizable']")]
        [CacheLookup]
        private IWebElement elem_btn_resizable;


        //ITEMS
        [FindsBy(How = How.XPath, Using = "//div[@id='resizableBoxWithRestriction']//span")]
        private IWebElement elem_item_first_resiable_arrow;

        [FindsBy(How = How.XPath, Using = "//div[@id='resizable']//span")]
        private IWebElement elem_item_second_resizable_arrow;


        //CONTAINERS
        [FindsBy(How = How.XPath, Using = "//div[@class='resizable-container']")]
        private IWebElement elem_container_resizable;


        //WAITS
        [FindsBy(How = How.XPath, Using = "//div[@class='element-list collapse show']")]
        private IWebElement elem_wait_interactions_menu;

        [FindsBy(How = How.XPath, Using = "")]
        private IWebElement elem_wait_;

        //RESULTS
        [FindsBy(How = How.XPath, Using = "//div[@id='resizableBoxWithRestriction']")]
        private IWebElement elem_result_size_of_first_box;

        [FindsBy(How = How.XPath, Using = "//div[@id='resizable']")]
        private IWebElement elem_result_size_of_second_box;

        [FindsBy(How = How.XPath, Using = "//div[@class='constraint-area']")]
        private IWebElement elem_result_size_of_second_constraint_area;



        //Xpaths of WAITS
        string interactionsMenu = "//div[@class='element-list collapse show']";
        string resizableContainer = "//div[@class='resizable-container']";


        //[FindsBy(How = How.XPath, Using = "")]
        //private IWebElement elem_btn_;

        public POInteractionsResizable(IWebDriver driver)
        {
            this._driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void goToPage()
        {
            _driver.Navigate().GoToUrl(demoqaInteractionsURL);
            WaitForInteractionsMenu();
        }
        public void ClickResizableBtn()
        {
            var methods = new Method(_driver);
            MoveToLastBtn();
            elem_btn_resizable.Click();
            WaitForResizableContainer();
            methods.SleepInMiliseconds(500);
            MoveToSecondBtn();
        }

        public void ResizeFirstBoxToMinimum()
        {
            var methods = new Method(_driver);
            methods.DragAndDropByOffset(elem_item_first_resiable_arrow, -590, -160);
        }
        public void ResizeFirstBoxToMax()
        {
            var methods = new Method(_driver);
            methods.DragAndDropByOffset(elem_item_first_resiable_arrow, 550, 120);
        }
        public void ResizeSecondBoxToMinimum()
        {
            var methods = new Method(_driver);
            methods.DragAndDropByOffset(elem_item_second_resizable_arrow, -180, -180);
        }
        public void ResizeSecondBoxToPoint()
        {
            var methods = new Method(_driver);
            methods.DragAndDropByOffset(elem_item_second_resizable_arrow, 800, 500);
        }



        public string GetSizeOfFirstBox()
        {
            var methods = new Method(_driver);
            return methods.GetSize(elem_result_size_of_first_box);
        }
        public string GetSizeOfSecondBox()
        {
            var methods = new Method(_driver);
            return methods.GetSize(elem_result_size_of_second_box);
        }
        public string GetSizeOfConstraintArea()
        {
            var methods = new Method(_driver);
            return methods.GetSize(elem_result_size_of_second_constraint_area);
        }

        public void MoveToLastBtn()
        {
            Actions actions = new Actions(_driver);
            actions.MoveToElement(elem_btn_move_to).Perform();
        }
        public void MoveToLastBtnWithDelay()
        {
            var methods = new Method(_driver);
            Actions actions = new Actions(_driver);
            actions.MoveToElement(elem_btn_move_to).Perform();
            methods.SleepInMiliseconds(500);
        }
        public void MoveToSecondBtn()
        {
            var methods = new Method(_driver);
            Actions actions = new Actions(_driver);
            actions.MoveToElement(elem_btn_move_to_second).Perform();
            methods.SleepInMiliseconds(500);
        }
        //WAITS 
        private void WaitForInteractionsMenu()
        {
            var methods = new Method(_driver);
            methods.WaitUntilVisible(interactionsMenu);
        }
        private void WaitForResizableContainer()
        {
            var methods = new Method(_driver);
            methods.WaitUntilVisible(resizableContainer);
        }

    }
}
