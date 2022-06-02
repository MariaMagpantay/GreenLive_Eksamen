using Festival.Shared.Models;
using Festival.Shared.Views;

namespace Festival.Client.Service
{
    public interface IPersonService
    {
        Task<Person[]?> GetAllPersoner(); //henter alle personer 
        Task<Tuple<int, int>?> AddPerson(Person newPerson); //tilføjer en person
        Task<int> UpdatePerson(Person item); //updaterer en person 
        Task<int> DeletePerson(int id); //sletter en person   
    }
}

