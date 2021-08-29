using System;

namespace BowlingGame
{
    class Program
    {
        static void Main(string[] args)
        {
            //string input = "9- 9- 9- 9- 9- 9- 9- 9- 9- 9-";
            //string input = "5/ 5/ 5/ 5/ 5/ 5/ 5/ 5/ 5/ 5/ 5";
            string input = "X X X X X X X X X X X X";
            InputTranslator newTranslator = new InputTranslator(input);
            var rollsInGame = newTranslator.TranslateInputToRollList();
            Game newGame = new Game(rollsInGame);
            Console.WriteLine(newGame.CalculateResult());
        }
    }
}
