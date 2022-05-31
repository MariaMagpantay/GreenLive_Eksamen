using Festival.Shared.Models;
using Festival.Shared.Views;



namespace Festival.Client.Service

{

    public interface IStatusService
    {
        Task<int> UpdateVagtStatus(Vagt status); //updaterer status på vagt

    }
}