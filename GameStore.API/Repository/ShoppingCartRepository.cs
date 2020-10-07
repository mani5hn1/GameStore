using System.Collections.Generic;
using GameStore.API.Model;

namespace GameStore.API.Repository
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
