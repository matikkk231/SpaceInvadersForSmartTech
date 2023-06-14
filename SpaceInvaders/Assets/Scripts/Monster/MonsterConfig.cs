using System;
using UnityEngine;

namespace Monster
{
    [Serializable]
    public class MonsterConfig
    {
        public MonsterType Type;
        public Vector2Int Position;
    }

    public enum MonsterType
    {
        LittleMonster
    }
}