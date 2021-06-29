using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лаб_2__полиморфизм_
{
    class Square : Figure
    {
        double side;
        public double Side 
        { 
            get { return side; } 
            set { if (value >= 0) side = value; else side = 1; } 
        }
        public Square(int x, int y, double s) : base(x, y)
        {
            S = s;
        }
        public override double S 
        {
            get { return side * side; }
            set { if (value >= 0 && value <= 100) side = Math.Sqrt(value); else side = 1; }
        }
        public override bool Equal(Figure f)
        {
            if(f is Square)
            {
                return X == f.X && Y == f.Y && S == f.S;
            }
            return false;
        }
        public override bool Crossing(Figure f)
        {
            if (f is Point)
            {
                return f.X <= X + Side / 2 && f.X >= X - Side / 2 && f.Y >= Y - Side / 2 && f.Y <= Y + Side / 2;
            }
            else
            {
                if (f is Circle)
                {
                    Circle circle = f as Circle;
                    double x = Math.Abs(circle.X - X);
                    double y = Math.Abs(circle.Y - Y);

                    if (x > (Side / 2 + circle.R))
                        return false;
                    if (y > (Side / 2 + circle.R))
                        return false;
                    if (x <= Side / 2)
                        return true;
                    if (y <= Side / 2)
                        return true;
                    double dd = Math.Pow(x - Side / 2, 2) +
                                         Math.Pow(y - Side / 2, 2);
                    return dd <= (circle.R * circle.R);
                }
                else
                {
                    if (f is Square)
                    {
                        if (Math.Abs(f.X - X) <= Side / 2 + ((Square)f).Side / 2 && Math.Abs(f.Y - Y) <= Side / 2 + ((Square)f).Side / 2)
                            return true;
                        else return false;
                    }
                    else
                    {
                        return f.Crossing(this);
                    }
                }
            }
        }
        public override bool ZeroIn()
        {
            return Crossing(new Point(0, 0));
        }
        public override string ToString()
        {
            return String.Format($"Квадрат, координаты: ({X},{Y}), площадь: {S}, перечение с (0,0): {ZeroIn()}, сторона: {Side:f3}");
        }
    }
}
