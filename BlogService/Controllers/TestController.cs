using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AspNetCore.Yandex.ObjectStorage;

namespace BlogService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        public YandexStorageService _objectStoreService;
        public TestController() :base() { }
        [HttpGet]
        public async Task<Stream> GetPhoto(string fileName)
        {
            var result = await _objectStoreService.ObjectService.GetAsync(fileName);
            await result.ReadAsStreamAsync();
            var stream = result.ReadAsStreamAsync();
            return null;
        }
    }
}
