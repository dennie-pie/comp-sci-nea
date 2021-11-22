using System;

namespace fish
{
    class Program
    {
        static void Main(string[] args)
        {
            CellOverlord c = new CellOverlord();
            dungeon d = new dungeon(c);
            d.generate();
        }
    }
}
