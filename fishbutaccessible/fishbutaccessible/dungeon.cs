using System;
using System.Collections.Generic;
using System.Text;


namespace fish
{

    class Cells
    {
        private int x, y;
        private int[] loc;
        private bool centre, hasRoom;

        public void setHR(bool hr) { hasRoom = hr; }
        public bool getHR() { return hasRoom; }
        public int[] getLoc()
        {
            return loc;
        }
        public Cells(int X, int Y, bool cent)
        {
            x = X;
            y = Y;
            loc = new int[2] { x, y };
            centre = cent;
            hasRoom = false;
        }
    }

    class dungeon
    {
        private Cells[,] dungeonMap = new Cells[8, 8];

        public Cells[,] getMap()
        {
            return dungeonMap;
        }
        public void setMap(Cells[,] newMap)
        {
            dungeonMap = newMap;
        }

        public void setDungeonMap()
        {
            for (int x = 0; x <= 8; x++)
            {
                for (int y = 0; y <= 8; y++)
                {
                    string loc;
                    loc = (Convert.ToString(y) + Convert.ToString(x));
                    if (loc == "44") { Cells cell = new Cells(x, y, true); cell.setHR(true); }
                    else { Cells cell = new Cells(x, y, false); }
                }
            }

        }

        public void generate()
        {
            //this is where it all happens baby
            //the cell at pos 44 already has a room in it. now we will pick a random number between 2-4 to see how many drunkards we will start with.
            Random r = new Random();
            int drunkards = r.Next(2, 4);
            for (int i = 0; i <= drunkards; i++)
            {
                drunkard dr = new drunkard(4,4);
                List<int[]> tempSteps = dr.walk();
                foreach(var j in tempSteps)
                {
                    dungeonMap[j[0], j[1]].setHR(true);
                }
            }
        }
    }
}
