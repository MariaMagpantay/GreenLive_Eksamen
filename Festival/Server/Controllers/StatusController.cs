using Microsoft.AspNetCore.Mvc;
using Festival.Server.Models;
using Festival.Shared.Models;
using Festival.Shared.Views;
using System.Net;


namespace Festival.Server.Controllers
{
    [ApiController] //tager imod request fra klienten (rest api)
    [Route("api/Status")]
    public class StatusController : ControllerBase
    {
        private readonly IRepositoryPostgres Repository = new RepositoryPostgres();


        public StatusController(IRepositoryPostgres statusRepository)
        {
            if (Repository == null && statusRepository != null)
            {
                Repository = statusRepository;
                Console.WriteLine("Repository initialized");
            }
        }

        [HttpPut]
        public void UpdateVagtStatus(Vagt status)
        {
            Console.WriteLine("Update status called: " + status.ToString());
            Repository.UpdateVagtStatus(status);
        }
    }
}