using Festival.Shared.Models;
using Festival.Shared.Views;
using System.Net.Http.Json;

namespace Festival.Client.Service
{
    public class RolleService : IRolleService
    {
        private readonly HttpClient httpClient;

        public RolleService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }


        public async Task<RolleType[]?> GetAllRoller()
        {
            Console.WriteLine("Service - getAllRoller");
            //var result = httpClient.GetFromJsonAsync<RolleType[]>("api/rolle");
            //return result;
            return await httpClient.GetFromJsonAsync<RolleType[]>("api/rolle");
        }

    }
}
