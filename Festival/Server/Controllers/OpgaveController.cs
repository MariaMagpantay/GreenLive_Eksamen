using Microsoft.AspNetCore.Mvc;
using Festival.Server.Models;
using Festival.Shared.Models;
using Festival.Shared.Views;


namespace Festival.Server.Controllers
{
    [ApiController] //tager imod request fra klienten (rest api)
    [Route("api/opgaver")]
    public class OpgaveController : ControllerBase
    {
        private readonly IRepositoryPostgres Repository = new RepositoryPostgres();

        public OpgaveController(IRepositoryPostgres opgaveRepository)
        {
            if (Repository == null && opgaveRepository != null)
            {
                Repository = opgaveRepository;
                Console.WriteLine("Repository initialized");
            }
        }


        [HttpGet]
        public IEnumerable<Opgaver> GetAllOpgaver()
        {
            Console.WriteLine("GetAllOpgaver kaldes controller");
            return Repository.GetAllOpgaver();
        }


    }
}
