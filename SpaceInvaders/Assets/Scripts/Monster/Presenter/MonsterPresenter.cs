using System;
using Monster.Model;
using Monster.View;
using UnityEngine;

namespace Monster.Presenter
{
    public class MonsterPresenter : IDisposable
    {
        private readonly IMonsterView _view;
        private readonly IMonsterModel _model;

        public MonsterPresenter(IMonsterView view, IMonsterModel model)
        {
            _model = model;
            _view = view;
            AddListeners();
        }

        private void AddListeners()
        {
            _model.Attacked += OnAttacked;
            _model.Moved += OnMoved;
            _view.ReachedKeyPoint += _model.Move;
        }

        private void RemoveListeners()
        {
            _model.Attacked -= OnAttacked;
            _model.Moved -= OnMoved;
            _view.ReachedKeyPoint -= _model.Move;
        }

        private void OnAttacked()
        {
            _view.Attack();
        }

        private void OnMoved(MovingDirection direction)
        {
            _view.Move(direction);
        }

        public void Dispose()
        {
            RemoveListeners();
        }
    }
}