using UnityEngine;

namespace Monster
{
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