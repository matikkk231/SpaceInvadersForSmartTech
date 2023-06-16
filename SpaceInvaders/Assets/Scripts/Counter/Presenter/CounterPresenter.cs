using System;
using Counter.Model;
using Counter.View;

namespace Counter.Presenter
{
    public class CounterPresenter : IDisposable
    {
        private readonly ICounterModel _model;
        private readonly ICounterView _view;

        public CounterPresenter(ICounterView view, ICounterModel model)
        {
            _model = model;
            _view = view;
            AddListeners();
        }

        private void AddListeners()
        {
            _model.ScoreChanged += OnScoreChanged;
            _model.RoundChanged += OnRoundChanged;
        }

        private void RemoveListeners()
        {
            _model.ScoreChanged -= OnScoreChanged;
            _model.RoundChanged -= OnRoundChanged;
        }

        private void OnRoundChanged(int round)
        {
            _view.ShowRound(round);
        }

        private void OnScoreChanged(int score)
        {
            _view.ShowScore(score);
        }

        public void Dispose()
        {
            RemoveListeners();
        }
    }
}