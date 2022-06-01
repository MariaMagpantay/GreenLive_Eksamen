using Festival.Shared.Models;
using Festival.Shared.Views;
using Dapper;
using Npgsql;
using System.Linq;

namespace Festival.Server.Models
{
    public class RepositoryPostgres : IRepositoryPostgres
    {
        DBContext db = new DBContext();


        //CRUD til person controller 
        public List<Person> GetAllPersoner()
        {
            Console.WriteLine("get all persons repository");
            var sql = "SELECT person_id as personid, navn as personnavn, tlf as persontlf, email as personemail, foedselsdato as personfoedselsdato, rolle_id as rolleid, team_id as teamid FROM person";
            var personer = db.connection.Query<Person>(sql);
            return personer.ToList();
        }

        public int AddPerson(Person newPerson)
        {
            Console.WriteLine("add persons repository");
            var parameters = new DynamicParameters(); //Opretter en dictionary 
            parameters.Add("PersonNavn", newPerson.PersonNavn); //Tilføjer til dicionary 
            parameters.Add("PersonEmail", newPerson.PersonEmail);
            parameters.Add("PersonTlf", newPerson.PersonTlf);
            parameters.Add("PersonFoedselsdato", newPerson.PersonFoedselsdato);
            parameters.Add("RolleID", newPerson.RolleID);
            //parameters.Add("TeamID", newPerson.TeamID); 

            var sql = "INSERT INTO person (navn, email, tlf, foedselsdato, rolle_id) VALUES (@PersonNavn, @PersonEmail, @PersonTlf, @PersonFoedselsdato, @RolleID) RETURNING person_id";
            var newPersonId = db.connection.ExecuteScalar<int>(sql, parameters);
            Console.WriteLine("person er added");
            return newPersonId;
        }

        public bool UpdatePerson(Person item)
        {
            Console.WriteLine("update persons repository");
            var parameters = new DynamicParameters(); //Opretter en dictionary 
            parameters.Add("PersonID", item.PersonID); //Tilføjer til dicionary 
            parameters.Add("PersonNavn", item.PersonNavn);
            parameters.Add("PersonEmail", item.PersonEmail);
            parameters.Add("PersonTlf", item.PersonTlf);

            var sql = "UPDATE person SET navn = @PersonNavn, email = @PersonEmail, tlf = @PersonTlf WHERE person_id = @PersonID";
            var personExists = ExistsPersonWithID(item.PersonID);
            if (personExists)
            {
                db.connection.Query(sql, parameters);
                Console.WriteLine("person er opdateret");
                return true;
            }
            else
                return false;
        }

        private bool ExistsPersonWithID(int id)//Hjælpemetode til UpdatePerson 
        {
            Console.WriteLine("Repository.ExistsPersonWithId called with id: " + id);
            var sql = $"SELECT 1 FROM person WHERE EXISTS(SELECT 1 FROM person where person_id = {id})";
            var person = db.connection.Query(sql);
            return person.Any();  //returner id = -1 hvis ikke fundet. 
        }

        public Person GetPerson(int id)
        {
            return new Person();
        }

        public bool DeletePerson(int id)
        {
            var sql = $"DELETE FROM person WHERE person_id = {id}";
            Console.WriteLine("sql: " + sql);
            int rows = db.connection.Execute(sql);
            if (rows > 0)
                return true;
            else
                return false;
        }

        public bool DeletePersKomp(int PersonID)
        {
            var sql = $"DELETE FROM pers_komp WHERE person_id = {PersonID}";
            Console.WriteLine("sql: " + sql);
            int rows = db.connection.Execute(sql);
            if (rows > 0)
                return true;
            else
                return false;
        }
        public void RemovePersonFromVagter(int PersonID)
        {
            var sql = $"UPDATE vagter SET person_id = NULL WHERE person_id = {PersonID}";
            var result = db.connection.Query(sql);
        }





        //Til rolle controller 
        public List<RolleType> GetAllRoller()
        {
            Console.WriteLine("get all roller repository");
            var sql = "SELECT rolle_id as rolleid, rolle FROM rolletype";
            var result = db.connection.Query<RolleType>(sql);
            return result.ToList();
        }




        //Til Vagt controller  
        public List<VagtView> GetAllVagter()
        {
            Console.WriteLine("get all in vagt view repository");
            var sql = "SELECT vagt_id as vagtid, start_tid as starttid, slut_tid as sluttid, dato, type, status, changed, opgave_id as opgaveid, opgave_navn as opgavenavn, beskrivelse, person_id as personid, navn FROM v_v as opgavevagter ORDER BY vagt_id ASC";
            var personer = db.connection.Query<VagtView>(sql);
            return personer.ToList();
        }

