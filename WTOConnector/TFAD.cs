using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;

namespace WTOConnector
{
    public class TFAD
    {
        public static void TFAD_fn(string APIkey = "ddae623be7c2489f822320c33bd77fd3", string mainURL = "https://tfadatabase.org/api/transparency/procedures_contacts_single_window?subscription-key=")
        {
            var URL = mainURL + APIkey;

            dynamic dynObj = APIRequest.Json_fn(URL);
            DataAccess.TADF_DATA(dynObj);
        }

    }
}
