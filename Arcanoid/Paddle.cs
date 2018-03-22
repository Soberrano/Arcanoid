using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arcanoid
{
    class Paddle
    {
        public Rectangle Bounds { get; set; }
        public int Speed { get; set; }
        public Point Velocity { get; set; }

        public Paddle()
        {
            Speed = 1;
        }

        public void Update(float dt, Game game)
        {
            //обрабатываем клавиатуру
            Velocity = new Point();
            if (Controling.IsKeyDown(Keys.Left) || Controling.IsKeyDown(Keys.A))
                Velocity = new Point(-Speed, 0);
            if (Controling.IsKeyDown(Keys.Right) || Controling.IsKeyDown(Keys.D))
                Velocity = new Point(Speed, 0);

            //сдвигаем ракетку
            var bounds = Bounds;
            bounds.Offset(Velocity.X, Velocity.Y);

            //не вышли за пределы поля?
            if (bounds.Left >= game.Bounds.Left && bounds.Right <= game.Bounds.Right)
            {
                Bounds = bounds;
            }
        }

        public virtual void Draw(Graphics g)
        {
            g.FillRectangle(Brushes.Green, Bounds);
            g.DrawRectangle(Pens.Lime, Bounds);
        }
    }
}
