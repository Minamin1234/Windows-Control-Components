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
    public partial class Tab_01 : UserControl
    {

        /*
         * Property...
         * Size(Default): 675, 14
         * BackColor(Default): 117,117,117
        */
        public Tab_01()
        {
            InitializeComponent();
        }

        private int _Width = 1400;
        public int TabWidth
        {
            get { return this.Size.Width; }
            set
            {
                _Width = value;
                this.Size = new Size(value, this.Size.Height);
            }
        }
        private int _Height = 50;
        public int Tab_Height
        {
            get { return this.Size.Height; }
            set
            {
                _Height = value;
                this.Size = new Size(this.Size.Width, value);
            }
        }
        private Color _TabColor = Color.FromArgb(117, 117, 117);
        public Color TabColor
        {
            get { return this.BackColor; }
            set
            {
                _TabColor = value;
                this.BackColor = value;
            }
        }

        private int _ConerRadius = 10;
        public int ConerRadius
        {
            get { return _ConerRadius; }
            set { _ConerRadius = value; }
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            //this.Size = new Size(this.Size.Width, Height);
            int Radiusradius = ConerRadius * 2;
            GraphicsPath gPath = new GraphicsPath();

            gPath.AddPie(0, 0, Radiusradius, Radiusradius, 180, 90);
            gPath.AddPie(this.Width - Radiusradius, 0, Radiusradius, Radiusradius, 270, 90);
            //gPath.AddPie(0, this.Height - Radiusradius, Radiusradius, Radiusradius, 90, 90);
            //gPath.AddPie(this.Width - Radiusradius, this.Height - Radiusradius, Radiusradius, Radiusradius, 0, 90);
            gPath.AddRectangle(new Rectangle(ConerRadius, 0, this.Width - Radiusradius, this.Height));
            gPath.AddRectangle(new Rectangle(0, ConerRadius, ConerRadius, this.Height - ConerRadius));
            gPath.AddRectangle(new Rectangle(this.Width - ConerRadius, ConerRadius, ConerRadius, this.Height - ConerRadius));

            this.Region = new Region(gPath);
        }
    }
}
