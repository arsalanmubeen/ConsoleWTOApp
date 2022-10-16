using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.IO;
using System.Net;

namespace WTOConnector
{
    public class APIRequest
    {
        public static dynamic Json_fn(string URL)//, out int respCode)
        {
            dynamic dynObj = null;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
            HttpWebResponse webResponse = (HttpWebResponse)request.GetResponse();
            if (webResponse.StatusCode == HttpStatusCode.OK)
            {
                Stream webStream = webResponse.GetResponseStream();
                StreamReader responseReader = new StreamReader(webStream);
                string response = responseReader.ReadToEnd();
                dynObj = JsonConvert.DeserializeObject(response);
                //respCode = 1; //OK
            }
            else
            {
                //respCode = 0; //ERROR
            }

            return dynObj;
        }

        public static string Json_Response(string URL)//, out int respCode)
        {
            string json = string.Empty;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
            //try
            //{
                HttpWebResponse webResponse = (HttpWebResponse)request.GetResponse();


                if (webResponse.StatusCode == HttpStatusCode.OK)
                {
                    using (Stream webStream = webResponse.GetResponseStream())
                    {
                        using (StreamReader responseReader = new StreamReader(webStream))
                        {
                            json = responseReader.ReadToEnd();
                        }
                    }
                }
            //}
            //catch (WebException ex)
            //{
            //    if (ex.Status == WebExceptionStatus.ProtocolError)
            //    {
            //        URL = URL.Replace("&ps=all", "");
            //        json = Json_Response(URL);
            //    }
            //    else
            //        Console.WriteLine(ex.Message);
            //}
            return json;
        }
    }
}
