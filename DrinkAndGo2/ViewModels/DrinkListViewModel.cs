﻿using DrinkAndGo2.Data.Models;

namespace DrinkAndGo2.ViewModels
{
    public class DrinkListViewModel
    {
        public IEnumerable<Drink> Drinks { get; set; }
        public string CurrentCategory { get; set; }
    }
}
