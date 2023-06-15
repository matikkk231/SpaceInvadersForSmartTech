using System;
using System.Collections.Generic;
using Level.Model;
using Level.View;
using Monster.Model;
using Monster.Presenter;
using Player.Model;
using Player.Presenter;
using Round;
using UnityEngine;

namespace Level.Presenter
{
    public class LevelPresenter : IDisposable
    {
        private readonly ILevelView _view;
        private readonly ILevelModel _model;

        private List<IDisposable> _roudns;
        private List<IDisposable> _monsterPresenters;
        private IDisposable _player;

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

        private void OnRoundStarted(RoundConfig roundConfig, List<IMonsterModel> monsterModels,
            IPlayerModel playerModel)
        {
            _monsterPresenters = new List<IDisposable>();
            foreach (var monsterModel in monsterModels)
            {
                _monsterPresenters.Add(
                    new MonsterPresenter(_view.CreateMonsterView(monsterModel.Type, monsterModel.Position),
                        monsterModel));
            }

            var startPlayerPosition = new Vector2Int(0, -_model.LevelScale.y);
            _player = new PlayerPresenter(playerModel, _view.CreatePlayerView(startPlayerPosition));

            _view.StartRound(roundConfig);
        }

        public void Dispose()
        {
            RemoveListeners();
            foreach (var monsterPresenter in _monsterPresenters)
            {
                monsterPresenter.Dispose();
            }
        }
    }
}