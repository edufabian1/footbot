using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootBot.Models
{
    public interface IActivity
    {
        string Name { get; set; }
        int getCostISeconds();
    }
}
