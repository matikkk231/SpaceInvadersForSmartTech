using System;
using Monster.View;
using UnityEngine;

namespace Monster.Model
{
    public interface IMonsterModel
    {
        Action<MovingDirection> Moved { get; set; }
        Action Attacked { get; set; }

        MonsterType Type { get; set; }
        Vector2Int Position { get; set; }
        int Health { get; set; }

        public void Attack();
        public void Move();
    }
}