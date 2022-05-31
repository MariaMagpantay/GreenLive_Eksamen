using Festival.Shared.Models;
using Festival.Shared.Views;



namespace Festival.Client.Service

{

	public interface IVagtService
	{
		Task<VagtView[]?> GetAllVagter(); //henter alle obejkter i listen ind i et array 
		Task<int> AddVagt(Vagt newVagt); //tilføjer en vagt til databasen 
		Task<int> UpdateVagt(Vagt item); //updaterer en vagt i databasen
		Task<int> UpdateVagtStatus(Vagt status); //updaterer status på vagt

	}
}