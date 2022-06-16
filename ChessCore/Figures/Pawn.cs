//Saifullin Bulat 220 P Chess_4 task: 15.06.2022
namespace Chess_4
{
    class Pawn : Piece
    {
        public Pawn(string coords) : base(coords) { }
        public Pawn(int newX, int newY) : base(newX, newY) { }

        protected override bool IsRightMove(int x1, int y1)
        {
            return ((this.x == x1 && this.y == 2 && this.y + 2 >= y1) ||
                    (this.x == x1 && this.y + 1 == y1));
        }
    }
}
