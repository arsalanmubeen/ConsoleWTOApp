using System;

namespace WTOConnector
{
    public class Program
    {
        public static string mainURL = "https://api.wto.org/timeseries/v1/";
        public static string APIkey = "ddae623be7c2489f822320c33bd77fd3";
        static void Main()
        {



            //DataAccess.TruncateTableFun();
            //Console.WriteLine("TruncateTable done");
            //Indicators.Indicators_fn();
            //Console.WriteLine("Indicators done");
            //Partner_economies.Partner_economies_fn();
            //Console.WriteLine("Partner_economies done");
            //Time_period.Year_fn();
            //Console.WriteLine("Time_period done");
            //Topics.Topics_fn();
            //Console.WriteLine("Topics done");
            //Frequencies.Frequencies_fn();
            //Console.WriteLine("Frequencies done");
            //Periods.Periods_fn();
            //Console.WriteLine("Periods done");
            //Units.Units_fn();
            //Console.WriteLine("Units done");
            //Indicator_categories.Indicator_categories_fn();
            //Console.WriteLine("Indicator_categories done");
            //Geographical_regions.Geographical_regions_fn();
            //Console.WriteLine("Geographical_regions done");
            //Economic_groups.Economic_groups_fn();
            //Console.WriteLine("Economic_groups done");
            //Reporting_economies.Reporting_economies_fn();
            //Console.WriteLine("Reporting_economies done");
            //Classifications.Classifications_fn();
            //Console.WriteLine("Classifications done");
            //Products_sectors.Products_sectors_fn();
            //Console.WriteLine("Products_sectors done");
            //Value_flags.Value_flags_fn();
            //Console.WriteLine("Value_flags done");
            //TFAD.TFAD_fn();
            //Console.WriteLine("TFAD done");
            Timeseries_datapoints.Timeseries_datapoints_fn(false);
            Console.WriteLine("Timeseries_datapoints done");
            Console.ReadKey();



        }
    }
}
