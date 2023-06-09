﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BreadProjectLibrary;
namespace UserProfileService
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersManager _usersManager;
        public UsersController(IUsersManager usersManager)
        {
            _usersManager = usersManager;
        }
        [HttpPost]
        public async Task<User> CreateUser([FromBody] CreateUserRequest request)
        {
            return await _usersManager.CreateUser(request);
        }
        [HttpDelete("{id:int}")]
        public async Task<User> DeleteUser(int id)
        {
            return await _usersManager.DeleteUser(id);
        }
        [HttpGet("many")]
        public async Task<List<User>> GetUsers()
        {
            return await _usersManager.Get();
        }
        [HttpGet("one/{id:int}")]
        public async Task<User> GetUserById([FromRoute]int id)
        {
            return await _usersManager.GetById(id);
        }
        [HttpGet("getUserAfterLogin")]
        public async Task<User> getUserAfterLogin([FromQuery] LoginRequest request)
        {
            return await _usersManager.CheckRegistration(request);
        }
    }
}
