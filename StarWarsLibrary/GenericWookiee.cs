using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace StarWarsLibrary
{
    public abstract class GenericHttpWookiee<T> where T : class
    {
        private HttpClient client;
        private string apiUrl;
        public GenericHttpWookiee()
        {
            client = new HttpClient();
            apiUrl = "http://swapi.dev/api";
        }


        private string GetUrl(string endpoint)
        {
            string url = string.Empty;
            Uri uriResult;
            if (Uri.TryCreate(endpoint, UriKind.Absolute, out uriResult) && uriResult.Scheme == Uri.UriSchemeHttp)
            {
                url = endpoint;
            }
            else
            {
                url = string.Concat(apiUrl, endpoint);
            }
            return url;
        }
        private async Task<HttpResponseMessage> GetResponseMessage(string endpoint)
        {
            HttpResponseMessage response = await client.GetAsync(new Uri(GetUrl(endpoint)));
            response.EnsureSuccessStatusCode();
            return response;
        }
        
        private async Task<String> GetResultData(HttpResponseMessage response)
        {
            String responseString = null;
            if (response.IsSuccessStatusCode)
            {
                if (response.Content is object && response.Content.Headers.ContentType.MediaType == "application/json")
                {
                    responseString = await response.Content.ReadAsStringAsync();
                }
            }
            return responseString;

        }

        protected IList<T> PaginatedData(string endpoint)
        {
            List<T> entityCollection = new List<T>();
                    try
                    {
                        var entity = JsonConvert.DeserializeObject<StarWarsEntity<T>>(GetResultData(GetResponseMessage(endpoint).Result).Result);
                        entityCollection.AddRange(entity.results);
                        while (entity.next!=null)
                        {
                                 entity = JsonConvert.DeserializeObject<StarWarsEntity<T>>(GetResultData(
                                 GetResponseMessage(entity.next).Result).Result);
                                 entityCollection.AddRange(entity.results);
                        }

                    }
                    catch (Exception)
                    {
                        throw;
                    }

            return entityCollection;

        }

        protected T GetSingleData(string endpoint)
        {
            T entity = null;
            try
            {
                 entity = JsonConvert.DeserializeObject<T>(GetResultData(GetResponseMessage(endpoint).Result).Result);
              

            }
            catch (Exception)
            {
                throw;
            }

            return entity;
        }
    }
}
