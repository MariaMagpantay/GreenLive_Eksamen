using Festival.Shared.Models;
using Festival.Shared.Views;
using System.Net.Http.Json;


namespace Festival.Client.Service
{
    public class FrivilligService : IFrivilligService
    {
        private readonly HttpClient httpClient;

        public FrivilligService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public Task<PersonKompetence[]?> GetAllFrivillige()
        {
            Console.WriteLine("Service - getAllPersKomp");
            var result =
            httpClient.GetFromJsonAsync<PersonKompetence[]>("api/sefrivillig");
            return result;
        }
    }
}
