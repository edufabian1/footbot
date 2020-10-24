using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.models
{
    public class Food
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Cost { get; set; }
        public CostMeasureEnum  CostMeasure { get; set; }
        public int Benefits { get; set; }
    }
}
