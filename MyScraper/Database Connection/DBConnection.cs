using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Data.SqlClient;

namespace MyScraper
{
    // revolve around integrating the database
    public class Server
    {
        //TODO: Be able to open and close DB and import scraped data into the database

        IWebDriver driver = new ChromeDriver();


        List<StockTable> ListOfStocks = new List<StockTable>();

        public void LogginIn()
        {

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

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            driver.Navigate().GoToUrl("http://finance.yahoo.com/");

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            driver.Navigate().GoToUrl("https://finance.yahoo.com/portfolio/p_0/view");

            driver.Quit();
        }

        public void ConnectionToDB()
        {

            string connectionString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection db;

            db = new SqlConnection(connectionString);
            db.Open();

            Console.WriteLine();
            Console.WriteLine("Database has been opened");
            
            for(int stock = 1; stock <= 10; stock++)
            {
                var symbol = driver.FindElement(By.XPath("//*[@id=\"pf - detail - table\"]/div[1]/table/tbody/tr[" + stock + "]/td[1]")).GetAttribute("innerText");
                var lastPrice = driver.FindElement(By.XPath("//*[@id=\"pf - detail - table\"]/div[1]/table/tbody/tr[" + stock + "]/td[2]")).GetAttribute("innerText");
                var change = driver.FindElement(By.XPath("//*[@id=\"pf - detail - table\"]/div[1]/table/tbody/tr[" + stock + "]/td[3]")).GetAttribute("innerText");
                var pchg = driver.FindElement(By.XPath("//*[@id=\"pf - detail - table\"]/div[1]/table/tbody/tr[" + stock + "]/td[4]")).GetAttribute("innerText");
                var currency = driver.FindElement(By.XPath("//*[@id=\"pf - detail - table\"]/div[1]/table/tbody/tr[" + stock + "]/td[5]")).GetAttribute("innerText");
                var marketTime = driver.FindElement(By.XPath("//*[@id=\"pf - detail - table\"]/div[1]/table/tbody/tr[" + stock + "]/td[6]")).GetAttribute("innerText");
                var volumeAvg = driver.FindElement(By.XPath("//*[@id=\"pf - detail - table\"]/div[1]/table/tbody/tr[" + stock + "]/td[9]")).GetAttribute("innerText");

                StockTable newStocks = new StockTable();
                newStocks.Symbol = symbol;
                newStocks.LastPrice = lastPrice;
                newStocks.Change = change;
                newStocks.PChg = pchg;
                newStocks.Currency = currency;
                newStocks.MarketTime = marketTime;
                newStocks.VolumeAvg = volumeAvg;

                ListOfStocks.Add(newStocks);
            }

            foreach (StockTable stock in ListOfStocks)
            {

            }

        }
    }
        
}
