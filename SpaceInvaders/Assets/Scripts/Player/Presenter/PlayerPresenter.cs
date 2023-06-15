using System;
using Gun.Presenter;
using Player.Model;
using Player.View;

namespace Player.Presenter
{
    public class PlayerPresenter : IDisposable
    {
        private readonly IPlayerModel _model;
        private readonly IPlayerView _view;
        private readonly IDisposable _gunPresenter;

        public PlayerPresenter(IPlayerModel model, IPlayerView view)
        {
            _view = view;
            _model = model;
            _gunPresenter = new GunPresenter(view.Gun, model.GunModel);
            AddListeners();
        }

        private void AddListeners()
        {
            _view.AttackPressed += OnAttackPressed;
            _model.Died += OnDied;
            _view.Damaged += OnDamaged;
        }

        private void RemoveListeners()
        {
            _view.AttackPressed -= OnAttackPressed;
            _model.Died -= OnDied;
            _view.Damaged -= OnDamaged;
        }

        private void OnAttackPressed()
        {
            _model.Attack();
        }

        private void OnDied()
        {
            _view.Die();
        }

        private void OnDamaged(int damage)
        {
            _model.Health -= damage;
        }

        public void Dispose()
        {
            RemoveListeners();
            _gunPresenter.Dispose();
        }
    }
}