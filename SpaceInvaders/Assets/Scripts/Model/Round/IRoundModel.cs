using System;

namespace Model.Round
{
    public interface IRoundModel
    {
        Action RoundWon { get; }
        Action RoundLoosed { get; }

        void StartRound();
    }
}