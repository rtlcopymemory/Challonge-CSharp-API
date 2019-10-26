using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Challonge_API {
    public class Api {
        private Credentials credentials;
        private const String CHALLONGE_API_URL = "api.challonge.com/v1";
        private static readonly HttpClient client = new HttpClient();
        public enum Methods {GET, POST, PUT, DELETE}

        /*
         * Returns true if the credentials changed, false otherwise.
         * You may only set the credentials once, this is to protect the data after the first set
         */
        public bool setCredentials(string username, string token) {
            if (credentials == null) {
                credentials.Username = username;
                credentials.Token = token;
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
        public async Task<String> Fetch(Api.Methods method, string path, Dictionary<string, string> body) {
            FormUrlEncodedContent content = new FormUrlEncodedContent(body);
            string fullpath = "https://" + CHALLONGE_API_URL + "/" + path;

            HttpResponseMessage response = null;
            switch (method) {
                case Methods.GET:
                    response = await client.GetAsync(fullpath);
                    break;
                case Methods.POST:
                    response = await client.PostAsync(fullpath, content);
                    break;
                case Methods.PUT:
                    response = await client.PutAsync(fullpath, content);
                    break;
                case Methods.DELETE:
                    response = await client.DeleteAsync(fullpath);
                    break;
                default:
                    response = null;
                    break;
            }

            if (response == null) return "";
            return response.Content.ReadAsStringAsync().ToString();
        }

        /*
         * Returns the JObject (used like a Dictionary) of the response
         */
        public async Task<JObject> FetchAndParse(Api.Methods method, string path, Dictionary<string, string> body) {
            string responseAsString = await Fetch(method, path, body);
            return JObject.Parse(responseAsString);
        }
    }
}
