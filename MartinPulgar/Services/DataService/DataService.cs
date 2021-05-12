using MartinPulgar.Models;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace MartinPulgar.Services
{
    public class DataService : IDataService
    {
        private HttpClient _client;

        public DataService()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://reqres.in/");
        }

        public async Task<HttpStatusCode> UplodData(DataModel dataModel)
        {
            try
            {
                var response = await _client.PostAsJsonAsync("api/diaries/", dataModel);
                if (response.IsSuccessStatusCode)
                    return response.StatusCode;

                var content = await response.Content.ReadAsStringAsync();
                throw new Exception(content);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
