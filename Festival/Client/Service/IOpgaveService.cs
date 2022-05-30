using Festival.Shared.Models;
using Festival.Shared.Views;

namespace Festival.Client.Service
{
    //metoder oprettes 
    public interface IOpgaveService
    {
        Task<Opgaver[]?> GetAllOpgaver(); //henter alle obejkter i listen ind i et array

    }
}
