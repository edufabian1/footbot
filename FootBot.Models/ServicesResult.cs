using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootBot.Models
{
    public class ServicesResult<T>
    {
        public string Message { get; set; }
        public bool Ok
        {
            get { return string.IsNullOrEmpty(Message) ? true : false; }
            set { Ok = value; }
        }
        public T Result { get; set; }
    }
}
