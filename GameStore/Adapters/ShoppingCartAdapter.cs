using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
 
using GameStore;
using GameStore.Utility;
using GameStore.ViewHolders;

namespace GameStore.Adapters
{
    public class ShoppingCartAdapter : RecyclerView.Adapter
    {
        private readonly ShoppingCartItem _shoppingCartRepository;

        public ShoppingCartAdapter()
        {
            _shoppingCartRepository = new ShoppingCartItem();
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.cart_viewholder, parent, false);

            CartViewHolder cartViewHolder = new CartViewHolder(itemView, OnClick);
            return cartViewHolder;
        }

        void OnClick(int position)
        {
            //not needed here
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            if (holder is CartViewHolder cartViewHolder)
            {
                var game = _shoppingCartRepository.GetAllShoppingCartItems()[position].Game;
                cartViewHolder.GameNameTextView.Text = game.gameName;
                cartViewHolder.GameAmountTextView.Text = _shoppingCartRepository.GetAllShoppingCartItems()[position].Amount.ToString();

                var imageBitmap = ImageHelper.GetImageBitmapFromUrl(game.imageUrlthumbnail);
                cartViewHolder.GameImageView.SetImageBitmap(imageBitmap);
            }
        }

        public override int ItemCount => _shoppingCartRepository.GetAllShoppingCartItems().Count;
    }
}