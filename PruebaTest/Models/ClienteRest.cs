using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PruebaTest.Models
{
    public class ClienteRest<T>
    {
        public async Task<T> LLamarServicioPostGeneral<T2>(String apiUrl, String recurso, T2 Params)
        {
            try
            {
                Uri requestUrl = CreateRequestUri(apiUrl, string.Format(System.Globalization.CultureInfo.InvariantCulture,
                recurso));
                var serviceResult = default(T);
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Clear();
                    HttpResponseMessage Res = await client.PostAsync(requestUrl.ToString(), CreateHttpContent<T2>(Params));
                    String Response = Res.Content.ReadAsStringAsync().Result;
                    if (Res.IsSuccessStatusCode)
                    {
                        serviceResult = JsonConvert.DeserializeObject<T>(Response);
                    }
                    else
                    {
                        throw new Exception(Response);
                    }
                }
                return serviceResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private Uri CreateRequestUri(String BaseEndpoint, string relativePath, string queryString = "")
        {
            var uBaseEndpoint = new Uri(BaseEndpoint);
            var endpoint = new Uri(uBaseEndpoint, relativePath);
            var uriBuilder = new UriBuilder(endpoint);
            uriBuilder.Query = queryString;
            return uriBuilder.Uri;
        }
        private HttpContent CreateHttpContent<T2>(T2 content)
        {
            var json = JsonConvert.SerializeObject(content, MicrosoftDateFormatSettings);
            //var json = JsonConvert.SerializeObject(content);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }
        private static JsonSerializerSettings MicrosoftDateFormatSettings
        {
            get
            {
                return new JsonSerializerSettings
                {
                    DateFormatHandling = DateFormatHandling.MicrosoftDateFormat
                };
            }
        }
    }
}