using System;
using System.IO;
using CsvHelper;
using Tools.csv;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;

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
                    LoadCSV(cmd);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + Environment.NewLine + ex.StackTrace);
            }
        }

        private static void LoadCSV(string input)
        {
            var ss = input.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            if (ss.Length <= 1)
            {
                return;
            }

            var dir = new DirectoryInfo(ss[1]);
            var fs = dir.GetFiles("*.csv");
            int cnt = 1;
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddXmlFile("app.config", false, true);
            var configuration = builder.Build();
            var connectionString = configuration.GetConnectionString("SqliteConnection");
            using (var connection = new SqliteConnection("Filename=" + connectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    foreach (var f in fs)
                    {
                        Console.WriteLine($"{cnt}/{fs.Length}, {f.Name}");
                        cnt += 1;
                        using (var streamReader = File.OpenText(f.FullName))
                        {
                            var csv = new CsvReader(streamReader);
                            csv.Read();
                            csv.ReadHeader();
                            while (csv.Read())
                            {
                                GetRow(csv, connection);
                            }
                        }
                    }

                    transaction.Commit();
                }

                connection.Close();
            }

            Console.WriteLine("loadcsv done.");
        }

        private static void GetRow(CsvReader row, SqliteConnection connection)
        {
            //股票代码	股票名称	交易日期	新浪行业	新浪概念	新浪地域	开盘价	最高价	最低价	收盘价
            //后复权价	前复权价	涨跌幅	成交量	成交额	换手率	流通市值	总市值	是否涨停	是否跌停
            //市盈率TTM	市销率TTM	市现率TTM	市净率 MA_5	MA_10	MA_20	MA_30	MA_60
            var code = row.GetField<string>(0);
            var name = row.GetField<string>(1);
            var day = row.GetField<string>(2);
            var open = row.GetField<double>(6);
            var high = row.GetField<double>(7);
            var low = row.GetField<double>(8);
            var close = row.GetField<double>(9);
            var backwardAdjustedPrice = row.GetField<double>(10);
            var forwardAdjustedPrice = row.GetField<double>(11);
            var change = row.GetField<double>(12);
            var volume = row.GetField<double>(13);
            var turnover = row.GetField<double>(14);
            var turnoverRate = row.GetField<double>(15);
            var marketCapFlow = row.GetField<double>(16);
            var marketCap = row.GetField<double>(17);
            var stopRise = Math.Abs(row.GetField<double>(18) - 1) < 0.1;
            var stopPlummet = Math.Abs(row.GetField<double>(19) - 1) < 0.1;
            row.TryGetField<double>(20, out var pe);
            row.TryGetField<double>(21, out var ps);
            row.TryGetField<double>(22, out var pcf);
            row.TryGetField<double>(23, out var pb);
            row.TryGetField<double>(24, out var ma5);
            row.TryGetField<double>(25, out var ma10);
            row.TryGetField<double>(26, out var ma20);
            row.TryGetField<double>(27, out var ma30);
            row.TryGetField<double>(28, out var ma60);
            using (var command = connection.CreateCommand())
            {
                command.CommandText = string.Format(@"INSERT INTO Bars (Code, day, open, high, low, close,
                backwardAdjustedPrice, forwardAdjustedPrice, change, volume,
                turnover, turnoverRate, marketCapFlow, marketCap,
                stopRise, stopPlummet, pe, ps, pcf, pb,
                ma5, ma10, ma20, ma30, ma60) VALUES(""{0}"",""{1}"",{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},
{12},{13},""{14}"",""{15}"",{16},{17},{18},{19},{20},{21},{22},{23},{24})",
                    code, day, open, high, low, close,
                    backwardAdjustedPrice, forwardAdjustedPrice, change, volume,
                    turnover, turnoverRate, marketCapFlow, marketCap,
                    stopRise, stopPlummet, pe, ps, pcf, pb,
                    ma5, ma10, ma20, ma30, ma60);
                command.ExecuteNonQuery();
            }
        }

        private static void GetRow(CsvReader row, BarContext db)
        {
            //股票代码	股票名称	交易日期	新浪行业	新浪概念	新浪地域	开盘价	最高价	最低价	收盘价
            //后复权价	前复权价	涨跌幅	成交量	成交额	换手率	流通市值	总市值	是否涨停	是否跌停
            //市盈率TTM	市销率TTM	市现率TTM	市净率 MA_5	MA_10	MA_20	MA_30	MA_60
            var id = row.GetField<string>(0);
            var name = row.GetField<string>(1);
            var day = row.GetField<DateTime>(2);
            var open = row.GetField<double>(6);
            var high = row.GetField<double>(7);
            var low = row.GetField<double>(8);
            var close = row.GetField<double>(9);
            var backwardAdjustedPrice = row.GetField<double>(10);
            var forwardAdjustedPrice = row.GetField<double>(11);
            var change = row.GetField<double>(12);
            var volume = row.GetField<double>(13);
            var turnover = row.GetField<double>(14);
            var turnoverRate = row.GetField<double>(15);
            var marketCapFlow = row.GetField<double>(16);
            var marketCap = row.GetField<double>(17);
            var stopRise = Math.Abs(row.GetField<double>(18) - 1) < 0.1;
            var stopPlummet = Math.Abs(row.GetField<double>(19) - 1) < 0.1;
            row.TryGetField<double>(20, out var pe);
            row.TryGetField<double>(21, out var ps);
            row.TryGetField<double>(22, out var pcf);
            row.TryGetField<double>(23, out var pb);
            row.TryGetField<double>(24, out var ma5);
            row.TryGetField<double>(25, out var ma10);
            row.TryGetField<double>(26, out var ma20);
            row.TryGetField<double>(27, out var ma30);
            row.TryGetField<double>(28, out var ma60);
            var bar = new Bar(id, day, open, high, low, close,
                backwardAdjustedPrice, forwardAdjustedPrice, change, volume,
                turnover, turnoverRate, marketCapFlow, marketCap,
                stopRise, stopPlummet, pe, ps, pcf, pb,
                ma5, ma10, ma20, ma30, ma60);
            db.Bars.Add(bar);
        }
    }
}