//Saifullin Bulat 220 P Chess_4 task: 15.06.2022
using System;
namespace Chess4WPF
{
    class Rook : Piece
    {
        public Rook(string cords) : base(cords) { }
        public Rook(int x, int y) : base(x, y) { }

        protected override bool IsRightMove(int x1, int y1)
        {
            return this.x == x1 || this.y == y1;
        }
    }
}
