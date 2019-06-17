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
    class Selenium
    {
        public static void Connect()
        {

            IWebDriver driver = new ChromeDriver();

            

            // grab table data and print it to the console
           // IWebElement table = driver.FindElement(By.XPath("//*[@id=\"pf-detail-table\"]/div[1]/table"));


            // IList<IWebElement> allRows = driver.FindElements(By.TagName("tr"));

           // foreach (IWebElement allRow in allRows)
           // {
             //   Console.WriteLine(allRow.Text);
           // }
        }
    }
}

