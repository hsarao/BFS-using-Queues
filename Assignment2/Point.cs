using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment2
{
    public class Point
    {
        public int Row { get; }
        public int Column { get; }

        public Point(int row, int column)
        {
            this.Row = row;
            this.Column = column;
        }

        //public int getRow()
        //{
        //    return this.row;
        //}

        //public int getColumn()
        //{
        //    return this.column;
        //}

        override
        public String ToString()
        {
            return "[" + Row.ToString() + ", " + Column.ToString() + "]";
        }
    }
}
