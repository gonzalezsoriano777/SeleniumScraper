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

            IWebDriver driver = new ChromeDriver();

            //Navigating yahoo finance
            driver.Navigate().GoToUrl("http://finance.yahoo.com/");

            // duration time to sign in
            WebDriverWait LogIn = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            LogIn.Until(ExpectedConditions.ElementToBeClickable(By.Id("uh-signedin")));

            IWebElement signIn = driver.FindElement(By.Id("uh-signedin"));

            signIn.Click();

            IWebElement username = driver.FindElement(By.Id("login-username"));

            username.SendKeys("gonzalez.soriano");
     
            username.Submit();

            WebDriverWait passwdDuration = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            passwdDuration.Until(ExpectedConditions.ElementToBeClickable(By.Id("login-passwd")));

            IWebElement password = driver.FindElement(By.Id("login-passwd"));

            password.SendKeys("Hector3463");
            password.SendKeys(Keys.Enter);

            

            


        }
    }
}
 
