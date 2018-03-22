using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcanoid
{
    class Ball
    {
        public Rectangle Bounds;//размеры мячика
        public Point Velocity;//скорость
        public int Speed = 5;

        public void Update(float dt, Game game)
        {
            Rectangle b = Bounds;
            b.Offset(Velocity.X, Velocity.Y);
            //Ищем центр мячика
            Point cp = new Point(Bounds.X + Bounds.Width / 2, Bounds.Y + Bounds.Height / 2);

            //обрабатываем столкновения с блоками
            for (int y = 0; y < game.RndLevel.Height; y++)
                for (int x = 0; x < game.RndLevel.Width; x++)
                    if (game.RndLevel.Cells[x, y] != null)
                    {
                        Rectangle rect = game.GetBlockRect(x, y);//прямоугольник блока
                        if (Bounds.IntersectsWith(rect))//столкновение?
                        {
                            Velocity.Y = cp.Y < rect.Top + rect.Height / 2 ? -Speed : Speed;
                            game.RndLevel.Cells[x, y].OnHit(x, y, game);
                            break;
                        }
                    }

            //столкновения с ракеткой
            {
                Rectangle rect = game.Paddle.Bounds;
                if (Bounds.IntersectsWith(rect))//столкновение?
                {
                    //считаем направление отскока
                    var padding = 7;

                    Velocity.Y = -Speed;
                    Velocity.X += Math.Sign(game.Paddle.Velocity.X);

                    if (cp.X < rect.Left + padding) Velocity.X = -Speed;
                    if (cp.X > rect.Right - padding) Velocity.X = Speed;
                }
            }

            //столкновения со стенками
            if (b.Left < game.Bounds.Left || b.Right > game.Bounds.Right) Velocity.X *= -1;
            if (b.Top < game.Bounds.Top) Velocity.Y *= -1;

            //двигаем мяч
            Bounds.Offset(Velocity.X, Velocity.Y);
        }

        public virtual void Draw(Graphics g)
        {
            var path = new GraphicsPath();

            path.AddEllipse(Bounds);
            using (var brush = new PathGradientBrush(path) { CenterColor = Color.White, SurroundColors = new Color[] { Color.Red } })
            {
                g.FillPath(brush, path);
                g.DrawPath(Pens.Black, path);
            }
        }
    }
}
