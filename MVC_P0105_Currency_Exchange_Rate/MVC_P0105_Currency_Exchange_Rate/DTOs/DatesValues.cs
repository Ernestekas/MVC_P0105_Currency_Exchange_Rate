using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_P0105_Currency_Exchange_Rate.DTOs
{
    public class DatesValues
    {
        public List<int> Years { get; set; } = new List<int>();
        public List<int> Months { get; set; } = new List<int>();
        public List<int> Days { get; set; } = new List<int>();
    }
}
