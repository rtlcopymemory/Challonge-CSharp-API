using System;
using System.Net.Http;
using System.Web;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Challonge_API {
    public class Api {
        private Credentials credentials = new Credentials();
        private const String CHALLONGE_API_URL = "api.challonge.com/v1";
        private static readonly HttpClient client = new HttpClient();
        public enum Methods {GET, POST, PUT, DELETE}

        /*
         * Returns true if the credentials changed, false otherwise.
         */
        public bool setCredentials(string username, string token) {
            credentials.Username = username;
            credentials.Token = token;

            // Basic Auth
            String encoded = Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(credentials.Username + ":" + credentials.Token));
            if (!client.DefaultRequestHeaders.Contains("Authorization")) {
                client.DefaultRequestHeaders.Add("Authorization", "Basic " + encoded);
                return true;
            }
            return false;
        }

        public Tuple<string, string> getCredentials() {
            return new Tuple<string, string>(credentials.Username, credentials.Token);
        }

        /*
         * Returns the content of a request
         */
        public async Task<string> Fetch(Api.Methods method, string path, Dictionary<string, string> parameters = null) {
            if (!parameters.ContainsKey("api_key")) {
                parameters.Add("api_key", credentials.Token);
            }
            FormUrlEncodedContent content = new FormUrlEncodedContent(parameters);

            // Full Path
            string fullpath = "https://" + CHALLONGE_API_URL + "/" + path;

            HttpResponseMessage response = null;
            string query = "";
            switch (method) {
                case Methods.GET:
                    foreach (KeyValuePair<string, string> entry in parameters) {
                        query += HttpUtility.UrlEncode(entry.Key) + "=" + HttpUtility.UrlEncode(entry.Value) + "&";
                    }
                    response = await client.GetAsync(fullpath + "?" + query);
                    break;
                case Methods.POST:
                    response = await client.PostAsync(fullpath, content);
                    break;
                case Methods.PUT:
                    response = await client.PutAsync(fullpath, content);
                    break;
                case Methods.DELETE:
                    foreach (KeyValuePair<string, string> entry in parameters) {
                        query += HttpUtility.UrlEncode(entry.Key) + "=" + HttpUtility.UrlEncode(entry.Value) + "&";
                    }
                    response = await client.DeleteAsync(fullpath + "?" + query);
                    break;
                default:
                    response = null;
                    break;
            }

            if (response == null) return "";
            return await response.Content.ReadAsStringAsync();
        }

        /*
         * Returns the JObject (used like a Dictionary) of the response
         */
        public async Task<JObject> FetchAndParse(Api.Methods method, string path, Dictionary<string, string> body) {
            string responseAsString = await Fetch(method, path, body);
            if (responseAsString[0] == '{') {
                return new JObject(new JProperty("result", JObject.Parse(responseAsString)));
            }
            else {
                // The API either returns a {data...} which is a JSon object or a [data...] which is an array
                return new JObject(new JProperty("result", JArray.Parse(responseAsString)));
            }
        }
    }
}
