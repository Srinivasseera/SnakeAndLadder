using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeAndLadder.Game
{
    public class Dice
    {
        private Random random = new Random();
        public int roll() 
        {
            return random.Next(1, 7);
        }

    }
}
