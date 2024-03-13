using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V120.Network;
using OpenQA.Selenium.Support.UI;

namespace uiTest
{
    [TestClass]
    public class UnitTest1
    {          
            private static readonly string DriverDirectory = "C:\\Users\\xiaohui\\Desktop\\programor\\webDrivers";
            private static IWebDriver _driver;

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            _driver = new ChromeDriver(DriverDirectory);
        }


        [ClassCleanup]
        public static void TearDown()
        {
            _driver.Dispose();

        }

        [TestMethod]
            public void TestMethod1()
        {
            _driver.Navigate().GoToUrl("file:///C:/Users/xiaohui/Desktop/programor/javascript/collect/Words/caculator/index.html");
            Assert.AreEqual("caculator", _driver.Title);


           IWebElement inputElement1 =_driver.FindElement(By.Id("inputOne"));
            inputElement1.SendKeys("2");

            IWebElement inputElment2 =_driver.FindElement(By.Id("inputTwo"));
            inputElment2.SendKeys("3");

            //IWebElement opretertest =_driver.FindElement(By.Id("selectOp"));
            //opretertest.SendKeys("+");
            
            IWebElement selectElement = _driver.FindElement(By.Name("operation"));
               var select  = new SelectElement(selectElement);
            select.SelectByValue("+");

            IWebElement buttonElement = _driver.FindElement(By.Id("buttonOne"));
            buttonElement.Click();

            IWebElement webElement = _driver.FindElement(By.Id("output"));
            Assert.AreEqual("5", webElement.Text);
           }

        [TestMethod]
           public void TestMethod2()
        {
            _driver.Navigate().GoToUrl("file:///C:/Users/xiaohui/Desktop/programor/javascript/collect/Words/js/index.html");
            Assert.AreEqual("testworld", _driver.Title);

            IWebElement inputElement1 =_driver.FindElement(By.Id("input"));
            inputElement1.SendKeys("hello");

            IWebElement saveButton =_driver.FindElement(By.Id("saveButton"));
            saveButton.Click();

            IWebElement showButton = _driver.FindElement(By.Id("showButton"));
            showButton.Click();

            IWebElement output = _driver.FindElement(By.Id("output"));
            Assert.AreEqual("hello", output.Text);

            IWebElement clearButton = _driver.FindElement(By.Id("clearButton"));
            clearButton.Click();
            saveButton.Click();
            showButton.Click();

            Assert.AreEqual("null words", output.Text);

        }
      
    }
}