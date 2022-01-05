using MVC_P0105_Currency_Exchange_Rate.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MVC_P0105_Currency_Exchange_Rate.Repositories
{
    public class CurrencyRepository
    {
        private string _urlBase = "http://www.lb.lt/webservices/ExchangeRates/ExchangeRates.asmx/getExchangeRatesByDate?Date=";
        public List<Currency> GetCurrenciesByDate(DateTime date)
        {
            string url = _urlBase + $"{date.Year}-{date.Month}-{date.Day}";
            List<Currency> result = new List<Currency>();
            XmlDocument xml = new XmlDocument();
            XmlNodeList nodeList;

            xml.Load(url);
            nodeList = xml.DocumentElement.SelectNodes("/ExchangeRates/item");

            foreach(XmlNode node in nodeList)
            {
                Currency c = new Currency()
                {
                    Date = node.SelectSingleNode("date").InnerText,
                    Name = node.SelectSingleNode("currency").InnerText,
                    Quantity = int.Parse(node.SelectSingleNode("quantity").InnerText),
                    Rate = double.Parse(node.SelectSingleNode("rate").InnerText, CultureInfo.InvariantCulture)
                };
                c.Unit = $"LTL per {c.Quantity} {c.Name}.";
                result.Add(c);
            }

            return result;
        }
    }
}
