using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace fish
{
    class drunkard
    {
        private CellOverlord c;
        private Random r;
        private int startx, starty, stepamount, currx, curry, gen;
        private List<string> moves; //moves can be: lt (left turn) ut (up turn) rt (right turn) dt (down turn) lf (left forward) uf (up forward) rf (right forward) df (down forward)
         //left motion, -1, up motion +10, down motion -10, right motion +1

        public drunkard(int sx, int sy, int Gen, CellOverlord C)
        {
            r = new Random();
            moves = new List<string>();
            c = C;
            startx = sx;
            starty = sy;
            currx = sx;
            curry = sy;
            stepamount = r.Next(3,5);
            gen = Gen;
        }

        public void walk()
        {
            moves.Add("start");
            turn();
            for (int i = 0; i <= stepamount; i++)
            {
                bool valid = false;
                while (!valid)
                {
                    int nextmove = r.Next(100);
                    if (nextmove > 20) { valid = turn(); }
                    else { valid = forward(); }
                }
            }
        }

        public bool turn()
        {
            Random r = new Random();
            bool valid = false;
                int turndir = r.Next(4);
                switch (turndir) //1 = left, 2 = up, 3 = right, 4 = down
                {
                    case (0):
                        valid = validatePos(currx - 1, curry, "lt");
                        if (valid)
                        {
                            moves.Add("lt");
                            currx -= 1;
                            c.setRoom(currx, curry, Convert.ToString(gen));
                        }
                        return valid;
                    case (1):
                        valid = validatePos(currx, curry + 1, "ut");
                        if (valid)
                        {
                            moves.Add("ut");
                            curry += 1;
                            c.setRoom(currx, curry, Convert.ToString(gen));
                        }
                    return valid;
                    case (2):
                        valid = validatePos(currx + 1, curry, "rt");
                        if (valid)
                        {
                            moves.Add("rt");
                            currx += 1;
                            c.setRoom(currx, curry, Convert.ToString(gen)); 
                        }
                        return valid;
                    case (3):
                        valid = validatePos(currx, curry - 1, "dt");
                        if (valid)
                        {
                            moves.Add("dt");
                            curry -= 1;
                            c.setRoom(currx, curry, Convert.ToString(gen));
                        }
                        return valid;
                }
            return valid;
        }

        public bool forward()
        {
            bool valid;
            switch (moves.Last())
            {
                case ("lt"):
                case ("lf"):
                    valid = validatePos(currx - 1, curry);
                    if (valid)
                    {
                        moves.Add("lf");
                        currx -= 1;
                        c.setRoom(currx, curry, Convert.ToString(gen));
                    }
                    return valid;
                case ("dt"):
                case ("df"):
                    valid = validatePos(currx, curry - 1);
                    if (valid)
                    {
                        moves.Add("df");
                        curry -= 1;
                        c.setRoom(currx, curry, Convert.ToString(gen));
                    }
                    return valid;
                case ("rt"):
                case ("rf"):
                    valid = validatePos(currx + 1, curry);
                    if (valid)
                    {
                        moves.Add("rf");
                        currx += 1;
                        c.setRoom(currx, curry, Convert.ToString(gen));
                    }
                    return valid;
                case ("ut"):
                case ("uf"):
                    valid = validatePos(currx, curry + 1);
                    if (valid)
                    {
                        moves.Add("uf");
                        curry += 1;
                        c.setRoom(currx, curry, Convert.ToString(gen));
                    }
                    return valid;
            }
            return false;
        }
        public bool validatePos(int x,int y)
        {
            if ( y >= c.getmMapSize() || x >= c.getmMapSize() || c.hasRoom(x, y) || y < 0 || x < 0)
            {
                return false;
            }
            return true;
        }
        public bool validatePos(int x, int y, string currm)
        {
            if (moves.Last() == currm || y >= c.getmMapSize() || x >= c.getmMapSize() || c.hasRoom(x, y) || y < 0 || x < 0)
            {
                return false;
            }
            return true;
        }
    }
}

