using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using FragmentManager = Android.Support.V4.App.FragmentManager;
using Fragment = Android.Support.V4.App.Fragment;
using GameStore.Fragments;
using System.IO;
using SQLite;

namespace GameStore.Adapters
{
    public class CategoryFragmentAdapter : FragmentPagerAdapter
    {
        //public static string dpPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "user.db3");
        //SQLiteConnection db = new SQLiteConnection(dpPath);


        private readonly List<Category> _categories;

        public CategoryFragmentAdapter(FragmentManager fm) : base(fm)
        {

            //var gameRepository = new GameRepository();
            var game = new RegisterGame();
            _categories = game.GetCategoriesWithGames();

            //db.CreateTable<AddGame>();


        }
        public override int Count => /*db.Table<AddGame>().ToList().Count*/_categories.Count;

        public override Fragment GetItem(int position)
        {
            GameCategoryFragment gameCategoryFragment = new GameCategoryFragment(_categories[position]);
            return gameCategoryFragment;
        }

        public override Java.Lang.ICharSequence GetPageTitleFormatted(int position)
        {
            return new Java.Lang.String(_categories[position].CategoryName);
        }
    }
}