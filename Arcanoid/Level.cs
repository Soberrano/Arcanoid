using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcanoid
{
    class Level
    {
        public Brick[,] Cells { get; set; }

        public static Level Parse(string s)
        {
            var res = new Level();
            var lines = s.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            res.Cells = new Brick[lines[0].Length, lines.Length];

            for (int y = 0; y < lines.Length; y++)
                for (int x = 0; x < lines[0].Length; x++)
                    switch (lines[y][x])
                    {
                        case '1': res.Cells[x, y] = new Brick(); break;
                        case '2': res.Cells[x, y] = new ImmortalBrick(); break;
                    }

            return res;
        }

        public Brick this[int x, int y]
        {
            get { return Cells[x, y]; }
            set { Cells[x, y] = value; }
        }

        public int Width
        {
            get { return Cells.GetLength(0); }
        }

        public int Height
        {
            get { return Cells.GetLength(1); }
        }
    }
}
