using System;

namespace Counter.Model
{
    public interface ICounterModel
    {
        Action<int> ScoreChanged { get; set; }
        Action<int> RoundChanged { get; set; }

        void IncreaseScore(int scorePoints);
    }
}