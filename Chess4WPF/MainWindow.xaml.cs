using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Chess4WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<string> pieces;
        private Piece piece;

        public MainWindow()
        {
            InitializeComponent();
            pieces = new List<string> {"Pawn", "Rook", "Bishop", "Knight", "Rook", "Queen"};
            PiecesList.ItemsSource = pieces;
        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            var sendButton = (Button)sender;
            int x = Grid.GetColumn(sendButton);
            int y = Grid.GetRow(sendButton);

            Image myImage3 = new Image();
            BitmapImage bi3 = new BitmapImage();
            bi3.BeginInit();
            switch (PiecesList.Text)
            {
                case "Pawn":
                    bi3.UriSource = new Uri(@"C:\Users\User\source\repos\Chess4\Chess4WPF\PieceIcons\wP.png");
                    break;
                case "Knight":
                    bi3.UriSource = new Uri(@"C:\Users\User\source\repos\Chess4\Chess4WPF\PieceIcons\wN.png");
                    break;
                case "King":
                    bi3.UriSource = new Uri(@"C:\Users\User\source\repos\Chess4\Chess4WPF\PieceIcons\wK.png");
                    break;
                case "Bishop":
                    bi3.UriSource = new Uri(@"C:\Users\User\source\repos\Chess4\Chess4WPF\PieceIcons\wB.png");
                    break;
                case "Queen":
                    bi3.UriSource = new Uri(@"C:\Users\User\source\repos\Chess4\Chess4WPF\PieceIcons\wQ.png");
                    break;
                case "Rook":
                    bi3.UriSource = new Uri(@"C:\Users\User\source\repos\Chess4\Chess4WPF\PieceIcons\wR.png");
                    break;
            }
            bi3.EndInit();
            myImage3.Stretch = Stretch.Fill;
            myImage3.Source = bi3;
        }
    }
}
