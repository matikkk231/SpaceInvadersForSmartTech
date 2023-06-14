using System;
using Monster.Model;
using Monster.View;

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
        }

        private void RemoveListeners()
        {
            _model.Attacked -= OnAttacked;
        }

        private void OnAttacked()
        {
            _view.Attack();
        }

        public void Dispose()
        {
            RemoveListeners();
        }
    }
}