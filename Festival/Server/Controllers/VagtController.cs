using Microsoft.AspNetCore.Mvc;
using Festival.Server.Models;
using Festival.Shared.Models;
using Festival.Shared.Views;
using System.Net;


namespace Festival.Server.Controllers
{
    [ApiController]
    [Route("api/vagt")]
    public class VagtController : ControllerBase
    {
        private readonly IRepositoryPostgres Repository = new RepositoryPostgres();


        public VagtController(IRepositoryPostgres vagtRepository)
        {
            if (Repository == null && vagtRepository != null)
            {
                Repository = vagtRepository;
                Console.WriteLine("Repository initialized");
            }
        }


        [HttpGet]
        public IEnumerable<VagtView>GetAllVagter()
        {
            Console.WriteLine("GetAllVagter kaldes controller");
            return Repository.GetAllVagter();
        }

        [HttpPost]
        public void AddVagt(Vagt newVagt)
        {
            Console.WriteLine("Add person called: " + newVagt.ToString());
            Repository.AddVagt(newVagt);
        }

        [HttpPut]
        public void UpdateVagt(Vagt item)
        {
            Console.WriteLine("Update vagt called: " + item.ToString());
            Repository.UpdateVagt(item);
        }

        [HttpPut]
        public void UpdateVagtStatus(Vagt status)
        {
            Console.WriteLine("Update status called: " + status.ToString());
            Repository.UpdateVagtStatus(status);
        }
    }
}