using System;
using System.Collections.Generic;
using Level.Config;
using Monster.Model;
using Player.Model;
using Round;
using UnityEngine;

namespace Level.Model
{
    public class LevelModel : ILevelModel
    {
        public Action<RoundConfig, List<IMonsterModel>> RoundStarted { get; set; }

        private readonly List<RoundConfig> _rounds;
        private List<IMonsterModel> _monsters { get; set; }
        private IPlayerModel _player { get; set; }
        private int _currentRound;
        private const int _startPlayerHealth = 3;

        public Vector2Int LevelScale { get; }
        public IPlayerModel Player => _player;

        public List<RoundConfig> Rounds
        {
            get => _rounds;
        }

        public int CurrentRound
        {
            get => _currentRound;
        }

        public LevelModel(LevelConfig config)
        {
            _rounds = config.Rounds;
            LevelScale = config.Scale;
            _player = SpawnPlayer();
        }

        public void StartLevel()
        {
            _monsters = SpawnMonsters(_rounds[_currentRound]);
            RoundStarted?.Invoke(_rounds[_currentRound], _monsters);
            foreach (var monster in _monsters)
            {
                monster.Move();
            }
        }

        private List<IMonsterModel> SpawnMonsters(RoundConfig roundConfig)
        {
            var monsters = new List<IMonsterModel>();
            foreach (var monsterConfig in roundConfig.MonsterConfigs)
            {
                var isOutBorder = CheckMonsterOutBorder(monsterConfig.Position);
                if (isOutBorder)
                {
                    throw new Exception("monster spawn position out of border");
                }

                var monster = new MonsterModel(monsterConfig, LevelScale);
                monster.Died += OnMonsterDied;
                monsters.Add(monster);
            }

            return monsters;
        }

        private IPlayerModel SpawnPlayer()
        {
            _player = new PlayerModel(_startPlayerHealth);
            return _player;
        }

        private bool CheckMonsterOutBorder(Vector2Int monsterPosition)
        {
            var isOutHorizontalBorder = monsterPosition.x > LevelScale.x || monsterPosition.x < -LevelScale.x;
            var isOutVerticalBorder = monsterPosition.y > LevelScale.y || monsterPosition.y < -LevelScale.y;

            if (isOutHorizontalBorder || isOutVerticalBorder)
            {
                return true;
            }

            return false;
        }

        private void OnMonsterDied()
        {
            foreach (var monster in _monsters)
            {
                if (monster.Health <= 0)
                {
                    monster.Died -= OnMonsterDied;
                    Debug.Log("monsterDied");
                    _monsters.Remove(monster);

                    if (_monsters.Count == 0)
                    {
                        StartNextRound();
                    }

                    break;
                }
            }
        }

        private void StartNextRound()
        {
            _currentRound++;
            StartLevel();
        }
    }
}