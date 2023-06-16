using System;

namespace Counter.Model
{
    public class CounterModel : ICounterModel
    {
        public Action<int> ScoreChanged { get; set; }
        public Action<int> RoundChanged { get; set; }

        private int _score;
        private int _round;

        public void IncreaseScore(int scorePoints)
        {
            _score += scorePoints;
            ScoreChanged?.Invoke(_score);
        }

        public void ChangeRound(int currentRound)
        {
            _round = currentRound;
            RoundChanged?.Invoke(_round);
        }
    }
}