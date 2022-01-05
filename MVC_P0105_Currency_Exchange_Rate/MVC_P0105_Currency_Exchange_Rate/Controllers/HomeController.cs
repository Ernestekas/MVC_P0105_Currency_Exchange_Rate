using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVC_P0105_Currency_Exchange_Rate.DTOs;
using MVC_P0105_Currency_Exchange_Rate.Models;
using MVC_P0105_Currency_Exchange_Rate.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace MVC_P0105_Currency_Exchange_Rate.Controllers
{
    public class HomeController : Controller
    {
        private CurrencyService _currencyService;
        
        public HomeController(CurrencyService currencyService)
        {
            _currencyService = currencyService;
        }

        public IActionResult ShowCurrencies(CurrenciesModel model)
        {
            if (!model.FirstLoad)
            {
                try
                {
                    model = _currencyService.GetCurrenciesModel(new DateTime(model.Year, model.Month, model.Day));
                }
                catch
                {
                    ModelState.AddModelError("Name", "Selected day is invalid.");
                }
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult GetRates(CurrenciesModel model)
        {
            model.FirstLoad = false;

            return RedirectToAction(nameof(ShowCurrencies), model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

