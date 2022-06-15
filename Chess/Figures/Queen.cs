//Saifullin Bulat 220 P Chess_3 task: 15.04.2022
using System;
namespace Chess_3
{
    internal class Queen : Piece
    {
        public Queen(string coords) : base(coords) { }
        public Queen(int x, int y) : base(x, y) { }

        protected override bool IsRightMove(int x1, int y1)
        {
            return (this.x == x1 || this.y == y1)
                || (Math.Abs(this.x - x1) == Math.Abs(this.y - y1));
        }
    }
}
