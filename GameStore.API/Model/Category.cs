using System.Collections.Generic;
using Newtonsoft.Json;

namespace GameStore.API.Model
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        [JsonIgnore]
        public List<Game> Games { get; set; }

    }
}
