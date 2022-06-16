//Saifullin Bulat 220 P Chess_4 task: 15.06.2022
using System;
using System.Collections.Generic;

namespace Chess4WPF
{
    public class PieceData
    {
        public string Name;
        public Dictionary<string, int> Data;

        public override string ToString()
        {
            return Name;
        }
    }
    static public class PieceFabric
    {
        static public Piece Make(PieceData p)
        {
            Piece piece = null;

            switch (p.Name)
            {
                case "Queen":
                case "Q":
                    piece = new Queen(p.Data["X"], p.Data["Y"]);
                    break;

                case "Pawn":
                case "P":
                    piece = new Pawn(p.Data["X"], p.Data["Y"]);
                    break;

                case "Rook":
                case "R":
                    piece = new Rook(p.Data["X"], p.Data["Y"]);
                    break;

                case "Knight":
                case "N":
                    piece = new Knight(p.Data["X"], p.Data["Y"]);
                    break;

                case "King":
                case "K":
                    piece = new King(p.Data["X"], p.Data["Y"]);
                    break;

                case "Bishop":
                case "B":
                    piece = new Bishop(p.Data["X"], p.Data["Y"]);
                    break;

                default: throw new Exception("Wrong piece name");
            }

            return piece;
        }
    }

}
