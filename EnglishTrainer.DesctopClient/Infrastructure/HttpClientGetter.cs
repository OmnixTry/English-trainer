using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace EnglishTrainer.DesctopClient.Infrastructure
{
    static class HttpClientGetter
    {
        static async Task<HttpResponseMessage> PostAsync<T>(this HttpClient httpClient, string url, T data)
        {
            var dataAsString = JsonConvert.SerializeObject(data);
            var content = new StringContent(dataAsString);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return await httpClient.PostAsync(url, content);
        }

        static async Task<T> ReadAsJsonAsync<T>(this HttpContent content)
        {
            var dataAsString = await content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(dataAsString);
        }

        static StringContent MakeStringContent<T>(T data)
        {
            string serializedData = JsonConvert.SerializeObject(data);
            StringContent content = new StringContent(serializedData);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return content;
        }

        static HttpClient CreateHttpClient()
        {
            var handler = new HttpClientHandler();
            handler.ClientCertificateOptions = ClientCertificateOption.Manual;
            handler.ServerCertificateCustomValidationCallback =
                (httpRequestMessage, cert, cetChain, policyErrors) =>
                {
                    return true;
                };

            return new HttpClient(handler);
        }

        public static async Task<ReturnType> PostRequrestAsync<DataType, ReturnType>(string url, DataType data)
        {
            using (HttpClient client = CreateHttpClient())
            {
                StringContent content = MakeStringContent(data);
                HttpResponseMessage response = client.PostAsync(url, content).Result;
                string text = await response.Content.ReadAsStringAsync();
                return await HttpContentExtensions.ReadAsJsonAsync<ReturnType>(response.Content);
            }
        }

        public static async Task<ReturnType> GetResultAsync<ReturnType>(string url)
        {
            using (HttpClient client = CreateHttpClient())
            {
                HttpResponseMessage response = client.GetAsync(url).Result;
                string text = await response.Content.ReadAsStringAsync();
                return await HttpContentExtensions.ReadAsJsonAsync<ReturnType>(response.Content);
            }
        }

    }
}
