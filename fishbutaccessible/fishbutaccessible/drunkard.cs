using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace fish
{
    class drunkard
    {
        private dungeon d = new dungeon();
        private int startpos, stepamount, currpos;
        private List<int> steps;
        private List<string> moves; //moves can be: lt (left turn) ut (up turn) rt (right turn) dt (down turn) lf (left forward) uf (up forward) rf (right forward) df (down forward)
        private Cells[,] map; //left motion, -1, up motion +10, down motion -10, right motion +1

        public drunkard(string spos)
        {
            moves = new List<string>();
            steps = new List<int>();
            map = d.getMap();
            startpos = Convert.ToInt32(spos);
            currpos = startpos;
            stepamount = 5;
        }

        public void walk()
        {
            Random r = new Random();
            steps.Add(44);
            moves.Add("start");

            for (int i = 0; i <= stepamount; i++)
            {
                Console.WriteLine($"i started at {startpos}, i am currently at {currpos} and my last move was {moves.Last()}");
                bool moveVal;
                do
                {
                    Console.WriteLine("moving");
                    int nextmove = r.Next(0,100);
                    if (nextmove > 50) { moveVal = turn(); }
                    else { moveVal = forward(); }
                }
                while (!moveVal);
            }

        }

        public bool turn()
        {
            Random r = new Random();
            Console.WriteLine("well this isnt implemented yet but imagine you just did a great big turn in whatever diection");
            r.Next()






            return true;
        }
        public bool forward()
        {
            bool valid;
            switch (moves.Last())
            {
                case ("lt"):
                case ("lf"):
                    valid = validatePos(currpos - 1);
                    if (valid)
                    {
                        moves.Add("lf");
                        currpos -= 1;
                        steps.Add(currpos);
                    }
                    return valid;
                case ("dt"):
                case ("df"):
                    valid = validatePos(currpos - 10);
                    if (valid)
                    {
                        moves.Add("df");
                        currpos -= 10;
                        steps.Add(currpos);
                    }
                    return valid;
                case ("rt"):
                case ("rf"):
                    valid = validatePos(currpos + 1);
                    if (valid)
                    {
                        moves.Add("rf");
                        currpos += 1;
                        steps.Add(currpos);
                    }
                    return valid;
                case ("ut"):
                case ("uf"):
                    valid = validatePos(currpos + 10);
                    if (valid)
                    {
                        moves.Add("uf");
                        currpos += 10;
                        steps.Add(currpos);
                    }
                    return valid;
            }
            return false;
        }
        public bool validatePos(int pos)
        {
            string p = Convert.ToString(pos);
            if (!steps.Contains(pos) && !map[Convert.ToInt16(p[0]), Convert.ToInt16(p[1])].getHR())
            {
                return true;
            }
            else { return false; }
        }
        public bool validatePos(int pos, string currm)
        {
            string p = Convert.ToString(pos);
            if (!steps.Contains(pos) && !map[Convert.ToInt16(p[0]), Convert.ToInt16(p[1])].getHR() && moves.Last() != currm)
            {
                return true;
            }
            else { return false; }
        }
    }
}
