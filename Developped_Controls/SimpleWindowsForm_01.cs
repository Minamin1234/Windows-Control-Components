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
    public partial class SimpleWindowsForm_01 : Form
    {
        public SimpleWindowsForm_01()
        {
            InitializeComponent();
        }

        private bool _Movable = true;
        public bool Movable
        {
            get { return _Movable; }
            set { _Movable = value; }
        }

        private int _RoundRate = 4;
        public int RoundRate
        {
            get { return _RoundRate; }
            set { _RoundRate = value; }
        }

        private int _ConerRadius
        {
            get { return (this.Size.Width / 2) * RoundRate / 100; }
        }

        private int _DConerRadius
        {
            get { return _ConerRadius * 2; }
        }

        private Point CurrentMousePos;

        private void OnLoad(object sender, EventArgs e)
        {
            //タイトル無しのフォーム
            this.FormBorderStyle = FormBorderStyle.None;
        }

        private void OnDraw(object sender, PaintEventArgs e)
        {
            if(_ConerRadius != 0)
            {
                GraphicsPath gPath = new GraphicsPath();

                gPath.AddPie(0, 0, _DConerRadius, _DConerRadius, 180, 90);
                gPath.AddPie(this.Width - _DConerRadius, 0, _DConerRadius, _DConerRadius, 270, 90);
                gPath.AddPie(0, this.Height - _DConerRadius, _DConerRadius, _DConerRadius, 90, 90);
                gPath.AddPie(this.Width - _DConerRadius, this.Height - _DConerRadius, _DConerRadius, _DConerRadius, 0, 90);

                gPath.AddRectangle(new Rectangle(_ConerRadius, 0, this.Width - _DConerRadius, this.Height));
                gPath.AddRectangle(new Rectangle(0, _ConerRadius, _ConerRadius, this.Height - _DConerRadius));
                gPath.AddRectangle(new Rectangle(this.Width - _ConerRadius, _ConerRadius, _ConerRadius, this.Height - _DConerRadius));

                this.Region = new Region(gPath);
            }
            
        }

        private void MouseButton_Down(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                this.CurrentMousePos = new Point(e.X, e.Y);
            }
        }

        private void MouseButton_Up(object sender, MouseEventArgs e)
        {

        }

        private void Mouse_Moved(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if(this.Movable == true)
                {
                    this.Location = new Point(this.Location.X + e.X - this.CurrentMousePos.X, this.Location.Y + e.Y - this.CurrentMousePos.Y);
                }
            }
        }
    }
}
