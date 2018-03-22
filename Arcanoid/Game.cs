using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Arcanoid
{
    class Game
    {


        public Level RndLevel { get; set; }
        public Paddle Paddle { get; set; }
        public Ball Ball { get; set; }

        //public int NextLevelNumber { get; set; }

        public Rectangle Bounds { get; set; }

        public void InitLevel()
        {
            Ball = new Ball();
            Ball.Bounds = new Rectangle(Bounds.Width / 2, (int)(Bounds.Height * 0.9f), 10, 10);
            Ball.Velocity = new Point(0, -5);
            Ball.Speed = 5;

            Paddle = new Paddle();
            Paddle.Bounds = new Rectangle(Bounds.Width / 2, (int)(Bounds.Height * 0.95f), 80, 15);
            Paddle.Speed = 6;

            #region генерация уровня
            Random rnd1 = new Random();
            int a;
            string b = null;
            for (int c = 0; c < 5; c++)
            {

                for (int i = 0; i < 19; i++)
                {

                    a = rnd1.Next(0, 3);
                    b += a;
                }
                b += "\n";
            }
            RndLevel = Level.Parse(b);
            #endregion
        }
        public void Undead()
        {
            Ball = new Ball();
            Ball.Bounds = new Rectangle(Bounds.Width / 2, (int)(Bounds.Height * 0.9f), 10, 10);
            Ball.Velocity = new Point(0, -5);
            Ball.Speed = 5;

            Paddle = new Paddle();
            Paddle.Bounds = new Rectangle(Bounds.Width / 2, (int)(Bounds.Height * 0.95f), 80, 15);
            Paddle.Speed = 6;
        }
        /// <summary>
        /// Все блоки уничтожены?
        /// </summary>
        public bool IsLevelCompleted()
        {
            foreach (var c in RndLevel.Cells)
                if (c != null && c.IsBreakable) return false;

            return true;
        }

        /// <summary>
        /// Мяч вышел за пределы поля ?
        /// </summary>
        public bool IsGameOver()
        {
            return Ball.Bounds.Bottom > Bounds.Bottom + 2;
        }

        public void Update(float dt)
        {
            Ball.Update(dt, this);
            Paddle.Update(dt, this);
        }

        public virtual void Draw(Graphics g)
        {
            //рисуем блоки
            for (int y = 0; y < RndLevel.Height; y++)
                for (int x = 0; x < RndLevel.Width; x++)
                    if (RndLevel.Cells[x, y] != null)
                        RndLevel.Cells[x, y].Draw(g, GetBlockRect(x, y));

            //рисуем мяч и ракетку
            Ball.Draw(g);
            Paddle.Draw(g);
        }

        public Rectangle GetBlockRect(int x, int y)
        {
            var w = (int)(1f * Bounds.Width / RndLevel.Width);
            var h = 15;
            return new Rectangle(x * w, y * h, w, h);
        }
    }
}

