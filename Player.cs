using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeAndLadder.Game
{
    public class Player
    {
        public int Position { get; set; }
        public int DiceRollCount { get; set; }
        public Player() 
        {
            Position = 0;
            DiceRollCount = 0;
        }
        public void UpdatePosition(int move)
        {
            Position += move;
            if(Position < 0)
            {
                Position = 0;
            }
            DiceRollCount++;
        }
        public void SetPosition(int position) 
        {
            Position = position;
        }
    }
}
