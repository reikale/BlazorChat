using System.ComponentModel.DataAnnotations;

namespace BlazorChat.Shared.Models
{
    public class ChatHistory
    {
        [Key]
        public int Id { get; set; }
        public int FromUserId { get; set; }
        public int ToUserId { get; set; }
        public string Message { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
