﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BreadProjectLibrary;
namespace BreadService
{
    [Route("[controller]")]
    [ApiController]
    public class PicturesController : ControllerBase
    {
        private readonly IPicturesManager _picturesManager;
        public PicturesController(IPicturesManager picturesManager)
        {
            _picturesManager = picturesManager;
        }
        [HttpPost]
        public async Task<bool> PostPicture(Picture picture) 
        {
            return await _picturesManager.PostPicture(picture);
        }
        [HttpGet("{id:int}")]
        public async Task<Picture> GetPicture(int id)
        {
            return await _picturesManager.GetPicture(id);
        }
        [HttpDelete("{id:int}")]
        public async Task<bool> DeletePicture(int id)
        {
            return await _picturesManager.DeletePicture(id);
        }

    }
}
