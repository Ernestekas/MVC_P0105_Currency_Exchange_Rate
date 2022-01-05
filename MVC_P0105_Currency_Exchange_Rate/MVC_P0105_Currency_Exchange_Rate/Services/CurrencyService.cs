using MVC_P0105_Currency_Exchange_Rate.DTOs;
using MVC_P0105_Currency_Exchange_Rate.Models;
using MVC_P0105_Currency_Exchange_Rate.Repositories;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MVC_P0105_Currency_Exchange_Rate.Services
{
    public class CurrencyService
    {
        private string _url = "http://www.lb.lt/webservices/ExchangeRates/ExchangeRates.asmx/getExchangeRatesByDate?Date=";
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

        public List<Currency> GetCurrencies(DateTime date)
        {
            string urlDayBefore = _url + $"{date.Year}-{date.Month}-{date.Day - 1}";
            List<Currency> result = new List<Currency>();
            XmlDocument xml = new XmlDocument();
            XmlDocument xml1 = new XmlDocument();
            XmlNodeList nodeList;
            XmlNodeList nodeListDayBefore;

            _url += $"{date.Year}-{date.Month}-{date.Day}";

            xml.Load(_url);
            nodeList = xml.DocumentElement.SelectNodes("/ExchangeRates/item");

            xml1.Load(urlDayBefore);
            nodeListDayBefore = xml1.DocumentElement.SelectNodes("/ExchangeRates/item");

            for (int i = 0; i < nodeList.Count; i++)
            {
                XmlNode node = nodeList[i];
                XmlNode nodeP = nodeListDayBefore[i];

                Currency c = new Currency()
                {
                    Date = node.SelectSingleNode("date").InnerText,
                    Name = node.SelectSingleNode("currency").InnerText,
                    Quantity = int.Parse(node.SelectSingleNode("quantity").InnerText),
                    Rate = double.Parse(node.SelectSingleNode("rate").InnerText, CultureInfo.InvariantCulture)
                };
                c.Unit = $"LTL per {c.Quantity} {c.Name}.";

                Currency cP = new Currency()
                {
                    Rate = double.Parse(nodeP.SelectSingleNode("rate").InnerText, CultureInfo.InvariantCulture)
                };

                c.Change = Math.Round(c.Rate - cP.Rate, 4);
                result.Add(c);
            }

            result = result.OrderByDescending(c => c.Change).ToList();
            return result;
        }
    }
}
