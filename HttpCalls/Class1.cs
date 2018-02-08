using System;
using System.IO;
using System.Net;
using System.Text;

namespace LogicApps.HttpCalls
{
    public class IntegrationOps
    {
        public void InsertData() {
            //var client = new RestClient("https://prod-35.westeurope.logic.azure.com:443/workflows/37e0e31c0f3a4f1cb32831edecbc1520/triggers/manual/paths/invoke?api-version=2016-10-01&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0&sig=GAh3EZWAij2NO7sDmCEEmhWvwBfolv93vTEeboSD-hE");
            //var request = new RestRequest(Method.POST);
            //request.AddHeader("Cache-Control", "no-cache");
            //request.AddHeader("Content-Type", "application/json");
            //request.AddParameter("application/json", "{\n\"Station\" : \"From RB\",\n\"PersonId\" : 1\n}", ParameterType.RequestBody);
            //IRestResponse response = client.Execute(request);

            var request = (HttpWebRequest)WebRequest.Create("https://prod-35.westeurope.logic.azure.com:443/workflows/37e0e31c0f3a4f1cb32831edecbc1520/triggers/manual/paths/invoke?api-version=2016-10-01&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0&sig=GAh3EZWAij2NO7sDmCEEmhWvwBfolv93vTEeboSD-hE");

            var postData = "{\n\"Station\" : \"From RB\",\n\"PersonId\" : 1\n}";
            var data = Encoding.ASCII.GetBytes(postData);

            request.Method = "POST";
            request.ContentType = "application/json";
            request.ContentLength = data.Length;

            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            var response = (HttpWebResponse)request.GetResponse();

            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
        }
    }
}
