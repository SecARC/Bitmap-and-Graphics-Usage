using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace week03_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            Bitmap bitmap = new Bitmap(300, 300);
            Graphics g = Graphics.FromImage(bitmap);

            g.Clear(Color.White);

            //shape code will go here
            int sides = (int)numericUpDown1.Value;

            float r = 100;
            PointF center = new PointF(150, 150);
            float alpha = (float)(2 * Math.PI / sides);
            float theta = 0;
            //create a circle
            g.DrawEllipse(Pens.Silver, center.X - r, center.Y - r, 2 * r, 2 * r);

            //create multiple triangles until end of circle
            while (theta < 2 * Math.PI)
            {
                PointF p0 = center;
                PointF p1 = new PointF((float)(center.X + r * Math.Cos(theta)), (float)(center.Y + r * Math.Sin(theta)));
                theta += alpha;
                PointF p2 = new PointF((float)(center.X + r * Math.Cos(theta)), (float)(center.Y + r * Math.Sin(theta)));
                string coord = string.Format("({0} {1})", Math.Round(p2.X - center.X, 1), -Math.Round((p2.Y - center.Y), 1));
                g.DrawString(coord, SystemFonts.DefaultFont, Brushes.Blue, p2);

                g.DrawPolygon(Pens.Purple, new PointF[] { p0, p1, p2 });
            }
            //write center point
            g.DrawString("(0,0)", SystemFonts.DefaultFont, Brushes.Blue, center);


            //end of shape code

            bitmap.Save(@"C:\Users\PC\source\repos\week03-3\week03-3\images\polygon.jpg");
            pictureBox1.Image = bitmap;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap bitmap = new Bitmap(300, 300);
            Graphics g = Graphics.FromImage(bitmap);

            g.Clear(Color.White);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            //shape code will go here

            PointF center = new PointF(150, 150);
            List<PointF> points = new List<PointF>();
            float theta = 0;
            float dt = (float)(2 * Math.PI / 100);
            while (theta < 2 * Math.PI)
            {
                PointF p = new PointF(center.X + 5 * heartX(theta), center.Y - 5 * heartY(theta));
                points.Add(p);
                theta += dt;
            }

            g.FillPolygon(Brushes.Red, points.ToArray());


            
            //end of shape code

            bitmap.Save(@"C:\Users\PC\source\repos\week03-3\week03-3\images\heart.jpg");
            pictureBox2.Image = bitmap;
        }
        private float heartX(float theta)
        {
            return (float)(16 * (Math.Pow(Math.Sin(theta), 3)));
        }
        private float heartY(float theta)
        {
            return (float)(13 * Math.Cos(theta) - 5 * Math.Cos(2 * theta) - 2 * Math.Cos(3 * theta) - Math.Cos(4 * theta));
        }
    }
}
