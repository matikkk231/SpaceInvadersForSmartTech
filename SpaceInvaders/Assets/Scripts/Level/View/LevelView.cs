using System;
using System.Collections.Generic;
using Counter.View;
using Level.Config;
using Monster;
using Monster.View;
using Player.View;
using Round;
using UnityEngine;

namespace Level.View
{
    public class LevelView : MonoBehaviour, ILevelView
    {
        [SerializeField] private List<MonsterPreset> _monsterPresets;
        [SerializeField] private GameObject _playerPrefab;
        [SerializeField] private GameObject _counterPrefab;
        private const float _positionMeasure = 1;

        public IMonsterView CreateMonsterView(MonsterType type, Vector2Int position, RoundConfig roundConfig)
        {
            foreach (var preset in _monsterPresets)
            {
                if (preset.Type == type)
                {
                    IMonsterView monster = Instantiate(preset.MonsterPrefab).GetComponent<MonsterView>();
                    monster.Position =
                        new Vector2(position.x * _positionMeasure, position.y * _positionMeasure);
                    monster.SetDistanceBetweenPoints(_positionMeasure);
                    monster.SetSpeed(roundConfig.RoundSpeed);
                    return monster;
                }
            }

            throw new Exception("monster type wasn't found");
        }

        public IPlayerView CreatePlayerView(Vector2Int position, LevelConfig levelConfig)
        {
            var player = Instantiate(_playerPrefab).GetComponent<IPlayerView>();
            player.Position =
                new Vector2(position.x * _positionMeasure, position.y * _positionMeasure);
            player.Position = new Vector2(position.x * _positionMeasure, position.y * _positionMeasure);
            player.MaxPositionX = levelConfig.Scale.x * _positionMeasure;
            player.MaxPositionY = levelConfig.Scale.y * _positionMeasure;
            player.MinPositionX = -levelConfig.Scale.x * _positionMeasure;
            player.MinPositionY = -levelConfig.Scale.y * _positionMeasure - _positionMeasure;

            return player;
        }

        public ICounterView CreateCounterView()
        {
            var counter = Instantiate(_counterPrefab).GetComponent<ICounterView>();
            return counter;
        }

        [Serializable]
        private struct MonsterPreset
        {
            [SerializeField] public GameObject MonsterPrefab;
            [SerializeField] public MonsterType Type;
        }
    }
}