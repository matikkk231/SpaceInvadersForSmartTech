using System;
using UnityEngine;

namespace Monster
{
    [Serializable]
    public class MonsterConfig
    {
        public MonsterType Type;
        public Vector2Int Position;
        public int Reward;
        public int Health;
        public int Damage;
    }

    public enum MonsterType
    {
        LittleMonster,
        MediumMonster
    }
}