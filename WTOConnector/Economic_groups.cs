using System;
using System.Configuration;
using System.Data.SqlClient;

namespace WTOConnector
{
    public class Economic_groups
    {
        public static void Economic_groups_fn(string APIkey = "ddae623be7c2489f822320c33bd77fd3", string mainURL = "https://api.wto.org/timeseries/v1/")
        {
            var URL = mainURL + "territory/groups?subscription-key=" + APIkey;

            dynamic dynObj = APIRequest.Json_fn(URL);
            if (dynObj != null)
                DataAccess.InsertEconomic_groups(dynObj);

        }

    }
}
