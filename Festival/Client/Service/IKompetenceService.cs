using Festival.Shared.Models;
using Festival.Shared.Views;

namespace Festival.Client.Service
{
    public interface IKompetenceService
    {
        Task<Kompetence[]?> GetAllKompetencer(); //henter kompetencer fra databasen
        Task<int> AddKompetence(Perskomp newKompetence); //tilføjer en kompetence til databasen
    }
}


