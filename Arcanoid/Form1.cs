using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arcanoid
{
    public partial class Form1 : Form
    {
        private Game game;

        public Form1()
        {
            InitializeComponent();

            game = new Game();
            game.Bounds = pFG.ClientRectangle;
            game.InitLevel();
            pFG.Game = game;

            Timer tm = new Timer { Enabled = true, Interval = 20 };
            tm.Tick += delegate
            {
                var dt = 0.1f;
                game.Update(dt);
                pFG.Invalidate();

                if (game.IsGameOver())//мяч потерян
                {
                    tm.Stop();
                    MessageBox.Show("Game over!");
                    game.InitLevel();//начало новой игры
                    tm.Start();
                }

                if (game.IsLevelCompleted())//уровень пройден?
                {
                    tm.Stop();
                    game.InitLevel();//сгенерируй новый уровень
                    tm.Start();
                }
            };
        }
    }
}
