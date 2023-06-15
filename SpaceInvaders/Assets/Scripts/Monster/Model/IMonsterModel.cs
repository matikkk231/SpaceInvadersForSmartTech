using System;
using Gun.Model;
using Monster.View;
using UnityEngine;

namespace Monster.Model
{
    public interface IMonsterModel
    {
        Action<MovingDirection> Moved { get; set; }

        MonsterType Type { get; set; }
        Vector2Int Position { get; set; }
        int Health { get; set; }
        IGunModel Gun { get; set; }

        public void Attack();
        public void Move();
    }
}