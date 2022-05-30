using Microsoft.AspNetCore.Mvc;
using Festival.Server.Models;
using Festival.Shared.Models;


namespace Festival.Server.Controllers
{
    [ApiController]
    [Route("api/rolle")]
    public class RolleController : ControllerBase
    {
        private readonly IRepositoryPostgres Repository = new RepositoryPostgres();

        public RolleController(IRepositoryPostgres rolleRepository)
        {
            if (Repository == null && rolleRepository != null)
            {
                Repository = rolleRepository;
                Console.WriteLine("Repository initialized");
            }
        }


        [HttpGet]
        public IEnumerable<RolleType> GetAllRoller()
        {
            Console.WriteLine("GetAllRoller kaldes controller");
            return Repository.GetAllRoller();
        }


    }
}
