using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_RayRender
{
    public static class MyMath
    {
        /// <summary>
        /// 三角函数获得cosθ值
        /// </summary>
        /// <param name="a">角度</param>
        /// <returns></returns>
        public static double Cos (double a)
        {

            return Math.Cos(a / 180 * Math.PI);
        }

        /// <summary>
        /// 三角函数获得sinθ值
        /// </summary>
        /// <param name="a">角度</param>
        /// <returns></returns>
        public static double Sin ( double a )
        {

            return Math.Sin(a / 180 * Math.PI);
        }

        /// <summary>
        /// 三角函数获得tanθ值
        /// </summary>
        /// <param name="a">角度</param>
        /// <returns></returns>
        public static double Tan ( double a )
        {

            return Math.Tan(a / 180 * Math.PI);
        }

        /// <summary>
        /// 三维向量点乘
        /// </summary>
        /// <param name="a">向量a</param>
        /// <param name="b">向量b</param>
        /// <returns></returns>
        public static double Dot (Vector3 a,Vector3 b)
        {
            return a.X * b.X + a.Y * b.Y + a.Z * b.Z;
        }

        /// <summary>
        /// 四维向量点乘
        /// </summary>
        /// <param name="a">向量a</param>
        /// <param name="b">向量b</param>
        /// <returns></returns>
        public static double Dot ( Vector4 a,Vector4 b )
        {
            return a.X * b.X + a.Y * b.Y + a.Z * b.Z+a.W*b.W;
        }

        /// <summary>
        /// 向量归一化
        /// </summary>
        /// <param name="a">三维向量</param>
        /// <returns>归一化后的向量</returns>
        public static Vector3 Normalize(Vector3 a)
        {
            double value = a.X * a.X + a.Y * a.Y + a.Z * a.Z;
            if ( value == 0 )
            {
                return new Vector3(0,0,0);
            }
            else {
                return a / (Math.Sqrt(value));
            }
        }

        /// <summary>
        /// 输入两个三维向量a和b返回两个向量之间的距离
        /// </summary>
        /// <param name="a">向量a</param>
        /// <param name="b">向量b</param>
        /// <returns></returns>
        public static double Distance (Vector3 a , Vector3 b)
        {
            return Math.Sqrt((a.X - b.X) * (a.X - b.X) + (a.Z - b.Z) * (a.Z - b.Z) + (a.Y - b.Y) * (a.Y - b.Y)); 
        }

        /// <summary>
        /// 输入一个数,限制其最小值与最大值
        /// </summary>
        /// <param name="a">浮点数</param>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <returns></returns>
        public static double Clamp(double a, double min,double max )
        {
            double value = a;
            if (value < min)
            {
                value = min;
            }
            else if (value > max)
            {
                value = max;
            }

            return value;
        }

        /// <summary>
        /// 输入一个三维向量限制其各个分量最大值与最小值
        /// </summary>
        /// <param name="a">三维向量</param>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <returns></returns>
        public static Vector3 Clamp(Vector3 a, double min, double max)
        {
            a.X =Clamp(a.X, min, max);
            a.Y =Clamp(a.Y, min, max);
            a.Z =Clamp(a.Z, min, max);
            return a;
        }

        public static Vector3 Abs(Vector3 a)
        {
            a.X = Math.Abs(a.X);
            a.Y = Math.Abs(a.Y);
            a.Z = Math.Abs(a.Z);
            return a;
        }

        public static Vector3 Max (Vector3 a , double b)
        {
            a.X = Math.Max(a.X,b);
            a.Y = Math.Max(a.Y,b);
            a.Z = Math.Max(a.Z,b);
            return a;
        }

        public static Vector3 Max(Vector3 a, Vector3 b)
        {
            a.X = Math.Max(a.X, b.X);
            a.Y = Math.Max(a.Y, b.Y);
            a.Z = Math.Max(a.Z, b.Z);
            return a;
        }

        public static Vector3 Lerp (Vector3 a , Vector3 b, double value)
        {

            return a * (1 - value) + b * value;
        }

        public static double Lerp(double a, double b, double value)
        {

            return a * (1 - value) + b * value;
        }

        public static Vector3 Pow (Vector3 a,double b)
        {
            return new Vector3(Math.Pow(a.X, b), Math.Pow(a.Y, b), Math.Pow(a.Z, b));
        }
    }
}
