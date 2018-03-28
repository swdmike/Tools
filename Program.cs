using System;
using System.IO;
using System.Security.Cryptography;
using CsvHelper;
using Tools.csv;

namespace Tools
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string cmd = Console.ReadLine();
                //loadcsv D:\abc
                if (cmd.StartsWith("loadcsv"))
                {
                    var ss = cmd.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                    if (ss.Length > 1)
                    {
                        using (var db = new BarContext())
                        {
                            
                        }

                        /*
                        var fs = Directory.EnumerateFiles(ss[1]);
                        foreach (var f in fs)
                        {
                            using (var streamReader = File.OpenText(f))
                            {
                                var csv = new CsvReader(streamReader);
                                csv.Read();
                                csv.ReadHeader();
                                //股票代码	股票名称	交易日期	新浪行业	新浪概念	新浪地域	开盘价	最高价	最低价	收盘价
                                //后复权价	前复权价	涨跌幅	成交量	成交额	换手率	流通市值	总市值	是否涨停	是否跌停
                                //市盈率TTM	市销率TTM	市现率TTM	市净率 MA_5	MA_10	MA_20	MA_30	MA_60
                                while (csv.Read())
                                {
                                    var id = csv.GetField<string>("股票代码");
                                    var name = csv.GetField<string>("股票名称");
                                    var day = csv.GetField<DateTime>("交易日期");
                                    var open = csv.GetField<double>("开盘价");
                                    var high = csv.GetField<double>("最高价");
                                    var low = csv.GetField<double>("最低价");
                                    var close = csv.GetField<double>("收盘价");
                                    var backwardAdjustedPrice = csv.GetField<double>("后复权价");
                                    var forwardAdjustedPrice = csv.GetField<double>("前复权价");
                                    var change = csv.GetField<double>("涨跌幅");
                                    var volume = csv.GetField<double>("成交量");
                                    var turnover = csv.GetField<double>("成交额");
                                    var turnoverRate = csv.GetField<double>("换手率");
                                    var marketValue = csv.GetField<double>("流通市值");
                                    var marketCap = csv.GetField<double>("总市值");
                                    var stopRise = csv.GetField<double>("是否涨停");
                                    var stopPlummet = csv.GetField<double>("是否跌停");
                                    var PE = csv.GetField<double>("市盈率");
                                    var PS = csv.GetField<double>("市销率");
                                    var PCF = csv.GetField<double>("市现率");
                                    var PB = csv.GetField<double>("市净率");
                                    var ma5 = csv.GetField<double>("MA_5");
                                    var ma10 = csv.GetField<double>("MA_10");
                                    var ma20 = csv.GetField<double>("MA_20");
                                    var ma30 = csv.GetField<double>("MA_30");
                                    var ma60 = csv.GetField<double>("MA_60");


                                }
                            }
                        }
                        */
                    }
                }
                Console.WriteLine("loadcsv done.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + Environment.NewLine + ex.StackTrace);
            }
        }
    }
}