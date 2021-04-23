using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_RayRender
{
    public class Vector4
    {
        private double _x;
        private double _y;
        private double _z;
        private double _w;

        public double X
        {
            get
            {
                return _x;
            }

            set
            {
                _x = value;
            }
        }

        public double Y
        {
            get
            {
                return _y;
            }

            set
            {
                _y = value;
            }
        }

        public double Z
        {
            get
            {
                return _z;
            }

            set
            {
                _z = value;
            }
        }

        public double W
        {
            get
            {
                return _w;
            }

            set
            {
                _w = value;
            }
        }

        public Vector3 XYZ
        {
            get
            {
                return new Vector3(X, Y, Z);
            }
        }

        public Vector4 (Vector3 a, double b){
            this.X = a.X;
            this.Y = a.Y;
            this.Z = a.Z;
            this.W = b;
        }

        public Vector4 ( Vector4 a )
        {
            this.X = a.X;
            this.Y = a.Y;
            this.Z = a.Z;
            this.W = a.W;
        }

        public Vector4 ( double x,double y,double z,double w )
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
            this.W = w;
        }

    }
}
