namespace BowlingGame
{
    public class Roll 
    {
        public Roll()
        {
            PinsTaken = 0;
            IsStrike = false;
            IsSpare = false;
            IsBonusRoll = false;
        }

        public int PinsTaken { get; set; }
        public bool IsStrike { get; set; }
        public bool IsSpare { get; set; }
        public bool IsBonusRoll { get; set; }

    }
}
