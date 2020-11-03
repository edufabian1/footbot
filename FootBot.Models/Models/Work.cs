namespace FootBot.Models.Models
{
    public class Work
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Cost { get; set; }
        public int Hours { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }
        public int Prize { get; set; }

        public int getCostISeconds()
        {
            return (Minutes * 60) + (Hours * 3600) + Seconds;
        }
    }
}
