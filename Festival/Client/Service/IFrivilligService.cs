using Festival.Shared.Models;
using Festival.Shared.Views;

namespace Festival.Client.Service
{
    public interface IFrivilligService
    {
        Task<PersonKompetence[]?> GetAllFrivillige(); //henter alle personer med kompetancer fra view
    }
}
