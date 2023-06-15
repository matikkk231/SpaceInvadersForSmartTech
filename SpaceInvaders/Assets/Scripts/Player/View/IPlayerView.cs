using System;

namespace Player.View
{
    public interface IPlayerView
    {
        Action<int> Damaged { get; set; }
        Action AttackStarted { get; set; }

        void Attack(int damage);
        void GetDamage(int damage);
    }
}