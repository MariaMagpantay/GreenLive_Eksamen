using Festival.Shared.Models;
using Festival.Shared.Views;
using System.Net.Http.Json;

namespace Festival.Client.Service
{
    public class KompetenceService : IKompetenceService
    {
        private readonly HttpClient httpClient;
        public KompetenceService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<int> AddKompetence(Perskomp newKompetence)
        {
            var response = await httpClient.PostAsJsonAsync("api/kompetence", newKompetence);
            var responseStatusCode = response.StatusCode;
            return (int)responseStatusCode;
        }

        public async Task<Kompetence[]?> GetAllKompetencer()
        {
            return await httpClient.GetFromJsonAsync<Kompetence[]>("api/kompetence");
        }
    }
}
