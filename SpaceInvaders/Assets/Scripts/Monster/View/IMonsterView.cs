using System;
using UnityEngine;

namespace Monster.View
{
    public interface IMonsterView
    {
        Action<int> Damaged { get; set; }
        Action PositionChanged { get; set; }

        Vector2 Position { get; set; }

        void Attack();
        void GetDamage(int damageAmount);
    }
}