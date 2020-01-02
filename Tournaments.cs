using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Challonge_API {
    public class Tournaments {
        static public async Task<JObject> Index(Api api, Dictionary<string, string> parameters) {
            string path = "tournaments.json";

            return await api.FetchAndParse(Api.Methods.GET, path, parameters);
        }

        static public async Task<JObject> Create(Api api, Dictionary<string, string> parameters) {
            string path = "tournaments.json";
            if (!parameters.ContainsKey("tournament[name]") || !parameters.ContainsKey("tournament[url]")) {
                throw new MissingFieldException("Missing either tournament[name] or tournament[url]");
            }

            return await api.FetchAndParse(Api.Methods.POST, path, parameters);
        }

        static public async Task<JObject> Show(Api api, string tournament, Dictionary<string, string> parameters) {
            string path = "tournaments" + tournament + ".json";

            return await api.FetchAndParse(Api.Methods.GET, path, parameters);
        }

        static public async Task<JObject> Update(Api api, string tournament, Dictionary<string, string> parameters) {
            string path = "tournaments" + tournament + ".json";

            return await api.FetchAndParse(Api.Methods.PUT, path, parameters);
        }

        static public async Task<JObject> Destroy(Api api, string tournament, Dictionary<string, string> parameters) {
            string path = "tournaments" + tournament + ".json";

            return await api.FetchAndParse(Api.Methods.DELETE, path, parameters);
        }

        static public async Task<JObject> ProcessCheckIns(Api api, string tournament, Dictionary<string, string> parameters) {
            string path = "tournaments" + tournament + "/process_check_ins.json";

            return await api.FetchAndParse(Api.Methods.POST, path, parameters);
        }

        static public async Task<JObject> AbortCheckIns(Api api, string tournament, Dictionary<string, string> parameters) {
            string path = "tournaments" + tournament + "/abort_check_ins.json";

            return await api.FetchAndParse(Api.Methods.POST, path, parameters);
        }

        static public async Task<JObject> Start(Api api, string tournament, Dictionary<string, string> parameters) {
            string path = "tournaments" + tournament + "start.json";

            return await api.FetchAndParse(Api.Methods.POST, path, parameters);
        }

        static public async Task<JObject> Finalize(Api api, string tournament, Dictionary<string, string> parameters) {
            string path = "tournaments" + tournament + "finalize.json";

            return await api.FetchAndParse(Api.Methods.POST, path, parameters);
        }

        static public async Task<JObject> Reset(Api api, string tournament, Dictionary<string, string> parameters) {
            string path = "tournaments" + tournament + "reset.json";

            return await api.FetchAndParse(Api.Methods.POST, path, parameters);
        }

        static public async Task<JObject> OpenForPredictions(Api api, string tournament, Dictionary<string, string> parameters) {
            string path = "tournaments" + tournament + "open_for_predictions.json";

            return await api.FetchAndParse(Api.Methods.POST, path, parameters);
        }
    }
}
