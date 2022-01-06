using MVC_P0105_Currency_Exchange_Rate.DTOs;
using MVC_P0105_Currency_Exchange_Rate.Models;
using MVC_P0105_Currency_Exchange_Rate.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MVC_P0105_Currency_Exchange_Rate.Services
{
    public class CurrencyService
    {
        private CurrencyRepository _currencyRepository;

        public CurrencyService(CurrencyRepository currencyRepository)
        {
            _currencyRepository = currencyRepository;
        }

        public CurrenciesModel GetCurrenciesModel(DateTime selectedDate)
        {
            DateTime yesterday = selectedDate.AddDays(-1);

            CurrenciesModel result = new CurrenciesModel()
            {
                Year = selectedDate.Year,
                Month = selectedDate.Month,
                Day = selectedDate.Day
            };

            List<Currency> currencies = _currencyRepository.GetCurrenciesByDate(selectedDate);
            List<Currency> currenciesYesterday = _currencyRepository.GetCurrenciesByDate(yesterday);

            foreach(Currency c in currencies)
            {
                Currency cYesterday = currenciesYesterday.FirstOrDefault(x => x.Name == c.Name);
                c.Change = Math.Round(c.Rate - cYesterday.Rate, 4);
            }

            result.Currencies = currencies.OrderByDescending(x => x.Change).ToList();

            return result;
        }
    }
}
