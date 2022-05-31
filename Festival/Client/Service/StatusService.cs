using Festival.Shared.Models;
using Festival.Shared.Views;
using System.Net.Http.Json;

namespace Festival.Client.Service

{
    public class StatusService : IStatusService
    {
        private readonly HttpClient httpClient;

        public StatusService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<int> UpdateVagtStatus(Vagt status)
        {
            var response = await httpClient.PutAsJsonAsync("api/status", status);
            var responseStatusCode = response.StatusCode;
            return (int)responseStatusCode;
        }

    }

}

