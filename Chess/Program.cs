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
            int x = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());
            int x1 = int.Parse(Console.ReadLine());
            int y1 = int.Parse(Console.ReadLine());

            try
            {
                var piece = PieceFabric.Make(new PieceData
                {
                    Name = chess,
                    Data = new Dictionary<string, int>
                                                {
                                                    { "X",x },
                                                    { "Y", y}
                                                }
                });
                piece.Move(x1,y1);
                piece.Print();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
