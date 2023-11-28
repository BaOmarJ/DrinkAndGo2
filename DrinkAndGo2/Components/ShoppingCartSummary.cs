using DrinkAndGo2.Data.Models;
using DrinkAndGo2.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DrinkAndGo2.Components
{
    public class ShoppingCartSummary : ViewComponent
    {
        private readonly ShoppingCart _shoppingCart;
        public ShoppingCartSummary(ShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart;
        }

        public IViewComponentResult Invoke()
        {
            //var items = _shoppingCart.GetShoppingCartItems(); // get items from database.
            var items = new List<ShoppingCartItem>() { new ShoppingCartItem(), new ShoppingCartItem() };
            _shoppingCart.ShoppingCartItems = items;

            var shoppingCartViewModel = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };
            return View(shoppingCartViewModel);
        }
    }
}
