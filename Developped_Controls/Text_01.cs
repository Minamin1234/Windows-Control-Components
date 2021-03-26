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
    public partial class Text_01 : UserControl
    {
        public Text_01()
        {
            InitializeComponent();
        }

        public float TextSize
        {
            get { return this.Size.Height; }
        }

        private Color _TextColor = Color.FromArgb(117, 117, 117);
        public Color TextColor
        {
            get { return _TextColor; }
            set { _TextColor = value;
                this.BackColor = value;
            }
        }

        private string _CurrentText = "Text";
        public string CurrentText
        {
            get { return _CurrentText; }
            set { _CurrentText = value; }
        }

        private FontStyle _TextStyle = FontStyle.Regular;
        public FontStyle TextStyle
        {
            get { return _TextStyle;}
            set { _TextStyle = value; }
        }

        private FontFamily _TextFont = new FontFamily("Arial");
        public FontFamily TextFont
        {
            get { return _TextFont; }
            set { _TextFont = value; }
        }

        private void OnDraw(object sender, PaintEventArgs e)
        {
            GraphicsPath gPath = new GraphicsPath();

            gPath.AddString(CurrentText, TextFont, (int)TextStyle, TextSize, new Point(0, 0), StringFormat.GenericDefault);

            this.Region = new Region(gPath);
        }
    }
}
