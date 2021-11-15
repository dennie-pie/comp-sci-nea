using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace fish
{
    class drunkard
    {
        private dungeon d = new dungeon();
        private int startx, starty, stepamount, currx, curry, gen;
        private List<int[]> steps;
        private List<string> moves; //moves can be: lt (left turn) ut (up turn) rt (right turn) dt (down turn) lf (left forward) uf (up forward) rf (right forward) df (down forward)
        private Cells[,] map; //left motion, -1, up motion +10, down motion -10, right motion +1

        public drunkard(int sx, int sy, int Gen)
        {
            moves = new List<string>();
            steps = new List<int[]>();
            map = d.getMap();
            startx = sx;
            starty = sy;
            currx = sx;
            curry = sy;
            stepamount = 5;
            gen = Gen;
        }

        public void stepsPrep()
        {
            foreach (var ceLL in map)
            {
                if (ceLL.getHR())
                {
                    steps.Add(new int[] { ceLL.getLoc()[0], ceLL.getLoc()[1], Convert.ToInt32(ceLL.getGen()) });
                }
            }
        }

        public List<int[]> walk()
        {
            Random r = new Random();
            stepsPrep();
            moves.Add("start");
            turn();
            for (int i = 0; i <= stepamount; i++)
            {
                bool moveVal;
                do
                {
                    int nextmove = r.Next(100);
                    if (nextmove > 50) { moveVal = turn(); }
                    else { moveVal = forward(); }
                }
                while (!moveVal);
            }
            return steps;
        }

        public bool turn()
        {
            Random r = new Random();
            bool valid = false;
            do
            {
                int turndir = r.Next(4);
                switch (turndir) //1 = left, 2 = up, 3 = right, 4 = down
                {
                    case (0):
                        valid = validatePos(currx - 1, curry, "lt");
                        if (valid)
                        {
                            moves.Add("lt");
                            currx -= 1;
                            steps.Add(new int[] { currx, curry, gen });
                        }
                        break;
                    case (1):
                        valid = validatePos(currx, curry + 1, "ut");
                        if (valid)
                        {
                            moves.Add("ut");
                            curry += 1;
                            steps.Add(new int[] { currx, curry, gen });
                        }
                        break;
                    case (2):
                        valid = validatePos(currx + 1, curry, "rt");
                        if (valid)
                        {

                            moves.Add("rt");
                            currx += 1;
                            steps.Add(new int[] { currx, curry, gen });
                        }
                        break;
                    case (3):
                        valid = validatePos(currx, curry - 1, "dt");
                        if (valid)
                        {

                            moves.Add("dt");
                            curry -= 1;
                            steps.Add(new int[] { currx, curry, gen });
                        }
                        break;
                }
            } while (valid);
            

            return true;
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
                        steps.Add(new int[] { currx, curry, gen });
                    }
                    return valid;
                case ("dt"):
                case ("df"):
                    valid = validatePos(currx, curry - 1);
                    if (valid)
                    {
                        moves.Add("df");
                        curry -= 1;
                        steps.Add(new int[] { currx, curry, gen });
                    }
                    return valid;
                case ("rt"):
                case ("rf"):
                    valid = validatePos(currx + 1, curry);
                    if (valid)
                    {
                        moves.Add("rf");
                        currx += 1;
                        steps.Add(new int[] { currx, curry, gen }) ;
                    }
                    return valid;
                case ("ut"):
                case ("uf"):
                    valid = validatePos(currx, curry + 1);
                    if (valid)
                    {
                        moves.Add("uf");
                        curry += 1;
                        steps.Add(new int[] { currx, curry, gen });
                    }
                    return valid;
            }
            return false;
        }
        public bool validatePos(int x,int y)
        {
            int[] pos = new int[] { x, y };
            if (steps.Contains(pos) | y > 8 | x > 8 | y < 0 | x < 0)
            {
                return false;
            }
            return true;
        }
        public bool validatePos(int x, int y, string currm)
        {
            int[] pos = new int[] { x, y };
            if (steps.Contains(pos) || moves.Last() == currm || y > 8 || x > 8 || y < 0 || x < 0) //!map[Convert.ToInt16(p[0]), Convert.ToInt16(p[1])].getHR()
            {
                return false;
            }
            return true;
        }
    }
}
