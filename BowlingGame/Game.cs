using System.Collections.Generic;

namespace BowlingGame
{
    public class Game
    {
        public Game(List<Roll> rollsInGame)
        {
            RollsInGame = rollsInGame;
        }

        public int CalculateResult()
        {
            int mainPoints = 0;
            int bonusPoints = 0;
            for (int i = 0; i < RollsInGame.Count; i++)
            {
                if (!RollsInGame[i].IsBonusRoll)
                {
                    mainPoints += RollsInGame[i].PinsTaken;
                    bonusPoints += CalculateBonus(i);
                }
            }
            return mainPoints + bonusPoints;
        }

        private int CalculateBonus(int rollIndex)
        {
            int bonus = 0;
            if (RollsInGame[rollIndex].IsSpare)
            {
               bonus=  RollsInGame[rollIndex + 1].PinsTaken;
            }
            else if (RollsInGame[rollIndex].IsStrike)
            {
                bonus = RollsInGame[rollIndex + 1].PinsTaken + RollsInGame[rollIndex + 2].PinsTaken;
            }

            return bonus;
        }

        private List<Roll> RollsInGame { get; set; }

    }
}
