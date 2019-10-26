using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Challonge_API {
    class Matches {
        static async Task<JObject> Index(Api api, string tournament, Dictionary<string, string> parameters) {
            string path = "tournaments/" + tournament + "/matches.json";

            return await api.FetchAndParse(Api.Methods.GET, path, parameters);
        }

        static async Task<JObject> Show(Api api, string tournament, string matchId, Dictionary<string, string> parameters) {
            // https://api.challonge.com/v1/tournaments/{tournament}/matches/{match_id}.{json|xml}
            string path = "tournaments/" + tournament + "/matches/" + matchId + ".json";

            return await api.FetchAndParse(Api.Methods.GET, path, parameters);
        }
    }
}
