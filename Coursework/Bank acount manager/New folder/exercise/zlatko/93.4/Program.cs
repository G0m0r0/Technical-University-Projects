using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _93._4
{
    //page 93 exercise 3
    //maze, mouse, cheese
    //backtracking
    class Program
    {
        static char[,] maze;
        static List<char> path = new List<char>();
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.Write("Enter size of maze nXn: ");
            int n = int.Parse(Console.ReadLine());
            maze = new char[n, n];
            int xMouse = 0;
            int yMouse = 0;

            InitializeMaze(maze);

            PrintMaze(maze);

            SetMouseAndCheese(maze, ref xMouse, ref yMouse);

            FindAllPaths(xMouse, yMouse, ' ');
        }

        private static void FindAllPaths(int x, int y, char direction)
        {
            if (OutSideMaze(x, y))
            {
                return;
            }

            path.Add(direction);

            if (IsCheese(x, y))
            {
                Console.WriteLine(string.Join(string.Empty,path.Skip(1)));
            }
            else if (IsPassable(x, y))
            {
                maze[x, y] = 'x';
                FindAllPaths(x + 1, y, 'D'); //Down
                FindAllPaths(x - 1, y, 'U'); //Up
                FindAllPaths(x, y + 1, 'R'); //Right
                FindAllPaths(x, y - 1, 'L'); //Left

                maze[x, y] = ' ';
            }
            path.RemoveAt(path.Count - 1);
        }

        private static bool IsPassable(int x, int y)
        {
            if (maze[x, y] == 'x')
            {
                return false;
            }

            if (maze[x, y] == '◻')
            {
                return false;
            }

            return true;
        }

        private static bool IsCheese(int x, int y)
        {
            return maze[x, y] == 'C';
        }

        private static bool OutSideMaze(int x, int y)
        {
            if (x < 0 || x >= maze.GetLength(0))
            {
                return true;
            }

            if (y < 0 || y >= maze.GetLength(0))
            {
                return true;
            }

            return false;
        }

        private static void SetMouseAndCheese(char[,] maze,ref int xMouse,ref int yMouse)
        {
            while (true)
            {
                Console.WriteLine("Choose empty space to place mouse");
                Console.Write("X= ");
                xMouse = int.Parse(Console.ReadLine()) - 1;
                Console.Write("Y= ");
                yMouse = int.Parse(Console.ReadLine()) - 1;

                if (maze[xMouse, yMouse] == '◻')
                    Console.WriteLine("This is wall, place mouse on empty place!");
                else
                {
                    maze[xMouse, yMouse] = 'M';
                    PrintMaze(maze);
                    break;
                }
            }

            while (true)
            {
                Console.WriteLine("Choose empty space to place cheese");
                Console.Write("X= ");
                int xCheese = int.Parse(Console.ReadLine()) - 1;
                Console.Write("Y= ");
                int yCheese = int.Parse(Console.ReadLine()) - 1;

                if (maze[xCheese, yCheese] == '◻')
                    Console.WriteLine("This is wall, place cheese on empty place!");
                else
                {
                    maze[xCheese, yCheese] = 'C';
                    PrintMaze(maze);
                    break;
                }
            }
        }

        private static void PrintMaze(char[,] maze)
        {
            Console.Write(" ");
            for (int i = 1; i <= maze.GetLength(0); i++)
            {
                Console.Write(i);
            }
            Console.WriteLine();
            for (int i = 0; i < maze.GetLength(0); i++)
            {
                Console.Write($"{i+1}");
                for (int j = 0; j < maze.GetLength(0); j++)
                {
                    Console.Write(maze[i, j]);
                }
                Console.WriteLine();
            }
        }

        private static void InitializeMaze(char[,] maze)
        {
            for (int i = 0; i < maze.GetLength(0); i++)
            {
                for (int j = 0; j < maze.GetLength(0); j++)
                {
                    Random rnd = new Random();
                    int next = rnd.Next(0, 2);
                    if (next == 1)
                        maze[i, j] = '◻';
                    else
                        maze[i, j] = ' ';
                }
            }
        }
    }
}
