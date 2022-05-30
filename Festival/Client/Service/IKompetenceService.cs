using Festival.Shared.Models;
using Festival.Shared.Views;

namespace Festival.Client.Service

{

    public interface IKompetenceService

    {

        Task<int> AddKompetence(Perskomp newKompetence); //tilføjer en kompetence til databasen

        Task<Kompetence[]?> GetAllKompetencer();
    }

}


