//Saifullin Bulat 220 P Chess_4 task: 15.06.2022
using System;
namespace Chess4WPF
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
