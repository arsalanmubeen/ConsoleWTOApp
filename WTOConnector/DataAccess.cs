using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace WTOConnector
{
    public class DataAccess
    {
        public static string ConnString
        {
            get
            {
                return @"Data Source=DESKTOP-EIL08RK\MSSQLSERVER_ARSL;Initial Catalog=WTO_DB;Integrated Security=True";
            }
        }

        #region Timeseries_datapoints

        public static DataTable GetWTOIndicatorsCode()
        {
            SqlConnection conn = new SqlConnection(ConnString);
            conn.Open();
            using (conn)
            {
                SqlCommand cmd = new SqlCommand("Select Code,startYear,endYear from WTOIndicators", conn);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    return dt;
                }
            }
        }
        public static string response;
        public static void InsertTimeSeriesDataPoint(Timeseries_datapoint datapoint)
        {

            SqlConnection conn = new SqlConnection(ConnString);
            conn.Open();
            using (conn)
            {

                SqlCommand cmd = new SqlCommand("WTO_SP_DataAccess", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("indicatorCategoryCode", datapoint.IndicatorCategoryCode);
                cmd.Parameters.AddWithValue("indicatorCategory", datapoint.IndicatorCategory);
                cmd.Parameters.AddWithValue("indicatorCode", datapoint.IndicatorCode);
                cmd.Parameters.AddWithValue("indicator", datapoint.Indicator);
                cmd.Parameters.AddWithValue("reportingEconomyCode", datapoint.ReportingEconomyCode);
                cmd.Parameters.AddWithValue("reportingEconomy", datapoint.ReportingEconomy);
                cmd.Parameters.AddWithValue("partnerEconomyCode", datapoint.PartnerEconomyCode);
                cmd.Parameters.AddWithValue("partnerEconomy", datapoint.PartnerEconomy);
                cmd.Parameters.AddWithValue("productOrSectorClassificationCode", datapoint.ProductOrSectorClassificationCode);
                cmd.Parameters.AddWithValue("productOrSectorClassification", datapoint.ProductOrSectorClassification);
                cmd.Parameters.AddWithValue("productOrSectorCode", datapoint.ProductOrSectorCode);
                cmd.Parameters.AddWithValue("productOrSector", datapoint.ProductOrSector);
                cmd.Parameters.AddWithValue("periodCode", datapoint.PeriodCode);
                cmd.Parameters.AddWithValue("period", datapoint.Period);
                cmd.Parameters.AddWithValue("frequencyCode", datapoint.FrequencyCode);
                cmd.Parameters.AddWithValue("frequency", datapoint.Frequency);
                cmd.Parameters.AddWithValue("unitCode", datapoint.UnitCode);
                cmd.Parameters.AddWithValue("unit", datapoint.Unit);
                cmd.Parameters.AddWithValue("year", datapoint.Year);
                cmd.Parameters.AddWithValue("valueFlagCode", datapoint.ValueFlagCode);
                cmd.Parameters.AddWithValue("valueFlag", datapoint.ValueFlag);
                cmd.Parameters.AddWithValue("textValue", datapoint.TextValue);
                cmd.Parameters.AddWithValue("value", datapoint.Value);
                cmd.Parameters.AddWithValue("TableName", "WTOTimeseries_datapoints");

                cmd.ExecuteNonQuery();
            }


        }



        #endregion

        #region TruncateTable

        public static void TruncateTableFun()
        {

            string[] Tablename = new string[]
            {
                "WTOIndicators",
                "Partner_economies",
                "Years" ,
                "Topics",
                "Frequencies",
                "Periods",
                "Units",
                "Indicator_categories",
                "Geographical_regions",
                "Economic_groups",
                "Reporting_economies",
                "Classifications",
                "Products_sectors",
                "TADFCountryName",
                "TADF_import_export_and_transit_procedures",
                "TADF_Enquiry_points",
                "Value_flags",
                "WTOTimeseries_datapoints"
            };
            SqlConnection conn = new SqlConnection(ConnString);
            conn.Open();
            using (conn)
            {
                for (int i = 0; i < Tablename.Length; i++)
                {
                    SqlCommand cmd = new SqlCommand("truncate table " + Tablename[i] + ";", conn);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        #endregion

        #region Classifications
        public static void InsertClassifications(dynamic dynObj)
        {
            string name;
            SqlConnection conn = new SqlConnection(ConnString);
            conn.Open();
            using (conn)
            {
                foreach (var item in dynObj)
                {
                    name = (string)item.name;

                    SqlCommand cmd = new SqlCommand("WTO_SP_DataAccess", conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.AddWithValue("code", (string)item.code);
                    cmd.Parameters.AddWithValue("name", name.Replace("'", "''"));
                    cmd.Parameters.AddWithValue("TableName", "Classifications");


                    //SqlCommand cmd = new SqlCommand("insert into Classifications values('" + (string)item.code + "'," +
                    //    "'" + name.Replace("'", "''") + "'" + ");", conn);

                    cmd.ExecuteNonQuery();

                }
            }


        }

        #endregion

        #region Economic_groups

        public static void InsertEconomic_groups(dynamic dynObj)
        {
            SqlConnection conn = new SqlConnection(ConnString);
            conn.Open();
            using (conn)
            {
                foreach (var item in dynObj)
                {

                    SqlCommand cmd = new SqlCommand("insert into Economic_groups values('" + (string)item.code + "'," +
                        "'" + (string)item.name + "'," +
                        Convert.ToInt32(item.displayOrder) + ");", conn);
                    cmd.ExecuteNonQuery();

                }
            }

        }
        #endregion

        #region Frequencies

        public static void insertFrequencies(dynamic dynObj)
        {
            SqlConnection conn = new SqlConnection(ConnString);
            conn.Open();
            using (conn)
            {
                foreach (var item in dynObj)
                {

                    SqlCommand cmd = new SqlCommand("insert into Frequencies values('" + (string)item.code + "'," +
                        "'" + (string)item.name + "');", conn);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        #endregion

        #region Geographical_regions

        public static void InsertGeographical_regions(dynamic dynObj)
        {
            SqlConnection conn = new SqlConnection(ConnString);
            conn.Open();
            using (conn)
            {
                foreach (var item in dynObj)
                {

                    SqlCommand cmd = new SqlCommand("insert into Geographical_regions values('" + (string)item.code + "'," +
                        "'" + (string)item.name + "'," +
                        Convert.ToInt32(item.displayOrder) + ");", conn);
                    cmd.ExecuteNonQuery();

                }
            }
        }
        #endregion

        #region Indicator_categories
        public static void InsertIndicator_categories(dynamic dynObj)
        {
            SqlConnection conn = new SqlConnection(ConnString);
            conn.Open();
            using (conn)
            {
                foreach (var item in dynObj)
                {

                    SqlCommand cmd = new SqlCommand("insert into indicator_categories values('" + (string)item.code + "'," +
                        "'" + (string)item.name + "'," +
                        "'" + (string)item.parentCode + "'," +
                        Convert.ToInt32(item.sortOrder) + ");", conn);
                    cmd.ExecuteNonQuery();

                }
            }
        }
        #endregion

        #region Indicators
        public static void InsertIndicators(dynamic dynObj)
        {
            SqlConnection conn = new SqlConnection(ConnString);
            conn.Open();
            using (conn)
            {
                foreach (var item in dynObj)
                {

                    SqlCommand cmd = new SqlCommand("insert into WTOIndicators values('" + (string)item.code + "'," +
                        "'" + (string)item.name + "'," +
                        "'" + (string)item.categoryCode + "'," +
                        "'" + (string)item.categoryLabel + "'," +
                        "'" + (string)item.subcategoryCode + "'," +
                        "'" + (string)item.subcategoryLabel + "'," +
                        "'" + (string)item.unitCode + "'," +
                        "'" + (string)item.unitLabel + "'," +
                              Convert.ToInt32(item.startYear) + "," +
                              Convert.ToInt32(item.endYear) + "," +
                        "'" + (string)item.frequencyCode + "'," +
                        "'" + (string)item.frequencyLabel + "'," +
                              Convert.ToInt32(item.numberReporters) + "," +
                              Convert.ToInt32(item.numberPartners == null ? 0 : item.numberPartners) + "," +
                        "'" + (string)item.productSectorClassificationCode + "'," +
                        "'" + (string)item.productSectorClassificationLabel + "'," +
                        "'" + (string)item.hasMetadata + "'," +
                              Convert.ToInt32(item.numberDecimals) + "," +
                              Convert.ToInt32(item.numberDatapoints) + "," +
                        "'" + (string)item.updateFrequency + "'," +
                        "'" + (string)item.description + "'," +
                              Convert.ToInt32(item.sortOrder) + ");", conn);

                    cmd.ExecuteNonQuery();

                }
            }

        }
        #endregion

        #region Partner_economies
        public static void InsertPartner_economies(dynamic dynObj)
        {
            string name;
            SqlConnection conn = new SqlConnection(ConnString);
            conn.Open();
            using (conn)
            {
                foreach (var item in dynObj)
                {
                    name = (string)item.name;
                    SqlCommand cmd = new SqlCommand("insert into Partner_economies values('" + (string)item.code + "'," +
                        "'" + (string)item.iso3A + "'," +
                        "'" + name.Replace("'", "''") + "'," +
                        Convert.ToInt32(item.displayOrder) + ");", conn);

                    cmd.ExecuteNonQuery();

                }
            }
        }
        #endregion

        #region Periods
        public static void insertPeriods(dynamic dynObj)
        {
            SqlConnection conn = new SqlConnection(ConnString);
            conn.Open();
            using (conn)
            {
                foreach (var item in dynObj)
                {

                    SqlCommand cmd = new SqlCommand("insert into Periods values('" + (string)item.code + "'," +
                        "'" + (string)item.name + "'," +
                        "'" + (string)item.description + "'," +
                        "'" + (string)item.frequencyCode + "'," +
                        Convert.ToInt32(item.displayOrder) + ");", conn);

                    cmd.ExecuteNonQuery();

                }
            }

        }
        #endregion

        #region Products_sectors
        public static void InsertProducts_sectors(dynamic dynObj)
        {
            string name;
            SqlConnection conn = new SqlConnection(ConnString);
            conn.Open();
            using (conn)
            {
                foreach (var item in dynObj)
                {
                    name = (string)item.name;
                    SqlCommand cmd = new SqlCommand("insert into Products_sectors values('" + (string)item.code + "'," +
                        "'" + name.Replace("'", "''") + "'," +
                        "'" + (string)item.note + "'," +
                        "'" + (string)item.productClassification + "'," +
                        "'" + (string)item.codeUnique + "'," +
                              Convert.ToInt32(item.displayOrder == null ? 0 : item.displayOrder) + "," +
                        "'" + (string)item.hierarchy + "'" + ");", conn);

                    cmd.ExecuteNonQuery();

                }
            }
        }
        #endregion

        #region Reporting_economies
        public static void insertReporting_economies(dynamic dynObj)
        {
            string name;
            SqlConnection conn = new SqlConnection(ConnString);
            conn.Open();
            using (conn)
            {
                foreach (var item in dynObj)
                {
                    name = (string)item.name;
                    SqlCommand cmd = new SqlCommand("insert into Reporting_economies values('" + (string)item.code + "'," +
                        "'" + (string)item.iso3A + "'," +
                        "'" + name.Replace("'", "''") + "'," +
                        Convert.ToInt32(item.displayOrder) + ");", conn);

                    cmd.ExecuteNonQuery();

                }
            }
        }
        #endregion

        #region Time_period
        public static void InsertTime_period(dynamic dynObj)
        {
            string name;
            SqlConnection conn = new SqlConnection(ConnString);
            conn.Open();
            using (conn)
            {
                foreach (var item in dynObj)
                {
                    name = (string)item.name;
                    SqlCommand cmd = new SqlCommand("insert into Years values(" + Convert.ToInt32((string)item.year) + ");", conn);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        #endregion

        #region Topics
        public static void InsertTopics(dynamic dynObj)
        {
            string name;
            SqlConnection conn = new SqlConnection(ConnString);
            conn.Open();
            using (conn)
            {
                foreach (var item in dynObj)
                {
                    name = (string)item.name;
                    SqlCommand cmd = new SqlCommand("insert into Topics values('" + (string)item.id + "'," +
                        "'" + (string)item.name + "'," +
                        Convert.ToInt32(item.sortOrder) + ");", conn);

                    cmd.ExecuteNonQuery();

                }
            }

        }
        #endregion

        #region Units
        public static void InsertUnits(dynamic dynObj)
        {
            SqlConnection conn = new SqlConnection(ConnString);
            conn.Open();
            using (conn)
            {
                foreach (var item in dynObj)
                {

                    SqlCommand cmd = new SqlCommand("insert into Units values('" + (string)item.code + "'," +
                        "'" + (string)item.name + "');", conn);
                    cmd.ExecuteNonQuery();

                }
            }
        }
        #endregion

        #region Value_flags
        public static void InsertValue_flags(dynamic dynObj)
        {
            SqlConnection conn = new SqlConnection(ConnString);
            conn.Open();
            using (conn)
            {
                foreach (var item in dynObj)
                {

                    SqlCommand cmd = new SqlCommand("insert into Value_flags values('" + (string)item.code + "'," +
                        "'" + (string)item.description + "'" + ");", conn);

                    cmd.ExecuteNonQuery();

                }
            }

        }
        #endregion

        #region TAFD
        public static void TADF_DATA(dynamic dynObj)
        {
            SqlConnection conn = new SqlConnection(ConnString);
            conn.Open();
            string name = string.Empty,
                ID = string.Empty,
                title,
                description,
                email,
                telephone,
                fax,
                single_window;
          
            using (conn)
            {
                foreach (var item in dynObj)
                {
                    name = (string)item.name;
                    ID = (string)item.id;
                    single_window= string.Empty;
                    SqlCommand cmd;
                    if (item.single_window != null)
                    {
                        single_window = (string)item.single_window;

                        cmd = new SqlCommand("insert into [TADFCountryName] values('" + name.Replace("'", "''") + "'," +
                             "'" + ID + "'," +
                            "'" + single_window.Replace("'", "''") + "'" + ");", conn);
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        cmd = new SqlCommand("insert into [TADFCountryName] values('" + name.Replace("'", "''") + "'," +
                             "'" + ID + "'," +
                            "'" + single_window + "'" + ");", conn);
                        cmd.ExecuteNonQuery();
                    }
                    
                  
                    if (item.import_export_and_transit_procedures != null)
                    {
                        title = string.Empty;
                        description = string.Empty;
                        email = string.Empty;
                        telephone = string.Empty;
                        fax = string.Empty;

                        foreach (var item2 in item.import_export_and_transit_procedures)
                        {
                            title = (string)item2.title == null ? "" : (string)item2.title;
                            description = (string)item2.description;
                            email = (string)item2.email;
                            telephone = (string)item2.telephone;
                            fax = (string)item2.fax;

                            foreach (var item3 in item2.websites)
                            {
                                 cmd = new SqlCommand("insert into [TADF_import_export_and_transit_procedures] values('" + ID + "'," +
                                         "'" + title.Replace("'", "''") + "'," +
                                         "'" + description.Replace("'", "''") + "'," +
                                         "'" + email + "'," +
                                          "'" + telephone + "'," +
                                         "'" + fax + "'," +
                                         "'" + (string)item3 + "'" + ");", conn);

                                    cmd.ExecuteNonQuery();
                            }

                        }

                    }

                    if (item.enquiry_points != null)
                    {
                        title = string.Empty;
                        description = string.Empty;
                        email = string.Empty;
                        telephone = string.Empty;
                        fax = string.Empty;

                        foreach (var item2 in item.enquiry_points)
                        {
                            title = (string)item2.title == null ? "" : (string)item2.title;
                            description = (string)item2.description;
                            email = (string)item2.email;
                            telephone = (string)item2.telephone;
                            fax = (string)item2.fax;

                            foreach (var item3 in item2.websites)
                            {
                                cmd = new SqlCommand("insert into [TADF_Enquiry_points] values('" + ID + "'," +
                                        "'" + title.Replace("'", "''") + "'," +
                                        "'" + description.Replace("'", "''") + "'," +
                                        "'" + email + "'," +
                                         "'" + telephone + "'," +
                                        "'" + fax + "'," +
                                        "'" + (string)item3 + "'" + ");", conn);

                                cmd.ExecuteNonQuery();
                            }

                        }

                    }
                }
            }
        }
        #endregion

    }
}
