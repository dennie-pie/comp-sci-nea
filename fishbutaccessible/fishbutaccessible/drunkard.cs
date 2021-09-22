using System;
using System.Collections.Generic;
using System.Text;

namespace fish
{
    class drunkard
    {
        private dungeon d = new dungeon();
        private int startpos, stepamount;
        private List<int> steps, moves;
        private Cells[,] map;

        public drunkard(string spos)
        {
            map = d.getMap();
            startpos = Convert.ToInt32(spos);
            stepamount = 5;
        }

        public void walk()
        {
            Random r = new Random();
            for (int i = 0; i <= stepamount; i++)
            {
                int nextmove = r.Next(1, 2);
                if (nextmove == 1) { turn(); }
                else { forward(); }
            }

        }

        public void turn()
        {
            Random r = new Random();

        }
        public void forward()
        {

        }
    }
}
