using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Android.App;
using Android.OS;
using Android.Widget;
using SQLite;

namespace GameStore
{
    [Activity(Label = "RegisterGame")]
    public class RegisterGame : Activity
    {
        string selectedItem;
        
        public static readonly Dictionary<string, Category> AllCategories = new Dictionary<string, Category>()
        {
            {"Action", new Category{CategoryName = "Action"}},
            {"Adventure", new Category{CategoryName = "Adventure"}},
            {"Sport", new Category{CategoryName = "Sport"}},
            {"Shooter", new Category{CategoryName = "Shooter"}},
        };

        public List<AddGame> listdata = new List<AddGame>();

        EditText txtgame;
        EditText txtdescritpion;
        EditText longdescription;
        EditText price;
        EditText imageurl;
        EditText imagethumbnailurl;
        Spinner gameCategory1;
        Button create;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.add_game);
            // Create your application here  
            create = FindViewById<Button>(Resource.Id.addgamebutton);
            txtgame = FindViewById<EditText>(Resource.Id.textgameadd1);
            txtdescritpion = FindViewById<EditText>(Resource.Id.textgameadd2);
            longdescription = FindViewById<EditText>(Resource.Id.textgameadd3);
            price = FindViewById<EditText>(Resource.Id.textgameadd4);
            imageurl = FindViewById<EditText>(Resource.Id.textgameadd5);
            imagethumbnailurl = FindViewById<EditText>(Resource.Id.textgameadd6);
            gameCategory1 = FindViewById<Spinner>(Resource.Id.spinner1);

            var spinner = FindViewById<Spinner>(Resource.Id.spinner1);
            spinner.ItemSelected += (s, e) =>
            {
                string firstItem = spinner.SelectedItem.ToString();
                if (firstItem.Equals(spinner.SelectedItem.ToString()))
                {
                    selectedItem = spinner.SelectedItem.ToString();
                }
                create.Click += Create_Click;
            };
        }

        private void Create_Click(object sender, EventArgs e)
        {
            try
            {
                string dpPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "user.db3");
                var db = new SQLiteConnection(dpPath);
                //db.DeleteAll(db.TableMappings.First());
                //db.DeleteAll(db.TableMappings.First());
                db.Table<AddGame>();
                
                var x = db.TableMappings.ToList();
                var tbl = new AddGame();
                tbl.gameName = txtgame.Text;
                tbl.description = txtdescritpion.Text;
                tbl.longDescription = longdescription.Text;
                tbl.price = price.Text;
                tbl.gameCategory1 = selectedItem.ToString();
                tbl.imageUrl = imageurl.Text;
                tbl.imageUrlthumbnail = imagethumbnailurl.Text;

                db.Insert(tbl);
                Toast.MakeText(this, "Record Added Successfully", ToastLength.Short).Show();
                //db.DeleteAll(db.TableMappings.First());

            }
            catch (Exception ex)
            {
                Toast.MakeText(this, ex.ToString(), ToastLength.Short).Show();
            }
        }

        private static List<AddGame> AllGames()
        {
            string dpPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "user.db3");
            var db = new SQLiteConnection(dpPath);
            db.CreateTable<AddGame>();
            return db.Query<AddGame>("Select * from AddGame").ToList();
        }

        public List<AddGame> GetAllGames()
        {
            return AllGames();
        }

        public List<Category> GetCategoriesWithGames()
        { 
            foreach (var category in AllCategories.Values)
            {
                category.Game = AllGames().Where(c=>c.Category == category.CategoryName).ToList(); 
            }

            return AllCategories.Values.ToList();
        }
    }
}