        public void AddVagt(Vagt newVagt)
        {
            Console.WriteLine("add vagt repository"); //console test  
            var parameters = new DynamicParameters(); //Opretter en dictionary  
            parameters.Add("OpgaveID", newVagt.OpgaveID); //Tilføjer felter til dicionary  
            parameters.Add("StartTid", newVagt.StartTid);
            parameters.Add("SlutTid", newVagt.SlutTid);
            parameters.Add("Dato", newVagt.Dato);
            parameters.Add("PersonID", newVagt.PersonID);
            parameters.Add("VagtType", newVagt.VagtType);

            //sql statement 
            var sql = "INSERT INTO vagter (opgave_id, start_tid, slut_tid, dato, type)" + "VALUES (@OpgaveID, @StartTid, @SlutTid, @Dato, @VagtType)";
            db.connection.Query(sql, parameters);
            Console.WriteLine("vagt er oprettet");
        }

        public bool UpdateVagt(Vagt item)
        {
            Console.WriteLine("update vagt repository");
            var parameters = new DynamicParameters(); //Opretter en dictionary 
            parameters.Add("PersonID", item.PersonID); //Tilføjer til dicionary 
            parameters.Add("VagtID", item.VagtID);

            var sql = "UPDATE vagter SET person_id = @PersonID WHERE vagt_id = @VagtID";
            var VagtExists = ExistsVagtWithID((int)item.VagtID);
            if (VagtExists)
            {
                db.connection.Execute(sql, parameters);
                Console.WriteLine("vagt er opdateret");
                return true;
            }
            else
            {
                return false;
            }

        }


        private bool ExistsVagtWithID(int? id)//Hjælpemetode til UpdateVagt og UpdateVagtStatus
        {
            Console.WriteLine("Repository.ExistsVagtWithId called with id: " + id);
            var sql = $"SELECT 1 FROM vagter WHERE EXISTS(SELECT 1 FROM vagter where vagt_id = {id})";
            var vagt = db.connection.Query(sql);
            return vagt.Any();  //returner id = -1 hvis ikke fundet. 
        }



        //Til Kompetence controller
        public List<Kompetence> GetAllKompetencer()
        {
            Console.WriteLine("get all kompetencer repository");
            var sql = "SELECT kompetence_id AS kompetenceid, type FROM kompetence";
            var result = db.connection.Query<Kompetence>(sql);
            return result.ToList();
        }

        public void AddKompetence(Perskomp newKompetence)
        {
            Console.WriteLine("add kompetence repository");
            var parameters = new DynamicParameters(); //Opretter en dictionary 
            parameters.Add("PersonID", newKompetence.PersonID); //Tilføjer til dicionary 
            parameters.Add("KompetenceID", newKompetence.KompetenceID);

            var sql = "INSERT INTO pers_komp as pk (person_id, kompetence_id) VALUES (@PersonID, @KompetenceID)";
            db.connection.Query(sql, parameters);
            Console.WriteLine("kompetence er added til person");
        }



        //Til Frivillig controller
        public List<PersonKompetence> GetAllFrivillige()
        {
            Console.WriteLine("get all Frivillige repository");
            var sql = "SELECT person_id as personid, navn as personnavn, tlf as persontlf, email as personemail, foedselsdato as personfoedselsdato, kompetence_id as kompetenceid, type as type FROM perskomp ORDER BY type asc";
            var frivillig = db.connection.Query<PersonKompetence>(sql);
            return frivillig.ToList();
        }



        //Til Opgaver controller
        public List<Opgaver> GetAllOpgaver()
        {
            Console.WriteLine("get all opgaver repository");
            var sql = "SELECT opgave_id as opgaveid, opgave_navn as opgavenavn, beskrivelse, kategori_id as kategoriid FROM opgaver";
            var result = db.connection.Query<Opgaver>(sql);
            return result.ToList();
        }

        // Til Status controller
        public bool UpdateVagtStatus(Vagt status)
        {
            Console.WriteLine("update vagt repository på status");
            var parameters = new DynamicParameters(); //Opretter en dictionary 
            parameters.Add("Status", status.Status); //Tilføjer til dicionary 
            parameters.Add("VagtID", status.VagtID);
            var sql = "UPDATE vagter SET status = @Status WHERE vagt_id = @VagtID";
            var vagtExists = ExistsVagtWithID((int)status.VagtID);
            if (vagtExists)
            {
                db.connection.Execute(sql, parameters);
                Console.WriteLine("Vagtstatus er opdateret");
                return true;
            }
            else
            {
                return false;
            }
        }

        //tom constructor 

        public RepositoryPostgres()

        {



        }



    }



}

