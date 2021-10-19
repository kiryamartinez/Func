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
            bool isAlive = true;
            int pacmanX = 0, pacmanY = 0;
            int pacmanDX = 0, pacmanDY = 1;
            int ghostX = 0, ghostY = 0;
            int ghostDX = 0, ghostDY = -1;
            int allDots = 0, collectDots = 0;
            Console.CursorVisible = false;
            char[,] map = ReadMap("map1", ref pacmanX, ref pacmanY, ref allDots,ref ghostX, ref ghostY);
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
                    CollectDots(map, pacmanX, pacmanY, ref collectDots);
                    Move(map,'@', ref pacmanX, ref pacmanY, pacmanDX, pacmanDY);
                }
                if (map[ghostX + ghostDX, ghostY + ghostDY] != '#')
                {
                    Move(map, 'W', ref ghostX, ref ghostY, ghostDX, ghostDY);
                }
                else
                {
                    ChangeDirection(ref ghostDX, ref ghostDY);
                }
                System.Threading.Thread.Sleep(100);
                if (pacmanX == ghostX && pacmanY == ghostY)
                {
                    isAlive = false;
                }
                if(collectDots == allDots || !isAlive)
                {
                    isPlaying = false;
                }
            }
            if (collectDots == allDots)
            {
                Console.SetCursorPosition(20, 20);
                Console.WriteLine("ВЫ ПОБЕДИЛИ!");
            }
            else if (!isAlive)
            {
                Console.SetCursorPosition(20, 20);
                Console.WriteLine("ВЫ ПОГИБЛИ!");
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
        static void Move(char[,] map,char symbol, ref int X, ref int Y, int DX, int DY)
        {
            Console.SetCursorPosition(Y, X);
            Console.Write(map[X,Y]);
            X += DX;
            Y += DY;
            Console.SetCursorPosition(Y, X);
            Console.Write(symbol);
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
        static void ChangeDirection(ref int DX, ref int DY)
        {
            Random random = new Random();
            int ghostDir = random.Next(1, 5);
            switch (ghostDir)
            {
                case 1:
                    DX = -1; DY = 0;
                    break;
                case 2:
                    DX = 1; DY = 0;
                    break;
                case 3:
                    DX = 0; DY = -1;
                    break;
                case 4:
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
        static char[,] ReadMap(string mapName, ref int pacmanX, ref int pacmanY, ref int allDots,ref int ghostX, ref int ghostY)
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
                        map[i, j] = '.';
                    }
                    if (map[i,j] == 'W')
                    {
                        ghostX = i;
                        ghostY = j;
                        map[i, j] = '.';
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
