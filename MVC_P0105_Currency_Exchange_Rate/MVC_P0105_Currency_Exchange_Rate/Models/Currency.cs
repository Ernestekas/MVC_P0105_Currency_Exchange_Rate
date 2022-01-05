using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_P0105_Currency_Exchange_Rate.Models
{
    public class Currency
    {
        public string Date { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public double Rate { get; set; }
        public string Unit { get; set; }
        public double Change { get; set; }
    }
}
