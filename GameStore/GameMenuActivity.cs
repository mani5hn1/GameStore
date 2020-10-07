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
using Android.Support.V7.Widget;
using GameStore.Adapters;

namespace GameStore
{
    [Activity(Label = "GameMenuActivity")]
    public class GameMenuActivity : Activity
    {
        private RecyclerView _gameRecyclerView;
        private RecyclerView.LayoutManager _gameLayoutManager;
        private GameAdapter _gameAdapter;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Create your application here
            SetContentView(Resource.Layout.game_menu);
            _gameRecyclerView = FindViewById<RecyclerView>(Resource.Id.gameMenuRecyclerView);
            //game adapter
            //layout manager
            //view holder
            _gameLayoutManager = new LinearLayoutManager(this);
            _gameRecyclerView.SetLayoutManager(_gameLayoutManager);

            _gameAdapter = new GameAdapter();
            //await _gameAdapter.LoadData();

            _gameAdapter.ItemClick += GameAdapter_ItemClick;
            _gameRecyclerView.SetAdapter(_gameAdapter);

        }

        private void GameAdapter_ItemClick(object sender, int e)
        {
            var intent = new Intent();
            intent.SetClass(this, typeof(New_Games_Store.GameDetail));
            intent.PutExtra("selectedGameId", e);
            StartActivity(intent);
        }

      
    }
}