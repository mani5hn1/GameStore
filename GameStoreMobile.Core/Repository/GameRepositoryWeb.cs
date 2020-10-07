using GameStoreMobile.Core.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace GameStoreMobile.Core.Repository
{
   public class GameRepositoryWeb
    {

        public async Task<List<Game>> GetAllGames()
        {
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var responseMessage = await httpClient.GetAsync("http://192.168.0.1:5000/api/game/");

            if (!responseMessage.IsSuccessStatusCode) return null;

            var jsonResult = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
            var games = JsonConvert.DeserializeObject<IEnumerable<Game>>(jsonResult);
            return games.ToList();

        }

        public async Task<Game> GetGameById(int id)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var responseMessage = await httpClient.GetAsync("http://192.168.1.35:5000/api/game/" + id);

            if (!responseMessage.IsSuccessStatusCode) return null;

            var jsonResult = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
            var pies = JsonConvert.DeserializeObject<Game>(jsonResult);
            return pies;
        }
    }
}
