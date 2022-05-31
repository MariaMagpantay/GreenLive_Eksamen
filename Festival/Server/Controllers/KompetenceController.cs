using Microsoft.AspNetCore.Mvc;
using Festival.Server.Models;
using Festival.Shared.Views;
using Festival.Shared.Models;
using System.Net;

namespace Festival.Server.Controllers
{
    [ApiController]
    [Route("api/kompetence")]
    public class KompetenceController : ControllerBase
    {
        private readonly IRepositoryPostgres Repository = new RepositoryPostgres();


        public KompetenceController(IRepositoryPostgres kompetenceRepository)
        {
            if (Repository == null && kompetenceRepository != null)
            {
                Repository = kompetenceRepository;
                Console.WriteLine("Repository initialized");
            }
        }


        [HttpGet]
        public IEnumerable<Kompetence> GetAllKompetencer()
        {
            Console.WriteLine("GetAllKompetencer kaldes controller");
            return Repository.GetAllKompetencer();

        }

        [HttpPost]
        public void AddKompetence(Perskomp newKompetence)
        {
            Console.WriteLine("Add kompetence called:" + newKompetence.ToString());
            Repository.AddKompetence(newKompetence);
        }
    }
}