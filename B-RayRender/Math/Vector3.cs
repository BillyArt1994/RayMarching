using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_RayRender
{
    public class Vector3
    {
        private double x;
        private double y;
        private double z;

        public double X
        {
            get
            {
                return x;
            }

            set
            {
                x = value;
            }
        }

        public double Y
        {
            get
            {
                return y;
            }

            set
            {
                y = value;
            }
        }

        public double Z
        {
            get
            {
                return z;
            }

            set
            {
                z = value;
            }
        }

        public Vector2 XY
        {
            get
            {
                return new Vector2(X, Y);
            }
        }

        public Vector2 XZ
        {
            get
            {
                return new Vector2(X, Z);
            }
        }

        public double Lenght
        {
            get
            {
                return Math.Sqrt(X * X + Y * Y + Z * Z);
            }
        }

        public Vector3()
        {

        }

        public Vector3(double a)
        {
            this.X = a;
            this.Y = a;
            this.Z = a;
        }


        public Vector3(Vector3 a)
        {
            this.X = a.X;
            this.Y = a.Y;
            this.Z = a.Z;
        }

        public Vector3(double x, double y, double z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public Vector3( Vector2 a,double b)
        {
            this.X = a.X;
            this.Y = a.Y;
            this.Z = b;
        }

        private static Vector3 Plus(Vector3 a, Vector3 b)
        {
            return new Vector3(a.x + b.x, a.y + b.y, a.z + b.z);
        }

        private static Vector3 Subtraction(Vector3 a, Vector3 b)
        {
            return new Vector3(a.x - b.x, a.y - b.y, a.z - b.z);
        }

        private static Vector3 Division(Vector3 a, double b)
        {
            return new Vector3(a.x / b, a.y / b, a.z / b);
        }

        private static Vector3 Multiply(Vector3 a, double b)
        {
            return new Vector3(a.x * b, a.y * b, a.z * b);
        }

        private static Vector3 Multiply(Vector3 a, Vector3 b)
        {
            return new Vector3(a.x * b.x, a.y * b.y, a.z * b.z);
        }

        public static Vector3 operator +(Vector3 a, Vector3 b)
        {
            return Vector3.Plus(a, b);
        }
        public static Vector3 operator +(Vector3 a, double b)
        {
            return Vector3.Plus(a, new Vector3 (b,b,b));
        }

        public static Vector3 operator -(Vector3 a, Vector3 b)
        {
            return Vector3.Subtraction(a, b);
        }

        public static Vector3 operator *(Vector3 a, double b)
        {
            return Vector3.Multiply(a, b);
        }

        public static Vector3 operator *(Vector3 a, Vector3 b)
        {
            return Vector3.Multiply(a, b);
        }

        public static Vector3 operator /(Vector3 a, double b)
        {
            return Vector3.Division(a, b);
        }

        public static bool operator <(Vector3 a, double b)
        {
            if (Math.Max(Math.Max(a.X,a.Y),a.Z)<b)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator >(Vector3 a, double b)
        {
            if (Math.Min(Math.Min(a.X, a.Y), a.Z) > b)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator <=(Vector3 a, double b)
        {
            if (Math.Max(Math.Max(a.X, a.Y), a.Z) < b || a.x*3 ==b)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator >=(Vector3 a, double b)
        {
            if (Math.Min(Math.Min(a.X, a.Y), a.Z) > b || a.x * 3 == b)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
