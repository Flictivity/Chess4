//Saifullin Bulat 220 P Chess_4 task: 15.06.2022
using System;
using System.Collections.Generic;

namespace Chess4WPF
{
    class Program
    {
        public static void Main()
        {
            string chess = Console.ReadLine();
            //int x = Console.ReadLine();
            //int y = Console.ReadLine();
            //int x1 = Console.ReadLine();
            //int x2 = Console.ReadLine();
            string startCords = Console.ReadLine();
            string moveCords = Console.ReadLine();

            try
            {
                var piece = PieceFabric.Make(chess, startCords);
                Console.WriteLine(piece.Move(moveCords) ? "YES" : "NO");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
