using System;
using System.Configuration;
using System.Data.SqlClient;

namespace WTOConnector
{
    public class Value_flags
    {
        public static void Value_flags_fn(string APIkey = "ddae623be7c2489f822320c33bd77fd3", string mainURL = "https://api.wto.org/timeseries/v1/")
        {
            var URL = mainURL + "value_flags?subscription-key=" + APIkey;

            dynamic dynObj = APIRequest.Json_fn(URL);

            if (dynObj != null)
                DataAccess.InsertValue_flags(dynObj);
        }

    }
}
