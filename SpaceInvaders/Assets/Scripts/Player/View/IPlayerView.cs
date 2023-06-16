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

        float MaxPositionX { get; set; }
        float MaxPositionY { get; set; }
        float MinPositionX { get; set; }
        float MinPositionY { get; set; }
        Vector2 Position { set; }


        void GetDamage(int damage);
        void Die();
    }
}