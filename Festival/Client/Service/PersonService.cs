using Festival.Shared.Models;
using Festival.Shared.Views;
using System.Net.Http.Json;

namespace Festival.Client.Service
{
    public class PersonService : IPersonService
    {
        private readonly HttpClient httpClient;

        public PersonService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }


        public Task<Person[]?> GetAllPersoner()
        {
            Console.WriteLine("Service - getAllPersoner");
            var result =
            httpClient.GetFromJsonAsync<Person[]>("api/person");
            return result;
        }

        public async Task<Tuple<int, int>?> AddPerson(Person newPerson)
        {
            var response = await httpClient.PostAsJsonAsync<Person>("api/person", newPerson);
            var responseStatusCode = response.StatusCode;
            return Tuple.Create((int)responseStatusCode, (int)Int32.Parse(await response.Content.ReadAsStringAsync()));
        }

        public async Task<int> UpdatePerson(Person item)
        {
            var response = await httpClient.PutAsJsonAsync("api/person", item);
            var responseStatusCode = response.StatusCode;
            return (int)responseStatusCode;
        }


        public async Task<int> DeletePerson(int id)
        {
            Console.WriteLine("Service - DeletePerson");
            var response = await httpClient.DeleteAsync("api/person/" + id);
            var responseStatusCode = response.StatusCode;
            return (int)responseStatusCode;
        }
    }
}
