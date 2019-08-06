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
            
           // History Table
            Scraping dB = new Scraping();
            dB.LogginIn();
            dB.TransitionToPortfolio();
            dB.InsertingData();

            //Scraping only the 12 stocks

            // SingularScraping dbStock = new SingularScraping();
            // dbStock.LogIn();
            // dbStock.TransitionToPortfolio();
            // dbStock.InsertingData();
            

        }

    }
}
 
