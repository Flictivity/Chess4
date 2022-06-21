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
        private List<string> piecesNames;
        private Piece piece;
        private List<Piece> pieces;
        private Piece selectedPiece = null;

        public MainWindow()
        {
            InitializeComponent();
            piecesNames = new List<string> {"Pawn", "Rook", "Bishop", "Knight", "Rook", "Queen"};
            PiecesList.ItemsSource = piecesNames;
            pieces = new List<Piece>();
        }

        private void btnAddPiece_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(tbCords.Text != "" && PiecesList.SelectedItem != null)
                {
                    piece = PieceFabric.Make(new PieceData
                    {
                        Name = PiecesList.Text,
                        Data = new Dictionary<string, string>
                                    {
                                        { "Cords", tbCords.Text}
                                    }
                    });

                    var btn = GetButton(piece.x, piece.y);
                    if (btn.Content == null)
                    {
                        btn.Content = GetPieceImg(PiecesList.Text);
                        pieces.Add(piece);
                    }
                    else
                    {
                        MessageBox.Show("This corrdinates not empty");
                    }
                }
            }
            catch
            {
                MessageBox.Show("Select Piece type");
            }
        }
        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var clickedBtn = (Button)sender;
                if (clickedBtn.Content != null)
                {
                    selectedPiece = GetPiece(Grid.GetColumn(clickedBtn), Grid.GetRow(clickedBtn));
                }
                if (clickedBtn.Content == null && selectedPiece != null)
                {
                    var oldBtn = GetButton(selectedPiece.x, selectedPiece.y);
                    if (selectedPiece.Move(Grid.GetColumn(clickedBtn), Grid.GetRow(clickedBtn)))
                    {
                        oldBtn.Content = null;
                        clickedBtn.Content = GetPieceImg(selectedPiece.ToString().Split('.')[1]);
                        selectedPiece = null;
                    }
                }
            }
            catch{ }
        }
        private Image GetPieceImg(string name)
        {
            Image myImage3 = new Image();
            try
            {
                BitmapImage bi3 = new BitmapImage();
                bi3.BeginInit();
                switch (name)
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
            catch
            {
                MessageBox.Show("Error!");
            }

            return myImage3;
        }

        private Button GetButton(int x, int y)
        {
            foreach (Button btn in Board.Children)
            {
                if (Grid.GetRow(btn) == y && Grid.GetColumn(btn) == x)
                {
                    return btn;
                }
            }
            return null;
        }

        private void btnRemovePiece_Click(object sender, RoutedEventArgs e)
        {
             Dictionary<char, int> dict = new Dictionary<char, int>
            {
                {'A',1},
                {'B',2},
                {'C',3},
                {'D',4},
                {'E',5},
                {'F',6},
                {'G',7},
                {'H',8}
            };

            string delCords = tbCords.Text;
            int x = dict[delCords[0]];
            int y = Convert.ToInt32(Convert.ToString(delCords[1]));

            var delPiece = GetPiece(x,y);
            var delPieceBtn = GetButton(x, y);

            if (delPieceBtn.Content != null)
            {
                delPieceBtn.Content = null;
                pieces.Remove(delPiece);
            }
        }
        private Piece GetPiece(int x, int y)
        {
            Piece searchPiece = null;
            for(int i = 0; i < pieces.Count; i++)
            {
                if(pieces[i].x == x && pieces[i].y == y)
                {
                    searchPiece = pieces[i];
                }
            }
            return searchPiece;
        }
    }
}
