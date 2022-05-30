using Festival.Shared.Models;
using Festival.Shared.Views;
using System.Net.Http.Json;

namespace Festival.Client.Service
{
    public class OpgaveService : IOpgaveService
    {
        private readonly HttpClient httpClient;

        public OpgaveService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }


        public async Task<Opgaver[]?> GetAllOpgaver()
        {
            Console.WriteLine("Service - getAllOpgaver");
            //var result = httpClient.GetFromJsonAsync<RolleType[]>("api/rolle");
            //return result;
            return await httpClient.GetFromJsonAsync<Opgaver[]>("api/opgaver");
        }

    }
}
