using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.View;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using GameStore.Adapters;

namespace GameStore
{
    [Activity(Label = "GameMenuWithTabsActivity")]
    public class GameMenuWithTabsActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.game_menu_tabs);
            // Create your application here
          

            CategoryFragmentAdapter categoryFragmentAdapter = new CategoryFragmentAdapter(SupportFragmentManager);
            ViewPager viewPager = FindViewById<ViewPager>(Resource.Id.gamePager);
            viewPager.Adapter = categoryFragmentAdapter;
        }
    }
}