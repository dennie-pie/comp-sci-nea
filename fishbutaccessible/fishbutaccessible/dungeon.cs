using System;
using System.Collections.Generic;
using System.Text;


namespace fish
{

    class Cells
    {
        private string location;
        private bool centre, hasRoom;

        public void setHR(bool hr) { hasRoom = hr; }

        public string getLoc()
        {
            return location;
        }
        public Cells(string loc, bool cent)
        {
            location = loc;
            centre = cent;
            hasRoom = false;
            Console.WriteLine(location);
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
                    if (loc == "44") { Cells cell = new Cells(loc, true); cell.setHR(true); }
                    else { Cells cell = new Cells(loc, false); }
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
                drunkard dr = new drunkard("44");

            }
        }
    }
}
