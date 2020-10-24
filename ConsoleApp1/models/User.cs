using ConsoleApp1.models;

namespace ConsoleApp1
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public PlayerActionEnum PlayerAction { get; set; }
        public int Count { get; set; }
        public Food Food { get; set; }
        public Training Training { get; set; }

        public User()
        {
            Food = new Food();
            Training = new Training();
        }
    }
}
