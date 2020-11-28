using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace W6OP.HamCockpitPlugins.SpaceWeather
{
    class WebManager
    {
        private readonly HttpClient client = new HttpClient();

        /// <summary>
        /// 
        /// </summary>
        public WebManager()
        {

        }

        internal string RetrieveSunSpotData(string url)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="imageUrl"></param>
        /// <returns></returns>
        public Image DownloadImageFromUrl(string imageUrl)
        {
            Image image;
            try
            {
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(imageUrl);
                webRequest.AllowWriteStreamBuffering = true;
                webRequest.Timeout = 30000;

                WebResponse webResponse = webRequest.GetResponse();

                Stream stream = webResponse.GetResponseStream();

                image = Image.FromStream(stream);

                webResponse.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

            return image;
        }

        public string DownloadDataFromUrl(string url)
        {
            string data = null;

            try
            {
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
                webRequest.AllowWriteStreamBuffering = true;
                webRequest.Timeout = 30000;

                WebResponse webResponse = webRequest.GetResponse();

                Stream stream = webResponse.GetResponseStream();

                //image = Image.FromStream(stream);

                webResponse.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

            return data;
        }

       

        public async Task<string> GetJsonAsync(string uri)
        {
            string json = null;

            HttpResponseMessage response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                json = await response.Content.ReadAsStringAsync();
            }
            return json;
        }

    } // end class
}
