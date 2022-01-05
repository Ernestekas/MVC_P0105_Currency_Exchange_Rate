using MVC_P0105_Currency_Exchange_Rate.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_P0105_Currency_Exchange_Rate.DTOs
{
    public class DisplaySelectedDate
    {
        public int Year { get; set; } = 1993;
        public int Month { get; set; } = 1;
        public int Day { get; set; } = 2;
        public bool FirstLoad { get; set; } = true;
        public AllCurrencies Currencies { get; set; }
    }
}
