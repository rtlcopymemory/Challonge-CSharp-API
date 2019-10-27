using Microsoft.VisualStudio.TestTools.UnitTesting;
using Challonge_API;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API_test {
    [TestClass]
    public class UnitTest1 {
        [TestMethod]
        public void TestFetch() {
            Api api = new Api();
            string username = System.IO.File.ReadAllText(@"../../../username.txt");
            string token = System.IO.File.ReadAllText(@"../../../token.txt");
            api.setCredentials(username, token);

            string path = "tournaments.json";
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("state", "all");
            Task<string> TaskFetch = Task.Run(() => api.Fetch(Api.Methods.GET, path, param));
            TaskFetch.Wait();
            string result = "" + TaskFetch.Result;
            Assert.AreNotEqual("", result);
            Assert.IsTrue(result.Contains("tournament"));
        }
    }
}
