using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PacMan
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isPlaying = true;
            int pacmanX = 0, pacmanY = 0;
            int pacmanDX = 0, pacmanDY = 1;
            int allDots = 0, collectDots = 0;
            Console.CursorVisible = false;
            char[,] map = ReadMap("map1", ref pacmanX, ref pacmanY, ref allDots);
            DrawMap(map);

            while (isPlaying)
            {
                Console.SetCursorPosition(0,15);
                Console.WriteLine($"Вы собрали {collectDots}/{allDots}");
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    ChangeDirection(key, ref pacmanDX, ref pacmanDY);
                }
                if (map[pacmanX + pacmanDX, pacmanY + pacmanDY] != '#')
                {
                    Move(ref pacmanX, ref pacmanY, pacmanDX, pacmanDY);
                    CollectDots(map,pacmanX,pacmanY,ref collectDots);
                }
                System.Threading.Thread.Sleep(110);
                if(collectDots == allDots)
                {
                    isPlaying = false;
                }
            }
            if (isPlaying == false)
            {
                Console.SetCursorPosition(20, 20);
                Console.WriteLine("ВЫ ПОБЕДИЛИ!");
            }
        }

        static void CollectDots(char[,] map, int pacmanX, int pacmanY, ref int collectDots)
        {
            if (map[pacmanX, pacmanY] == '.')
            {
                collectDots++;
                map[pacmanX, pacmanY] = ' ';
            }
        }
        
        static void Move(ref int X, ref int Y, int DX, int DY)
        {
            Console.SetCursorPosition(Y, X);
            Console.Write(' ');
            X += DX;
            Y += DY;
            Console.SetCursorPosition(Y, X);
            Console.Write('@');
        }

        static void ChangeDirection(ConsoleKeyInfo key, ref int DX, ref int DY)
        {
            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    DX = -1; DY = 0;
                    break;
                case ConsoleKey.DownArrow:
                    DX = 1; DY = 0;
                    break;
                case ConsoleKey.LeftArrow:
                    DX = 0; DY = -1;
                    break;
                case ConsoleKey.RightArrow:
                    DX = 0; DY = 1;
                    break;
            }
        }

        static void DrawMap(char[,] map)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(map[i,j]);
                }
                Console.WriteLine();
            }
        }

        static char[,] ReadMap(string mapName, ref int pacmanX, ref int pacmanY, ref int allDots)
        {
            string[] newFile = File.ReadAllLines($"maps/{mapName}.txt");
            char[,] map = new char[newFile.Length,newFile[0].Length];

            for (int i = 0 ; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    map[i, j] = newFile[i][j];
                    if (map[i,j] == '@')
                    {
                        pacmanX = i;
                        pacmanY = j;
                    }
                    if (map[i, j] == ' ')
                    {
                        map[i, j] = '.';
                        allDots++;
                    }
                }
            }
            return map;
        }
    }
}
