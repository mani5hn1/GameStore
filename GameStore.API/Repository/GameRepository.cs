using System.Collections.Generic;
using System.Linq;
using GameStore.API.Model;

namespace GameStore.API.Repository
{
    public class GameRepository
    {
        public static readonly Dictionary<string, Category> AllCategories = new Dictionary<string, Category>()
        {
            {"Action", new Category{CategoryName = "Action"}},
            {"Adventure", new Category{CategoryName = "Adventure"}},
            {"Sport", new Category{CategoryName = "Sport"}},
        };

        public static readonly List<Game> AllGames = new List<Game>()
        {
            new Game{GameId = 1, Category = AllCategories["Adventure"], Name = "Far Cry 4", Price = 39.99M, InStock = true, IsGameOfTheWeek = true, Image = "https://vignette.wikia.nocookie.net/farcry/images/7/73/FC4_KEYART_PACK-610x722.jpg/revision/latest?cb=20180525041932",ImageThumbnailUrl = "https://vignette.wikia.nocookie.net/farcry/images/7/73/FC4_KEYART_PACK-610x722.jpg/revision/latest?cb=20180525041932", ShortDescription = "Far Cry 4 is a 2014 first-person shooter game developed by Ubisoft Montreal and published by Ubisoft." ,LongDescription = "It is the successor to the 2012 video game Far Cry 3, and the fourth main installment in the Far Cry series. The game takes place in Kyrat, a fictional Himalayan country. The main story follows Ajay Ghale, a young Kyrati-American, as he is caught in a civil war involving Kyrat's Royal Army, controlled by tyrannical king Pagan Min, and a rebel movement called the Golden Path. Gameplay focuses on combat and exploration; players battle enemy soldiers and dangerous wildlife using a wide array of weapons. The game features many elements found in role-playing games, such as a branching storyline, and side quests. The game also features a map editor both cooperative and competitive multiplayer modes." },
            new Game{GameId = 2, Category = AllCategories["Sport"], Name = "FIFA 20", Price = 49.99M, InStock = true, IsGameOfTheWeek = false, Image = "https://cdn-products.eneba.com/resized-products/qoA2QojrFaqg8VtfKSEJm1jsXU-9UEJJSNf2WTvMBjE_390x400_1x-0.jpeg",ImageThumbnailUrl = "https://cdn-products.eneba.com/resized-products/qoA2QojrFaqg8VtfKSEJm1jsXU-9UEJJSNf2WTvMBjE_390x400_1x-0.jpeg", ShortDescription = "FIFA 20 is a football simulation video game published by Electronic Arts as part of the FIFA series." ,LongDescription = "It is the 27th installment in the FIFA series, and was released on 27 September 2019 for Microsoft Windows, PlayStation 4, Xbox One, and Nintendo Switch. Real Madrid winger Eden Hazard was named the new cover star of the Regular Edition, with Liverpool defender Virgil van Dijk on the cover of the Champions Edition. Former Juventus and Real Madrid midfielder Zinedine Zidane was later named as the cover star for the Ultimate Edition. The game features VOLTA Football for the first time, a new mode that provides a variance on the traditional 11v11 gameplay and focuses on small-sided street and futsal games. The mode is believed to be focused on the former FIFA Street series." },
            new Game{GameId = 3, Category = AllCategories["Action"], Name = "Mortal Kombat 11", Price = 42.99M, InStock = false, IsGameOfTheWeek = false, Image = "https://upload.wikimedia.org/wikipedia/en/thumb/7/7e/Mortal_Kombat_11_cover_art.png/220px-Mortal_Kombat_11_cover_art.png",ImageThumbnailUrl = "https://upload.wikimedia.org/wikipedia/en/thumb/7/7e/Mortal_Kombat_11_cover_art.png/220px-Mortal_Kombat_11_cover_art.png", ShortDescription = "Mortal Kombat 11 is a fighting game developed by NetherRealm Studios and published by Warner Bros. Interactive Entertainment." ,LongDescription = "Continue the epic saga through a new cinematic story that is more than 25 years in the making. Players will take on the role of a variety of past and present characters in a time-bending new narrative that pits Raiden against Kronika, the Keeper of Time who created existence at the dawn of history. Offers nearly infinite customization options, giving players more control and providing a deeper and more personalised experience than ever before. Players can customize their fighters with a variety of Skins, Gear, Special Abilities, Intro and Victory Cinemas, Taunts and Brutalities that can be earned via gameplay." },

        };

        public List<Game> GetAllGames()
        {
            return AllGames;
        }

        public List<Category> GetCategoriesWithGames()
        {
            foreach (var category in AllCategories.Values)
            {
                category.Games = AllGames.Where(c => c.Category == category).ToList();
            }
            return AllCategories.Values.ToList();
        }

        public Game GetGameById(int id)
        {
            return AllGames.FirstOrDefault(g => g.GameId == id);

        }
    }
}
