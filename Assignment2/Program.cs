using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    class Program
    {
        static void Main(string[] args)
        {
            Maze test = new Maze("C:\\Users\\jslns\\Desktop\\JasleenDocs\\Bitterms\\term5\\Programming\\Assignment2\\Assignment2\\bin\\Debug\\simpleWithExit.maze");
            Console.WriteLine(test.PrintMaze());
            Console.WriteLine(test.DepthFirstSearch());
            
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}
