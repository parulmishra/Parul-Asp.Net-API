using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Parul_Asp.Net_API.Models
{
    public class Repo
    {
        public string name { get; set; }
        public string url { get; set; }
        public int stargazers_count { get; set; }

        public static List<Repo> GetRepos()
        {
            var client = new RestClient();
            client.BaseUrl = new Uri("https://api.github.com");

            var request = new RestRequest("users/parulmishra/starred", Method.GET);
            request.AddHeader("User-Agent", "parulmishra");
            

            var response = new RestResponse();

            Task.Run(async () =>
            {
                response = await GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();

            JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(response.Content);
            var repoList = JsonConvert.DeserializeObject<List<Repo>>(jsonResponse.ToString());
            Console.WriteLine(jsonResponse);
            return repoList;
        }
        public static Task<IRestResponse> GetResponseContentAsync(RestClient theClient, RestRequest theRequest)
        {
            var tcs = new TaskCompletionSource<IRestResponse>();
            theClient.ExecuteAsync(theRequest, response => {
                tcs.SetResult(response);
            });
            return tcs.Task;
        }
    }
}
