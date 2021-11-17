using System;
using System.Collections.Generic;
using System.Text;


namespace fish
{

    class Cells
    {
        private int x, y;
        private int[] loc;
        private bool hasRoom;
        private string gen;

        public void setHR(bool hr) { hasRoom = hr; }
        public string getGen() { return gen; }
        public void setGen(string ng) { gen = ng; }
        public int[] getLoc()
        {
            return loc;
        }
        public Cells(int X, int Y, string cent)
        {
            x = X;
            y = Y;
            loc = new int[2] { x, y };
            gen = cent;
            hasRoom = false;
        }
        public Cells(int X, int Y)
        {
            x = X;
            y = Y;
            loc = new int[2] { x, y };
            hasRoom = false;
        }
    }

    class dungeon
    {
        private Cells[,] dungeonMap = new Cells[9, 9];

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
                    if (loc == "44") { Cells cell = new Cells(x, y, "centre"); cell.setHR(true); dungeonMap[x, y] = cell; }
                    else { Cells cell = new Cells(x, y); dungeonMap[x, y] = cell; }
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
                drunkard dr = new drunkard(4,4,i+1, dungeonMap);
                List<int[]> tempSteps = dr.walk();
                foreach(var j in tempSteps)
                {
                    dungeonMap[j[0], j[1]].setHR(true);
                    dungeonMap[j[0], j[1]].setGen(Convert.ToString(j[2]));
                }
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
                    switch (dungeonMap[i, j].getGen())
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
