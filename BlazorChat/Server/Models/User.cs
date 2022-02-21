using System.ComponentModel.DataAnnotations;

namespace BlazorChat.Server.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Source { get; set; }
        public string? ProfilePicture { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? About { get; set; }
        public int? Notifications { get; set; }
        public DateTime? DateCreated { get; set; }

        public User()
        {

        }
        public User(int Id, string FirstName, string LastName)
        {
            this.Id = Id;
            this.FirstName = FirstName;
            this.LastName = LastName;
        }
    }
}
