using MVC_P0105_Currency_Exchange_Rate.Models;
using System.Collections.Generic;

namespace MVC_P0105_Currency_Exchange_Rate.DTOs
{
    public class CurrenciesModel
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
        public bool FirstLoad { get; set; } = true;
        public List<Currency> Currencies { get; set; }
        public DatesValues PossibleDates { get; set; } = new DatesValues();

        public CurrenciesModel()
        {
            for(int i = 1993; i <= 2014; i++)
            {
                PossibleDates.Years.Add(i);
            }
            for(int i = 1; i <= 12; i++)
            {
                PossibleDates.Months.Add(i);
            }
            for(int i = 1; i <= 31; i++)
            {
                PossibleDates.Days.Add(i);
            }
        }
    }
}
