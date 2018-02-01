using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using XamarinTemplate.Schemas;

namespace XamarinTemplate {

    public class RestService {

        HttpClient client = new HttpClient();

        public string urlRestApi = "";
        public string contentType = "application/json";

        public RestService() { }

        // ======================================================================
        // Method
        // ======================================================================

        private float count = 1;
        private float limit = 5;

        public async Task<string> GETAsync (string url) {

            try {

                // check limit
                if (count > limit) { return null; }

                // next count
                count++;

                // send a GET request  
                var resultString = await client.GetStringAsync(GetRequest(url));

                // handling the answer  
                return JsonConvert.DeserializeObject(resultString).ToString();

            } catch (Exception e) {

                // Console
                Console.WriteLine(e.Message);

                // Return Data  
                return await GETAsync(url);

            }

        }

        public async Task<string> POSTAsync (Object paramsRoute) {

            try {

                // check limit
                if (count > limit) { return null; }

                // next count
                count++;

                // Create a new Route  
                var route = new RouteSchema { route = paramsRoute };

                // create the request content and define Json
                var json = JsonConvert.SerializeObject(route);
                var content = new StringContent(json, Encoding.UTF8, contentType);

                //  send a POST request  
                var result = await client.PostAsync(GetRequest(), content);

                // on error throw a exception  
                result.EnsureSuccessStatusCode();

                // handling the answer  
                var resultString = await result.Content.ReadAsStringAsync();

                // handling the answer  
                return JsonConvert.DeserializeObject(resultString).ToString();

            } catch (Exception e) {

                // Console
                Console.WriteLine(e.Message);

                // Return Data  
                return await POSTAsync(paramsRoute);

            }

        }

        public async Task<string> PUTAsync (Object paramsRoute) {

            try {

                // check limit
                if (count > limit) { return null; }

                // next count
                count++;

                // Create a new Route  
                var route = new RouteSchema { route = paramsRoute };

                // create the request content and define Json
                var json = JsonConvert.SerializeObject(route);
                var content = new StringContent(json, Encoding.UTF8, contentType);

                //  send a POST request  
                var result = await client.PutAsync(GetRequest(), content);

                // on error throw a exception  
                result.EnsureSuccessStatusCode();

                // handling the answer  
                var resultString = await result.Content.ReadAsStringAsync();

                // handling the answer  
                return JsonConvert.DeserializeObject(resultString).ToString();

            } catch (Exception e) {

                // Console
                Console.WriteLine(e.Message);

                // Return Data  
                return await PUTAsync(paramsRoute);

            }

        }

        public async Task<string> DELETEAsync (string url) {

            try {

                // check limit
                if (count > limit) { return null; }

                // next count
                count++;

                // send a GET request  
                var resultString = await client.GetStringAsync(GetRequest(url));

                // handling the answer  
                return JsonConvert.DeserializeObject(resultString).ToString();

            } catch (Exception e) {

                // Console
                Console.WriteLine(e.Message);

                // Return Data  
                return await DELETEAsync(url);

            }

        }

        // ======================================================================
        // HTTP Request & Response
        // ======================================================================

        public string GetRequest (string url = null) {
            return (string.IsNullOrWhiteSpace(url)) ? string.Format(urlRestApi) : string.Format(url);
        }

        public String toString (Object objectToSerialize) {
            return JsonConvert.SerializeObject(objectToSerialize);
        }

        public ResponseSchema toObject (String stringToDeserialize) {
            return JsonConvert.DeserializeObject<ResponseSchema>(stringToDeserialize);
        }

    }

}