using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Applications_01.Developped_Controls
{
    public partial class RoundButton_01 : UserControl
    {
        //RoundButton_01
        /*
         * Property...
         * BackColor(228, 100, 78)
         * Size(15, 15)
        */

        private ColorMaker _ColorMaker = new ColorMaker();
        public RoundButton_01()
        {
            InitializeComponent();
        }

        private int _Radius = 15;
        public int Radius
        {
            get { return _Radius; }
            set { _Radius = value;
                this.Size = new Size(value, value);
            }
        }

        private int _RateOfIncrease = 80;
        private int _RateOfDecrease
        {
            get { return _RateOfIncrease; }
        }

        public int RateOfIncrease
        {
            get { return _RateOfIncrease; }
            set { _RateOfIncrease = value; }
        }

        private Color _DefaultColor = Color.FromArgb(228, 100, 78);
        public Color DefaultColor
        {
            get { return _DefaultColor; }
            set { _DefaultColor = value;
                this.BackColor = value;
            }
        }


        private void OnDraw(object sender, PaintEventArgs e)
        {
            this.Size = new Size(Radius, Radius);
            GraphicsPath gPath = new GraphicsPath();
            gPath.AddEllipse(new Rectangle(0, 0, Radius, Radius));
            this.Region = new Region(gPath);
        }

        private void MouseButton_Down(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                this.BackColor = _ColorMaker.MakeClickedColor(DefaultColor, RateOfIncrease);
                Invalidate();
            }
            else
            {

            }
            
        }

        private void MouseHovered(object sender, EventArgs e)
        {
            ColorMaker CColorMaker = new ColorMaker();
            this.BackColor = CColorMaker.MakeHoveredColor(DefaultColor, RateOfIncrease);


            Invalidate();
            
        }

        private void MouseLeft(object sender, EventArgs e)
        {
            this.BackColor = DefaultColor;
            Invalidate();
        }

        private void MouseButton_Up(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                this.BackColor = DefaultColor;
                Invalidate();
            }
            else
            {

            }
        }
    }

    public class ColorMaker
    {
        public ColorMaker()
        {

        }


        public Color MakeHoveredColor(Color BaseColor,int RateOfIncrease)
        {
            
            int R = BaseColor.R + ((255 - BaseColor.R) * RateOfIncrease / 100);
            int G = BaseColor.G + ((255 - BaseColor.G) * RateOfIncrease / 100);
            int B = BaseColor.B + ((255 - BaseColor.B) * RateOfIncrease / 100);
            Color CurrentColor = Color.FromArgb(R, G, B);


            return CurrentColor;
        }

        public Color MakeClickedColor(Color BaseColor,int RateOfDecrease)
        {
            int R = BaseColor.R - (BaseColor.R * RateOfDecrease / 100);
            int G = BaseColor.G - (BaseColor.G * RateOfDecrease / 100);
            int B = BaseColor.B - (BaseColor.B * RateOfDecrease / 100);

            Color CurrentColor = Color.FromArgb(R, G, B);
            return CurrentColor;
        }
    }
}
