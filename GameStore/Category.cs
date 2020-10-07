using SQLite;
using System;
using System.Collections.Generic;
using System.IO;

namespace GameStore
{
    public class Category
    {
        public static string dpPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "user.db3");
        public static SQLiteConnection db = new SQLiteConnection(dpPath);

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<AddGame> Game { get; set; }


    }
}