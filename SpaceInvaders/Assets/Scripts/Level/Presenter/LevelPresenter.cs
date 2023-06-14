using System;
using System.Collections.Generic;
using Level.Model;
using Level.View;
using Monster.Model;
using Round;

namespace Level.Presenter
{
    public class LevelPresenter : IDisposable
    {
        private readonly ILevelView _view;
        private readonly ILevelModel _model;

        private List<IDisposable> _roudns;

        public LevelPresenter(ILevelView view, ILevelModel model)
        {
            _view = view;
            _model = model;
            AddListeners();
        }

        private void AddListeners()
        {
            _model.RoundStarted += OnRoundStarted;
        }

        private void RemoveListeners()
        {
            _model.RoundStarted -= OnRoundStarted;
        }

        private void OnRoundStarted(RoundConfig roundConfig, List<MonsterModel> monsterModels)
        {
            _view.StartRound(roundConfig);
        }

        public void Dispose()
        {
            RemoveListeners();
        }
    }
}