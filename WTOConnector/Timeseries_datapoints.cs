using Newtonsoft.Json.Linq;
using SharpCompress.Archives;
using SharpCompress.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;

namespace WTOConnector
{
    public class Timeseries_datapoints
    {
        public static void Timeseries_datapoints_fn(bool JsonLoad = true, string DownloadingPath = null, string APIkey = "ddae623be7c2489f822320c33bd77fd3", string mainURL = "https://api.wto.org/timeseries/v1/")
        {
            if (!JsonLoad)
            {
                DownloadingPath = DownloadingPath == null ? Environment.GetFolderPath(Environment.SpecialFolder.Desktop) : DownloadingPath;
                DownloadingPath = DownloadingPath.Contains("WTODownloadedFile") ? DownloadingPath : Path.Combine(DownloadingPath, "WTODownloadedFile");
                if (!Directory.Exists(DownloadingPath))
                    Directory.CreateDirectory(DownloadingPath);
            }
            string URL = string.Empty;
            //dynamic dynObj = null;
            string json = string.Empty, PATH;
            int startYear, endYear;
            try
            {
                DataTable dt = DataAccess.GetWTOIndicatorsCode();
                //Console.WriteLine("DATa GETDED");
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        //Console.WriteLine(Convert.ToString(row["Code"]));
                        startYear = Convert.ToInt32(row["startYear"]);
                        endYear = Convert.ToInt32(row["endYear"]);


                        if (JsonLoad)
                            if (startYear == 0 && endYear == 0)
                            {
                                URL = string.Format("{0}data?i={1}&max=1000000&subscription-key={2}", mainURL, Convert.ToString(row["Code"]), APIkey);
                                //URL = string.Format("{0}data?i={1}&ps=all&max=1000000&subscription-key={2}", Program.mainURL, "TP_B_0040", Program.APIkey);
                                json = APIRequest.Json_Response(URL);
                                SET_Timeseries_datapoint(json);
                                Thread.Sleep(2000);
                            }
                            else if (startYear == 0 || endYear == 0)
                            {
                                URL = string.Format("{0}data?i={1}&ps={3}&max=1000000&subscription-key={2}", mainURL, Convert.ToString(row["Code"]), APIkey, "all");
                                //URL = string.Format("{0}data?i={1}&ps=all&max=1000000&subscription-key={2}", Program.mainURL, "TP_B_0040", Program.APIkey);
                                json = APIRequest.Json_Response(URL);
                                SET_Timeseries_datapoint(json);
                                Thread.Sleep(2000);
                            }
                            else
                            {
                                for (int i = startYear; i < endYear + 1; i++)
                                {
                                    //Console.WriteLine(Convert.ToString(i));
                                    URL = string.Format("{0}data?i={1}&ps={3}&max=1000000&subscription-key={2}", mainURL, Convert.ToString(row["Code"]), APIkey, i);
                                    json = APIRequest.Json_Response(URL);
                                    SET_Timeseries_datapoint(json);
                                    Thread.Sleep(2000);
                                }
                            }
                        else// IF U WANT CSV DATA
                        {
                            if (startYear == 0 && endYear == 0)
                            { URL = string.Format("{0}data?i={1}&fmt=csv&max=1000000&subscription-key={2}", mainURL, Convert.ToString(row["Code"]), APIkey); }
                            else
                            { URL = string.Format("{0}data?i={1}&fmt=csv&ps=all&max=1000000&subscription-key={2}", mainURL, Convert.ToString(row["Code"]), APIkey); }


                            PATH = Path.Combine(DownloadingPath, Convert.ToString(row["Code"]) + ".rar");
                            try { WEBCALL(URL, PATH); }

                            catch (Exception EX)
                            {
                                if (EX.Message.Contains("The operation has timed out"))
                                {
                                    Thread.Sleep(3000);
                                    WEBCALL(URL, PATH); ;
                                }
                            }

                            try
                            {
                                using (var archive = ArchiveFactory.Open(PATH))
                                    foreach (var entry in archive.Entries)
                                    {
                                        entry.WriteToDirectory(DownloadingPath, new ExtractionOptions() { });

                                        File.Move(Path.Combine(DownloadingPath, entry.Key), Path.Combine(DownloadingPath, Convert.ToString(row["Code"]) + ".csv"));
                                    }
                                File.Delete(PATH);
                            }
                            catch (Exception) { }

                        }
                    }
                }
            }

