using BlazorChat.Shared.Models;
using System.Net.Http.Json;

namespace BlazorChat.Client.ViewModels
{
    public class ProfileViewModel
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public long Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Source { get; set; }
        public ProfileViewModel()
        {

        }
        private HttpClient _httpClient;
        public ProfileViewModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task UpdateProfile()
        {
            User user = this;

            await _httpClient.PutAsJsonAsync("api/user/updateprofile/" + this.Id, user);
            this.Message = "Profile updated successfully";
        }
        public async Task GetProfile()
        {
            if (this.Id != 0 && this.Email != null)
            {
                throw new FileNotFoundException();
            }
            else
            {
                User user = await _httpClient.GetFromJsonAsync<User>("api/user/updateprofile/" + this.Id);
                // Modeli pakonvertuojam i viewmodel
                LoadCurrentObject(user);
                this.Message = "Profile loaded successfully";
            }
            
            
        }
        private void LoadCurrentObject(ProfileViewModel profileViewModel)
        {
            this.FirstName = profileViewModel.FirstName;
            this.LastName = profileViewModel.LastName;
            this.Email = profileViewModel.Email;
            this.Password = profileViewModel.Password;
            this.Source = profileViewModel.Source;
        }
        public static implicit operator ProfileViewModel(User user)
        {
            //keiciam model i viewmodel
            return new ProfileViewModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Id = user.Id,
                Password = user.Password,
                Source = user.Source
            };
        }
        public static implicit operator User(ProfileViewModel profileViewModel)
        {
            //keiciam viewmodel i model
            return new User
            {
                FirstName = profileViewModel.FirstName,
                LastName = profileViewModel.LastName,
                Email = profileViewModel.Email,
                Id = profileViewModel.Id,
                Password = profileViewModel.Password,
                Source = profileViewModel.Source

            };
        }
    }
}
