using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Challonge_API {
    public class MatchAttachments {
        static public async Task<JObject> Index(Api api, string tournament, string matchId, Dictionary<string, string> parameters) {
            string path = "tournaments/" + tournament + "/matches/" + matchId + "/attachments.json";

            return await api.FetchAndParse(Api.Methods.GET, path, parameters);
        }

        static public async Task<JObject> Create(Api api, string tournament, string matchId, Dictionary<string, string> parameters) {
            string path = "tournaments/" + tournament + "/matches/" + matchId + "/attachments.json";

            return await api.FetchAndParse(Api.Methods.POST, path, parameters);
        }

        static public async Task<JObject> getAttachment(Api api, string tournament, string matchId, string attachmentId, Dictionary<string, string> parameters) {
            string path = "tournaments/" + tournament + "/matches/" + matchId + "/attachments/" + attachmentId + ".json";

            return await api.FetchAndParse(Api.Methods.GET, path, parameters);
        }

        static public async Task<JObject> UpdateAttachment(Api api, string tournament, string matchId, string attachmentId, Dictionary<string, string> parameters) {
            string path = "tournaments/" + tournament + "/matches/" + matchId + "/attachments/" + attachmentId + ".json";

            return await api.FetchAndParse(Api.Methods.PUT, path, parameters);
        }

        static public async Task<JObject> DeleteAttachment(Api api, string tournament, string matchId, string attachmentId, Dictionary<string, string> parameters) {
            string path = "tournaments/" + tournament + "/matches/" + matchId + "/attachments/" + attachmentId + ".json";

            return await api.FetchAndParse(Api.Methods.DELETE, path, parameters);
        }
    }
}
