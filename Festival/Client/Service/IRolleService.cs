using Festival.Shared.Models;
using Festival.Shared.Views;

namespace Festival.Client.Service
{
    //metoder oprettes 
    public interface IRolleService
    {
        Task<RolleType[]?> GetAllRoller(); //henter alle roller 
    }
}
