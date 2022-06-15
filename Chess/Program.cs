//Saifullin Bulat 220 P Chess_3 task: 15.04.2022
using System;
namespace Chess_3
{
    class Program
    {
        public static void Main()
        {
            Knight knight = new Knight(1,1);
            knight.Print();
            knight.Move("B3");
            knight.Print();
            Console.WriteLine();

            Queen queen = new Queen("A1");
            queen.Print();
            queen.Move("B2");
            queen.Print();
            Console.WriteLine();

            Bishop bishop = new Bishop(4, 4);
            bishop.Print();
            bishop.Move(5,5);
            bishop.Print();
            Console.WriteLine();

            queen = new Queen("A1");
            queen.Print();
            queen.Move(3,3);
            queen.Print();
            Console.WriteLine();

            King king = new King("D4");
            king.Print();
            king.Move(5,5);
            king.Print();
            Console.WriteLine();

            Rook rook = new Rook(4,4);
            rook.Print();
            rook.Move("D5");
            rook.Print();
            Console.WriteLine();

            knight = new Knight("A1");
            knight.Print();
            knight.Move("H8");
            knight.Print();
            Console.WriteLine();
        }
    }
}
