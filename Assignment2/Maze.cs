using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    public class Maze
    {
        public String pathTofollow = "";
        private Point startingPoint;
        private Point point;
        public char[][] maze;
        public int ColumnLength { get; private set; }
        public int RowLength { get; private set; }
        private int row;
        private int column;
        private string result;
        private Stack<Point> reversedStack = null;
        Stack<Point> stack = new Stack<Point>();
        private Stack<Point> reverseCloned;
        Queue<Point> queue = new Queue<Point>();
        Point currentPoint;
        Point exitPoint;

        public Maze(String filename)
        {
            readMazeFile(filename);

        }

        public Maze(int startingRow, int startingColumn, char[][] existingMaze)
        {

            if (startingRow < 0 || startingColumn < 0 || startingRow >= existingMaze.Length
                || startingColumn >= existingMaze[0].Length)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                this.RowLength = existingMaze.Length;
                this.startingPoint = new Point(startingRow, startingColumn);
                this.maze = existingMaze;
                this.ColumnLength = existingMaze[0].Length;
                row = startingPoint.Row;
                column = startingPoint.Column;
                pathTofollow = "Path to follow from Start [" + row + ", " + column + "] to Exit [";

            }
        }

        public void readMazeFile(string mazeFileName)
        {
            try
            {
                //Pass the file path and file name to the StreamReader constructor
                //StreamReader streamReader = new StreamReader(mazeFileName);
                String[] lineArray = File.ReadAllLines(mazeFileName);
                String firstRow = lineArray[0];
                String[] columnRows = firstRow.Split();
                int rows = int.Parse(columnRows.First());
                int columns = int.Parse(columnRows[1]);
                this.RowLength = rows;
                this.ColumnLength = columns;
                // throwing invalid rank specifier error
                maze = new char[rows][];
                String[] startingPoints = lineArray[1].Split();

                startingPoint = new Point(int.Parse(startingPoints.First()), int.Parse(startingPoints[1]));
                row = startingPoint.Row;
                column = startingPoint.Column;
                pathTofollow = "Path to follow from Start [" + row + ", " + column + "] to Exit [";

                // Access one line at a time
                for (int y = 2; y < lineArray.Count(); y++)
                {
                    maze[y - 2] = new char[columns];
                    string line = lineArray[y];

                    // Access each character in the file
                    for (int x = 0; x < line.Count(); x++)
                    {
                        //char c = line[x];
                        this.maze[y - 2][x] = line[x];
                    }
                }
                Console.WriteLine("Maze has generated.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }

        public Point GetStartingPoint()
        {
            return this.startingPoint;
        }

        public char[][] GetMaze()
        {
            return this.maze;
        }

        public String PrintMaze()
        {
            String printedmaze = "";
            for (int i = 0; i < maze.Length; i++)
            {
                for (int j = 0; j < maze[i].Length; j++)
                {
                    printedmaze += (maze[i][j]);
                }
                if (i != (maze.Length - 1))
                {
                    printedmaze += "\n";
                }
            }
            return printedmaze;
        }

        public string DepthFirstSearch()
        {

            //Point point;
            //stack.Push(startingPoint);
            if (maze[row][column] == 'E')
            {
                Point point = new Point(row, column);
                stack.Push(point);
                reversedStack = new Stack<Point>();
                Stack<Point> cloned = (Stack<Point>)stack.Clone();
                Point start = null;

                pathTofollow += row + ", " + column + "] - " + (stack.count - 1) + " steps:\n";

                while (stack.GetSize() > 0)
                {
                    if (maze[stack.Top().Row][stack.Top().Column] != 'E')
                    {
                        maze[stack.Top().Row][stack.Top().Column] = '.';
                    }
                    start = cloned.Pop();
                    reversedStack.Push(start);
                    stack.Pop();
                }

                reverseCloned = (Stack<Point>)reversedStack.Clone();
                while (!reversedStack.IsEmpty())
                {
                    if (reversedStack.count != 1)
                    {
                        pathTofollow += reversedStack.GetHead().GetElement() + "\n";
                    }
                    reversedStack.Head = reversedStack.Head.GetNext();
                    reversedStack.count--;
                }

                result = pathTofollow + PrintMaze();

            }
            else
            {
                if (maze[row][column] != 'V')
                {
                    point = new Point(row, column);
                    stack.Push(point);
                    maze[row][column] = 'V';
                    DepthFirstSearch();
                }
                else
                {

                    if (maze[row + 1][column] == ' ' || maze[row + 1][column] == 'E')
                    {
                        row = row + 1;
                        RecursiveCall(row, column);

                    }
                    else if (maze[row][column + 1] == ' ' || maze[row][column + 1] == 'E')
                    {
                        column = column + 1;
                        RecursiveCall(row, column);

                    }
                    else if (maze[row][column - 1] == ' ' || maze[row][column - 1] == 'E')
                    {
                        column = column - 1;
                        RecursiveCall(row, column);

                    }
                    else if (maze[row - 1][column] == ' ' || maze[row - 1][column] == 'E')
                    {
                        row = row - 1;
                        RecursiveCall(row, column);

                    }
                    else
                    {
                        stack.Pop();
                        if (!stack.IsEmpty())
                        {
                            point = stack.Top();
                            row = point.Row;
                            column = point.Column;
                            DepthFirstSearch();
                        }
                        else
                        {
                            reverseCloned = new Stack<Point>();
                            result = "No exit found in maze!\n\n" + PrintMaze();
                        }

                    }
                }

            }

            return result;
        }

        private void RecursiveCall(int row, int column)
        {
            point = new Point(row, column);
            stack.Push(point);
            if (maze[row][column] != 'E')
            {
                maze[row][column] = 'V';
            }
            DepthFirstSearch();
        }

        public Stack<Point> GetPathToFollow()
        {
            if (reverseCloned == null)
            {
                throw new ApplicationException();
            }
            return reverseCloned;
        }

        public string BreadthFirstSearch()
        {
            String result = "";

            if (getPath() == null)
            {
            }
            else
            {

            }
            return result;
        }

        private Point getPath()
        {
            queue.Enqueue(new Point(startingPoint.Row, startingPoint.Column));

            while (queue.GetSize() != 0)
            {
                currentPoint = queue.Dequeue();

                if (maze[currentPoint.Row][currentPoint.Column] == 'E')
                {
                    exitPoint = currentPoint;
                    return exitPoint;
                }
                else
                {
                    maze[currentPoint.Row][currentPoint.Column] = 'V';

                    if (Test(currentPoint.Row + 1, currentPoint.Column))
                    {
                        queue.Enqueue(new Point(currentPoint.Row + 1, currentPoint.Column));
                    }
                    // going east
                    if (Test(currentPoint.Row, currentPoint.Column + 1))
                    {
                        queue.Enqueue(new Point(currentPoint.Row, currentPoint.Column + 1));
                    }
                    //going west
                    if (Test(currentPoint.Row, currentPoint.Column - 1))
                    {
                        queue.Enqueue(new Point(currentPoint.Row, currentPoint.Column - 1));
                    }
                    //going north
                    if (Test(currentPoint.Row - 1, currentPoint.Column))
                    {
                        queue.Enqueue(new Point(currentPoint.Row - 1, currentPoint.Column));
                    }
                   
                }
                
            }
            return null;
        }

        public Boolean Test(int row, int column)
        {

            if ((row >= 0 && column >= 0 && (maze[row][column] == ' ' || maze[row][column] == 'E')))
            {
                return true;
            }
            return false;
        }
    
    }
}

