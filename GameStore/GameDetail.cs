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
using GameStore.Utility;
using GameStore;
using System.IO;
using SQLite;

namespace New_Games_Store
{

    [Activity(Label = "GameDetail"  )]
    public class GameDetail : Activity
    {
        public static string dpPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "user.db3");
        public SQLiteConnection db = new SQLiteConnection(dpPath);
        private AddGame _selectedGame;
        private ImageView _gameImageView;
        private TextView _gameNameTextView1;
        private TextView _shortDescriptionTextView;
        private TextView _longDescriptionTextView;
        private TextView _priceTextView;
        private EditText _amountEditText;
        private Button _addToCartButton;

        public AddGame GetGameById(int id)
        {
            db.CreateTable<AddGame>();
            return db.Query<AddGame>("Select * from AddGame").FirstOrDefault(g => g.id == id);
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Game_Detail);


            // Create your application here
            
            var selectedGameId = Intent.Extras.GetInt("selectedGameId");
            var x = new AddGame();
                      
            _selectedGame = db.Query<AddGame>("Select * from AddGame").FirstOrDefault(g => g.id == (selectedGameId));
            FindViews();
            BindData();
            LinkEventHandlers();
        }
        

        private void BindData()
        {
            _gameNameTextView1.Text = _selectedGame.gameName;
            _shortDescriptionTextView.Text = _selectedGame.description;
            _longDescriptionTextView.Text = _selectedGame.longDescription;
            _priceTextView.Text = "Price:  £" + _selectedGame.price;

            var imageBitmap = ImageHelper.GetImageBitmapFromUrl(_selectedGame.imageUrlthumbnail);

            _gameImageView.SetImageBitmap(imageBitmap);
        }

        private void FindViews()
        {
            _gameImageView = FindViewById<ImageView>(Resource.Id.GameImageView);
            _gameNameTextView1 = FindViewById<TextView>(Resource.Id.GametextView1);
            _shortDescriptionTextView = FindViewById<TextView>(Resource.Id.ShortDescriptiontextView1);
            _longDescriptionTextView = FindViewById<TextView>(Resource.Id.DescriptiontextView1);
            _priceTextView = FindViewById<TextView>(Resource.Id.PricetextView1);
            _amountEditText = FindViewById<EditText>(Resource.Id.editText1);
            _addToCartButton = FindViewById<Button>(Resource.Id.addToCartbutton1);


        }
        private void LinkEventHandlers()
        {
            _addToCartButton.Click += AddToCartButton_Click;
        }
        private void AddToCartButton_Click(object sender, EventArgs e)
        {
            var amount = int.Parse(_amountEditText.Text);

            ShoppingCartItem shoppingCart = new ShoppingCartItem();
            shoppingCart.AddToShoppingCart(_selectedGame, amount);
            Toast.MakeText(Application.Context, "Game added to cart", ToastLength.Long).Show();

            this.Finish();
        }

    }



}