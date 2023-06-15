using System;
using Gun.Model;

namespace Player.Model
{
    public class PlayerModel : IPlayerModel
    {
        public Action Died { get; set; }

        private const int _weaponDamage = 1;
        private readonly IGunModel _gunModel;
        private int _health;

        public int Health
        {
            get => _health;
            set
            {
                _health = value;
                if (_health <= 0)
                {
                    Died?.Invoke();
                }
            }
        }

        public IGunModel GunModel
        {
            get => _gunModel;
        }

        public PlayerModel(int health)
        {
            _gunModel = new GunModel(_weaponDamage);
            _health = health;
        }

        public void Attack()
        {
            _gunModel.Attack();
        }
    }
}