using GameStoreMobile.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameStoreMobile.Core.Repository
{
    public class ShoppingCartRepository
    {
        private static ShoppingCart _shoppingCart = new ShoppingCart();

        public void AddToShoppingCart(Game game, int amount)
        {
            var shoppingCartItem = new ShoppingCartItem()
            {
                Game = game,
                Amount = amount
            };

            _shoppingCart.CartItems.Add(shoppingCartItem);
        }

        public List<ShoppingCartItem> GetAllShoppingCartItems()
        {

            return _shoppingCart.CartItems;
        }

    }
}
