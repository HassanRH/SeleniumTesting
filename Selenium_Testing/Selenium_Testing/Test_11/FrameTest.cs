using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Selenium_Testing.Test_11
{
    [TestClass]
    public class FrameTest
    {

        static IWebDriver driver = new ChromeDriver();

        [ClassInitialize]
        public static void BeforeAll(TestContext context)
        {
        }

        [TestInitialize]
        public void Before()
        {
            driver.Navigate().GoToUrl(Helper.PageUrl() + "/frames.html");

           
        }

        [TestMethod]
        public void TestFrames()
        {
            // simulate switching from "frames.html" to "topNav"
            driver.SwitchTo().Frame("topNav");

            // sleep for 3s

            Thread.Sleep(3000);

            //find the element whose id is  "Menu 2 in top frame" and click on it
            driver.FindElement(By.LinkText("Menu 2 in top frame")).Click();

            // switch to the default content
            driver.SwitchTo().DefaultContent();

            // sleep for 3s
            Thread.Sleep(3000);

            // switch to the "content.html" frame
            driver.Navigate().GoToUrl("file:///C:/Users/Hassan/Desktop/Selenium_Testing%20Hassan/Selenium_Testing/Pages/content.html");


            // find the element whose link text is "Load white page" and click on it
            driver.FindElement(By.LinkText("Load white page")).Click();


            // sleep for 5 s
            Thread.Sleep(5000);
        }

        [TestMethod]
        public void TestIFrame()
        {
            // navigate to the page  iframe.html
            driver.Navigate().GoToUrl(Helper.PageUrl() + "/iframe.html");

            // find the element whose name is "user" and type the word "agileway"
            IWebElement element = driver.FindElement(By.Name("user"));
            element.SendKeys("agileway");

            // switch to the "Frame1" frame
            driver.SwitchTo().Frame("Frame1");

            //find the element whose name is "user" and type the word "agileway"
            driver.FindElement(By.Name("username")).SendKeys("agileway");

            // sleep for 3 s
            Thread.Sleep(3000);


            //find the element whose name is "password" and type the word "TestWise"
            driver.FindElement(By.Name("password")).SendKeys("TestWise");


            // find the element whose Id is "loginBtn" and click on it
            driver.FindElement(By.Id("loginBtn")).Click();


            //check that the page source code contains the string "Signed in"
            Assert.IsTrue(driver.PageSource.Contains("Signed in"));


            // switch to the default content
            driver.SwitchTo().DefaultContent();


            // find the element whose Id="accept_terms" and click on it
            driver.FindElement(By.Id("accept_terms")).Click();
        }

        [TestMethod]
        public void TestIFrameByIndex()
        {
            // navigate to the page  iframes.html
            driver.Navigate().GoToUrl(Helper.PageUrl() + "/iframes.html");

            // switch to the first frame
            driver.SwitchTo().Frame(0);

            // find the lement whose name is "username" and type "agileway"
            driver.FindElement(By.Name("username")).SendKeys("agileway");

            // switch to the default content
            driver.SwitchTo().DefaultContent();

            // switch to the second frame
            driver.SwitchTo().Frame(1);

            // find the element whose id is "radio_male" and click on it.
            driver.FindElement(By.Id("radio_male")).Click();
        }

        [TestCleanup]
        public void After()
        {
        }

        [ClassCleanup]
        public static void AfterAll()
        {
            driver.Quit();
        }
    }

}
