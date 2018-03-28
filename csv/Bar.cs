using System;

namespace Tools.csv
{
    public class Bar
    {
        public string Id { get; set; }
        public DateTime Day { get; set; }
        public double Open { get; set; }
        public double High { get; set; }
        public double Low { get; set; }
        public double Close { get; set; }
        public double BackwardAdjustedPrice { get; set; }
        public double ForwardAdjustedPrice { get; set; }
        public double Change { get; set; }
        public double Volume { get; set; }
        public double Turnover { get; set; }
        public double TurnoverRate { get; set; }
        public double MarketCapFlow { get; set; }
        public double MarketCap { get; set; }
        public bool StopRise { get; set; }
        public bool StopPlummet { get; set; }
        public double PE { get; set; }
        public double PS { get; set; }
        public double PCF { get; set; }
        public double PB { get; set; }
        public double MA_5 { get; set; }
        public double MA_10 { get; set; }
        public double MA_20 { get; set; }
        public double MA_30 { get; set; }
        public double MA_60 { get; set; }
    }
}