using Microsoft.VisualStudio.TestTools.UnitTesting;
using Challonge_API;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace API_test {
    [TestClass]
    public class UnitTest1 {
        private Api api = new Api();

        public UnitTest1() {
            string username = System.IO.File.ReadAllText(@"../../../username.txt");
            string token = System.IO.File.ReadAllText(@"../../../token.txt");
            api.setCredentials(username, token);
        }

        [TestMethod]
        public void TestFetch() {
            string path = "tournaments.json";

            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("state", "all");

            Task<string> TaskFetch = Task.Run(() => api.Fetch(Api.Methods.GET, path, param));

            TaskFetch.Wait();

            string result = "" + TaskFetch.Result;

            Assert.AreNotEqual("", result);
            Assert.IsTrue(result.Contains("tournament"));
        }

        [TestMethod]
        public void TestFetchAndParse() {
            string path = "tournaments.json";

            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("state", "all");

            Task<JObject> TaskFetch = Task.Run(() => api.FetchAndParse(Api.Methods.GET, path, param));

            TaskFetch.Wait();

            JObject result = TaskFetch.Result;

            Assert.IsNotNull(result["result"][0]);
        }

        [TestMethod]
        public void DoesATournamentsQuery() {
            Dictionary<string, string> param = null;
            Task<JObject> TaskQuery = Task.Run(() => Tournaments.Index(api, param));

            TaskQuery.Wait();

            JObject result = TaskQuery.Result;

            Assert.IsNotNull(result["result"][0]);
        }
    }
}
