using System;
using Gun.Model;

namespace Player.Model
{
    public class PlayerModel : IPlayerModel
    {
        public Action Died { get; set; }
        public Action Attacked { get; set; }

        private const int _weaponDamage = 1;
        private readonly IGunModel _gunModel;
        public int Health { get; set; }

        public IGunModel GunModel
        {
            get => _gunModel;
        }

        public PlayerModel()
        {
            _gunModel = new GunModel(_weaponDamage);
        }

        public void Attack()
        {
            _gunModel.Attack();
        }
    }
}