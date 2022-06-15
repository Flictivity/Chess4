//Sharipov Kamil 220 P Chess_3 task: 15.04.2022
using System;
namespace Chess_3
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
