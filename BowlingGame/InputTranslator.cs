using System;
using System.Collections.Generic;

namespace BowlingGame
{
    public class InputTranslator
    {
        public InputTranslator(string input)
        {
            Input = input;
        }

        public List<Roll> TranslateInputToRollList()
        {
            List<Roll> rollList = new List<Roll>();
            int currentFrameNumber = 1; 

            for (int i = 0; i < Input.Length; i++)
            {
                Roll currentRoll = TranslateCharToRoll(i);

                if (currentRoll != null)
                {
                    SetIsBonusRoll(currentFrameNumber, currentRoll);
                    rollList.Add(currentRoll); 
                } else
                {
                    currentFrameNumber++;
                }
            }
            return rollList;
        }
     
        private Roll TranslateCharToRoll(int charIndex)
        {
            char currentCharacter = Input[charIndex];

            if(currentCharacter==' ')
            {
                return null;
            }

            Roll currentRoll = new Roll();

            if (currentCharacter == '-')
            {
            }
            else if (currentCharacter == 'X')
            {
                currentRoll.PinsTaken = 10;
                currentRoll.IsStrike = true;
            }
            else if (currentCharacter == '/')
            {
                char previousCharacter = Input[charIndex - 1];
                currentRoll.PinsTaken = 10 - (int)Char.GetNumericValue(previousCharacter);
                currentRoll.IsSpare = true;
            }
            else
            {
                currentRoll.PinsTaken = (int)Char.GetNumericValue(currentCharacter);
            }
            return currentRoll;
        }

        private void SetIsBonusRoll(int frameNumber, Roll currentRoll)
        {
            if (frameNumber > 10)
            {
                currentRoll.IsBonusRoll = true;
            }
        }

        private string Input { get; set; }
    }
}
