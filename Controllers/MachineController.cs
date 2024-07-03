
using Microsoft.AspNetCore.Mvc;

namespace MiniMesTrainApi.Controllers
{
   // [ApiController]
    [Route ("api/v1/machine")] 
    public class MachineController : Controller
    {
        [HttpGet]
        [Route ("all")]
        public IActionResult ListOfMachines()
        {
            return Ok("Works");
        }

    }
    

}