using SQLite;

namespace GameStore
{
    public class AddGame
    {
        [PrimaryKey, AutoIncrement, Column("_Id")]
        public int id { get; set; }
        [MaxLength(25)]

        public string gameName { get; set; }
        
        public string description { get; set; }

        public string longDescription { get; set; }

        public string price { get; set; }

        public string imageUrl { get; set; }
         
        public string imageUrlthumbnail { get; set; }

        public string gameCategory1 { get; set; }

        public string Category { get; set; }
    }
}