using BreadProjectLibrary;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BreadService
{
    [Route("[controller]")]
    [ApiController]
    public class BreadController : ControllerBase
    {
        private readonly IBreadManager _breadManager;
        public BreadController(IBreadManager breadManager)
        {
            _breadManager = breadManager;
        }
        [HttpPost]
        public async Task<Bread> CreateBread([FromBody] CreateBreadRequest request)
        {
            return await _breadManager.CreateBread(request);
        }
        [HttpPut]
        public async Task<Bread> UpdateBread([FromBody] UpdateBreadRequest request)
        {
            return await _breadManager.UpdateBread(request);
        }
        [HttpDelete("{id:int}")]
        public async Task<Bread> DeleteBread(int id)
        {
            return await _breadManager.DeleteBread(id);
        }
        [HttpGet("many")]
        public async Task<List<Bread>> GetAllBread()
        {
            return await _breadManager.Get();
        }
        [HttpGet("many/{category:int}")]
        public async Task<List<Bread>> GetBreadByCategory(ProjectEnums.BreadCategory category)
        {
            return await _breadManager.GetByCategory(category);
        }
        [HttpGet("one/{id:int}")]
        public async Task<Bread> GetBreadById(int id)
        {
            return await _breadManager.GetById(id);
        }
    }
}
