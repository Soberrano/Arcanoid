using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcanoid
{
    class Brick
    { /// <summary>
      /// Можно ли разрушить блок?
      /// </summary>
        public virtual bool IsBreakable { get; protected set; }

        public Brick()
        {
            IsBreakable = true;
        }

        public virtual void Draw(Graphics g, Rectangle rect)
        {
            g.FillRectangle(Brushes.Brown, rect);
            g.DrawRectangle(Pens.Black, rect);
        }

        /// <summary>
        /// Удар мячом
        /// </summary>
        public virtual void OnHit(int x, int y, Game game)
        {
            if (IsBreakable)
            {
                game.RndLevel[x, y] = null; // уничтожение блока
            }
        }
    }
}
