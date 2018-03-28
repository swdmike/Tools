using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tools.csv
{
    public class Bar
    {
        [Key] //主键 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //设置自增
        public int Id { get; set; }
        public string Code { get; }
        public DateTime Day { get; }
        public double Open { get; }
        public double High { get; }
        public double Low { get; }
        public double Close { get; }
        public double BackwardAdjustedPrice { get; }
        public double ForwardAdjustedPrice { get; }
        public double Change { get; }
        public double Volume { get; }
        public double Turnover { get; }
        public double TurnoverRate { get; }
        public double MarketCapFlow { get; }
        public double MarketCap { get; }
        public bool StopRise { get; }
        public bool StopPlummet { get; }
        public double PE { get; }
        public double PS { get; }
        public double PCF { get; }
        public double PB { get; }
        public double Ma5 { get; }
        public double Ma10 { get; }
        public double Ma20 { get; }
        public double Ma30 { get; }
        public double Ma60 { get; }

        public Bar(string code, DateTime day, double open, double high, double low, double close,
            double backwardAdjustedPrice, double forwardAdjustedPrice, double change, double volume,
            double turnover, double turnoverRate, double marketCapFlow, double marketCap,
            bool stopRise, bool stopPlummet, double pe, double ps, double pcf, double pb,
            double ma5, double ma10, double ma20, double ma30, double ma60)
        {
            Code = code;
            Day = day;
            Open = open;
            High = high;
            Low = low;
            Close = close;
            BackwardAdjustedPrice = backwardAdjustedPrice;
            ForwardAdjustedPrice = forwardAdjustedPrice;
            Change = change;
            Volume = volume;
            Turnover = turnover;
            TurnoverRate = turnoverRate;
            MarketCapFlow = marketCapFlow;
            MarketCap = marketCap;
            StopRise = stopRise;
            StopPlummet = stopPlummet;
            PE = pe;
            PS = ps;
            PCF = pcf;
            PB = pb;
            Ma5 = ma5;
            Ma10 = ma10;
            Ma20 = ma20;
            Ma30 = ma30;
            Ma60 = ma60;
        }
    }
}