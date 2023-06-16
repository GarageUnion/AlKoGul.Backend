using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BreadProjectLibrary;
namespace CraftBreadService
{
    [Route("[controller]")]
    [ApiController]
    public class CraftBreadController : ControllerBase
    {
        private readonly ICraftBreadManager _breadManager;
        public CraftBreadController(ICraftBreadManager breadManager)
        {
            _breadManager = breadManager;
        }
        [HttpPost]
        public async Task<CraftBread> CreateBread([FromBody] CreateBreadRequest request)
        {
            return await _breadManager.CreateBread(request);
        }
        [HttpPut]
        public async Task<CraftBread> UpdateBread([FromBody] UpdateBreadRequest request)
        {
            return await _breadManager.UpdateBread(request);
        }
        [HttpDelete("{id:int}")]
        public async Task<CraftBread> DeleteBread(int id)
        {
            return await _breadManager.DeleteBread(id);
        }
        [HttpGet("many")]
        public async Task<List<CraftBread>> GetAllBread()
        {
            return await _breadManager.Get();
        }
        [HttpGet("one/{id:int}")]
        public async Task<CraftBread> GetBreadById(int id)
        {
            return await _breadManager.GetById(id);
        }
    }
}
