//Saifullin Bulat 220 P Chess_3 task: 15.04.2022
using System;
using System.Collections.Generic;
namespace Chess_3
{
    class Piece
    {
        protected int x { set; get; }
        protected int y { set; get; }

        private Dictionary<char, int> dict = new Dictionary<char, int>
        {
            {'A',1},
            {'B',2},
            {'C',3},
            {'D',4},
            {'E',5},
            {'F',6},
            {'G',7},
            {'H',8}
        };

        private Dictionary<int, char> dict2 = new Dictionary<int, char>
        {
            {1,'A'},
            {2,'B'},
            {3,'C'},
            {4,'D'},
            {5,'E'},
            {6,'F'},
            {7,'G'},
            {8,'H'},
        };
        public Piece(string cords)
        {
            x = dict[cords[0]];
            y = int.Parse(Convert.ToString(cords[1]));
        }

        public Piece(int x1, int y1)
        {
            x = x1;
            y = y1;
        }

        protected virtual bool IsRightMove(int x1, int y1)
        {
            return false;
        }

        public void Move(string cordsToMove)
        {
            int x1 = dict[cordsToMove[0]];
            int y1 = int.Parse(cordsToMove[1].ToString());

            Move(x1, y1);
        }

        public void Move(int x1, int y1)
        {
            if (IsRightMove(x1, y1))
            {
                this.x = x1;
                this.y = y1;
            }
            else
            {
                throw new Exception("Can not move this coordinates!");
            }
        }

        public void Print()
        {
            Console.WriteLine($"Coordinats: {dict2[x]}{y}");
        }
    }

}