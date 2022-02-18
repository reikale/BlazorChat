using BlazorChat.Shared.Models;

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

        public static implicit operator ProfileViewModel (User user)
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
