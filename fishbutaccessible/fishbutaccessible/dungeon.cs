using System;
using System.Collections.Generic;
using System.Text;


namespace fish
{
    class Cells
    {
        private bool hasRoom;
        private string gen;

        public void setHR(bool hr) { hasRoom = hr; }
        public bool getHR() { return hasRoom; }
        public string getGen() { return gen; }
        public void setGen(string ng) { gen = ng; }

        public Cells(string cent)
        {
            gen = cent;
            hasRoom = false;
        }
        public Cells()
        {
            gen = null;
            hasRoom = false;
        }
    }
    class CellOverlord
    {
        private Cells[,] dungeonMap;
        private int mapSize;
        public CellOverlord()
        {
            mapSize = 9;
            dungeonMap = new Cells[mapSize, mapSize];

            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    dungeonMap[i, j] = new Cells();
                }
            }
        }
        public int getmMapSize() { return mapSize; }
        public Cells[,] getMap()
        {
            return dungeonMap;
        }
        public void setMap(Cells[,] newMap)
        {
            dungeonMap = newMap;
        }
        public bool hasRoom(int x, int y) { return dungeonMap[x, y].getHR(); }
        public void setRoom(int x, int y, string gen) { dungeonMap[x, y].setHR(true); dungeonMap[x, y].setGen(gen); }
        public void setEmpty(int x, int y) { dungeonMap[x, y].setHR(false); }
        public string getGen(int x, int y) { return dungeonMap[x, y].getGen(); }
    }

    class dungeon
    {
        private CellOverlord c;
        public dungeon(CellOverlord C)
        {
            c = C;
        }

        public void generate()
        {
            //this is where it all happens baby
            //the cell at pos 44 already has a room in it. now we will pick a random number between 2-4 to see how many drunkards we will start with.
            Random r = new Random();
            c.setRoom(4, 4, "centre");
            int drunkards = r.Next(2, 4);
            for (int i = 0; i <= drunkards; i++)
            {
                drunkard dr = new drunkard(4,4,i+1, c);
                dr.walk();
                tempDrawMap();
            }

        }

        public void tempDrawMap()
        {
            for (int i = 0; i < 9; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < 9; j++)
                {
                    switch (c.getGen(i,j))
                    {
                        case "centre":
                            Console.Write("[*]");
                            break;
                        case "1":
                            Console.Write("[1]");
                            break;
                        case "2":
                            Console.Write("[2]");
                            break;
                        case "3":
                            Console.Write("[3]");
                            break;
                        case "4":
                            Console.Write("[4]");
                            break;
                        case null:
                            Console.Write("| |");
                            break;
                    }
                }
            }
        }
    }
}
