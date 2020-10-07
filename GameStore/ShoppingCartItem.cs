using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace GameStore
{
    public class ShoppingCartItem
    {
        public AddGame Game
        {
            get;
            set;

        }

        public int Amount
        {
            get;
            set;
        }

        private static ShoppingCart _shoppingCart = new ShoppingCart();

        public void AddToShoppingCart(AddGame game, int amount)
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