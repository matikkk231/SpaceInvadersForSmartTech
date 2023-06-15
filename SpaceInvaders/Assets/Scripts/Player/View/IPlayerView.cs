using System;
using UnityEngine;

namespace Player.View
{
    public interface IPlayerView
    {
        Action<int> Damaged { get; set; }
        Action AttackStarted { get; set; }

        Vector2 Position { get; set; }

        void Attack(int damage);
        void GetDamage(int damage);
    }
}