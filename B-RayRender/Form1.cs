using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace B_RayRender
{
    public partial class Form1 : Form
    {
        public static Vector3 cameraPos;
        public static Vector2 screenSize;
        public static Vector3 spherePos;
        public static double sphereRadius;
        public static Vector3 boxPos;
        public static Vector3 boxSize;

        public static Vector3 lightPos;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            cameraPos = new Vector3(0, 0, -1);
            screenSize = new Vector2(512, 512);
            spherePos = new Vector3(2, 2, 4);
            sphereRadius = 1;
            lightPos = new Vector3(3,-3,0);
            boxPos = new Vector3(-2,0,7);
            boxSize = new Vector3(1.5,3,1.5);

            #region 
            base.OnPaint(e);
            Bitmap bm = new Bitmap(512, 512);
            var dc = e.Graphics;
            #endregion

            for (int i = 0; i < screenSize.X; i++)
            {
                for (int j = 0; j < screenSize.Y; j++)
                {
                    Vector3 col;
                    Vector3 ray = new Vector3(new Vector2(i, j) / screenSize * 2 - 1, 0)-cameraPos;
                    Vector3 rd = MyMath.Normalize(ray);
                    Vector3 p0 = cameraPos;
                    Vector3 p1 = RayMarching(p0,rd,60);
                    Vector3 normalDir = GetNormal(p1);
                    col = computeLightModel(new Vector3(0.8),p1,normalDir);
                    col = RayRelfect(col,p1,rd,normalDir,0.8);
                    col = MyMath.Clamp(col,0,1);
                    col *= 255;
                    bm.SetPixel(i,j,Color.FromArgb(255,Convert.ToInt32(col.X),Convert.ToInt32(col.Y),Convert.ToInt32(col.Z)));
                }
            }

            dc.DrawImageUnscaled(bm, 0, 0);
        }

        public Vector3 RayMarching(Vector3 p, Vector3 rd, int time)
        {
            if (time <= 0)
            {
                return p;
            }

            double minDis = DistanceField(p);
            if (minDis <= 0.01||minDis>15)
            {
                return p;
            }
            else
            {
                Vector3 newP = p + rd * minDis;
                return RayMarching(newP, rd, time - 1);
            }

        }

        public Vector3 RayRelfect (Vector3 col,Vector3 p,Vector3 ray,Vector3 normalDir,double rayScale)
        {
            Vector3 rd = GetRelfectDir(ray,normalDir);
            Vector3 p1 = RayMarching(p + normalDir * 0.03,rd,50);
            Vector3 normalDirN = GetNormal(p1);
            Vector3 relfectCol = computeLightModel(new Vector3(0.8),p1,normalDirN);
            relfectCol *= rayScale;
            col += relfectCol;
            if ( relfectCol <= 0.01 )
            {
                return col;
            }
            else
            {
                return RayRelfect(col,p1,rd,normalDirN,rayScale * 0.7);
            }
        }

        public double SphereSDF(Vector3 p)
        {
            double minDis = MyMath.Distance(p, spherePos) - sphereRadius;
            return minDis;
        }

        public  double BoxSDF ( Vector3 ray )
        {
            Vector3 q = MyMath.Abs(ray - boxPos) - boxSize;
            double result = MyMath.Max(q,0).Lenght + Math.Min(Math.Max(q.X,Math.Max(q.Y,q.Z)),0);
            return result;
        }

        public double DistanceField(Vector3 p)
        {
            double sphereSDF = SphereSDF(p);
            double planSDF = 3 - p.Y;
            double planRSDF = 5 - p.X;
            double planLSDF = Math.Abs(-5-p.X);
            double planFSDF = 13-p.Z;
            double planTSDF = Math.Abs(-9-p.Y);
            double boxSDF = BoxSDF(p);
            double minDis = Math.Min(sphereSDF,planSDF);
            minDis = Math.Min(minDis,boxSDF);
            return minDis;
        }

        public Vector3 GetNormal(Vector3 p)
        {
            double Offset = 0.00001;
            double dis = DistanceField(p);
            Vector3 normal = MyMath.Normalize(
                    new Vector3(DistanceField(p + new Vector3(Offset, 0, 0))- dis,
                                DistanceField(p + new Vector3(0, Offset, 0)) - dis,
                                DistanceField(p + new Vector3(0, 0, Offset)) - dis)
                                );
            return normal;
        }

        public double GetShandow ( Vector3 p,Vector3 normalDir,int time )
        {
            Vector3 rd = lightPos - p;
            Vector3 rdNor = MyMath.Normalize(rd);
            Vector3 Shandow = RayMarching(p + (normalDir * 0.03),rdNor,time);
            double dis = MyMath.Distance(p,Shandow);
            return dis < rd.Lenght ? 0 : 1;
        }

        public Vector3 GetRelfectDir ( Vector3 ray,Vector3 normal )
        {
            Vector3 relfectDir = ray - normal * 2 * (MyMath.Dot(ray,normal));
            return relfectDir;
        }

        public Vector3 GetHalfwayDir ( Vector3 viewDir,Vector3 lightDir )
        {
            Vector3 halfwayDir = MyMath.Normalize(viewDir + lightDir);
            return halfwayDir;
        }

        public Vector3 GetviewDir ( Vector3 p,Vector3 cameraPos )
        {
            Vector3 viewDir = MyMath.Normalize(cameraPos - p);
            return viewDir;
        }

        public Vector3 GetLightDir ( Vector3 p,Vector3 lightpos )
        {
            Vector3 lightDir = MyMath.Normalize(lightpos - p);
            return lightDir;
        }

        public Vector3 CheckerBoard ( Vector3 p,double size )
        {
            double zScale = Math.Floor(p.Z / size) % 2 == 0 ? 1 : 0;
            double grid = Math.Floor(p.X / size + zScale) % 2 == 0 ? 0 : 1;
            Vector3 col = MyMath.Lerp(new Vector3(0.78,0.28,0.15),new Vector3(0.98,0.83,0.04),grid);
            return col;
        }

        public Vector3 computeLightModel (Vector3 diffuse,Vector3 p,Vector3 normalDir)
        {
            //获得灯光向量
            Vector3 lightDir = GetLightDir(p,lightPos);
            //获得视角向量
            Vector3 viewDir = GetviewDir(p,cameraPos);
            //获得半角向量
            Vector3 halfwayDir = GetHalfwayDir(viewDir,lightDir);
            //获得阴影
            double Shandow = GetShandow(p,normalDir,35);
            //HalfLambert
            double NdotL = MyMath.Clamp(MyMath.Dot(lightDir,normalDir),0.001,1);
            double NdotH = MyMath.Dot(normalDir,halfwayDir);
            double ambient = 0;
            double Specular = Math.Pow(Math.Max(0,MyMath.Dot(normalDir,halfwayDir)),88);
            //乘漫反射颜色
            Vector3 col = new Vector3(NdotL,NdotL,NdotL) * diffuse;
            //乘阴影
            col *= Shandow * 0.8;
            //加高光颜色
            col += new Vector3(Specular);
            //乘灯光颜色
            col *= new Vector3(1,0.95,0.95);
            //加环境光
            col += new Vector3(0.49,0.63,1) * ambient;
            col = MyMath.Clamp(col,0,1);
            return col;
        }

    }
}