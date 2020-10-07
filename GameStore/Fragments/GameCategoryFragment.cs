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
using GameStore.Adapters;
using New_Games_Store;

namespace GameStore.Fragments
{
    public class GameCategoryFragment : Android.Support.V4.App.Fragment
    {
        private readonly Category _category;
        public GameCategoryFragment(Category category)
        {
            _category = category;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {

            View view = inflater.Inflate(Resource.Layout.game_menu_fragment, container, false);

            var categoryTextView = view.FindViewById<TextView>(Resource.Id.categoryTextView);
            categoryTextView.Text = _category.CategoryName;

            var gameRecyclerView = view.FindViewById<RecyclerView>(Resource.Id.gameMenuRecyclerView);
            var gameLayoutManager = new LinearLayoutManager(this.Context);
            gameRecyclerView.SetLayoutManager(gameLayoutManager);

            var gameAdapter = new GameAdapter(_category);
            gameAdapter.ItemClick += GameAdapter_ItemClick;
           gameRecyclerView.SetAdapter(gameAdapter);

            return view;
        }

        private void GameAdapter_ItemClick(object sender, int e)
        {
            var intent = new Intent();
            intent.SetClass(this.Context, typeof(GameDetail));
            intent.PutExtra("selectedGameId", e);
            StartActivity(intent);
        }
             

    }
}