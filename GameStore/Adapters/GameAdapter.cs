using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using GameStore.Utility;
using GameStore.ViewHolders;
using Java.Security;
using PCLStorage;
using SQLite;

namespace GameStore.Adapters
{
    public class GameAdapter : RecyclerView.Adapter
    {
        public static string dpPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "user.db3");
        SQLiteConnection db = new SQLiteConnection(dpPath);
        //var games1 = sqlitConnection.Table<AddGame>().ToList();

        private List<AddGame> _games;
        public event EventHandler<int> ItemClick;

        public GameAdapter(Category category)
        {
            _games = category.Game;
        }
        public GameAdapter()
        {
            db.CreateTable<AddGame>();
            _games = db.Query<AddGame>("Select * from AddGame").ToList();

        }

        //public async Task LoadData()
        //    {
        //        var gameRepository = new GameRepositoryWeb();
        //        _games = await gameRepository.GetAllGames();

        //    }
        public override int ItemCount => /*db.Table<AddGame>().ToList().Count*/ _games.Count;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            if (holder is GameViewHolder gameViewHolder)
            {
                gameViewHolder.GameNameTextView.Text = /*db.Query<AddGame>("Select * from AddGame").ToList()[position].gameName*/ _games[position].gameName;

                var imageBitmap = ImageHelper.GetImageBitmapFromUrl(/*db.Query<AddGame>("Select * from AddGame").ToList()[position].imageUrlthumbnail*/_games[position].imageUrlthumbnail);
                gameViewHolder.GameImageView.SetImageBitmap(imageBitmap);
            }
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView =
                LayoutInflater.From(parent.Context).Inflate(Resource.Layout.game_viewholder, parent, false);

            GameViewHolder gameViewHolder = new GameViewHolder(itemView, onClick );
            return gameViewHolder;
        }

        void onClick(int position)
        {
            var gameId = db.Query<AddGame>("Select * from AddGame").ToList()[position].id;
            ItemClick?.Invoke(this, gameId);

        }
    }
}