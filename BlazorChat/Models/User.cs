namespace BlazorChat.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public SubscribtionTypes SubscribtionType { get; set;}
        public List<CoinInStock> UserCoins { get; set; }
        public List<User> FriendsList { get; set; }
        public List<Newsfeed> TagsUserFollows { get; set; }
        
    }
}
