using MiniMesTrainApi.Repositories;
using MiniMesTrainApi;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniMesTrainApi.Models;

namespace MiniMesTrainApi.Controllers
{
   // [ApiController]
    [Route ("api/v1/machine")] 
    public class MachineController : Controller
    {
        [HttpGet]
        [Route ("add")]
        public IActionResult AddMachine()
        {
            MachinesRepo machinesRepo = new MachinesRepo(
            //machineRepo.CreateNew("Machine 1", "This is machine 1");
            return Ok();
        }
        
        

    }
    

}