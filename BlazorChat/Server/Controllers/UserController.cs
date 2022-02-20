using BlazorChat.Shared.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BlazorChat.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger, DataContext context)
        {
            _context = context;
            _logger = logger;
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


        // Authentication:
        [HttpPost("login")]
        public async Task<ActionResult<User>> LoginUser(User user)
        {
            User loggedInUser = await _context.Users.Where(u => u.Email == user.Email && u.Password == user.Password).FirstOrDefaultAsync();
            if (loggedInUser != null)
            {
                // create a claim
                var claim = new Claim(ClaimTypes.Name, loggedInUser.Email);
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, loggedInUser.Email),
                   
                };
                //create claimsIdentity
                var claimsIdentity = new ClaimsIdentity(
            claims, CookieAuthenticationDefaults.AuthenticationScheme);
                //create claimsPrincipal
                //var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                //signin user
                var authProperties = new AuthenticationProperties
                {
                    //AllowRefresh = <bool>,
                    // Refreshing the authentication session should be allowed.

                    //ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                    // The time at which the authentication ticket expires. A 
                    // value set here overrides the ExpireTimeSpan option of 
                    // CookieAuthenticationOptions set with AddCookie.

                    //IsPersistent = true,
                    // Whether the authentication session is persisted across 
                    // multiple requests. When used with cookies, controls
                    // whether the cookie's lifetime is absolute (matching the
                    // lifetime of the authentication ticket) or session-based.

                    //IssuedUtc = <DateTimeOffset>,
                    // The time at which the authentication ticket was issued.

                    //RedirectUri = <string>
                    // The full path or absolute URI to be used as an http 
                    // redirect response value.
                };

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);
            }
            return await Task.FromResult(loggedInUser);
        }

        [HttpGet("getcurrentuser")]
        public async Task<ActionResult<User>> GetCurrentUser()
        {
            User currentUser = new User();
            return await Task.FromResult(currentUser);
        }

        [HttpGet("logoutuser")]
        public async Task<ActionResult<String>> LogOutUser()
        {
            await Task.Delay(1000);
            return "Success";
        }
    }
    
}
