using System;

namespace fish
{
    class Program
    {
        static void Main(string[] args)
        {
            dungeon d = new dungeon();
            d.setDungeonMap();
            d.generate();
            //currently doesnt work since the first move is going to be a turn move.
            d.tempDrawMap();
        }
    }
}
