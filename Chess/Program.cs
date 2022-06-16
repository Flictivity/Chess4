//Saifullin Bulat 220 P Chess_4 task: 15.06.2022
using System;
namespace Chess_4
{
    class Program
    {
        public static void Main()
        {
            string chess = Console.ReadLine();
            string startCords = Console.ReadLine();
            string MoveCords = Console.ReadLine();

            try
            {
                var piece = PieceFabric.Make(chess, startCords);
                piece.Move(MoveCords);
                piece.Print();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
