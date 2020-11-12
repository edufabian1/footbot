using FootBot.Models.Enums;
using System;
using System.Security.Permissions;

namespace FootBot.Models.Models
{
    public class Food : IActivity
    {
        public int Id { get; set; }
        public string Name { get; set; }                
        public int Energy { get; set; }
        public int Hours { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }

        public int getCostISeconds()
        {
            return (Minutes * 60) + (Hours * 3600) + Seconds;
        }
    }
}
