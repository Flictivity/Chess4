//Saifullin Bulat 220 P Chess_4 task: 15.06.2022
using System;
using System.Collections.Generic;

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
                var piece = PieceFabric.Make(new PieceData 
                                             { 
                                                Name = chess, 
                                                Data = new Dictionary<string,string>
                                                {
                                                    { "Cords", $"{startCords}" }
                                                }
                                             });
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
