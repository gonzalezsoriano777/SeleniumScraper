using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace MyScraper
{
    public class Scraping
    {

        string[] stockFields = 
            { "@symbol", "@lastPrice", "@change", "@pchg", "@currency", "@marketTime", "@volumeAvg" };

        string[] stockData = 
            { "SQL", "T", "B", "R", "S", "12:30PM", "R" };

        string connectionString  = 
            @"Data Source=(localdb)\ProjectsV13;Initial Catalog=stockDatabase;Integrated Security=True;Connect Timeout=30;
            Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public void InsertingData()
        {
           
            using (SqlConnection db = new SqlConnection(connectionString))
            {
                string insertion = "INSERT INTO dbo.StockTable (Symbol, LastPrice, Change, PChg, Currency, MarketTime, VolumeAvg) VALUES (@symbol, @lastPrice, @change, @pchg, @currency, @marketTime, @volumeAvg)";

                using (SqlCommand import = new SqlCommand(insertion, db))
                {
                    import.Parameters.AddWithValue("@symbol", stockData[0]);
                    import.Parameters.AddWithValue("@lastPrice", stockData[1]);
                    import.Parameters.AddWithValue("@change", stockData[2]);
                    import.Parameters.AddWithValue("@pchg", stockData[3]);
                    import.Parameters.AddWithValue("@currency", stockData[4]);
                    import.Parameters.AddWithValue("@marketTime", stockData[5]);
                    import.Parameters.AddWithValue("@volumeAvg", stockData[6]);


                    db.Open();
                    Console.WriteLine("Database has been opened");

                    // returns the number of rows affected by the execution against conString
                    int result = import.ExecuteNonQuery();

                    Console.WriteLine("Database has been updated with info");
                   
                }
                db.Close();
            }

            Console.WriteLine("Database has been closed");
        }

        public void DeletingData()
        {

        }

        public void UpdatingData()
        {

        }
    }
}
