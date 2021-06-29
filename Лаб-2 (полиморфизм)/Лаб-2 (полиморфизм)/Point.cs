using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лаб_2__полиморфизм_
{
    class Point: Figure
    {
        public override double S { get { return 0; } set { } }
        public Point(int x, int y) : base(x, y) { }
        public override bool Equal(Figure f)
        {
            if (f is Point && f.X == X && f.Y == Y)
                return true;
            return false;
        }
        public override bool Crossing(Figure f)
        {
            if(f is Point)
            {
                return X == f.X && Y == f.Y;
            }
            else
            {
                return f.Crossing(this);
            }
        }
        public override bool ZeroIn()
        {
            return X == 0 && Y == 0;
        }
        public override string ToString()
        {
            return String.Format($"Точка. координаты: ({X}, {Y}), площадь: {S}, пересечение с (0,0): {ZeroIn()}");
        }
    }
}
