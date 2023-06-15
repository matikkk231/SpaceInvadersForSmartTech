using System.Collections.Generic;
using Monster;
using Monster.View;
using Player.View;
using Round;
using UnityEngine;
using UnityEngine.Serialization;

namespace Level.View
{
    public class LevelView : MonoBehaviour, ILevelView
    {
        [SerializeField] private GameObject _littleMonsterPref;
        [SerializeField] private GameObject _playerPref;
        private const float _positionMeasure = 1;
        private List<IMonsterView> _monsterViews = new List<IMonsterView>();
        private IPlayerView _playerView;

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

        public IPlayerView CreatePlayerView(Vector2Int position)
        {
            var player = Instantiate(_playerPref).GetComponent<IPlayerView>();
            player.Position =
                new Vector2(position.x * _positionMeasure, position.y * _positionMeasure);
            _playerView = player;
            player.Position = new Vector2(position.x * _positionMeasure, position.y * _positionMeasure);
            return player;
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