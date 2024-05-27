using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeAndLadder.Game
{
    public class Game
    {
        private Player[] players;
        private Dice dice;
        private Dictionary<int, int> snakes;
        private Dictionary<int, int> ladders;

        public Game(int numberOfPlayers)
        {
            players = new Player[numberOfPlayers];
            for (int i = 0; i < numberOfPlayers; i++)
            {
                players[i] = new Player();
            }

            dice = new Dice();

            snakes = new Dictionary<int, int>
    {
        { 16, 6 }, { 47, 26 }, { 49, 11 }, { 56, 53 }, { 62, 19 },
        { 64, 60 }, { 87, 24 }, { 93, 73 }, { 95, 75 }, { 98, 78 }
    };

            ladders = new Dictionary<int, int>
    {
        { 1, 38 }, { 4, 14 }, { 9, 31 }, { 21, 42 }, { 28, 84 },
        { 36, 44 }, { 51, 67 }, { 71, 91 }, { 80, 100 }
    };
        }

        private void CheckForSnakesOrLadders(Player player)
        {
            if (snakes.ContainsKey(player.Position))
            {
                player.SetPosition(snakes[player.Position]);
            }
            else if (ladders.ContainsKey(player.Position))
            {
                player.SetPosition(ladders[player.Position]);
            }
        }

        private bool PlayTurn(Player player)
        {
            int roll1 = dice.roll();
            player.UpdatePosition(roll1);
            Console.WriteLine($"Player rolls: {roll1}");

            if (player.Position > 100)
            {
                player.UpdatePosition(-roll1);
                Console.WriteLine($"Player stays at {player.Position} (over 100)");
                return false;
            }

            CheckForSnakesOrLadders(player);

            Console.WriteLine($"Player moves to {player.Position}");

            return ladders.ContainsKey(player.Position);
        }

        public void PlayGame()
        {
            int currentPlayer = 0;
            while (true)
            {
                bool ladderClimb;
                do
                {
                    ladderClimb = PlayTurn(players[currentPlayer]);
                    if (players[currentPlayer].Position == 100)
                    {
                        Console.WriteLine($"Player {currentPlayer + 1} wins the game!");
                        for (int i = 0; i < players.Length; i++)
                        {
                            Console.WriteLine($"Player {i + 1} rolled the dice {players[i].DiceRollCount} times");
                        }
                        return;
                    }
                } while (ladderClimb);
                currentPlayer = (currentPlayer + 1) % players.Length;
            }
        }
    }
}
