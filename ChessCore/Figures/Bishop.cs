//Saifullin Bulat 220 P Chess_4 task: 15.06.2022
using System;
namespace Chess4WPF
{
    class Bishop : Piece
    {
        public Bishop(string cords) : base(cords) { }
        public Bishop(int x, int y) : base(x, y) { }

        protected override bool IsRightMove(int x1, int y1)
        {
            return Math.Abs(this.x - x1) == Math.Abs(this.y - y1);
        }
    }
}
