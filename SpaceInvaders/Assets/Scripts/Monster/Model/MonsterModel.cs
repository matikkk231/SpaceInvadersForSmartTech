using System;
using UnityEngine;

namespace Monster.Model
{
    public class MonsterModel
    {
        private Action<MonsterType> Attacked { get; set; }

        private MonsterType Type;
        private Vector2Int Postion;
        private int Health;

        public MonsterModel(Vector2Int position, MonsterType type)
        {
            Postion = position;
            Type = type;

            switch (type)
            {
                case MonsterType.LittleMonster:
                    Health = 1;
                    break;
                default: throw new Exception("monster type not found");
            }
        }

        public void Attack()
        {
            Attacked?.Invoke(Type);
        }
    }
}