using System.Collections.Generic;
using Xunit;
using BowlingGame;

namespace BowlingTest
{
    public class GameTest
    {
        [Fact]
        public void GameCalculatesResultsCorrectlyWhenStrikesOnly()
        {
            // input = "X X X X X X X X X X X X";
            List<Roll> rollsInGame = new List<Roll>();
            for(int i=0; i<12; i++)
            {
                Roll currentRoll = new Roll();
                currentRoll.PinsTaken = 10;
                currentRoll.IsStrike = true;
                rollsInGame.Add(currentRoll);
            }
            rollsInGame[10].IsBonusRoll = true;
            rollsInGame[11].IsBonusRoll = true;

            Game newGame = new Game(rollsInGame);

            int result = newGame.CalculateResult();

            Assert.Equal(300, result);
        }
        
       [Fact]
        public void GameCalculatesResultsCorrectlyWhenMissedOnly()
        {
            // input = "-- -- -- -- -- -- -- -- -- --";
            List<Roll> rollsInGame = new List<Roll>();
            for (int i = 0; i < 20; i++)
            {
                Roll currentRoll = new Roll();
                currentRoll.PinsTaken = 0;
                rollsInGame.Add(currentRoll);
            }

            Game newGame = new Game(rollsInGame);
            int result = newGame.CalculateResult();
            Assert.Equal(0, result);
        }
        
       [Fact]
       public void GameCalculatesResultsCorrectlyWhenSparesInGame()
       {
            //input = "5/ 5/ 5/ 5/ 5/ 5/ 5/ 5/ 5/ 5/ 5";
            List<Roll> rollsInGame = new List<Roll>();
            for (int i = 0; i < 10; i++)
            {
                Roll currentRoll = new Roll();
                currentRoll.PinsTaken = 5;
                rollsInGame.Add(currentRoll);

                currentRoll = new Roll();
                currentRoll.PinsTaken = 5;
                currentRoll.IsSpare = true;
                rollsInGame.Add(currentRoll);
            }
            Roll bonusRoll = new Roll();
            bonusRoll.PinsTaken = 5;
            bonusRoll.IsBonusRoll = true;
            rollsInGame.Add(bonusRoll);

            Game newGame = new Game(rollsInGame);
            int result = newGame.CalculateResult();

            Assert.Equal(150, result);
       }
       
       [Fact]
       public void GameCalculatesResultsCorrectlyWhenNoSparesAndStrikes()
       {
            //input = "9- 9- 9- 9- 9- 9- 9- 9- 9- 9-";
            List<Roll> rollsInGame = new List<Roll>();
            for (int i = 0; i < 10; i++)
            {
                Roll currentRoll = new Roll();
                currentRoll.PinsTaken = 9;
                rollsInGame.Add(currentRoll);

                currentRoll = new Roll();
                currentRoll.PinsTaken = 0;
                rollsInGame.Add(currentRoll);
            }

            Game newGame = new Game(rollsInGame);
            int result = newGame.CalculateResult();

            Assert.Equal(90, result);
       }

        [Fact]
        public void GameCalculatesResultsCorrectlyWhenFramesAreNotRepeated()
        {
            //input = "-- 1- X 3- 4/ X X 7- -8 9/ 7";
            List<Roll> rollsInGame = new List<Roll>()
            {
                new Roll(){PinsTaken=0, IsBonusRoll=false, IsSpare=false, IsStrike=false },
                new Roll(){PinsTaken=0, IsBonusRoll=false, IsSpare=false, IsStrike=false },

                new Roll(){PinsTaken=1, IsBonusRoll=false, IsSpare=false, IsStrike=false },
                new Roll(){PinsTaken=0, IsBonusRoll=false, IsSpare=false, IsStrike=false },

                new Roll(){PinsTaken=10, IsBonusRoll=false, IsSpare=false, IsStrike=true },

                new Roll(){PinsTaken=3, IsBonusRoll=false, IsSpare=false, IsStrike=false },
                new Roll(){PinsTaken=0, IsBonusRoll=false, IsSpare=false, IsStrike=false },

                new Roll(){PinsTaken=4, IsBonusRoll=false, IsSpare=false, IsStrike=false },
                new Roll(){PinsTaken=6, IsBonusRoll=false, IsSpare=true, IsStrike=false },

                new Roll(){PinsTaken=10, IsBonusRoll=false, IsSpare=false, IsStrike=true },

                new Roll(){PinsTaken=10, IsBonusRoll=false, IsSpare=false, IsStrike=true },

                new Roll(){PinsTaken=7, IsBonusRoll=false, IsSpare=false, IsStrike=false },
                new Roll(){PinsTaken=0, IsBonusRoll=false, IsSpare=false, IsStrike=false },

                new Roll(){PinsTaken=0, IsBonusRoll=false, IsSpare=false, IsStrike=false },
                new Roll(){PinsTaken=8, IsBonusRoll=false, IsSpare=false, IsStrike=false },

                new Roll(){PinsTaken=9, IsBonusRoll=false, IsSpare=false, IsStrike=false },
                new Roll(){PinsTaken=1, IsBonusRoll=false, IsSpare=true, IsStrike=false },

                new Roll(){PinsTaken=7, IsBonusRoll=true, IsSpare=false, IsStrike=false}
            };
            
            Game newGame = new Game(rollsInGame);
            int result = newGame.CalculateResult();

            Assert.Equal(113, result);
        }
    }
}
