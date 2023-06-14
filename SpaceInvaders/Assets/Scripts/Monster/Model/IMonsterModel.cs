using System;
using UnityEngine;

namespace Monster.Model
{
    public interface IMonsterModel
    {
        Action Attacked { get; set; }

        MonsterType Type { get; set; }
        Vector2Int Position { get; set; }
        int Health { get; set; }

        public void Attack();
    }
}