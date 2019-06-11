using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyScraper
{
  
    public class StockDB
    {
        private string symbol;
        private double lastprice;
        private double change;
        private double chg;
        private string currency;
        private DateTime marketTime;
        private double volume;
        private double volumeAvg;


        public StockDB()
        {
        }

        public StockDB(string Symbol, double LastPrice, double Change, 
            double Chg, string Currency, DateTime MarketTime, double Volume, double VolumeAvg)
        {
            this.symbol = Symbol;
            this.lastprice = LastPrice;
            this.change = Change;
            this.chg = Chg;
            this.currency = Currency;
            this.marketTime = MarketTime;
            this.volume = Volume;
            this.volumeAvg = VolumeAvg;

        }
    }
}
