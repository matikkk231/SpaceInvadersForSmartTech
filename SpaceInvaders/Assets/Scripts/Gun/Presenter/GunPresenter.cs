using System;
using Gun.Model;
using Gun.View;

namespace Gun.Presenter
{
    public class GunPresenter : IDisposable

    {
        private readonly IGunView _view;
        private readonly IGunModel _model;

        public GunPresenter(IGunView view, IGunModel model)
        {
            _view = view;
            _model = model;
            AddListeners();
        }

        private void AddListeners()
        {
            _model.Attacked += OnAttacked;
            _view.PreparedToShoot += OnPreparedToShoot;
        }

        private void RemoveListeners()
        {
            _model.Attacked -= OnAttacked;
            _view.PreparedToShoot -= OnPreparedToShoot;
        }

        private void OnAttacked(int damage)
        {
            _view.Attack(damage);
        }

        private void OnPreparedToShoot()
        {
            _model.Attack();
        }

        public void Dispose()
        {
            RemoveListeners();
        }
    }
}