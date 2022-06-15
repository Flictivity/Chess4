//Saifullin Bulat 220 P Chess_3 task: 15.04.2022
using System;
namespace Chess_3
{
    class King : Piece
    {
        public King(string cords) : base(cords) { }
        public King(int x, int y) : base(x, y) { }
        protected override bool IsRightMove(int x1, int y1)
        {
            return Math.Abs(x1 - this.x) <= 1 && Math.Abs(y1 - this.y) <= 1;
        }
    }
}
