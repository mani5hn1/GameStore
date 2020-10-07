using System;
using System.Collections.Generic;
using System.Text;

namespace GameStoreMobile.Core.Model
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<Game> Game {get;set;}


    }
}
