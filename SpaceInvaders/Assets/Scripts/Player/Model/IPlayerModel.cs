using System;
using Gun.Model;

namespace Player.Model
{
    public interface IPlayerModel
    {
        Action Died { get; set; }

        int Health { get; set; }
        IGunModel GunModel { get; }

        void Attack();
    }
}