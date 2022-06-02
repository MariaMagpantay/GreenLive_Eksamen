using Festival.Shared.Models;
using Festival.Shared.Views;

namespace Festival.Client.Service
{
    public interface IOpgaveService
    {
        Task<Opgaver[]?> GetAllOpgaver(); //henter alle opgaver 
    }
}
