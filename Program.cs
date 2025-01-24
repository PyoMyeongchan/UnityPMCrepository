using System.ComponentModel;
using System.Numerics;

namespace L20250124
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //[][][][][][][][][][]
            //[][][][][][][][][][]
            //[][][][][][][][][][]
            //[][][][][][][][][][]

            char wall = '*';
            char floor = ' ';
            int playerX = 1;
            int playerY = 1;



            int[,] map =               {
                    { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                    { 1, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                    { 1, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                    { 1, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                    { 1, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                    { 1, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                    { 1, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                    { 1, 0, 0, 0, 0, 0, 0, 4, 0, 1 },
                    { 1, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
                    { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }
            };

            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey();

                Console.Clear();

                //process update
                if (keyInfo.Key == ConsoleKey.W)
                {
                    playerY--;
                }
                else if (keyInfo.Key == ConsoleKey.S)
                {
                    playerY++;
                }
                else if (keyInfo.Key == ConsoleKey.A)
                {
                    playerX--;
                }
                else if (keyInfo.Key == ConsoleKey.D)
                {
                    playerX++;
                }


                //Draw Map -> Render
                for (int y = 0; y < 10; y++)
                {
                    for (int x = 0; x < 10; x++)
                    {
                        if (x == playerX && y == playerY)
                        {
                            Console.Write('P');
                        }
                        else if (map[y, x] == 1)
                        {
                            Console.Write(wall);
                        }
                        else if (map[y, x] == 0)
                        {
                            Console.Write(floor);
                        }
                        else if (map[y, x] == 4)
                        {
                            Console.Write('M');
                        }
                    }
                    Console.Write('\n');
                }
            }

        }
    }
}

