namespace GameStore.API.Model
{
    public class Game
    {
        public int GameId { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public string ImageThumbnailUrl { get; set; }
        public bool IsGameOfTheWeek { get; set; }
        public bool InStock { get; set; }
        public Category Category { get; set; }


    }
}
