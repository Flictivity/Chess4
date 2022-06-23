//Saifullin Bulat 220 P Chess_4 task: 15.06.2022
using System;
using System.Collections.Generic;

namespace Chess4WPF
{
    static public class PieceFabric
    {
        private static Dictionary<char, int> pieceCordsConvert
            = new Dictionary<char, int>()
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
        static public Piece Make(string pieceName, int x, int y)
        {
            Piece piece = null;

            switch (pieceName)
            {
                case "Queen":
                case "Q":
                    piece = new Queen(x,y);
                    break;

                case "Pawn":
                case "P":
                    piece = new Pawn(x, y);
                    break;

                case "Rook":
                case "R":
                    piece = new Rook(x, y);
                    break;

                case "Knight":
                case "N":
                    piece = new Knight(x, y);
                    break;

                case "King":
                case "K":
                    piece = new King(x, y);
                    break;

                case "Bishop":
                case "B":
                    piece = new Bishop(x, y);
                    break;

                default: throw new Exception("Wrong piece name");
            }

            return piece;
        }
        public static Piece Make(string pieceName, string cords)
        {
            int x = pieceCordsConvert[cords[0]];
            int y = Convert.ToInt32(cords[1].ToString());
            return Make(pieceName, x, y);
        }
    }

}
