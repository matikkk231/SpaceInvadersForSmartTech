using System;
using Gun.View;
using UnityEngine;

namespace Player.View
{
    public interface IPlayerView
    {
        Action<int> Damaged { get; set; }
        Action AttackPressed { get; set; }

        IGunView Gun { get; set; }

        Vector2 Position { get; set; }

        void GetDamage(int damage);
    }
}