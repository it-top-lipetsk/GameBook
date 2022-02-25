using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
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
            _db = new SqliteConnection("Data Source=game_book.db");
            _command = new SqliteCommand
            {
                Connection = _db
            };
        }

        public async Task OpenAsync()
        {
            await _db.OpenAsync();
        }

        public async Task CloseAsync()
        {
            await _db.CloseAsync();
        }

        public async Task<List<Genre>> GetAllGenresAsync()
        {
            await _db.OpenAsync();

            var genres = new List<Genre>();
            _command.CommandText = "SELECT id, genre FROM tab_genres;";
            var res = await _command.ExecuteReaderAsync();
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
            
            await _db.CloseAsync();

            return genres;
        }

        public async Task<List<Game>> GetAllGamesAsync()
        {
            await _db.OpenAsync();

            var games = new List<Game>();

            _command.CommandText = "SELECT tab_games.id AS 'id', name, genre FROM tab_games JOIN tab_genres ON tab_games.id_genre = tab_genres.id;";
            var res = await _command.ExecuteReaderAsync();
            if (res.HasRows)
            {
                while (res.Read())
                {
                    games.Add(new Game
                    {
                        Id = res.GetInt32("id"),
                        Name = res.GetString("name"),
                        GenreName = res.GetString("genre")
                    });
                }
            }
            
            await _db.CloseAsync();

            return games;
        }
    }
}