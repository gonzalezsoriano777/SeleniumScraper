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

            using (SqlConnection db = new SqlConnection(connectionString))
            {
                string insertion = "INSERT INTO dbo.StockTable ( Stock_ID, Symbol, LastPrice, Change, PChg, Currency, MarketTime, VolumeAvg) VALUES ( @stock_ID , @symbol, @lastPrice, @change, @pchg, @currency, @marketTime, @volumeAvg)";

                using (SqlCommand import = new SqlCommand(insertion, db))
                {
                    import.Parameters.AddWithValue("@stock_ID", stockInfo[0]);
                    import.Parameters.AddWithValue("@symbol", stockInfo[1]);
                    import.Parameters.AddWithValue("@lastPrice", stockInfo[2]);
                    import.Parameters.AddWithValue("@change", stockInfo[3]);
                    import.Parameters.AddWithValue("@pchg", stockInfo[4]);
                    import.Parameters.AddWithValue("@currency", stockInfo[5]);
                    import.Parameters.AddWithValue("@marketTime", stockInfo[6]);
                    import.Parameters.AddWithValue("@volumeAvg", stockInfo[7]);


                    db.Open();
                    Console.WriteLine("Database has been opened");

                    // returns the number of rows affected by the execution against conString
                    var result = import.ExecuteNonQuery();

                    Console.WriteLine("Database has been INSERTED with info");

                }
                 db.Close();
            }

            Console.WriteLine("Database has been closed");
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