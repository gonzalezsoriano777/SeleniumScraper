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

        string[] stockFields = { "@symbol", "@lastPrice", "@change", "@pchg", "@currency", "@marketTime", "@volumeAvg" };
        
        public void ScrapingData()
        {
           
            string connectionString;

            connectionString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=stockDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            
            SqlDataAdapter adapter;

            using (SqlConnection db = new SqlConnection(connectionString))
            {
                string insertion = "INSERT INTO dbo.StockTable (Symbol, LastPrice, Change, PChg, Currency, MarketTime, VolumeAvg) VALUES (@symbol, @lastPrice, @change, @pchg, @currency, @marketTime, @volumeAvg)";

                using (SqlCommand import = new SqlCommand(insertion, db))
                {
                    import.Parameters.AddWithValue("@symbol", [])
                }


            }

        }
    }
}
