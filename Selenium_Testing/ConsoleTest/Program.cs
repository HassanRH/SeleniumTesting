using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest
{
    class Program
    {
      static   IWebDriver driver = new ChromeDriver();
        static void Main(string[] args)
        {
           

            ////// And now use this to visit Google
            //driver.Navigate().GoToUrl("http://www.google.com");

            //// Find the text input element by its name
            //IWebElement element = driver.FindElement(By.Name("q"));

            //// Enter something to search for
            //element.SendKeys("www.easj.dk");

            //// Now submit the form. WebDriver will find the form for us from the element
            //element.Submit();

            //Console.WriteLine(driver.Title);

            //Console.ReadKey();

            //// Check the title of the page
        }
    }
}
