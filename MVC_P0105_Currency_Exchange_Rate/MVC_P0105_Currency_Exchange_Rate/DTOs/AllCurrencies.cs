using MVC_P0105_Currency_Exchange_Rate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_P0105_Currency_Exchange_Rate.DTOs
{
    public class AllCurrencies
    {
        public List<Currency> Currencies { get; set; } = new List<Currency>();
    }
}
