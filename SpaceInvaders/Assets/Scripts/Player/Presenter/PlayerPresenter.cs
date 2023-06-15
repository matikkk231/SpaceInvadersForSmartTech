using System;
using Player.Model;
using Player.View;

namespace Player.Presenter
{
    public class PlayerPresenter : IDisposable
    {
        private readonly IPlayerModel _model;
        private readonly IPlayerView _view;

        public PlayerPresenter(IPlayerModel model, IPlayerView view)
        {
            _view = view;
            _model = model;
            AddListeners();
        }

        private void AddListeners()
        {
        }

        private void RemoveListeners()
        {
        }

        public void Dispose()
        {
            RemoveListeners();
        }
    }
}