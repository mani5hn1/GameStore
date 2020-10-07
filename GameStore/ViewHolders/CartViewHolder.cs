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

namespace GameStore.ViewHolders
{
    public class CartViewHolder : RecyclerView.ViewHolder
    {

        public ImageView GameImageView { get; set; }
        public TextView GameNameTextView { get; set; }
        public TextView GameAmountTextView { get; set; }

        public CartViewHolder(View itemView, Action<int> listener) : base(itemView)
        {
            GameImageView = itemView.FindViewById<ImageView>(Resource.Id.gameImageView);
            GameNameTextView = itemView.FindViewById<TextView>(Resource.Id.gameNameTextView);
            GameAmountTextView = itemView.FindViewById<TextView>(Resource.Id.gameAmountTextView);

            itemView.Click += (sender, e) => listener(base.LayoutPosition);
        }
    }
}