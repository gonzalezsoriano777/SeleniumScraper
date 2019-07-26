﻿using System;
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
            
            // open the database and now data can be put into it
         //  YahooCredentials server = new YahooCredentials();
         // server.Credentials();

          // Scraping dB = new Scraping();

            //dB.LogginIn();
            //dB.TransitionToPortfolio();
            //dB.InsertingData();

            SingularScraping dbStock = new SingularScraping();
            dbStock.LogIn();
            dbStock.TransitionToPortfolio();
            dbStock.InsertingData();


        }

    }
}
 
