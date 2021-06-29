using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лаб_2__полиморфизм_
{
    abstract class Figure
    {
        int x, y;
        public int X { get { return x; } set { if (Math.Abs(x) <= 8) x = value; else x = 0; } }
        public int Y { get { return y; } set { if (Math.Abs(y) <= 8) y = value; else y = 0; } }
        abstract public double S { get; set; }
        public Figure(int x, int y)
        {
            X = x;
            Y = y;
        }
        public void MoveTo(int newX, int newY)
        {
            X = newX;
            Y = newY;
        }
        public void MoveRel(int dx, int dy)
        {
            X += dx;
            Y += dy;
        }
        
        abstract public bool Equal(Figure f);
        abstract public bool Crossing(Figure f);
        abstract public bool ZeroIn();
        abstract public new string ToString();
        

    }
}
