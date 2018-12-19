using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using Google.Apis.Customsearch.v1;
using Google.Apis.Customsearch.v1.Data;

namespace CCrawlerTest
{
    class Program
    {
        public static void testGoogle(String keyword)
        {
            const string apiKey = "AIzaSyDX1_JJycCOwHk3XVDezpiemFbY3DMulUY";
            const string searchEngineId = "006042953132409517175:duovc56jfew";
            var query = keyword;
            string[] newUrl = new string[100];
            var count = 0;
            CustomsearchService customSearchService = new CustomsearchService(new Google.Apis.Services.BaseClientService.Initializer() { ApiKey = apiKey });
            CseResource.ListRequest listRequest = customSearchService.Cse.List(query);
            listRequest.Cx = searchEngineId;
            for (int i = 1; i <= 90; i += 10)
            {
                listRequest.Start = i;
                listRequest.Safe = CseResource.ListRequest.SafeEnum.Medium;
                Search search = listRequest.Execute();
                foreach (var item in search.Items)
                {
                    string holding = item.Link;
                    newUrl[count] = holding;
                    count += 1;
                    Console.WriteLine("Title : " + item.Title + Environment.NewLine + "Link : " + item.Link + Environment.NewLine + Environment.NewLine);
                }
            }
        }

        public static void FaceBookTets()
        {

        }

        static void Main(String[] args)
        {
            testGoogle("Погода");
            //WebRequest request = WebRequest.Create("http://engineerverse.com/");
            //using (var response = (HttpWebResponse)request.GetResponse())
            //{

            //    if (response.StatusCode == HttpStatusCode.OK)
            //    {
            //        using (var dataStream = response.GetResponseStream())
            //        {
            //            using (var reader = new StreamReader(dataStream))
            //            {
            //                String responseFromServer = reader.ReadToEnd();
            //                Console.WriteLine(responseFromServer);
            //            }

            //        }
            //    }
            //}

        }
    }
}
