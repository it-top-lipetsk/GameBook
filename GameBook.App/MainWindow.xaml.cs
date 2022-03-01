using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using GameBook.Lib;
using GameBook.Lib.Model;

namespace GameBook.App
{
    public partial class MainWindow : Window
    {
        private ObservableCollection<Game> Games { get; set; }
        private ObservableCollection<Genre> Genres { get; set; }

        public MainWindow()
        {
            Init();
            InitializeComponent();

            ListGames.ItemsSource = Games;
        }

        private void Init()
        {
            var db = new GameBookDb();
            Games = new ObservableCollection<Game>(db.GetAllGames());
            Genres = new ObservableCollection<Genre>(db.GetAllGenres());
        }

        private void ListGames_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var game = ListGames.SelectedItem as Game;

            InputId.Text = game.Id.ToString();
            InputName.Text = game.Name;
            InputGenre.ItemsSource = Genres;
            InputGenre.SelectedIndex = game.GenreId - 1;
        }
    }
}