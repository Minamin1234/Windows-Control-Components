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
    public partial class RoundButton_02 : UserControl
    {
        public RoundButton_02()
        {
            this.InitialRegion = this.Region;
            InitializeComponent();
        }

        /*
         * Property...
         * Size(Default): 167, 54
         * Color: Control
        */
        private Region InitialRegion = new Region();

        private Color _ButtonColor = Color.FromArgb(40, 240, 170);
        public Color ButtonColor
        {
            get { return _ButtonColor; }
            set { this.BackColor = value;
                _ButtonColor = value;
            }
        }

        private int _RoundRate = 50;
        public int RoundRate
        {
            get { return _RoundRate; }
            set { _RoundRate = value; }
        }

        private int _ConerRadius = 15;
        public int ConerRadius
        {
            get { return (this.Size.Height / 2) * RoundRate / 100; }
        }
        private int D_ConerRadius
        {
            get { return ConerRadius * 2; }
        }

        private int _RateOfIncrease = 50;
        public int RateOfIncrease
        {
            get { return _RateOfIncrease; }
            set { _RateOfIncrease = value; }
        }

        public Size ButtonSize
        {
            get { return this.Size; }
            set { this.Size = value; }
        }

        public Color MakeHoveredColor(Color CurrentColor,int RateOfIncrease)
        {
            int R = CurrentColor.R + ((255 - CurrentColor.R) * RateOfIncrease / 100);
            int G = CurrentColor.G + ((255 - CurrentColor.G) * RateOfIncrease / 100);
            int B = CurrentColor.B + ((255 - CurrentColor.B) * RateOfIncrease / 100);

            Color NewColor = Color.FromArgb(R, G, B);
            return NewColor;
        }

        public Color MakeClickedColor(Color CurrentColor,int RateOfIncrease)
        {
            int R = CurrentColor.R - (CurrentColor.R * RateOfIncrease / 100);
            int G = CurrentColor.G - (CurrentColor.G * RateOfIncrease / 100);
            int B = CurrentColor.B - (CurrentColor.B * RateOfIncrease / 100);

            Color NewColor = Color.FromArgb(R, G, B);
            return NewColor;
        }

        private void MouseButton_Down(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                this.BackColor = MakeClickedColor(this.ButtonColor, RateOfIncrease);
                Invalidate();
            }
            else
            {

            }
        }

        private void MouseHovered(object sender, EventArgs e)
        {
            this.BackColor = MakeHoveredColor(this.ButtonColor, RateOfIncrease);
            Invalidate();
        }

        private void MouseLeft(object sender, EventArgs e)
        {
            this.BackColor = this.ButtonColor;
        }

        private void Mouse_Up(object sender, MouseEventArgs e)
        {
            this.BackColor = this.ButtonColor;
        }

        private void OnDraw(object sender, PaintEventArgs e)
        {
            if(this.ConerRadius != 0)
            {
                GraphicsPath gPath = new GraphicsPath();

                gPath.AddPie(0, 0, D_ConerRadius, D_ConerRadius, 180, 90);
                gPath.AddPie(this.Width - D_ConerRadius, 0, D_ConerRadius, D_ConerRadius, 270, 90);
                gPath.AddPie(0, this.Height - D_ConerRadius, D_ConerRadius, D_ConerRadius, 90, 90);
                gPath.AddPie(this.Width - D_ConerRadius, this.Height - D_ConerRadius, D_ConerRadius, D_ConerRadius, 0, 90);

                gPath.AddRectangle(new Rectangle(ConerRadius, 0, this.Width - D_ConerRadius, this.Height));
                gPath.AddRectangle(new Rectangle(0, ConerRadius, ConerRadius, this.Height - D_ConerRadius));
                gPath.AddRectangle(new Rectangle(this.Width - ConerRadius, ConerRadius, ConerRadius, this.Height - D_ConerRadius));

                this.Region = new Region(gPath);

            }
            else
            {
                this.Region = InitialRegion;
            }
        }
    }
}
