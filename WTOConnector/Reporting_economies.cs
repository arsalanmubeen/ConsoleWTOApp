using System;
using System.Configuration;
using System.Data.SqlClient;

namespace WTOConnector
{
    public class Reporting_economies
    {
        public static void Reporting_economies_fn(string APIkey = "ddae623be7c2489f822320c33bd77fd3", string mainURL = "https://api.wto.org/timeseries/v1/")
        {
            var URL = mainURL + "reporters?subscription-key=" + APIkey;

            dynamic dynObj = APIRequest.Json_fn(URL);

            if (dynObj != null)
                DataAccess.insertReporting_economies(dynObj);

        }

    }
}
