using System;
using UnityEngine;

namespace Monster.Model
{
    public class MonsterModel : IMonsterModel
    {
        public Action Attacked { get; set; }

        public MonsterType Type { get; set; }
        public Vector2Int Position { get; set; }
        public int Health { get; set; }

        public MonsterModel(MonsterConfig config)
        {
            Position = config.Position;
            Type = config.Type;

            switch (Type)
            {
                case MonsterType.LittleMonster:
                    Health = 1;
                    break;
                default: throw new Exception("monster type not found");
            }
        }

        public void Attack()
        {
            Attacked?.Invoke();
        }
    }
}