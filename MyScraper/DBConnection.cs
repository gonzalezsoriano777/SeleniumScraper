using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        //  public string[] fields = { "@Symbol", "@LastPrice", "@Change", "@Chg", "@Currency", "@MarketTime", "@Volume", "@VolumeAvg", };

        List<StockTable> ListOfStocks = new List<StockTable>();

        public static void DBConnection()
        {
            string connectionString;
            SqlConnection db;

            connectionString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=stockDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            db = new SqlConnection(connectionString);
            db.Open();
            Console.WriteLine("Database has been opened");
            Console.WriteLine();
            
        }

        public void ScrapedData()
        {
            // focusing on adding the data to the database
            IWebDriver driver = new ChromeDriver();
            string[] info = new string[13];

            for(int stockData = 1; stockData < 10; stockData++)
            {
                var symbol = driver.FindElement(By.XPath("//*[@id=\"pf - detail - table\"]/div[1]/table/thead/tr/th[1]"));
                var lastPrice = driver.FindElement(By.XPath("//*[@id=\"pf - detail - table\"]/div[1]/table/thead/tr/th[2]"));
                var change = driver.FindElement(By.XPath("//*[@id=\"pf - detail - table\"]/div[1]/table/thead/tr/th[3]"));
                var chg = driver.FindElement(By.XPath("//*[@id=\"pf - detail - table\"]/div[1]/table/thead/tr/th[4]"));
                var currency = driver.FindElement(By.XPath("//*[@id=\"pf - detail - table\"]/div[1]/table/thead/tr/th[5]"));
                var marketTime = driver.FindElement(By.XPath("//*[@id=\"pf - detail - table\"]/div[1]/table/thead/tr/th[6]"));
                var volume = driver.FindElement(By.XPath("//*[@id=\"pf - detail - table\"]/div[1]/table/thead/tr/th[7]"));
                var volumeAvg = driver.FindElement(By.XPath("//*[@id=\"pf - detail - table\"]/div[1]/table/thead/tr/th[9]"));
            }




        }
    }
}