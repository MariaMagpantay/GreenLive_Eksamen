using Microsoft.AspNetCore.Mvc;
using Festival.Server.Models;
using Festival.Shared.Models;
using Festival.Shared.Views;
using System.Net.Http;

namespace Festival.Server.Controllers
{
    [ApiController]
    [Route("api/sefrivillig")]
    public class FrivilligController : ControllerBase
    {
        private readonly IRepositoryPostgres Repository = new RepositoryPostgres();
        public FrivilligController(IRepositoryPostgres PersonKompetenceRepository)
        {
            if (Repository == null && PersonKompetenceRepository != null)
            {
                Repository = PersonKompetenceRepository;
                Console.WriteLine("Repository initialized");
            }
        }


        [HttpGet]
        public IEnumerable<PersonKompetence> GetAllFrivillige()
        {
            Console.WriteLine("GetAllFrivillige kaldes controller");
            return Repository.GetAllFrivillige();
        }      
    }
}
