using System;

namespace Counter.Model
{
    public class CounterModel : ICounterModel
    {
        public Action<int> ScoreChanged { get; set; }
        public Action<int> RoundChanged { get; set; }

        private int _score;

        public void IncreaseScore(int scorePoints)
        {
            _score += scorePoints;
        }
    }
}