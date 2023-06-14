using System.Collections.Generic;
using Monster;
using Monster.View;
using Round;
using UnityEngine;

namespace Level.View
{
    public class LevelView : MonoBehaviour, ILevelView
    {
        [SerializeField] private GameObject _littleMonsterPref;
        private const float _positionMeasure = 1;
        private List<IMonsterView> _monsterViews = new List<IMonsterView>();

        public Vector2 LevelScale { get; set; }

        public void StartRound(RoundConfig roundConfig)
        {
            SetSpeed(roundConfig.RoundSpeed);
        }

        public IMonsterView CreateMonsterView(MonsterType type, Vector2Int position)
        {
            var monster = Instantiate(_littleMonsterPref).GetComponent<MonsterView>();
            monster.Position =
                new Vector2(position.x * _positionMeasure, position.y * _positionMeasure);
            monster.SetDistanceBetweenPoints(_positionMeasure);
            _monsterViews.Add(monster);
            return monster;
        }

        public void SetSpeed(float speed)
        {
            foreach (var monster in _monsterViews)
            {
                monster.SetSpeed(speed);
            }
        }
    }
}