using DrinkAndGo2.Data.Interfaces;
using DrinkAndGo2.Models;
using DrinkAndGo2.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DrinkAndGo2.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDrinkRepository _drinkRepository;
        public HomeController(IDrinkRepository drinkRepository)
        {
            _drinkRepository = drinkRepository;
        }

        public ViewResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                PreferredDrinks = _drinkRepository.PreferredDrinks
            };
            return View(homeViewModel);
        }
    }
}