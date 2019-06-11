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

        private string Symbol { get => symbol; set => symbol = value;}
        private double LastPrice { get => lastprice; set => lastprice = value; }
        private double Change { get => change; set => change = value; }
        private double Chg { get => chg; set => chg = value; }
        private string Currency { get => currency; set => currency = value; }
        private DateTime MarketTime { get => marketTime; set => marketTime = value; }
        private double Volume { get => volume; set => volume = value; }
        private double VolumeAvg { get => volumeAvg; set => volumeAvg = value; }
 
        // Constructor set for the columns of the table
        public StockDB(string _symbol, double _lastPrice, double _change, 
            double _chg, string _currency, DateTime _marketTime, double _volume, double _volumeAvg)
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
