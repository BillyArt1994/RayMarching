using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_RayRender
{
    public class Vector2
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Vector2 (double x, double y )
        {
            this.X = x;
            this.Y = y;
        }

        public double Lenght
        {
            get
            {
                return Math.Sqrt(X * X + Y * Y);
            }
        }

        private static Vector2 Division(Vector2 a, double b)
        {
            return new Vector2(a.X / b, a.Y / b);
        }

        private static Vector2 Division(Vector2 a, Vector2 b)
        {
            return new Vector2(a.X / b.X, a.Y / b.Y);
        }

        private static Vector2 Subtraction (Vector2 a ,Vector2 b)
        {
            return new Vector2(a.X - b.X,a.Y - b.Y);
        }

        private static Vector2 Subtraction(Vector2 a, double b)
        {
            return new Vector2(a.X - b, a.Y - b);
        }

        private static Vector2 plus ( Vector2 a,Vector2 b )
        {
            return new Vector2(a.X + b.X,a.Y + b.Y);
        }

        private static Vector2 plus ( Vector2 a,double b )
        {
            return new Vector2(a.X+b,a.Y+b);
        }

        private static Vector2 multiply (Vector2 a,double b )
        {
            return new Vector2(a.X * b,a.Y * b);
        }

        public static Vector2 operator - ( Vector2 a,Vector2 b )
        {
            return Vector2.Subtraction(a,b);
        }
        public static Vector2 operator -(Vector2 a, double b)
        {
            return Vector2.Subtraction(a, b);
        }

        public static Vector2 operator + ( Vector2 a,Vector2 b )
        {
            return Vector2.plus(a,b);
        }

        public static Vector2 operator + ( Vector2 a,double b )
        {
            return Vector2.plus(a,b);
        }

        public static Vector2 operator * ( Vector2 a,double b )
        {
            return Vector2.multiply(a,b);
        }
        public static Vector2 operator /(Vector2 a, double b)
        {
            return Vector2.Division(a, b);
        }
        public static Vector2 operator /(Vector2 a, Vector2 b)
        {
            return Vector2.Division(a, b);
        }
    }
}
