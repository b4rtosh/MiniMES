using MediatR;
using Microsoft.AspNetCore.Mvc;
using MiniMesTrainApi.Application.MachineMed.Queries;
using MiniMesTrainApi.Infrastructure.Persistence.Repositories;

namespace MiniMesTrainApi.Presentation.Controllers
{
    [Route("api/[controller]")]
    public class GenericController<TEntity> : ControllerBase where TEntity : class
    {
        private readonly IMediator _mediator;
        public GenericController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpPut]
        [Route("add")]
        public virtual async Task<IActionResult> Add ([FromBody] TEntity instance){
                return BadRequest("Wrong request");
        }
        
        [HttpGet]
        [Route("all")]
        public virtual async Task<IActionResult> GetAll()
        {
            return Ok();
        }
        
        [HttpDelete]
        [Route("delete/int/{id}")]
        public virtual async Task<IActionResult> DeleteOne([FromRoute] int id)
        {
            return Ok("Wrong request");
        }
        
        // [HttpDelete]
        // [Route("delete/long/{id}")]
        // public async Task<IActionResult> DeleteOne([FromRoute] long id)
        // {
        //     await _repo.DelById(id);
        //     return Ok("Deleted instance");
        // }
        //
        [HttpGet]
        [Route("int/{id}")]
        public virtual async Task<IActionResult> GetOne([FromRoute] int id)
        {
            return Ok();
        }
        
        [HttpGet]
        [Route("long/{id}")]
        public virtual async Task<IActionResult> GetOne([FromRoute] long id)
        {
           return BadRequest("Wrong request.");
        }
        
        [HttpPost]
        [Route("update")]
        public virtual async Task<IActionResult> UpdateOne([FromBody] TEntity updated)
        {

            return BadRequest("Wrong request.");
        }
    }

}