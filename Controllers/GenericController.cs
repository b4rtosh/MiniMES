using Microsoft.AspNetCore.Mvc;
using MiniMesTrainApi.Repositories;
using MiniMesTrainApi.Models;
namespace MiniMesTrainApi.Controllers
{
    [Route("api/[controller]")]
    public class GenericController<TEntity> : Controller where TEntity : class
    {
        private readonly DatabaseRepo<TEntity> _repo;

        public GenericController(DatabaseRepo<TEntity> repo)
        {
            _repo = repo;
        }
        
        [HttpPut]
        public async Task<IActionResult> Add ([FromBody] TEntity instance){
            try
            {
                instance = await _repo.CreateNew(instance);
                return Ok(instance);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    
        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetAll()
        {
            var all = await _repo.GetAll();
            return Ok(all);
        }
        
        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> DeleteOne([FromRoute] int id)
        {
            await _repo.DelById(id);
            return Ok("Deleted instance");
        }
        
        [HttpGet]
        [Route("{id}")]
        public virtual async Task<IActionResult> GetOne([FromRoute] int id)
        {
            var instance = await _repo.GetById(id);
            return Ok(instance);
        }
        
        [HttpGet]
        [Route("{id}")]
        public virtual async Task<IActionResult> GetOne([FromRoute] long id)
        {
            var instance = await _repo.GetById(id);
            return Ok(instance);
        }
        
        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> UpdateOne([FromBody] TEntity updated)
        {

           await _repo.Update(updated);
            return Ok($"Updated object:\n{updated}");
        }
    }

}