using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лаб_2__полиморфизм_
{
    class Circle: Figure
    {
        double r;
        public double R 
        { 
            get { return r; } 
            set 
            {
                if (value >= 0)
                    r = value;
                else r = 1;
            }  
        }

        public Circle(int x, int y, double s): base(x, y)
        {
            S = s;
        }

        public override double S 
        { 
            get 
            { 
                return r * r * Math.PI; 
            } 
            set 
            { 
                if (value >= 0 && value <= 100)
                    r = Math.Sqrt(value / Math.PI);
                else r = 1; 
            } 
        }

        public override bool Equal(Figure f)
        {
            if (f is Circle)
            {
                return X == f.X && Y == f.Y && S == f.S;
            }
            return false;
        }

        public override bool Crossing(Figure f)
        {
            if (f is Point)
            {
                return Math.Sqrt((f.X - X) * (f.X - X) + (f.Y - Y) * (f.Y - Y)) <= R;
            }
            else
            {
                if (f is Circle)
                {
                    return Math.Sqrt((f.X - X) * (f.X - X) + (f.Y - Y) * (f.Y - Y)) <= R + Math.Sqrt(f.S / Math.PI);
                }
                else
                {
                    return f.Crossing(this);
                }
            }
        }

        public override bool ZeroIn()
        {
            return Crossing(new Point(0, 0));
        }

        public override string ToString()
        {
            return String.Format("Круг, координаты: ({0},{1}), площадь: {2}, перечение с (0,0): {3}, радиус: {4:f3}",X,Y,S,ZeroIn(), R);
        }
    }
}
