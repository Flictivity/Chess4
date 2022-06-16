//Saifullin Bulat 220 P Chess_4 task: 15.06.2022
using System;
using System.Collections.Generic;

namespace Chess_4
{
    public class PieceData
    {
        public string Name;
        public Dictionary<string, string> Data;

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
                case "Q":
                    piece = new Queen(p.Data["Cords"]);
                    break;

                case "P":
                    piece = new Pawn(p.Data["Cords"]);
                    break;

                case "R":
                    piece = new Rook(p.Data["Cords"]);
                    break;

                case "N":
                    piece = new Knight(p.Data["Cords"]);
                    break;

                case "K":
                    piece = new King(p.Data["Cords"]);
                    break;

                case "B":
                    piece = new Bishop(p.Data["Cords"]);
                    break;

                default: throw new Exception("Wrong piece name");
            }

            return piece;
        }
    }

}
