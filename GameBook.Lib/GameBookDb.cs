using System.Collections.Generic;
using System.Data;
using GameBook.Lib.Model;
using Microsoft.Data.Sqlite;

namespace GameBook.Lib
{
    public class GameBookDb
    {
        private SqliteConnection _db;
        private SqliteCommand _command;

        public GameBookDb()
        {
            _db = new SqliteConnection(@"Data Source=D:\Programming\Education\ITStep\Lipetsk\GameBook\game_book.db");
            _command = new SqliteCommand
            {
                Connection = _db
            };
        }

        public List<Genre> GetAllGenres()
        {
            _db.Open();

            var genres = new List<Genre>();
            _command.CommandText = "SELECT id, genre FROM tab_genres;";
            var res = _command.ExecuteReader();
            if (res.HasRows)
            {
                while (res.Read())
                {
                    genres.Add( new Genre
                    {
                        Id = res.GetInt32("id"),
                        Name = res.GetString("genre")
                    });
                }
            }
            
            _db.Close();

            return genres;
        }

        public List<Game> GetAllGames()
        {
            _db.Open();

            var games = new List<Game>();

            _command.CommandText = "SELECT tab_games.id AS 'id', name, id_genre, genre FROM tab_games JOIN tab_genres ON tab_games.id_genre = tab_genres.id;";
            var res = _command.ExecuteReader();
            if (res.HasRows)
            {
                while (res.Read())
                {
                    games.Add(new Game
                    {
                        Id = res.GetInt32("id"),
                        Name = res.GetString("name"),
                        GenreId = res.GetInt32("id_genre"),
                        GenreName = res.GetString("genre")
                    });
                }
            }
            
            _db.Close();

            return games;
        }
    }
}