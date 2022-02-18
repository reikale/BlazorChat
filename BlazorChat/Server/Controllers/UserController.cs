using BlazorChat.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorChat.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DataContext _context;

        public UserController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = _context.Users.ToList();
            return Ok(users);
        }
        [HttpPut("updateprofile/{id}")]
        public async Task<User> UpdateProfile(int Id, [FromBody] User user)
        {
            User userToUpdate = await _context.Users.Where(x => x.Id == Id).FirstOrDefaultAsync();
            userToUpdate.FirstName = user.FirstName;
            userToUpdate.LastName = user.LastName;
            userToUpdate.Email = user.Email;
            await _context.SaveChangesAsync();
            return await Task.FromResult(user);
        }
        [HttpGet("updateprofile/{id}")]
        public async Task<User> GetProfile(int Id)
        {
            return await _context.Users.Where(x => x.Id == Id).FirstOrDefaultAsync();
        }

    }
    
}
