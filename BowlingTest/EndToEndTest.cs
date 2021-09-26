using Xunit;
using BowlingGame;
using System.Collections.Generic;

namespace BowlingTest
{
    public class EndToEndTest
    {
        [Theory]
        [InlineData("X X X X X X X X X X X X", 300)]
        [InlineData("-- -- -- -- -- -- -- -- -- --", 0)]
        [InlineData("5/ 5/ 5/ 5/ 5/ 5/ 5/ 5/ 5/ 5/ 5", 150)]
        [InlineData("9- 9- 9- 9- 9- 9- 9- 9- 9- 9-", 90)]
        [InlineData("-- 1- X 3- 4/ X X 7- -8 9/ 7", 113)]
        public void ProgramCalculatesResultCorrectlyGivenExampleData(string input, int expectedResult)
        {
            InputTranslator newTranslator = new InputTranslator(input);
            List<Roll> rollsInGame = newTranslator.TranslateInputToRollList();

            Game newGame = new Game(rollsInGame);
            int result = newGame.CalculateResult();

            Assert.Equal(expectedResult, result);
        }
    }
}
