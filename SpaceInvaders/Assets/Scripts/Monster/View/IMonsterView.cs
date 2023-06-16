using System;
using Gun.View;
using UnityEngine;

namespace Monster.View
{
    public interface IMonsterView
    {
        Action<int> Damaged { get; set; }
        Action ReachedKeyPoint { get; set; }

        IGunView GunView { get; }
        public Vector2 Position { get; set; }

        void GetDamage(int damageAmount);
        void Move(MovingDirection direction);
        void SetDistanceBetweenPoints(float measure);
        void SetSpeed(float speed);
        void Die();
    }
}