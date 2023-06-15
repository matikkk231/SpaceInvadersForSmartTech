using System;
using Gun.Presenter;
using Monster.Model;
using Monster.View;

namespace Monster.Presenter
{
    public class MonsterPresenter : IDisposable
    {
        private readonly IMonsterView _view;
        private readonly IMonsterModel _model;

        private readonly IDisposable _gunPresenter;

        public MonsterPresenter(IMonsterView view, IMonsterModel model)
        {
            _model = model;
            _view = view;
            _gunPresenter = new GunPresenter(view.GunView, model.Gun);
            AddListeners();
        }

        private void AddListeners()
        {
            _model.Moved += OnMoved;
            _view.ReachedKeyPoint += OnPointReached;
        }

        private void RemoveListeners()
        {
            _model.Moved -= OnMoved;
            _view.ReachedKeyPoint -= OnPointReached;
        }

        private void OnMoved(MovingDirection direction)
        {
            _view.Move(direction);
        }

        private void OnPointReached()
        {
            _model.Move();
        }

        public void Dispose()
        {
            RemoveListeners();
            _gunPresenter.Dispose();
        }
    }
}