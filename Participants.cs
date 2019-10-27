using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Challonge_API {
    class Participants {
        static async Task<JObject> Index(Api api, string tournament, Dictionary<string, string> parameters) {
            string path = "tournaments" + tournament + "/participants.json";

            return await api.FetchAndParse(Api.Methods.GET, path, parameters);
        }

        static async Task<JObject> Create(Api api, string tournament, Dictionary<string, string> parameters) {
            string path = "tournaments" + tournament + "/participants.json";

            return await api.FetchAndParse(Api.Methods.POST, path, parameters);
        }

        static async Task<JObject> BulkAdd(Api api, string tournament, Dictionary<string, string> parameters) {
            string path = "tournaments" + tournament + "/participants/bulk_add.json";

            return await api.FetchAndParse(Api.Methods.POST, path, parameters);
        }

        static async Task<JObject> Show(Api api, string tournament, Dictionary<string, string> parameters) {
            string path = "tournaments" + tournament + "/participants.json";

            return await api.FetchAndParse(Api.Methods.GET, path, parameters);
        }

        static async Task<JObject> Update(Api api, string tournament, string participantId, Dictionary<string, string> parameters) {
            string path = "tournaments" + tournament + "/participants/" + participantId + ".json";

            return await api.FetchAndParse(Api.Methods.PUT, path, parameters);
        }

        static async Task<JObject> CheckIn(Api api, string tournament, string participantId, Dictionary<string, string> parameters) {
            string path = "tournaments" + tournament + "/participants/" + participantId + "/check_in.json";

            return await api.FetchAndParse(Api.Methods.POST, path, parameters);
        }

        static async Task<JObject> UndoCheckIn(Api api, string tournament, string participantId, Dictionary<string, string> parameters) {
            string path = "tournaments" + tournament + "/participants/" + participantId + "/undo_check_in.json";

            return await api.FetchAndParse(Api.Methods.POST, path, parameters);
        }

        static async Task<JObject> Destroy(Api api, string tournament, string participantId, Dictionary<string, string> parameters) {
            string path = "tournaments" + tournament + "/participants/" + participantId + ".json";

            return await api.FetchAndParse(Api.Methods.DELETE, path, parameters);
        }

        static async Task<JObject> ClearAll(Api api, string tournament, Dictionary<string, string> parameters) {
            string path = "tournaments" + tournament + "/participants/clear.json";

            return await api.FetchAndParse(Api.Methods.DELETE, path, parameters);
        }

        static async Task<JObject> Randomize(Api api, string tournament, Dictionary<string, string> parameters) {
            string path = "tournaments" + tournament + "/participants/randomize.json";

            return await api.FetchAndParse(Api.Methods.POST, path, parameters);
        }
    }
}
