using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arcanoid
{
    partial class PanelForGaming : UserControl
    {
        public Game Game { get; set; }
        public PanelForGaming()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint, true);
            BackColor = Color.Black;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            if (Game == null)
                return;

            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            Game.Bounds = ClientRectangle;
            Game.Draw(e.Graphics);
        }
    }
}
