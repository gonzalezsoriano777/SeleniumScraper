using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using MyScraper.DatabaseEntity;



namespace MyScraper
{
    public class Scraping
    {
        
        string[] stockFields =
            { "@stock_ID" , "@symbol", "@lastPrice", "@change", "@pchg", "@currency", "@marketTime", "@volumeAvg" };

        string[] stockInfo =
            { "1" , "SQL", "T", "B", "R", "S", " 2/15/2001 12:30PM", "R" };

        string connectionString =
            @"Data Source=(localdb)\ProjectsV13;Initial Catalog=stockDatabase;Integrated Security=True;Connect Timeout=30;
            Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public void InsertingData()
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

            driver.Navigate().GoToUrl("https://finance.yahoo.com/portfolio/p_0/view");

            int counter;

            IWebElement tableBody = driver.FindElement(By.XPath("//*[@id=\"pf-detail-table\"]/div[1]/table"));
            System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> stockList = tableBody.FindElements(By.TagName("tr"));
            counter = stockList.Count;

            List<StockTable> ListOfStocks = new List<StockTable>();

            for (int stocks = 1; stocks <= counter; stocks++)
            {
                var symbol = driver.FindElement(By.XPath("//*[@id=\"pf-detail-table\"]/div[1]/table/thead/tr/th[1]")).GetAttribute("innerText");
                var lastPrice = driver.FindElement(By.XPath("//*[@id=\"pf-detail-table\"]/div[1]/table/thead/tr/th[2]")).GetAttribute("innerText");
                var change = driver.FindElement(By.XPath("//*[@id=\"pf-detail-table\"]/div[1]/table/thead/tr/th[3]")).GetAttribute("innerText");
                var pchg = driver.FindElement(By.XPath("//*[@id=\"pf-detail-table\"]/div[1]/table/thead/tr/th[4]")).GetAttribute("innerText");
                var currency = driver.FindElement(By.XPath("//*[@id=\"pf-detail-table\"]/div[1]/table/thead/tr/th[5]")).GetAttribute("innerText");
                var marketTime = driver.FindElement(By.XPath("//*[@id=\"pf-detail-table\"]/div[1]/table/thead/tr/th[6]")).GetAttribute("innerText");
                var volumeAvg = driver.FindElement(By.XPath("//*[@id=\"pf-detail-table\"]/div[1]/table/thead/tr/th[9]")).GetAttribute("innerText");


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

            driver.Quit();
            SqlConnection db = new SqlConnection(connectionString);
            db.Open();

            Console.WriteLine();
            Console.WriteLine("Database has been opened");

            foreach(StockTable stock in ListOfStocks)
            {

                SqlCommand insert = new SqlCommand("INSERT INTO dbo.StockTable ( Symbol, LastPrice, Change, PChg, Currency, MarketTime, VolumeAvg ) VALUES ( @symbol, @lastPrice, @change, @pchg, @currency, @marketTime, @volumeAvg )", db);

                insert.Parameters.AddWithValue("symbol", stock.Symbol);
                insert.Parameters.AddWithValue("lastPrice", stock.LastPrice);
                insert.Parameters.AddWithValue("change", stock.Change);
                insert.Parameters.AddWithValue("pchg", stock.PChg);
                insert.Parameters.AddWithValue("currency", stock.Currency);
                insert.Parameters.AddWithValue("marketTime", stock.MarketTime);
                insert.Parameters.AddWithValue("volumeAvg", stock.VolumeAvg);
                insert.ExecuteNonQuery();

            }

            db.Close();
            Console.WriteLine();
            Console.WriteLine("Database has been updated with info");

            Console.WriteLine();
            Console.WriteLine("Database has been closed!");

        }

        public void StockHistory()
        {

        }

        public void DeletingData()
        {

            string deletion = "DELETE FROM dbo.StockTable";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand(deletion, conn))
                {
                    command.ExecuteNonQuery();
                }

                conn.Close();
                Console.WriteLine("Database data has been put to DELETION!");
            }



        }

        public void UpdatingData()
        {

            string updatePhase = "UPDATE dbo.StockTable SET Symbol = 'SNL' WHERE Stock_ID = '1'";

            using (SqlConnection connString = new SqlConnection(connectionString))
            {
                connString.Open();

                using (SqlCommand command = new SqlCommand(updatePhase, connString))
                {
                    command.ExecuteNonQuery();
                }

                connString.Close();
                Console.WriteLine("Database has been UPDATED!");
            }

        }
    }
}