using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcanoid
{
    class ImmortalBrick: Brick
    {
        public ImmortalBrick()
        {//Блок разрушить невозможно
            IsBreakable = false;
        }

        public override void Draw(Graphics g, Rectangle rect)
        {
            g.FillRectangle(Brushes.Gold, rect);
            g.DrawRectangle(Pens.Black, rect);
        }
    }
}
