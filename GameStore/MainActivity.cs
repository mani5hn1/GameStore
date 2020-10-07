using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System;
using GameStore;
using Android.Graphics.Drawables;

namespace GameStore
{
    [Activity(/*Icon = "@drawable/ic_launcher",*/ Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private Button _cartButton;
        private Button _orderButton;
        private Button _aboutButton;
        private Button _tabsOrderButton;
        private Button _googleMapsButton;
        private Button _mapsButton;
        private Button _addGame;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            FindViews();
            LinkEventHandlers();
        }

        private void LinkEventHandlers()
        {
            _orderButton.Click += OrderButton_Click;
            _cartButton.Click += CartButton_Click;
            _aboutButton.Click += AboutButton_Click;
            _tabsOrderButton.Click += _tabsOrderButton_Click;
            _googleMapsButton.Click += GoogleMapsButton_Click;
            _mapsButton.Click += MapsButton_Click;
            _addGame.Click += AddGame_Click;
        }

        private void AddGame_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(RegisterGame));
        }

        private void _tabsOrderButton_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(GameMenuWithTabsActivity));
            StartActivity(intent);
        }

        private void GoogleMapsButton_Click(object sender, EventArgs e)
        {
            var geolocation = Android.Net.Uri.Parse("geo:51.5459, -0.2212");
            var intent = new Intent(Intent.ActionView, geolocation);
            StartActivity(intent);
        }

  
        private void FindViews()
        {
            _orderButton = FindViewById<Button>(Resource.Id.orderButton);
            _cartButton = FindViewById<Button>(Resource.Id.cartButton);
            _aboutButton = FindViewById<Button>(Resource.Id.aboutButton);
            _tabsOrderButton = FindViewById<Button>(Resource.Id.tabsOrderButton);
            _googleMapsButton = FindViewById<Button>(Resource.Id.googleMapsButton);
            _mapsButton = FindViewById<Button>(Resource.Id.mapsButton);
            _addGame = FindViewById<Button>(Resource.Id.addgameButton);

        }

        private void MapsButton_Click(object sender, System.EventArgs e)
        {
            Intent intent = new Intent(this, typeof(MapActivity));
            StartActivity(intent);
        }

        private void OrderButton_Click(object sender, System.EventArgs e)
        {
            Intent intent = new Intent(this, typeof(GameMenuActivity));
            StartActivity(intent);
        }

        private void AboutButton_Click(object sender, System.EventArgs e)
        {
            Intent intent = new Intent(this, typeof(AboutActivity));
            StartActivity(intent);
        }
        //private void TabsOrderButton_Click(object sender, System.EventArgs e)
        //{
        //    Intent intent = new Intent(this, typeof(PieMenuWithTabsActivity));
        //    StartActivity(intent);
        //}

        private void CartButton_Click(object sender, System.EventArgs e)
        {
            Intent intent = new Intent(this, typeof(CartActivity));
            StartActivity(intent);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }


    }
}