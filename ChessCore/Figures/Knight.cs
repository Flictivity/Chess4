//Saifullin Bulat 220 P Chess_4 task: 15.06.2022
using System;
namespace Chess_4
{
    class Knight : Piece
    {
        public Knight(int x, int y) : base(x, y) { }
        public Knight(string cords) : base(cords) { }
        protected override bool IsRightMove(int x1, int y1)
        {
            return ((Math.Abs(x - x1) == 2) && (Math.Abs(y - y1) == 1))
                || ((Math.Abs(x - x1) == 1) && (Math.Abs(y - y1) == 2));
        }
    }
}
