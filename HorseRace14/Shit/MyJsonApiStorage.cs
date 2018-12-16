using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace HorseRace14.Shit
{
    public class MyJsonApiStorage : IStorage
    {

        public string CreateDataStorage()
        {
            var apiClient = new ApiClient("https://api.myjson.com/");
            var response = apiClient.Post<dynamic> ("bins", new JObject());
            var uriString = response.Content.uri;
            var id = uriString.ToString().Replace("https://api.myjson.com/bins/", "");
            return id;
        }

        public T GetData<T>(string id)
        {
            var apiClient = new ApiClient("https://api.myjson.com/");
            var apiResponse = apiClient.Get<T>("bins/" + id);
            if (apiResponse.StatusCode == HttpStatusCode.InternalServerError)
                return default(T);

            return apiResponse.Content;
        }

        public void SaveData(string id, object data)
        {
            var apiClient = new ApiClient("https://api.myjson.com/");
            apiClient.Put<dynamic>("bins/" + id, JObject.FromObject(data));
        }

        public void DeleteData(string id)
        {
            // cant delete data from myJson site
        }

        private static T DeserializeData<T>(string data)
        {
            return JsonConvert.DeserializeObject<T>(data);
        }
    }
}
