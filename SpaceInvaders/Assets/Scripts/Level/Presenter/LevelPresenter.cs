using System;
using System.Collections.Generic;
using Level.Model;
using Level.View;
using Monster.Model;
using Monster.Presenter;
using Round;

namespace Level.Presenter
{
    public class LevelPresenter : IDisposable
    {
        private readonly ILevelView _view;
        private readonly ILevelModel _model;

        private List<IDisposable> _roudns;
        private List<IDisposable> _monsterPresenters;

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
            _monsterPresenters = new List<IDisposable>();
            foreach (var monsterModel in monsterModels)
            {
                _monsterPresenters.Add(
                    new MonsterPresenter(_view.CreateMonsterView(monsterModel.Type, monsterModel.Position),
                        monsterModel));
            }

            _view.StartRound(roundConfig);
        }

        public void Dispose()
        {
            RemoveListeners();
        }
    }
}