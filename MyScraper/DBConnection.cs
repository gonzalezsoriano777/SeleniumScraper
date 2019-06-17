using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.Data.Tools.Schema.Sql;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyScraper
{
    // revolve around integrating the database
    public class Server
    {
        //TODO: Be able to open and close DB and import scraped data into the database

        public string[] fields = { "@Symbol", "@LastPrice", "@Change", "@Chg", "@Currency", "@MarketTime", "@Volume", "@VolumeAvg", };

        public static void ScrapedData()
        {
            string connectionString;
            SqlConnection db;

            connectionString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=stockDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            db = new SqlConnection(connectionString);
            db.Open();
            Console.WriteLine("Database has been opened");
            Console.WriteLine();
            
            

        }
    }
}