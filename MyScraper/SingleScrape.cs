﻿using System;
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
    public class SingularScraping
    {
        IWebDriver driver = new ChromeDriver();

        string connectionString =
           @"Data Source=(localdb)\ProjectsV13;Initial Catalog=stockDatabase;Integrated Security=True;Connect Timeout=30;
            Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public void LogIn()
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
        }

        public void TransitionToPortfolio()
        {
            driver.Navigate().GoToUrl("https://finance.yahoo.com/portfolio/p_0/view");
        }


        public void InsertingData()
        {
            int counter;

            IWebElement tableBody = driver.FindElement(By.TagName("tbody"));
            System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> stockList = tableBody.FindElements(By.TagName("tr"));
            counter = stockList.Count;

            List<StockTable> ListStocks = new List<StockTable>();

            for (int stocks = 1; stocks <= counter; stocks++)
            {
                string symbol = driver.FindElement(By.XPath("//*[@id=\"pf-detail-table\"]/div[1]/table/tbody/tr[" + stocks + "]/td[1]/a")).GetAttribute("innerText");
                string lastPrice = driver.FindElement(By.XPath("//*[@id=\"pf-detail-table\"]/div[1]/table/tbody/tr[" + stocks + "]/td[2]/span")).GetAttribute("innerText");
                string change = driver.FindElement(By.XPath("//*[@id=\"pf-detail-table\"]/div[1]/table/tbody/tr[" + stocks + "]/td[3]/span")).GetAttribute("innerText");
                string pchg = driver.FindElement(By.XPath("//*[@id=\"pf-detail-table\"]/div[1]/table/tbody/tr[" + stocks + "]/td[4]/span")).GetAttribute("innerText");
                string currency = driver.FindElement(By.XPath("//*[@id=\"pf-detail-table\"]/div[1]/table/tbody/tr[" + stocks + "]/td[5]")).GetAttribute("innerText");
                string marketTime = driver.FindElement(By.XPath("//*[@id=\"pf-detail-table\"]/div[1]/table/tbody/tr[" + stocks + "]/td[6]/span")).GetAttribute("innerText");
                string volumeAvg = driver.FindElement(By.XPath("//*[@id=\"pf-detail-table\"]/div[1]/table/tbody/tr[" + stocks + "]/td[9]")).GetAttribute("innerText");



                StockTable newStocks = new StockTable();
                newStocks.Symbol = symbol;
                newStocks.LastPrice = lastPrice;
                newStocks.Change = change;
                newStocks.PChg = pchg;
                newStocks.Currency = currency;
                newStocks.MarketTime = marketTime;
                newStocks.VolumeAvg = volumeAvg;

                ListStocks.Add(newStocks);
            }

            driver.Quit();
            SqlConnection db = new SqlConnection(connectionString);
            db.Open();

            Console.WriteLine();
            Console.WriteLine("Database has been opened");

            foreach (StockTable stock in ListStocks)
            {
                SqlCommand insert = new SqlCommand("INSERT INTO dbo.stockData ( Symbol, LastPrice, Change, PChg, Currency, MarketTime, VolumeAvg ) VALUES ( @symbol, @lastPrice, @change, @pchg, @currency, @marketTime, @volumeAvg )", db);

                insert.Parameters.AddWithValue("@stockRecord", stock.StockRecord.ToString());
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
    }
}