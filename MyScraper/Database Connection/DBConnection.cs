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

        // public string[] fields = { "@symbol", "@lastPrice", "@change", "@pchg", "@currency", "@marketTime", "@volume", };

        List<StockTable> ListOfStocks = new List<StockTable>();

        public void ScrapedData()
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

            driver.Navigate().GoToUrl("http://finance.yahoo.com/");

            driver.Navigate().GoToUrl("https://finance.yahoo.com/portfolio/p_0/view");

            for (int stock = 1; stock <= 10; stock++)
            {
                var symbol = driver.FindElement(By.XPath("//*[@id=\"pf-detail-table\"]/div[1]/table/thead/tr[" + stock + "]/th[1]")).GetAttribute("innerText");
                var lastPrice = driver.FindElement(By.XPath("//*[@id=\"pf - detail - table\"]/div[1]/table/thead/tr[" + stock + "]/th[2]")).GetAttribute("innerText");
                var change = driver.FindElement(By.XPath("//*[@id=\"pf - detail - table\"]/div[1]/table/thead/tr[" + stock + "]/th[3]")).GetAttribute("innerText");
                var pchg = driver.FindElement(By.XPath("//*[@id=\"pf - detail - table\"]/div[1]/table/thead/tr[" + stock + "]/th[4]")).GetAttribute("innerText");
                var currency = driver.FindElement(By.XPath("//*[@id=\"pf - detail - table\"]/div[1]/table/thead/tr[" + stock + "]/th[5]")).GetAttribute("innerText");
                var marketTime = driver.FindElement(By.XPath("//*[@id=\"pf - detail - table\"]/div[1]/table/thead/tr[" + stock + "]/th[6]")).GetAttribute("innerText");
                var volume = driver.FindElement(By.XPath("//*[@id=\"pf - detail - table\"]/div[1]/table/thead/tr[" + stock + "]/th[7]")).GetAttribute("innerText");

                StockTable newStock = new StockTable();
                newStock.Symbol = symbol;
                newStock.LastPrice = lastPrice;
                newStock.Change = change;
                newStock.PChg = pchg;
                newStock.Currency = currency;
                newStock.MarketTime = marketTime;
                newStock.Volume = volume;

                ListOfStocks.Add(newStock);
            }

            driver.Quit();
        }

        public void DBConnection()
        {
            string connectionString;
            SqlConnection db;

            connectionString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=stockDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            db = new SqlConnection(connectionString);
            db.Open();
            Console.WriteLine("Database has been opened");
            Console.WriteLine();

            foreach (StockTable stock in ListOfStocks)
            {
                SqlCommand insert = new SqlCommand
                    ("INSERT INTO [StockTable] (Symbol, LastPrice, Change, PChg, Currency, MarketTime, Volume) " +
                    "VALUES ( @symbol, @lastPrice, @change, @pchg, @currency, @marketTime, @volume )", db);

                insert.Parameters.AddWithValue("symbol", stock.Symbol);
                insert.Parameters.AddWithValue("lastPrice", stock.LastPrice);
                insert.Parameters.AddWithValue("change", stock.Change);
                insert.Parameters.AddWithValue("pchg", stock.PChg);
                insert.Parameters.AddWithValue("currency", stock.Currency);
                insert.Parameters.AddWithValue("marketTime", stock.MarketTime);
                insert.Parameters.AddWithValue("volume", stock.Volume);
                insert.ExecuteNonQuery();

            }

            db.Close();
            Console.WriteLine("Was it updated at all?!");
        }
    }
        
}
