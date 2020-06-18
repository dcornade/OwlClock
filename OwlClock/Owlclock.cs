using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace OwlClock
{
    public partial class Owlclock: UserControl
    {
        ClockHands panal = new ClockHands();
        int deg = 270;
        int deg1 = 180;
        List<Label> Hrlabels = new List<Label>();
        List<Label> Minlabels = new List<Label>();
        public Owlclock()
        {
            InitializeComponent();

            this.Width = 280;
            this.Height = 280;
        }

        private void Owlclock_Load(object sender, EventArgs e)
        {
            panal.Left = (int)(this.Width / 5.2);
            panal.Top = (int)(this.Height / 5.2);
            panal.Height = (int)(this.Height / 1.6);
            panal.Width = (int)(this.Width / 1.6);
            drawletters();
            drawdots();
            this.Paint += new PaintEventHandler(UserControl1_Paint);
            this.BackColor = Color.Transparent;
        }

        private void UserControl1_Paint(object sender, PaintEventArgs e)
        {
            SolidBrush sdbrsh = new SolidBrush(Color.Blue);
            Graphics gr = e.Graphics;
            Pen pen = new Pen(Color.Green, (int)(this.Width * .08));
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle rect = new Rectangle((int)(this.Width * .05), (int)(this.Width * .05), this.Width - (int)(this.Width * .1), this.Width - (int)(this.Width * .1));
            gr.DrawEllipse(pen, rect);
            //drawhands();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            //drawhands();
            base.OnPaint(e);
        }
        protected override void OnResize(EventArgs e)
        {
            this.Width = this.Height;

            drawdots();
            drawletters();
            //panal.Size = new Size((64 / 100) * this.Width, (64 / 100) * this.Width);
            //panal.Location = new Point(this.Width * 17 / 100, this.Width * 17 / 100);
            panal.Left = (int)(this.Width * 16.9 / 100);
            panal.Top = (int)(this.Height * 16.9 / 100);
            panal.Height = (int)(this.Height * 66 / 100);
            panal.Width = (int)(this.Width * 66 / 100);
            this.Controls.Add(panal);
            //panal.Left = 30;
            //panal.Top = 30;
            //panal.Height = this.Height-150;
            //Graphics g = CreateGraphics();
            //Pen s = new Pen(Color.Green, 20);
            //g.SmoothingMode = SmoothingMode.AntiAlias;
            //Rectangle rect = new Rectangle(10, 10, this.Width - 22, this.Width - 22);
            //g.DrawEllipse(s, rect);
            base.OnResize(e);
        }
        private void drawdots()
        {
            Bitmap bitmap = new Bitmap(this.Width, this.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            bitmap.MakeTransparent();
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                SolidBrush s = new SolidBrush(Color.Blue);
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                //the central point of the rotation
                for (int i = 0; i < 60; i++)
                {
                    deg += 6;
                    if (deg == 360)
                    {
                        deg = 0;
                    }
                    int x, y;
                    int r = (int)(this.Width / 2.55);
                    int cy = this.Width / 2, cx = this.Width / 2;
                    x = (int)(cx + (r * Math.Cos(deg * Math.PI / 180)));
                    y = (int)(cy + (r * Math.Sin(deg * Math.PI / 180)));
                    //label1.Text = x + " : " + y;
                    g.TranslateTransform(x, y);
                    //rotation procedure
                    g.RotateTransform(deg);
                    g.FillRectangle(s, new Rectangle(0, 0, 5, 2));
                    g.RotateTransform(-(deg));
                    g.TranslateTransform(-x, -y);
                }
                this.BackgroundImage = bitmap;
                s.Dispose();
                g.Dispose();
            }
        }
        public void drawletters()
        {
            for (int i = 0; i < 12; i++)
            {
                deg = deg + 30;
                if (deg == 360)
                {
                    deg = 0;
                }
                int x, y;
                int r = (int)(this.Width / 2.9);
                int cy = (this.Width / 2), cx = (this.Width / 2);
                x = (int)(cx + (r * Math.Cos(deg * Math.PI / 180)));
                y = (int)(cy + (r * Math.Sin(deg * Math.PI / 180)));
                Hrlabels.Add(new Label());
                this.Hrlabels[i].AutoSize = true;
                this.Hrlabels[i].Name = "hrlabel" + i;
                this.Hrlabels[i].Size = new System.Drawing.Size(35, 13);
                this.Hrlabels[i].Font = new System.Drawing.Font("Microsoft Sans Serif", (float)(this.Width * .05), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))); ;
                this.Hrlabels[i].TabIndex = 2;
                this.Hrlabels[i].Text = (i + 1).ToString();
                this.Hrlabels[i].FlatStyle = FlatStyle.Flat;
                this.Hrlabels[i].BorderStyle = BorderStyle.None;
                this.Hrlabels[i].BackColor = Color.Transparent;
                x = x - Hrlabels[i].Width / 2;
                y = y - Hrlabels[i].Height / 2;
                this.Hrlabels[i].Location = new Point(x, y);
                this.Controls.Add(Hrlabels[i]);
            }
            for (int i = 0; i < 12; i++)
            {
                deg = deg + 30;
                if (deg == 360)
                {
                    deg = 0;
                }
                int x, y;
                int r = (int)(this.Width / 2.2);
                int cy = (this.Width / 2), cx = (this.Width / 2);
                x = (int)(cx + (r * Math.Cos(deg * Math.PI / 180)));
                y = (int)(cy + (r * Math.Sin(deg * Math.PI / 180)));
                Minlabels.Add(new Label());
                this.Minlabels[i].AutoSize = true;
                this.Minlabels[i].Name = "minlabel" + i;
                this.Minlabels[i].Size = new System.Drawing.Size(35, 13);
                this.Minlabels[i].Font = new System.Drawing.Font("Microsoft Sans Serif", (float)(this.Width * .025), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))); ;
                this.Minlabels[i].TabIndex = 2;
                int labeltext = 0;
                labeltext += (i + 1) * 5;
                this.Minlabels[i].Text = labeltext.ToString();
                this.Minlabels[i].ForeColor = Color.White;
                this.Minlabels[i].FlatStyle = FlatStyle.Flat;
                this.Minlabels[i].BorderStyle = BorderStyle.None;
                this.Minlabels[i].BackColor = Color.Transparent;
                x = x - Minlabels[i].Width / 2;
                y = y - Minlabels[i].Height / 2;
                Minlabels[i].Location = new Point(x, y);
                this.Controls.Add(Minlabels[i]);
            }
        }
        public int sec
        {
            get
            {
                return panal.sec;
            }
            set
            {
                panal.sec = value;
                panal.Refresh();
            }
        }
        public int min
        {
            get
            {
                return panal.min;
            }
            set
            {
                panal.min = value;
                panal.Refresh();
            }
        }
        public int hour
        {
            get
            {
                return panal.hr;
            }
            set
            {
                panal.hr = value;
                panal.Refresh();
            }
        }
    }
    class ClockHands : Panel
    {
        public int sec = 20, min = 30, hr = 8, deg = 270;
        public ClockHands()
        {
            //this.BackColor = Color.Red;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            int minit = sec / 10;
            int hirin = min / 10;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            GraphicsPath grpath = new GraphicsPath();
            grpath.AddEllipse(5, 5, this.Width - 10, this.Width - 10);
            this.Region = new Region(grpath);
            SolidBrush s = new SolidBrush(Color.Blue);
            Graphics g = e.Graphics;
            g.TranslateTransform(this.Width / 2, this.Width / 2);
            g.RotateTransform((deg + (sec * 6)));
            g.FillRectangle(s, new Rectangle(-(int)(this.Width * .1), -1, this.Width / 2, 2));
            g.RotateTransform(-(deg + (sec * 6)));
            g.RotateTransform((float)(deg + (min * 6) + (sec * .1)));
            g.FillRectangle(s, new Rectangle(0, -1, this.Width / 3, 3));
            g.RotateTransform(-(float)(deg + (min * 6) + (sec * .1)));
            g.RotateTransform((float)(deg + (hr * 30) + (min * .5)));
            g.FillRectangle(s, new Rectangle(0, -1, this.Width / 4, 3));
            g.RotateTransform(-(float)(deg + (hr * 30) + (min * .5)));
            base.OnPaint(e);
        }
        protected override void OnResize(EventArgs eventargs)
        {
            //drawHands();
            this.Width = this.Height;
            base.OnResize(eventargs);
        }
    }
}

