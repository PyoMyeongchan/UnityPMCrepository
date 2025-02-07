using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace L20250203
{
    internal class Program
    {
        //static 반환형 함수명(자료형 인자1, 자료형 인자2,.....)
        //{
        //    return 자료 반환;
        //}

        //숫자 두개 입력 받고 곱한 결과 리턴 함수
        static string Eat(string fruit)
        {
            return fruit + "을/를 먹다";
        }

        static float Multiply(float number1, float number2)
        {
            return number1 * number2;
        }

        static int Multiply(int number1, int number2)
        {
            return number1 * number2;
        }

        static float ApplyDamage(float damage)
        {
            return 1.0f;
        }

        static char wall = '*';
        static char floor = ' ';
        static int playerX = 1;
        static int playerY = 1;



        static int[,] map =               {
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
        static ConsoleKeyInfo keyInfo;

        static bool IsRunning = true;
        static void Main(string[] args)
        {
            while (IsRunning)
            {
                Input();
                Update();
                Render();
            }

            Console.Clear();
            Console.WriteLine("Game over");
        }

        private static void Render()
        {
            Console.Clear();

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

        private static void Update()
        {
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
            else if (keyInfo.Key == ConsoleKey.Escape)
            {
                IsRunning = false;
            }
        }

        private static void Input()
        {
            keyInfo = Console.ReadKey();
        }
    }
}
