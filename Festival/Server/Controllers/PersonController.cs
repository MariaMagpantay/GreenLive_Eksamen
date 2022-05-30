using Microsoft.AspNetCore.Mvc;
using Festival.Server.Models;
using Festival.Shared.Models;
using Festival.Shared.Views;
using System.Net;

namespace Festival.Server.Controllers
{
    [ApiController]
    [Route("api/person")]
    public class PersonController : ControllerBase
    {
        private readonly IRepositoryPostgres Repository = new RepositoryPostgres();


        public PersonController(IRepositoryPostgres personRepository)
        {
            if (Repository == null && personRepository != null)
            {
                Repository = personRepository;
                Console.WriteLine("Repository initialized");
            }
        }


        [HttpGet]
        public IEnumerable<Person> GetAllPersoner()
        {
            Console.WriteLine("GetAllPersoner kaldes controller");
            return Repository.GetAllPersoner();
        }


        [HttpPost]
        public int AddPerson(Person newPerson)
        {
            Console.WriteLine("Add person called: " + newPerson.ToString());
            return Repository.AddPerson(newPerson);
        }


        [HttpPut]
        public void UpdatePerson(Person item)
        {
            Console.WriteLine("Update person called: " + item.ToString());
            Repository.UpdatePerson(item);
        }

        [HttpGet("{id:int}")]
        public Person GetPerson(int id)
        {
            var result = Repository.GetPerson(id);
            return result;
        }


        [HttpDelete("{id:int}")]
        public StatusCodeResult DeletePerson(int id)
        {
            Console.WriteLine("Server: Delete person called: id = " + id);
            Repository.DeletePersKomp(id);
            Repository.RemovePersonFromVagter(id);
            bool deleted = Repository.DeletePerson(id);
            if (deleted)
            {
                Console.WriteLine("Server: Item deleted succces");
                int code = (int)HttpStatusCode.OK;
                return new StatusCodeResult(code);
            }
            else
            {
                Console.WriteLine("Server: Item deleted fail - not found");
                int code = (int)HttpStatusCode.NotFound;
                return new StatusCodeResult(code);
            }
        }
        /*[HttpGet]
        public IEnumerable<Person> GetMaxIDPerson()
        {
            Console.WriteLine("Get max id kaldes controller");
            return Repository.GetMaxIDPerson();
        }*/

    }
}
