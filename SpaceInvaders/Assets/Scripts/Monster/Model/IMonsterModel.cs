using System;
using Gun.Model;
using Monster.View;
using UnityEngine;

namespace Monster.Model
{
    public interface IMonsterModel
    {
        Action<MovingDirection> Moved { get; set; }
        Action Died { get; set; }

        MonsterType Type { get; }
        Vector2Int Position { get; }
        int Health { get; set; }
        IGunModel Gun { get; }

        public void Attack();
        public void Move();
    }
}