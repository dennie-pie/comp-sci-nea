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
            turn();
            for (int i = 0; i <= stepamount; i++)
            {
                Console.WriteLine($"i started at {startpos}, i am currently at {currpos} and my last move was {moves.Last()}");
                bool moveVal;
                do
                {
                    Console.WriteLine("moving");
                    
                    int nextmove = r.Next(100);
                    if (nextmove > 50) { moveVal = turn(); }
                    else { moveVal = forward(); }
                }
                while (!moveVal);
            }

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
                        valid = validatePos(currpos - 1, "lt");
                        if (valid)
                        {
                            moves.Add("lt");
                            currpos -= 1;
                            steps.Add(currpos);
                        }
                        break;
                    case (1):
                        valid = validatePos(currpos + 10, "ut");
                        if (valid)
                        {
                            moves.Add("ut");
                            currpos += 10;
                            steps.Add(currpos);
                        }
                        break;
                    case (2):
                        valid = validatePos(currpos + 1, "rt");
                        if (valid)
                        {

                            moves.Add("rt");
                            currpos += 1;
                            steps.Add(currpos);
                        }
                        break;
                    case (3):
                        valid = validatePos(currpos - 10, "dt");
                        if (valid)
                        {

                            moves.Add("dt");
                            currpos -= 10;
                            steps.Add(currpos);
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
            char y = p[0];
            char x = p[1];
            Console.WriteLine($"{Convert.ToString(p[0])} and {Convert.ToString(p[1])}");
            if (steps.Contains(pos) | y > 8 | x > 8) //&& map[Convert.ToInt16(p[0]), Convert.ToInt16(p[1])].getHR()
            {
                Console.WriteLine("what");
                return false;
            }
            else { return true; }
        }
        public bool validatePos(int pos, string currm)
        {
            string p = Convert.ToString(pos);
            char tempy = p[0];
            char tempx = p[1];
            int y = Convert.ToInt16(tempy);
            int x = Convert.ToInt16(tempx); // fix please
            Console.WriteLine($"{Convert.ToString(y)} and {Convert.ToString(x)}");
            if (steps.Contains(pos)) //!map[Convert.ToInt16(p[0]), Convert.ToInt16(p[1])].getHR()
            {
                Console.WriteLine("what (position is in steps somehow)");
                return false;
            }
            else if (moves.Last() == currm)
            {
                Console.Write($"last move = {moves.Last()} this move = {currm}");
                Console.WriteLine("what (current move???)");
                return false;
            }
            else if (y > 8)
            {
                Console.WriteLine($"what ({y}>8????) {y > 8}");
                return false;
            }
            else if (x > 8)
            {
                Console.WriteLine($"what ({x}>8?????????????????????????) {x > 8}");
                return false;
            }
            else { return true; }
        }
    }
}

