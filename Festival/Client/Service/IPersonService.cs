using Festival.Shared.Models;
using Festival.Shared.Views;

namespace Festival.Client.Service
{
    public interface IPersonService
    {
        Task<Person[]?> GetAllPersoner(); //henter alle obejkter i listen ind i et array
        Task<Tuple<int, int>?> AddPerson(Person newPerson); //tilføjer en person til databasen
        Task<int> UpdatePerson(Person item); //updaterer en person i databasen
        Task<Person?> GetPerson(int id); //henter specifik person fra databasen på id
        Task<int> DeletePerson(int id); //sletter en person fra databasen     
    }
}

