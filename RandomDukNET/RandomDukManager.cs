using System.Net;
using Newtonsoft.Json;
using RandomDukNET.Models;

namespace RandomDukNET
{
    public class RandomDukManager
    {
        private readonly string _url = "https://random-d.uk/api/v2";

        public async Task<Duk> GetRandom()
        {
            return await MakeAPICallGetJson(_url + "/random");
        }

        public async Task<Duk> GetQuack()
        {
            return await MakeAPICallGetJson(_url + "/quack");
        }

        public async Task<byte[]> GetDuckImageJpeg(string id)
        {
            return await MakeAPICallGetContents(_url + $"/{id}.jpg");
        }

        public async Task<byte[]> GetDuckImageGif(string id)
        {
            return await MakeAPICallGetContents(_url + $"/{id}.gif");
        }

        public async Task<byte[]> GetHttpDuckImage(string statusCode)
        {
            if (Enum.TryParse(statusCode, out HttpStatusCode code) && Enum.IsDefined(typeof(HttpStatusCode), code))
            {
                return await MakeAPICallGetContents(_url + $"/http/{statusCode}");
            }
            else
            {
                return await MakeAPICallGetContents(_url + "/http/400");
            }
        }

        private async Task<byte[]> MakeAPICallGetContents(string apiCall)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage message = await client.GetAsync(apiCall);

            if (message.StatusCode == HttpStatusCode.OK)
            {

                byte[] result = await message.Content.ReadAsByteArrayAsync();
                return result;
            }
            else
            {
                string api404 = apiCall.Substring(0, apiCall.LastIndexOf('/')) + "/404";
                message = await client.GetAsync(api404);
                byte[] result = await message.Content.ReadAsByteArrayAsync();
                return result;
            }
        }

        private async Task<Duk> MakeAPICallGetJson(string apiCall)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            HttpResponseMessage message = await client.GetAsync(apiCall);

            if (message.StatusCode == HttpStatusCode.OK)
            {
                string response = await client.GetStringAsync(apiCall);
                return DeserializeData(response);
            }
            else
            {
                return null;
            }
        }

        private Duk DeserializeData(string data)
        {
            return JsonConvert.DeserializeObject<Duk>(data);
        }
    }
}