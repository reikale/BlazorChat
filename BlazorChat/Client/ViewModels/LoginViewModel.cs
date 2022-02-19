using BlazorChat.Shared.Models;
namespace BlazorChat.Client.ViewModels
{
    public class LoginViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public LoginViewModel()
        {

        }
        private HttpClient _httpClient;
        public LoginViewModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task LoginUser()
        {
            await Task.Delay(1000);
        }

        public static implicit operator LoginViewModel(User user)
        {
            return new LoginViewModel
            {
                Email = user.Email,
                Password = user.Password
            };
        }
        public static implicit operator User (LoginViewModel loginViewModel)
        {
            return new User
            {
                Email = loginViewModel.Email,
                Password = loginViewModel.Password
            };
        }
    }
}