            catch (Exception EX)
            {
                //Console.WriteLine(EX.Message);
                if (EX.Message.Contains("The operation has timed out"))
                {
                    Thread.Sleep(2000);
                    Timeseries_datapoints_fn(JsonLoad, DownloadingPath, APIkey, mainURL);
                }
               //Console.ReadKey();
            }

        }

        static void WEBCALL(string URL, string PATH)
        {
            Thread.Sleep(2000);
            WebClient myWebClient = new WebClient();
            myWebClient.DownloadFile(URL, PATH);
        }


        static void SET_Timeseries_datapoint(string json)
        {
            if (!string.IsNullOrEmpty(json))
            {
                if (JObject.Parse(json).ContainsKey("Dataset"))
                {
                    var resultObjects = JEnumerable<JObject>.Empty;
                    resultObjects = AllChildren(JObject.Parse(json)).First(c => c.Type == JTokenType.Array && c.Path.Contains("Dataset"))
                   .Children<JObject>();

                    //ClassWriteLineOnTEXt.Fun(json);

                    if (resultObjects.Any())
                    {
                        Timeseries_datapoint datapoint;
                        foreach (JObject result in resultObjects)
                        {
                            datapoint = new Timeseries_datapoint();

                            datapoint.IndicatorCategoryCode = Convert.ToString(result["IndicatorCategoryCode"]).Replace("'", "''");
                            datapoint.IndicatorCategory = Convert.ToString(result["IndicatorCategory"]).Replace("'", "''");
                            datapoint.IndicatorCode = Convert.ToString(result["IndicatorCode"]).Replace("'", "''");
                            datapoint.Indicator = Convert.ToString(result["Indicator"]).Replace("'", "''");
                            datapoint.ReportingEconomyCode = Convert.ToString(result["ReportingEconomyCode"]).Replace("'", "''");
                            datapoint.ReportingEconomy = Convert.ToString(result["ReportingEconomy"]).Replace("'", "''");
                            datapoint.PartnerEconomyCode = Convert.ToString(result["PartnerEconomyCode"]).Replace("'", "''");
                            datapoint.PartnerEconomy = Convert.ToString(result["PartnerEconomy"]).Replace("'", "''");
                            datapoint.ProductOrSectorClassificationCode = Convert.ToString(result["ProductOrSectorClassificationCode"]).Replace("'", "''");
                            datapoint.ProductOrSectorClassification = Convert.ToString(result["ProductOrSectorClassification"]).Replace("'", "''");
                            datapoint.ProductOrSectorCode = Convert.ToString(result["ProductOrSectorCode"]).Replace("'", "''");
                            datapoint.ProductOrSector = Convert.ToString(result["ProductOrSector"]).Replace("'", "''");
                            datapoint.PeriodCode = Convert.ToString(result["PeriodCode"]).Replace("'", "''");
                            datapoint.Period = Convert.ToString(result["Period"]).Replace("'", "''");
                            datapoint.FrequencyCode = Convert.ToString(result["FrequencyCode"]).Replace("'", "''");
                            datapoint.Frequency = Convert.ToString(result["Frequency"]).Replace("'", "''");
                            datapoint.UnitCode = Convert.ToString(result["UnitCode"]).Replace("'", "''");
                            datapoint.Unit = Convert.ToString(result["Unit"]).Replace("'", "''");
                            datapoint.Year = Convert.ToInt32((string)result["Year"] == null ? 0 : result["Year"]);
                            datapoint.ValueFlagCode = Convert.ToString(result["ValueFlagCode"]).Replace("'", "''");
                            datapoint.ValueFlag = Convert.ToString(result["ValueFlag"]).Replace("'", "''");
                            datapoint.TextValue = Convert.ToString(result["TextValue"]).Replace("'", "''");
                            datapoint.Value = Convert.ToDecimal(((string)result["Value"] == null || (string)result["Value"] == "") ? "0.0" : result["Value"]);


                            DataAccess.InsertTimeSeriesDataPoint(datapoint);
                        }

                    }
                }

            }
        }
        private static IEnumerable<JToken> AllChildren(JToken json)
        {
            foreach (var c in json.Children())
            {
                yield return c;
                foreach (var cc in AllChildren(c))
                {
                    yield return cc;
                }
            }
        }
    }

    public class Timeseries_datapoint
    {
        public string IndicatorCategoryCode { get; set; }
        public string IndicatorCategory { get; set; }
        public string IndicatorCode { get; set; }
        public string Indicator { get; set; }
        public string ReportingEconomyCode { get; set; }
        public string ReportingEconomy { get; set; }
        public string PartnerEconomyCode { get; set; }
        public string PartnerEconomy { get; set; }
        public string ProductOrSectorClassificationCode { get; set; }
        public string ProductOrSectorClassification { get; set; }
        public string ProductOrSectorCode { get; set; }
        public string ProductOrSector { get; set; }
        public string PeriodCode { get; set; }
        public string Period { get; set; }
        public string FrequencyCode { get; set; }
        public string Frequency { get; set; }
        public string UnitCode { get; set; }
        public string Unit { get; set; }
        public int Year { get; set; }
        public string ValueFlagCode { get; set; }
        public string ValueFlag { get; set; }
        public string TextValue { get; set; }
        public decimal Value { get; set; }
    }
}
