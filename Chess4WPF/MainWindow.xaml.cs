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
        private List<Piece> pieces;
        private Piece selectedPiece;

        public MainWindow()
        {
            InitializeComponent();

            piecesNames = new List<string> 
            {"Pawn", "Rook", "Bishop", "Knight", "Rook", "Queen"};
            
            PiecesList.ItemsSource = piecesNames;
            pieces = new List<Piece>();
        }

        private void btnAddPiece_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(tbCords.Text != "" && PiecesList.SelectedItem != null)
                {
                    var piece = PieceFabric.Make(PiecesList.Text, tbCords.Text);

                    var btn = GetButton(piece.x, GetRightCords(piece.y));
                    if (btn.Content == null)
                    {
                        btn.Content = GetPieceImg(PiecesList.Text);
                        pieces.Add(piece);
                    }
                    else
                    {
                        MessageBox.Show("This corrdinates not empty!");
                    }
                }
            }
            catch
            {
                MessageBox.Show("Wrong input params!");
            }
        }
        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var clickedBtn = (Button)sender;
                int x = Grid.GetColumn(clickedBtn);
                int y = Grid.GetRow(clickedBtn);

                if (clickedBtn.Content != null)
                {
                    ResetFields();
                    selectedPiece = GetPiece(x,GetRightCords(y));
                    GetMoveFields();
                }
                if (clickedBtn.Content == null && selectedPiece != null)
                {
                    var oldBtn = GetButton(selectedPiece.x,
                        GetRightCords(selectedPiece.y));

                    if (selectedPiece.Move(x, GetRightCords(y)))
                    {
                        oldBtn.Content = null;
                        clickedBtn.Content = GetPieceImg(selectedPiece.ToString().
                            Split('.')[1]);
                        selectedPiece = null;
                                            ResetFields();
                    }
                    return;
                }
            }
            catch{ }
        }
        private Image GetPieceImg(string name)
        {
            Image myImage3 = new Image();
            System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"PieceIcons\wP.png");

            try
            {
                BitmapImage bi3 = new BitmapImage();
                bi3.BeginInit();
                switch (name)
                {
                    case "Pawn":
                        bi3.UriSource = new Uri("pack://application:,,,/PieceIcons/wP.png");
                        break;
                    case "Knight":
                        bi3.UriSource = new Uri("pack://application:,,,/PieceIcons/wN.png");
                        break;
                    case "King":
                        bi3.UriSource = new Uri("pack://application:,,,/PieceIcons/wK.png");
                        break;
                    case "Bishop":
                        bi3.UriSource = new Uri("pack://application:,,,/PieceIcons/wB.png");
                        break;
                    case "Queen":
                        bi3.UriSource = new Uri("pack://application:,,,/PieceIcons/wQ.png");
                        break;
                    case "Rook":
                        bi3.UriSource = new Uri("pack://application:,,,/PieceIcons/wR.png");
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
            try
            {
                var delPiece = selectedPiece;
                var delPieceBtn = GetButton(selectedPiece.x,
                                GetRightCords(selectedPiece.y));

                if (delPieceBtn.Content != null)
                {
                    delPieceBtn.Content = null;
                    selectedPiece = null;
                    pieces.Remove(delPiece);
                    ResetFields();
                }
            }
            catch
            {
                MessageBox.Show("Select piece!");
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
        private int GetRightCords(int row)
        {
            return Math.Abs(row - 9);
        }

        private void GetMoveFields()
        {
            if(selectedPiece != null)
            {
                foreach (Button btn in Board.Children)
                {
                    int x = Grid.GetColumn(btn);
                    int y = GetRightCords(Grid.GetRow(btn));
                    if (btn.Content == null && selectedPiece.TestMove(x, y))
                    {
                        btn.Background = Brushes.Green;
                    }
                }
            }
        }
        private void ResetFields()
        {
            try
            {
                foreach (Button btn in Board.Children)
                {
                    int x = Grid.GetColumn(btn);
                    int y = GetRightCords(Grid.GetRow(btn));
                    btn.Background = (x + y) % 2 == 0 ? Brushes.Black : Brushes.White;
                }
            }
            catch
            { }
        }
    }
}
