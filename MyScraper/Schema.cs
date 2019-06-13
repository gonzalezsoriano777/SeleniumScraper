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

        public string Symbol { get => symbol; set => symbol = value;}
        public double LastPrice { get => lastprice; set => lastprice = value; }
        public double Change { get => change; set => change = value; }
        public double Chg { get => chg; set => chg = value; }
        public string Currency { get => currency; set => currency = value; }
        public DateTime MarketTime { get => marketTime; set => marketTime = value; }
        public double Volume { get => volume; set => volume = value; }
        public double VolumeAvg { get => volumeAvg; set => volumeAvg = value; }
 
    }
}
