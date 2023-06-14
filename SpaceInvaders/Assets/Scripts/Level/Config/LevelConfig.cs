using System.Collections.Generic;
using Round;
using UnityEngine;

namespace Level.Config
{
    [CreateAssetMenu(menuName = "LevelConfig")]
    public class LevelConfig : ScriptableObject
    {
        public List<RoundConfig> Rounds;
        public Vector2Int Scale;
    }
}