using System;
using System.Collections.Generic;
using Level.Config;
using Monster.Model;
using Round;
using UnityEngine;

namespace Level.Model
{
    public class LevelModel : ILevelModel
    {
        private List<RoundConfig> _rounds { get; set; } = new List<RoundConfig>();
        private List<MonsterModel> _monsters { get; set; }
        private int _currentRound;
        public Action<RoundConfig, List<MonsterModel>> RoundStarted { get; set; }

        public Vector2 LevelScale { get; }

        public LevelModel(LevelConfig config)
        {
            _rounds = config.Rounds;
            LevelScale = config.Scale;
        }

        public void StartLevel()
        {
            SpawnMonsters(_rounds[_currentRound]);
            RoundStarted?.Invoke(_rounds[_currentRound], _monsters);
        }

        private void SpawnMonsters(RoundConfig roundConfig)
        {
            _monsters = new List<MonsterModel>();
            foreach (var monsterConfig in roundConfig.MonsterConfigs)
            {
                var isOutBorder = CheckMonsterOutBorder(monsterConfig.Position);
                if (isOutBorder)
                {
                    throw new Exception("monster spawn position out of border");
                }

                _monsters.Add(new MonsterModel(monsterConfig));
            }
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
    }
}