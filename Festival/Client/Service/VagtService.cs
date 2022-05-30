using Festival.Shared.Models;
using Festival.Shared.Views;
using System.Net.Http.Json;



namespace Festival.Client.Service

{
    public class VagtService : IVagtService
    {
        private readonly HttpClient httpClient;

        public VagtService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }



        public async Task<int> AddVagt(Vagt newVagt)
        {
            var response = await httpClient.PostAsJsonAsync("api/vagt", newVagt);
            var responseStatusCode = response.StatusCode;
            return (int)responseStatusCode;
        }


        public Task<VagtView[]?> GetAllVagter()
        {
            Console.WriteLine("Service - getAllVagter");
            var result =
            httpClient.GetFromJsonAsync<VagtView[]>("api/vagt");
            return result;
        }

        public async Task<int> UpdateVagt(Vagt item)
        {
            var response = await httpClient.PutAsJsonAsync("api/vagt", item);
            var responseStatusCode = response.StatusCode;
            return (int)responseStatusCode;
        }


        //public async Task<int> UpdateVagtStatus(Vagt status)
        //{
        //    var response = await httpClient.PutAsJsonAsync("api/vagt", status);
        //    var responseStatusCode = response.StatusCode;
        //    return (int)responseStatusCode;
        //}

    }

}
