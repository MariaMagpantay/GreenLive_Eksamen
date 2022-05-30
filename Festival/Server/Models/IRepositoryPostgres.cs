using Festival.Shared.Models;
using Festival.Shared.Views;
using Dapper;
using Npgsql;

namespace Festival.Server.Models
{
    public interface IRepositoryPostgres
    {
        //CRUD til person klassen
        List<Person> GetAllPersoner(); //metode til at hente alle personer ind i listen

        int AddPerson(Person newPerson); //metode til at tilføje en person til vores database

        bool UpdatePerson(Person item); //metode til at updatere en persons data i databasen

        Person GetPerson(int id); //metode til at hente én person på et bestemt id

        bool DeletePerson(int id); //metode til at slette en person fra vores database

        bool DeletePersKomp(int id);




        //Til rolle klassen
        List<RolleType> GetAllRoller(); //metode til at hente alle roller ind i listen
       


        //Til vagt klassen
        List<VagtView> GetAllVagter(); //metode til at hente alle personer ind i listen

        void AddVagt(Vagt newVagt); //metode til at tilføje en vagt til vores database

        bool UpdateVagt(Vagt item);

        void RemovePersonFromVagter(int PersonID);

        //bool UpdateVagtStatus(Vagt status); //metode til at updatere en vagtstatus i databasen



        //Til Perskomp
        void AddKompetence(Perskomp newKompetence); //metode til at tilføje en kompetence til vores table pers_komp

       
        // Til Kompetence
        List<Kompetence> GetAllKompetencer(); //metode til at hente alle kompetencer ind i listen


        // Til PersonKompetence (view)
        List<PersonKompetence> GetAllFrivillige(); //metode til at hente alle frivillige med kompetencer ind i listen 


        // Til Opgaver
        List<Opgaver> GetAllOpgaver(); //metode til at hente alle opgaver ind i listen



    }
}
