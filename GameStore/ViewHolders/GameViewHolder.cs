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
    public class GameViewHolder : RecyclerView.ViewHolder
    {
        public ImageView GameImageView { get; set; }

        public TextView GameNameTextView { get; set; }


        public GameViewHolder(View itemView, Action<int> listener) : base(itemView)
        {
            GameImageView = itemView.FindViewById<ImageView>(Resource.Id.GameImageView);
            GameNameTextView = itemView.FindViewById<TextView>(Resource.Id.GameNametextView1);

            itemView.Click += (Sender, e) => listener(base.LayoutPosition);
            
        }
    }
}