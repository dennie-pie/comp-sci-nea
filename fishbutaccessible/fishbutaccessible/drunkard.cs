using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace fish
{
    class drunkard
    {
        private Random r;
        private int startx, starty, stepamount, currx, curry, gen;
        private List<int[]> steps;
        private List<string> moves; //moves can be: lt (left turn) ut (up turn) rt (right turn) dt (down turn) lf (left forward) uf (up forward) rf (right forward) df (down forward)
        private Cells[,] map; //left motion, -1, up motion +10, down motion -10, right motion +1

        public drunkard(int sx, int sy, int Gen, Cells[,] Map)
        {
            r = new Random();
            moves = new List<string>();
            steps = new List<int[]>();
            map = Map;
            startx = sx;
            starty = sy;
            currx = sx;
            curry = sy;
            stepamount = r.Next(3,5);
            gen = Gen;
        }

        public void prepSteps()
        {
            foreach (var step in map)
            {
                int[] loc = step.getLoc();
                int[] temp = new int[3];
                Console.WriteLine($"{loc[0]}, {loc[1]}");
                if (step.getGen() == "centre") { temp[0] = loc[0]; temp[1] = loc[1]; temp[3] = 1; }
                else { temp[0] = loc[0]; temp[1] = loc[1]; temp[3] = Convert.ToInt32(step.getGen()); }
                
                steps.Add(temp);
            }
        }

        public List<int[]> walk()
        {
            prepSteps();
            moves.Add("start");
            turn();
            for (int i = 0; i <= stepamount; i++)
            {
                bool moveVal = false;
                while (!moveVal)
                {
                    int nextmove = r.Next(100);
                    if (nextmove > 30) { moveVal = turn(); }
                    else { moveVal = forward(); }
                }
            }
            return steps;
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
                            steps.Add(new int[] { currx, curry, gen });
                        }
                        return valid;
                    case (1):
                        valid = validatePos(currx, curry + 1, "ut");
                        if (valid)
                        {
                            moves.Add("ut");
                            curry += 1;
                            steps.Add(new int[] { currx, curry, gen });
                        }
                        return valid;
                    case (2):
                        valid = validatePos(currx + 1, curry, "rt");
                        if (valid)
                        {
                            moves.Add("rt");
                            currx += 1;
                            steps.Add(new int[] { currx, curry, gen });
                        }
                        return valid;
                    case (3):
                        valid = validatePos(currx, curry - 1, "dt");
                        if (valid)
                        {
                            moves.Add("dt");
                            curry -= 1;
                            steps.Add(new int[] { currx, curry, gen });
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
            if (y == 4 & x == 4)
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
            if (y == 4 & x == 4)
            {
                return false;
            }
            return true;
        }

   
    }
}
