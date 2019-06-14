using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

// Requires reference to WebDriver.Support.dll
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;

namespace MyScraper
{
    class Program
    {
        static void Main(string[] args)
        {

            IWebDriver driver = new ChromeDriver();

            //Navigating yahoo finance
            driver.Navigate().GoToUrl("http://yahoo.com/");

            // duration time to sign in
            WebDriverWait LogIn = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            LogIn.Until(ExpectedConditions.ElementToBeClickable(By.Id("uh-signin")));

            IWebElement signIn = driver.FindElement(By.Id("uh-signin"));

            signIn.Click();

            IWebElement username = driver.FindElement(By.Id("login-username"));

            username.SendKeys("gonzalez.soriano");

            username.Submit();

            WebDriverWait passwdDuration = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            passwdDuration.Until(ExpectedConditions.ElementToBeClickable(By.Id("login-passwd")));

            IWebElement password = driver.FindElement(By.Id("login-passwd"));

            password.SendKeys("Hector3463");
            password.SendKeys(Keys.Enter);

            driver.Navigate().GoToUrl("http://finance.yahoo.com/");

            driver.Navigate().GoToUrl("https://finance.yahoo.com/portfolio/p_0/view");

            // grab table data and print it to the console
            IWebElement table = driver.FindElement(By.XPath("//*[@id=\"pf-detail-table\"]/div[1]/table"));


            IList<IWebElement> allRows = driver.FindElements(By.TagName("tr"));

            foreach (IWebElement allRow in allRows)
            {
                Console.WriteLine(allRow.Text);
            }


        }

    }
}
 
