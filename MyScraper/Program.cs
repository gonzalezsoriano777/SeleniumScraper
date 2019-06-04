using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
// Requires reference to WebDriver.Support.dll
using OpenQA.Selenium.Support.UI;

namespace MyScraper
{
    class Program
    {
        static void Main(string[] args)
        {


            #region Extra data, will be deleted shortly


            // Create a new instance of the Chrome driver.
            // Note that it is wrapped in a using clause so that the browser is closed 
            // and the webdriver is disposed (even in the face of exceptions).

            // Also note that the remainder of the code relies on the interface, 
            // not the implementation.

            // Further note that other drivers (InternetExplorerDriver,
            // ChromeDriver, etc.) will require further configuration 
            // before this example will work. See the wiki pages for the
            // individual drivers at http://code.google.com/p/selenium/wiki
            // for further information.
            //Notice navigation is slightly different than the Java version
            //This is because 'get' is a keyword in C#

            #endregion

            

            using (IWebDriver driver = new ChromeDriver())
                {

                // opens chrome, and transitions straight the URL
                driver.Navigate().GoToUrl("https://login.yahoo.com/");

                    // Find the text input element by its name
                    IWebElement query = driver.FindElement(By.Name("q"));

                    // Enter something to search for
                    query.SendKeys("Apple");

                    // Now submit the form. WebDriver will find the form for us from the element
                    query.Submit();

                    // Google's search is rendered dynamically with JavaScript.
                    // Wait for the page to load, timeout after 10 seconds
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                    wait.Until(d => d.Title.StartsWith("cheese", StringComparison.OrdinalIgnoreCase));

                    // Should see: "Cheese - Google Search" (for an English locale)
                    Console.WriteLine("Page title is: " + driver.Title);
                }
        }
    }
}
 
