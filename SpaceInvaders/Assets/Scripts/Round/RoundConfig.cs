using System.Collections.Generic;
using Monster;
using UnityEngine;

namespace Round
{
    [CreateAssetMenu(menuName = "roundConfig")]
    public class RoundConfig : ScriptableObject
    {
        public List<MonsterConfig> MonsterConfigs;
        public int RoundSpeed;
    }
}