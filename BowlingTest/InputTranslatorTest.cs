using System.Collections.Generic;
using Xunit;
using BowlingGame;
using FluentAssertions;

namespace BowlingTest
{
    public class InputTranslatorTest
    {
        [Fact]
        public void InputTranslatorTranslatesCorrectlyWhenStrikesOnly()
        {
            List<Roll> expectedRollList = new List<Roll>();
            for (int i = 0; i < 12; i++)
            {
                Roll currentRoll = new Roll();
                currentRoll.PinsTaken = 10;
                currentRoll.IsStrike = true;
                expectedRollList.Add(currentRoll);
            }
            expectedRollList[10].IsBonusRoll = true;
            expectedRollList[11].IsBonusRoll = true;

            string input = "X X X X X X X X X X X X";
            InputTranslator newTranslator = new InputTranslator(input);
            var rollListAfterTranslation = newTranslator.TranslateInputToRollList();

            rollListAfterTranslation.Should().BeEquivalentTo(expectedRollList);
        }


        [Fact]
        public void InputTranslatorTranslatesCorrectlyWhenMissedOnly()
        {
            List<Roll> expectedRollList = new List<Roll>();
            for (int i = 0; i < 20; i++)
            {
                Roll currentRoll = new Roll();
                currentRoll.PinsTaken = 0;
                expectedRollList.Add(currentRoll);
            }

            string input = "-- -- -- -- -- -- -- -- -- --";
            InputTranslator newTranslator = new InputTranslator(input);
            var rollListAfterTranslation = newTranslator.TranslateInputToRollList();

            rollListAfterTranslation.Should().BeEquivalentTo(expectedRollList);
        }

        [Fact]
        public void InputTranslatorTranslatesCorrectlyWhenSparesInGame()
        {
            List<Roll> expectedRollList = new List<Roll>();
            for (int i = 0; i < 10; i++)
            {
                Roll currentRoll = new Roll();
                currentRoll.PinsTaken = 5;
                expectedRollList.Add(currentRoll);

                currentRoll = new Roll();
                currentRoll.PinsTaken = 5;
                currentRoll.IsSpare = true;
                expectedRollList.Add(currentRoll);
            }

            Roll bonusRoll = new Roll();
            bonusRoll.PinsTaken = 5;
            bonusRoll.IsBonusRoll = true;
            expectedRollList.Add(bonusRoll);

            string input = "5/ 5/ 5/ 5/ 5/ 5/ 5/ 5/ 5/ 5/ 5";
            InputTranslator newTranslator = new InputTranslator(input);
            var rollListAfterTranslation = newTranslator.TranslateInputToRollList();

            rollListAfterTranslation.Should().BeEquivalentTo(expectedRollList);
        }

        [Fact]
        public void InputTranslatorTranslatesCorrectlyWhenNoSparesAndStrikes()
        {
            List<Roll> expectedRollList = new List<Roll>();
            for (int i = 0; i < 10; i++)
            {
                Roll currentRoll = new Roll();
                currentRoll.PinsTaken = 9;
                expectedRollList.Add(currentRoll);

                currentRoll = new Roll();
                currentRoll.PinsTaken = 0;
                expectedRollList.Add(currentRoll);
            }

            string input = "9- 9- 9- 9- 9- 9- 9- 9- 9- 9-";
            InputTranslator newTranslator = new InputTranslator(input);
            var rollListAfterTranslation = newTranslator.TranslateInputToRollList();

            rollListAfterTranslation.Should().BeEquivalentTo(expectedRollList);
        }

        [Fact]
        public void InputTranslatorTranslatesCorrectlyWhenFramesAreNotRepeated()
        {
            List<Roll> expectedRollList = new List<Roll>()
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

            string input = "-- 1- X 3- 4/ X X 7- -8 9/ 7";
            InputTranslator newTranslator = new InputTranslator(input);
            var rollListAfterTranslation = newTranslator.TranslateInputToRollList();

            rollListAfterTranslation.Should().BeEquivalentTo(expectedRollList);
        }
    }
}
