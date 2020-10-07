using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameStoreMobile.Core.Model
{
   public class Game
    {
        [PrimaryKey, AutoIncrement, Column("_Id")]
        public int id { get; set; }
        [MaxLength(25)]

        public int GameId { get; set; }
        
        public string Name { get; set; }
        
        public string ShortDescription { get; set; }

        public string LongDescription { get; set; }

        public string Price { get; set; }

        public string Image { get; set; }

        public string ImageThumbnailUrl { get; set; }

        public bool IsGameOfTheWeek { get; set; }

        public bool InStock { get; set; }

        public Category Category1 { get; set; }

        public string Category { get; set; }


    }
}
