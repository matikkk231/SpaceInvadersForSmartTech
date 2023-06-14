using Monster;
using Monster.View;
using Round;
using UnityEngine;

namespace Level.View
{
    public class LevelView : MonoBehaviour, ILevelView
    {
        [SerializeField] private GameObject _littleMonsterPref;
        private const float _positionMeasureMultiply = 1;

        public Vector2 LevelScale { get; set; }

        public void StartRound(RoundConfig roundConfig)
        {
        }

        public IMonsterView CreateMonsterView(MonsterType type, Vector2Int position)
        {
            var monster = Instantiate(_littleMonsterPref).GetComponent<MonsterView>();
            monster.Position =
                new Vector2(position.x * _positionMeasureMultiply, position.y * _positionMeasureMultiply);
            return monster;
        }
    }
}