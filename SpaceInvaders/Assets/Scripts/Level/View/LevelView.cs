using Monster;
using Monster.View;
using Player.View;
using Round;
using UnityEngine;

namespace Level.View
{
    public class LevelView : MonoBehaviour, ILevelView
    {
        [SerializeField] private GameObject _littleMonsterPref;
        [SerializeField] private GameObject _playerPrefab;
        private const float _positionMeasure = 1;
        
        public IMonsterView CreateMonsterView(MonsterType type, Vector2Int position, RoundConfig roundConfig)
        {
            var monster = Instantiate(_littleMonsterPref).GetComponent<MonsterView>();
            monster.Position =
                new Vector2(position.x * _positionMeasure, position.y * _positionMeasure);
            monster.SetDistanceBetweenPoints(_positionMeasure);
            monster.SetSpeed(roundConfig.RoundSpeed);
            return monster;
        }

        public IPlayerView CreatePlayerView(Vector2Int position)
        {
            var player = Instantiate(_playerPrefab).GetComponent<IPlayerView>();
            player.Position =
                new Vector2(position.x * _positionMeasure, position.y * _positionMeasure);
            player.Position = new Vector2(position.x * _positionMeasure, position.y * _positionMeasure);
            return player;
        }
    }
}