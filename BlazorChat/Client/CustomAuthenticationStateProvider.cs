using BlazorChat.Shared.Models;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Json;
using System.Security.Claims;

namespace BlazorChat.Client
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly HttpClient _httpClient;
        public CustomAuthenticationStateProvider(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            User currentUser = await _httpClient.GetFromJsonAsync<User>("api/user/getcurrentuser");
            if (currentUser != null && currentUser.Email != null)
            {
                // create a claim
                var claimEmail = new Claim(ClaimTypes.Name, currentUser.Email);
                var claimsIdentifier = new Claim(ClaimTypes.NameIdentifier, Convert.ToString(currentUser.Id));
                // create claimsIdentity
                var claimsIdentity = new ClaimsIdentity(new[] { claimEmail, claimsIdentifier }, "serverAuth");
                // create claimsPrincipal
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                return new AuthenticationState(claimsPrincipal);
            }
            else
            {
                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
            }
        }
    }
}
