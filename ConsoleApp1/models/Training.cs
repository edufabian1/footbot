namespace ConsoleApp1.models
{
    public class Training
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Cost { get; set; }
        public CostMeasureEnum CostMeasure { get; set; }        
        public int Benefits { get; set; }
        public int Money { get; set; }
    }
}
