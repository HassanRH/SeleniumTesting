using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_Testing.Test_10
{
    [TestClass]
    public class AssertionTest
    {

        static IWebDriver driver = new ChromeDriver();
        String url;

        [ClassInitialize]
        public static void BeforeAll(TestContext context)
        {
        }

        [TestInitialize]
        public void Before()
        {
            driver.Navigate().GoToUrl(Helper.PageUrl() + "/assert.html");

           
        }

        [TestMethod]
        public void TestAssertTitle()
        {
            // simulate checking that the title of the page is not "Assertion"

            Assert.AreNotEqual(driver.Title,"Assertion");
          

            // simulate checking that the title of the page is  "Assertion Test Page"
           Assert.AreEqual(driver.Title,"Assertion Test Page");
        }

        [TestMethod]
        public void TestAssertPageText()
        {

            // Define the string  variable  matching_str ="Text assertion with a  (tab before), and \r\n(new line before)!"
            string matching_str = "Text assertion with a  (tab before), and \r\n(new line before)!";

            // Using TagName , find the appropriate element and Check that it contains  the matching_str  string.
            driver.FindElement(By.TagName("pre")).TagName.Contains(matching_str);
        }

        [TestMethod]
        public void TestAssertPageSource()
        {

            // Define the string  variable  html_fragment = "Text assertion with a  (<b>tab</b> before), and \r\n(new line before)!"
            string html_fragment = "Text assertion with a  (<b>tab</b> before), and \r\n(new line before)!";

            // Simulate retreiving the source code of the assert.html page and check that it contains  the  html_fragment  string.
           Assert.IsTrue(driver.PageSource.Contains(html_fragment));
        }

        [TestMethod]
        public void TestAssertLabelText()
        {
            // find the element whose Id is "label_1" and check that its text is "First Label"
            Assert.AreEqual(driver.FindElement(By.Id("label_1")).Text, "First Label");

            // find the element whose Id is "span_2" and check that its text is not "First Label"
            Assert.AreNotEqual(driver.FindElement(By.Id("span_2")).Text, "First Label");

            // write an assert statement to check the right text of the element whose id is "span_2"
            Assert.AreEqual("Second Span", driver.FindElement(By.Id("span_2")).Text);
        }

        [TestMethod]
        public void TestAssertDivText()
        {
            // find the element whose Id is "div_child_1" and check its text

            bool TestWise = driver.FindElement(By.Id("div_child_1")).Text.Contains("TestWise");
            Assert.IsTrue(TestWise);

            // find the element whose Id is "div_parent" and check its text

            bool BuildWise = driver.FindElement(By.Id("div_parent")).Text.Contains("BuildWise");
            Assert.IsTrue(BuildWise);

        }

        [TestMethod]
        public void TestAssertDivHtml()
        {
            // find the element whose Id is "div_parent" and call it "the_element"
            IWebElement the_element = driver.FindElement(By.Id("div_parent"));


            // Uncomment the following statement to execute a script on the element "the_element"
            //Object html = ((IJavaScriptExecutor)driver).ExecuteScript("return arguments[0].outerHTML;", the_element);
            Object html = ((IJavaScriptExecutor)driver).ExecuteScript("return arguments[0].outerHTML;", the_element);


            // Define the expected string after execution and call it "expected" . 
            string expected = "<div id=\"div_parent\">\r\n\t   Wise Products\r\n\t   <div id=\"div_child_1\">\r\n\t   \t TestWise\r\n\t   </div>\r\n\t   <div id=\"div_child_2\">\r\n\t   \t BuildWise\r\n\t   </div>\r\n\t </div>";

            // Assert that the expected and the output "html" are equal
            Assert.AreEqual(html, expected);
        }



        [TestMethod]
        public void TestAssertTextInTableCell()
        {
            // find the element whose Id is  "cell_1_1" and check its text
            bool A = driver.FindElement(By.Id("cell_1_1")).Text.Contains("A");
            Assert.IsTrue(A);

        }

        [TestMethod]
        public void TestAssertTextInTableCellWithIndex()
        {
            // find the table element whose Id is  "alpha_table" 
            driver.FindElement(By.Id("alpha_table"));
            // find the second cell in the second row  using XPath
            driver.FindElement(By.XPath("//*[@id='cell_2_2']"));
            // Check its text
            bool b = driver.FindElement(By.Id("cell_2_2")).Text.Contains("b");
            Assert.IsTrue(b);
        }

        [TestMethod]
        public void TestAssertTextInTableRow()
        {
            // find the element whose Id is  "row_1" and check its text

            driver.FindElement(By.Id("row_1"));
        }


        [TestMethod]
        public void TestAssertImagePresents()
        {
            // find the image element whose Id is  "next_go"  and check that the element is displayed
            Assert.IsTrue(driver.FindElement(By.Id("next_go")).Displayed);
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
