using Festival.Shared.Models;
using Festival.Shared.Views;
using Dapper;
using Npgsql;

namespace Festival.Server.Models
{
    public interface IRepositoryPostgres
    {
        //CRUD til person controller
        List<Person> GetAllPersoner(); //metode til at hente alle personer ind i listen
        int AddPerson(Person newPerson); //metode til at tilføje en person til vores database
        bool UpdatePerson(Person item); //metode til at updatere en persons data i databasen

        bool DeletePerson(int id); //metode til at slette en person fra vores database
        bool DeletePersKomp(int id); //metode til at hjælpe med slette en person fra vores database, hvor der er FK'er 
        void RemovePersonFromVagter(int PersonID); //metode til at hjælpe med slette en person fra vores database, hvor der er FK'er


        //Til rolle controller
        List<RolleType> GetAllRoller(); //metode til at hente alle roller ind i listen



        //Til vagt controller
        List<VagtView> GetAllVagter(); //metode til at hente alle personer ind i listen
        void AddVagt(Vagt newVagt); //metode til at tilføje en vagt til vores database
        bool UpdateVagt(Vagt item); //metode til at updatere en vagt i databasen




        // Til Kompetence controller
        List<Kompetence> GetAllKompetencer(); //metode til at hente alle kompetencer ind i listen
        void AddKompetence(Perskomp newKompetence); //metode til at tilføje en kompetence til vores accosiations-table pers_komp fra databasen



        // Til Frivillig controller
        List<PersonKompetence> GetAllFrivillige(); //metode til at hente alle frivillige med kompetencer ind i listen fra et view



        // Til Opgaver controller
        List<Opgaver> GetAllOpgaver(); //metode til at hente alle opgaver ind i listen



        // Til Status controller
        bool UpdateVagtStatus(Vagt status); //metode til at updatere en vagtstatus i databasen


    }
}
