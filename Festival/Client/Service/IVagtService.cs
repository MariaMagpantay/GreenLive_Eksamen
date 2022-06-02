using Festival.Shared.Models;
using Festival.Shared.Views;



namespace Festival.Client.Service

{

    public interface IVagtService
    {
        Task<VagtView[]?> GetAllVagter(); //henter alle vagter 
        Task<int> AddVagt(Vagt newVagt); //tilføjer en vagt 
        Task<int> UpdateVagt(Vagt item); //updaterer en vagt

    }
}