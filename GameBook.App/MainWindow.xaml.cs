using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using GameBook.Lib;
using GameBook.Lib.Model;

namespace GameBook.App
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<Game> Games { get; set; }
        public MainWindow()
        {
            //BUG Не запускается
            InitAsync();
            InitializeComponent();
        }

        private async Task InitAsync()
        {
            var db = new GameBookDb();
            var games = await db.GetAllGamesAsync();
            Games = new ObservableCollection<Game>(games);
        }
    }
}