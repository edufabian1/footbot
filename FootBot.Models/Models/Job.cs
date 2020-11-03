using FootBot.Models.Enums;

namespace FootBot.Models.Models
{
    public class Job
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CostEnergy { get; set; }
        public double CostTime { get; set; }
        public CostMeasureEnum CostMeasure { get; set; }
        public int Benefits { get; set; }
    }
}
