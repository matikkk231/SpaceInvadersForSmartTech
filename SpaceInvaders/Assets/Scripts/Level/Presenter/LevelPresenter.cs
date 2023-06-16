using System;
using System.Collections.Generic;
using Counter.Presenter;
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

        private List<IDisposable> _disposables;
        private List<IDisposable> _monsterPresenters;

        public LevelPresenter(ILevelView view, ILevelModel model)
        {
            _view = view;
            _model = model;
            OnLevelStarted();
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

        private void OnRoundStarted(RoundConfig roundConfig, List<IMonsterModel> monsterModels)
        {
            _monsterPresenters = new List<IDisposable>();
            foreach (var monsterModel in monsterModels)
            {
                _monsterPresenters.Add(
                    new MonsterPresenter(
                        _view.CreateMonsterView(monsterModel.Type, monsterModel.Position,
                            _model.Rounds[_model.CurrentRound]),
                        monsterModel));
            }
        }

        private void OnLevelStarted()
        {
            _disposables = new List<IDisposable>();
            
            var startPlayerPosition = new Vector2Int(0, -_model.LevelScale.y);
            _disposables.Add(new PlayerPresenter(_model.Player, _view.CreatePlayerView(startPlayerPosition)));
            _disposables.Add(new CounterPresenter(_view.CreateCounterView(), _model.Counter));
        }

        private void DisposeMonsters()
        {
            foreach (var monsterPresenter in _monsterPresenters)
            {
                monsterPresenter.Dispose();
            }

            _monsterPresenters.Clear();
        }

        private void DisposeOtherDisposables()
        {
            foreach (var disposable in _disposables)
            {
                disposable.Dispose();
            }

            _disposables.Clear();
        }

        public void Dispose()
        {
            RemoveListeners();
            DisposeMonsters();
            DisposeOtherDisposables();
        }
    }
}